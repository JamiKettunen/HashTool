using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using static System.Environment;

namespace HashToolGUI
{
    public class Hasher
    {
        private readonly string certutilExe = ExpandEnvironmentVariables(@"%windir%\System32\certutil.exe");

        private string _algorithm;
        public string Algorithm { get => _algorithm; set { _algorithm = value.Trim().ToUpper(); } }

        private string _hashableFilePath;
        public string HashableFilePath { get => _hashableFilePath; set { _hashableFilePath = value.Trim(); } }

        private string _comparisonHash;
        public string ComparisonHash { get => _comparisonHash; set { _comparisonHash = value.Trim(); } }

        public string CalculatedHash { get; private set; }
        public bool MatchingHashes { get; private set; }

        public TimeSpan TotalWorkingTime;
        public BackgroundWorker CertutilWorker;

        public Hasher(string algorithm = "", string fileToHash = "", string comparisonHash = "")
        {
            this.Algorithm = algorithm;
            this.HashableFilePath = fileToHash;
            this.ComparisonHash = comparisonHash;

            this.CalculatedHash = "";
            this.MatchingHashes = false;

            this.TotalWorkingTime = TimeSpan.Zero;

            this.CertutilWorker = new BackgroundWorker();
            this.CertutilWorker.DoWork += CertutilWorker_DoWork;
        }

        private void CertutilWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Results:
            // 0 = All good
            // 1 = General error
            // 2 = Hash parsing error (incorrect hash type?)
            int result = 1;
            bool error = true;

            try
            {
                if (File.Exists(certutilExe) && _algorithm != "" && File.Exists(_hashableFilePath))
                {
                    Process p = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = certutilExe,
                            Arguments = "-v -hashfile \"" + _hashableFilePath + "\" " + _algorithm,
                            CreateNoWindow = true,
                            UseShellExecute = false,
                            RedirectStandardOutput = true
                        }
                    };

                    p.Start();

                    CalculatedHash = "";
                    int ln = 0;
                    while (!p.StandardOutput.EndOfStream)
                    {
                        string line = p.StandardOutput.ReadLine();
                        ln++;
                        if (ln == 2 && !line.ToUpper().Contains("CERTUTIL")) { CalculatedHash = line; }
                        Debug.WriteLine($"[{ln}]: " + line);
                    }
                    this.TotalWorkingTime = DateTime.Now.Subtract(p.StartTime);
                    error = (String.IsNullOrEmpty(CalculatedHash.Trim()));
                    result = (error ? 2 : 0);

                    if(!error)
                    {
                        this.MatchingHashes = (ComparisonHash != "") ? (CalculatedHash == ComparisonHash) : false;
                    }
                }
            }
            catch {  }

            e.Result = result;
        }
    }
}
