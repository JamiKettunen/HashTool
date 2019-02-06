using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Media;
using System.Windows.Forms;
using HashToolGUI.Properties;

namespace HashToolGUI
{
    public partial class MainForm : Form
    {
        private Hasher hasher = new Hasher();

        private string hashableFile = "";
        private string HashableFile
        {
            get => hashableFile;
            set
            {
                hashableFile = value.Trim();
                btnCalculate.Enabled = (!String.IsNullOrEmpty(hashableFile));

                // Update disk identifier for hashing speed estimation
                UpdateDiskIdentifier();

                if (btnCalculate.Enabled) { btnCalculate.Text = (!String.IsNullOrEmpty(txtCompareHash.Text) ? "Verify" : "Calculate"); }
            }
        }

        private string diskIdentifier = "0 C";

        public MainForm()
        {
            // Reduces flickering on Controls
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

            hasher.CertutilWorker.RunWorkerCompleted += CertutilWorker_RunWorkerCompleted;

            InitializeComponent();

            picHashableEndFade.Parent = lblHashableName;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            comboAlgorithms.Text = Settings.Default.LastAlgorithm;

            SetStatus("Ready");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.LastAlgorithm = comboAlgorithms.Text;
            Settings.Default.Save();
        }

        #region Settings hashable file

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            if (!hasher.CertutilWorker.IsBusy) // Not hashing another file
            {
                try
                {
                    string draggedFile = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0].Trim();

                    SetHashableFile(draggedFile);
                }
                catch { }
            }
        }
        
        private void picHashableFileThumb_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                RestoreDirectory = true,
                Title = "HashTool GUI | Browse for hashable file",
                Multiselect = false
            };

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                SetHashableFile(ofd.FileName);
            }
        }

        #endregion

        #region UI appearance etc.

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop) && !hasher.CertutilWorker.IsBusy)
            {
                string draggedFile = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0].Trim();
                e.Effect = (!String.IsNullOrEmpty(draggedFile) && File.Exists(draggedFile)) ? DragDropEffects.Link : DragDropEffects.None;
            }
        }

        private void timerResetTitle_Tick(object sender, EventArgs e)
        {
            timerResetTitle.Stop();
            this.Text = "HashTool GUI | Ready";
        }

        private void lblHashableName_SizeChanged(object sender, EventArgs e)
        {
            bool showFade = (lblHashableName.Width - 2 > pnlHashableNameBg.Width);

            picHashableEndFade.Location = new Point(pnlHashableNameBg.Width - 30, 0);
            picHashableEndFade.Visible = showFade;
        }

        private void txtCompareHash_TextChanged(object sender, EventArgs e)
        {
            if (btnCalculate.Enabled)
            {
                btnCalculate.Text = (!String.IsNullOrEmpty(txtCompareHash.Text) ? "Verify" : "Calculate");
            }
        }

        #endregion

        #region Functions

        private void UpdateDiskIdentifier()
        {
            if (!String.IsNullOrEmpty(hashableFile))
            {
                try
                {
                    ManagementObjectCollection disks = new ManagementObjectSearcher("SELECT * FROM Win32_Volume").Get();
                    string diskName = "";
                    int index = 0;
                    foreach (ManagementObject item in disks)
                    {
                        diskName = item["Name"].ToString();
                        if (!String.IsNullOrEmpty(diskName) && hashableFile.StartsWith(diskName))
                        {
                            diskIdentifier = $"{index} {diskName.Substring(0, diskName.IndexOf(":"))}:";
                            break;
                        }
                        index++;
                    }
                }
                catch { diskIdentifier = null; }
            }
            else { diskIdentifier = null; }

            Debug.WriteLine($"UpdateDiskIdentifier(): diskIdentifier was updated to '{(!String.IsNullOrEmpty(diskIdentifier) ? diskIdentifier.ToString() : "null")}'");
        }

        private bool CurrentWorkingStatus
        {
            set
            {
                bool working = value;

                timerEstimate.Enabled = working;
                btnCalculate.Enabled = !working;
                picHashableFileThumb.Enabled = !working;
                progressHash.Value = (working ? 0 : 100);
                bool verifying = !String.IsNullOrEmpty(txtCompareHash.Text);
                btnCalculate.Text = (working ? (verifying ? "Verifying..." : "Calculating...") : (verifying ? "Verify" : "Calculate"));
                SetStatus(working ? (verifying ? "Verifying file" : "Calculating file hash") +  "..." : "Ready");

                comboAlgorithms.Enabled = !working;
                if (working)
                {
                    hasher.Algorithm = comboAlgorithms.Text;
                    hasher.HashableFilePath = hashableFile;
                    ActiveControl = txtCompareHash; txtCompareHash.Select(0, 0);
                    hasher.ComparisonHash = txtCompareHash.Text;
                    lblEstimatedHashingTime.Text = "Estimated hashing time: Calculating...";
                }
                txtCompareHash.Enabled = !working;

                txtCalculatedHash.Text = (working ? "" : hasher.CalculatedHash);
                ActiveControl = txtCalculatedHash; txtCalculatedHash.Select(0, 0);
                txtCalculatedHash.Enabled = !working;
            }
        }

        private void SetHashableFile(string filePath, bool setStatus = true)
        {
            try
            {
                if (String.IsNullOrEmpty(filePath) || !File.Exists(filePath)) // Reset hashable file details
                {
                    HashableFile = "";
                    picHashableFileThumb.Image = Resources.search_24x;
                    lblHashableName.Text = "None; Browse or drag && drop one here";
                    hashableFileToolTip.RemoveAll();
                    if (setStatus)
                    {
                        SetStatus("Hashable file non-existent, moved or deleted!", true, 2000);
                        SystemSounds.Exclamation.Play();
                    }
                    return;
                }

                string tmp = Path.GetFullPath(filePath);

                HashableFile = tmp;
                lblHashableName.Text = Path.GetFileName(hashableFile);
                picHashableFileThumb.Image = WindowsThumbnailProvider.GetThumbnail(hashableFile, 24, 24, ThumbnailOptions.None);
                hashableFileToolTip.SetTipEx(pnlHashableNameBg, hashableFile);
                if (setStatus) { SetStatus("Hashable file updated!", true, 2000); }
            }
            catch { if (setStatus) { SystemSounds.Asterisk.Play(); } }
        }

        private void SetStatus(string newStatus = "Ready", bool isTemporary = false, int resetInterval = 3000)
        {
            timerResetTitle.Stop();
            this.Text = "HashTool GUI | " + newStatus;

            if (isTemporary)
            {
                timerResetTitle.Interval = resetInterval;
                timerResetTitle.Start();
            }
        }

        #endregion

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (File.Exists(hashableFile))
            {
                CurrentWorkingStatus = true; // Change UI to block TextBox changes etc. while hashing the file

                if (!hasher.CertutilWorker.IsBusy)
                {
                    hasher.CertutilWorker.RunWorkerAsync();
                }
            }
            else
            {
                MessageBox.Show("The file to hash/verify is non-existent, has been moved or deleted!", "HashTool GUI | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CertutilWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            int result = (int)e.Result;

            CurrentWorkingStatus = false;
            
            txtCompareHash.ForeColor = (result == 0 && hasher.ComparisonHash != "") ? ((hasher.MatchingHashes) ? Color.Lime : Color.Red) : SystemColors.WindowText;
            SetStatus((result == 0) ? ((hasher.ComparisonHash != "") ? hasher.Algorithm + " hashes match: " + (hasher.MatchingHashes ? "Yes" : "No") : hasher.Algorithm + " hash calculated successfully!") : ((hasher.ComparisonHash != "") ? "File verified unsuccessfully!" : "Hash calculation unsuccessfull!"), true, 15000);
            
            if (result != 0) // Error
            {
                MessageBox.Show("An error occured during hashing/verifying!\n\nError code: 0x000" + result,
                                    "HashTool GUI | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else // No errors
            {
                double MBs = ((new FileInfo(hasher.HashableFilePath).Length / 1024) / 1024) / Math.Round(hasher.TotalWorkingTime.TotalSeconds, 15);
                //Debug.WriteLine("File size: " + MB + " MB");
                //Debug.WriteLine("Hashing time: ~" + );
                //var KBs = (new FileInfo(hasher.HashableFilePath).Length / Math.Round(hasher.TotalWorkingTime.TotalMilliseconds, 0));
                //Debug.WriteLine(hasher.Algorithm + " hashing speed: ~" + Math.Round(MBs, 0) + " MB/s");
                lblEstimatedHashingTime.Text = $"Estimated avg. read speed from '{hasher.HashableFilePath.Substring(0, 1)}': ~{Math.Round(MBs, 0)} MB/s";
            }
        }

        private double Median(double[] items)
        {
            double returnValue = 0;

            double[] sortedItems = (double[])items.Clone();
            Array.Sort(sortedItems);

            int itemsCount = sortedItems.Length;

            if (itemsCount % 2 == 1) // Get middle item
            {
                returnValue = sortedItems[(itemsCount / 2)];
            }
            else // Get average of 2 middle items
            {
                var firstValue = sortedItems[(itemsCount / 2) - 1];
                var secondValue = sortedItems[(itemsCount / 2)];
                returnValue = (firstValue + secondValue) / 2.0;
            }

            return returnValue;
        }

        private void txtCalculatedHash_TextChanged(object sender, EventArgs e)
        {
            picCopyCalculatedHash.Visible = (txtCalculatedHash.Text.Trim() != "" && hasher.ComparisonHash == "");/*groupHashing.Width - ((picCopyCalculatedHash.Visible) ? 124 : 97);*/
            txtCalculatedHash.Width = txtCompareHash.Width - Math.Abs(txtCalculatedHash.Location.X - txtCalculatedHash.Location.X) - ((picCopyCalculatedHash.Visible) ? 27 : 0);
        }

        private void picCopyCalculatedHash_Click(object sender, EventArgs e)
        {
            this.ActiveControl = txtCalculatedHash;
            txtCalculatedHash.Select(0, txtCalculatedHash.Text.Length);
            Clipboard.SetText(txtCalculatedHash.Text);
            SetStatus("Calculated hash copied to clipboard!", true);

        }

        private void comboAlgorithms_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get AVG hashing time for algorithm
            // lblEstimatedHashingTime.Text = ...

        }

        private bool estimate_variablesSet = false;
        private int estimate_lastProgress = 0;
        private ulong estimate_totalRead = 0;
        private Dictionary<string, object> estimate_infos = new Dictionary<string, object>();
        private FileInfo estimate_fileInfo = null;
        private ManagementObject estimate_wmiObj = null;

        private void timerEstimate_Tick(object sender, EventArgs e)
        {
            if(btnCalculate.Enabled) { timerEstimate.Stop(); estimate_variablesSet = false; } // Stop after done hashing
            
            if(!String.IsNullOrEmpty(diskIdentifier))
            {
                try
                {
                    if(!estimate_variablesSet)
                    {
                        estimate_lastProgress = 0;
                        estimate_totalRead = 0;
                        //estimate_infos = new Dictionary<string, object>();
                        estimate_fileInfo = new FileInfo(hashableFile);
                        estimate_wmiObj = new ManagementObject($"Win32_PerfFormattedData_PerfDisk_PhysicalDisk.Name='{diskIdentifier}'");
                        estimate_variablesSet = true;
                    }

                    estimate_infos = estimate_wmiObj.Properties.Cast<PropertyData>().ToDictionary(p => p.Name, p => p.Value);

                    if(estimate_infos != null)
                    {
                        bool verifying = !String.IsNullOrEmpty(hasher.ComparisonHash);

                        ulong currRead = (ulong)estimate_infos["DiskReadBytesPersec"];
                        int eta = -1;

                        if(currRead > 0)
                        {
                            estimate_totalRead += currRead;
                            //Console.WriteLine("CurrRead:  " + currRead + " Bytes/sec");
                            //Console.WriteLine("TotalRead: " + estimate_totalRead + " Bytes");
                            //Console.WriteLine("Total:     " + estimate_fileInfo.Length + " Bytes");
                            int progress = (int)Math.Max(Math.Min((100 * estimate_totalRead / (ulong)estimate_fileInfo.Length), 100), 0);
                            progressHash.Increment(progress - estimate_lastProgress); // Increment progress bar
                            SetStatus((verifying ? "Verifying file" : "Calculating file hash") + $": {progress}%");
                            //Console.WriteLine("Est. %:    " + progress);
                            //Console.WriteLine("ETA (s):   " + (((ulong)estimate_fileInfo.Length / currRead) - (estimate_totalRead / currRead)) + " seconds");
                            //Console.WriteLine("============================");
                            eta = (int)(((ulong)estimate_fileInfo.Length / currRead) - (estimate_totalRead / currRead));
                            estimate_lastProgress = progress;
                        }
                        else { Console.WriteLine("timerEstimate_Tick(): WARN: currRead <= 0!"); }

                        lblEstimatedHashingTime.Text = $"File {((verifying) ? "verification" : "hashing")} ETA: {((eta < 0 || currRead <= 0) ? "Unknown" : eta + $" second{((eta != 1) ? "s" : "")}")}";
                    }
                }
                catch { }
            }
            else { Console.WriteLine("timerEstimate_Tick(): Cannot calculate estimate as 'diskIdentifier' is null or empty"); }
        }
    }
}
