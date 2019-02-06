namespace HashToolGUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblVer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupHashing = new System.Windows.Forms.GroupBox();
            this.progressHash = new System.Windows.Forms.ProgressBar();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txtCalculatedHash = new System.Windows.Forms.TextBox();
            this.txtCompareHash = new System.Windows.Forms.TextBox();
            this.comboAlgorithms = new System.Windows.Forms.ComboBox();
            this.lblEstimatedHashingTime = new System.Windows.Forms.Label();
            this.lblCalculated = new System.Windows.Forms.Label();
            this.lblCompare = new System.Windows.Forms.Label();
            this.lblAlgorithm = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.pnlHashableNameBg = new System.Windows.Forms.Panel();
            this.lblHashableName = new System.Windows.Forms.Label();
            this.timerResetTitle = new System.Windows.Forms.Timer(this.components);
            this.hashableFileToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lblHelpInfo = new System.Windows.Forms.Label();
            this.timerEstimate = new System.Windows.Forms.Timer(this.components);
            this.picHashableFileThumb = new System.Windows.Forms.PictureBox();
            this.picHashableEndFade = new System.Windows.Forms.PictureBox();
            this.picCopyCalculatedHash = new System.Windows.Forms.PictureBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.picTopSeperator = new System.Windows.Forms.PictureBox();
            this.groupHashing.SuspendLayout();
            this.pnlHashableNameBg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHashableFileThumb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHashableEndFade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCopyCalculatedHash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTopSeperator)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 17.75F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(121, 35);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(169, 32);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "HashTool GUI";
            // 
            // lblVer
            // 
            this.lblVer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblVer.AutoSize = true;
            this.lblVer.Location = new System.Drawing.Point(130, 67);
            this.lblVer.Name = "lblVer";
            this.lblVer.Size = new System.Drawing.Size(27, 13);
            this.lblVer.TabIndex = 3;
            this.lblVer.Text = "v1.0";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.Location = new System.Drawing.Point(123, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "by @JamiKettunen";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupHashing
            // 
            this.groupHashing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupHashing.Controls.Add(this.progressHash);
            this.groupHashing.Controls.Add(this.btnCalculate);
            this.groupHashing.Controls.Add(this.txtCalculatedHash);
            this.groupHashing.Controls.Add(this.txtCompareHash);
            this.groupHashing.Controls.Add(this.picHashableFileThumb);
            this.groupHashing.Controls.Add(this.comboAlgorithms);
            this.groupHashing.Controls.Add(this.lblEstimatedHashingTime);
            this.groupHashing.Controls.Add(this.lblCalculated);
            this.groupHashing.Controls.Add(this.lblCompare);
            this.groupHashing.Controls.Add(this.lblAlgorithm);
            this.groupHashing.Controls.Add(this.lblFile);
            this.groupHashing.Controls.Add(this.pnlHashableNameBg);
            this.groupHashing.Controls.Add(this.picCopyCalculatedHash);
            this.groupHashing.Location = new System.Drawing.Point(12, 109);
            this.groupHashing.Name = "groupHashing";
            this.groupHashing.Size = new System.Drawing.Size(294, 196);
            this.groupHashing.TabIndex = 4;
            this.groupHashing.TabStop = false;
            this.groupHashing.Text = "Hashing";
            // 
            // progressHash
            // 
            this.progressHash.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.progressHash.Location = new System.Drawing.Point(106, 138);
            this.progressHash.Name = "progressHash";
            this.progressHash.Size = new System.Drawing.Size(171, 21);
            this.progressHash.TabIndex = 10;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCalculate.Enabled = false;
            this.btnCalculate.Location = new System.Drawing.Point(13, 137);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(87, 23);
            this.btnCalculate.TabIndex = 9;
            this.btnCalculate.Text = "&Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txtCalculatedHash
            // 
            this.txtCalculatedHash.Location = new System.Drawing.Point(77, 80);
            this.txtCalculatedHash.Name = "txtCalculatedHash";
            this.txtCalculatedHash.ReadOnly = true;
            this.txtCalculatedHash.Size = new System.Drawing.Size(200, 22);
            this.txtCalculatedHash.TabIndex = 8;
            this.txtCalculatedHash.TextChanged += new System.EventHandler(this.txtCalculatedHash_TextChanged);
            // 
            // txtCompareHash
            // 
            this.txtCompareHash.Location = new System.Drawing.Point(77, 109);
            this.txtCompareHash.Name = "txtCompareHash";
            this.txtCompareHash.Size = new System.Drawing.Size(200, 22);
            this.txtCompareHash.TabIndex = 8;
            this.txtCompareHash.TextChanged += new System.EventHandler(this.txtCompareHash_TextChanged);
            // 
            // comboAlgorithms
            // 
            this.comboAlgorithms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAlgorithms.FormattingEnabled = true;
            this.comboAlgorithms.Items.AddRange(new object[] {
            "MD2",
            "MD4",
            "MD5",
            "SHA1",
            "SHA256",
            "SHA384",
            "SHA512"});
            this.comboAlgorithms.Location = new System.Drawing.Point(77, 21);
            this.comboAlgorithms.Name = "comboAlgorithms";
            this.comboAlgorithms.Size = new System.Drawing.Size(200, 21);
            this.comboAlgorithms.TabIndex = 4;
            this.comboAlgorithms.SelectedIndexChanged += new System.EventHandler(this.comboAlgorithms_SelectedIndexChanged);
            // 
            // lblEstimatedHashingTime
            // 
            this.lblEstimatedHashingTime.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblEstimatedHashingTime.Location = new System.Drawing.Point(17, 170);
            this.lblEstimatedHashingTime.Name = "lblEstimatedHashingTime";
            this.lblEstimatedHashingTime.Size = new System.Drawing.Size(260, 13);
            this.lblEstimatedHashingTime.TabIndex = 3;
            this.lblEstimatedHashingTime.Text = "File hashing ETA: Unknown";
            this.lblEstimatedHashingTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCalculated
            // 
            this.lblCalculated.AutoSize = true;
            this.lblCalculated.Location = new System.Drawing.Point(11, 83);
            this.lblCalculated.Name = "lblCalculated";
            this.lblCalculated.Size = new System.Drawing.Size(64, 13);
            this.lblCalculated.TabIndex = 3;
            this.lblCalculated.Text = "Calculated:";
            // 
            // lblCompare
            // 
            this.lblCompare.AutoSize = true;
            this.lblCompare.Location = new System.Drawing.Point(19, 112);
            this.lblCompare.Name = "lblCompare";
            this.lblCompare.Size = new System.Drawing.Size(56, 13);
            this.lblCompare.TabIndex = 3;
            this.lblCompare.Text = "Compare:";
            // 
            // lblAlgorithm
            // 
            this.lblAlgorithm.AutoSize = true;
            this.lblAlgorithm.Location = new System.Drawing.Point(14, 24);
            this.lblAlgorithm.Name = "lblAlgorithm";
            this.lblAlgorithm.Size = new System.Drawing.Size(61, 13);
            this.lblAlgorithm.TabIndex = 3;
            this.lblAlgorithm.Text = "Algorithm:";
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(14, 54);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(28, 13);
            this.lblFile.TabIndex = 3;
            this.lblFile.Text = "File:";
            // 
            // pnlHashableNameBg
            // 
            this.pnlHashableNameBg.Controls.Add(this.picHashableEndFade);
            this.pnlHashableNameBg.Controls.Add(this.lblHashableName);
            this.pnlHashableNameBg.Location = new System.Drawing.Point(70, 54);
            this.pnlHashableNameBg.Name = "pnlHashableNameBg";
            this.pnlHashableNameBg.Size = new System.Drawing.Size(207, 13);
            this.pnlHashableNameBg.TabIndex = 7;
            // 
            // lblHashableName
            // 
            this.lblHashableName.AutoSize = true;
            this.lblHashableName.Location = new System.Drawing.Point(0, 0);
            this.lblHashableName.Name = "lblHashableName";
            this.lblHashableName.Size = new System.Drawing.Size(209, 13);
            this.lblHashableName.TabIndex = 3;
            this.lblHashableName.Text = "None; Browse or drag && drop one here";
            this.lblHashableName.SizeChanged += new System.EventHandler(this.lblHashableName_SizeChanged);
            // 
            // timerResetTitle
            // 
            this.timerResetTitle.Interval = 3000;
            this.timerResetTitle.Tick += new System.EventHandler(this.timerResetTitle_Tick);
            // 
            // lblHelpInfo
            // 
            this.lblHelpInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblHelpInfo.AutoSize = true;
            this.lblHelpInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.lblHelpInfo.Location = new System.Drawing.Point(161, 92);
            this.lblHelpInfo.Name = "lblHelpInfo";
            this.lblHelpInfo.Size = new System.Drawing.Size(92, 13);
            this.lblHelpInfo.TabIndex = 3;
            this.lblHelpInfo.Text = "Press F1 for help";
            this.lblHelpInfo.Visible = false;
            // 
            // timerEstimate
            // 
            this.timerEstimate.Interval = 1000;
            this.timerEstimate.Tick += new System.EventHandler(this.timerEstimate_Tick);
            // 
            // picHashableFileThumb
            // 
            this.picHashableFileThumb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picHashableFileThumb.Image = global::HashToolGUI.Properties.Resources.search_24x;
            this.picHashableFileThumb.Location = new System.Drawing.Point(44, 49);
            this.picHashableFileThumb.Name = "picHashableFileThumb";
            this.picHashableFileThumb.Size = new System.Drawing.Size(24, 24);
            this.picHashableFileThumb.TabIndex = 6;
            this.picHashableFileThumb.TabStop = false;
            this.picHashableFileThumb.Click += new System.EventHandler(this.picHashableFileThumb_Click);
            // 
            // picHashableEndFade
            // 
            this.picHashableEndFade.BackColor = System.Drawing.Color.Transparent;
            this.picHashableEndFade.BackgroundImage = global::HashToolGUI.Properties.Resources.text_end_fade;
            this.picHashableEndFade.Location = new System.Drawing.Point(177, 0);
            this.picHashableEndFade.Name = "picHashableEndFade";
            this.picHashableEndFade.Size = new System.Drawing.Size(30, 13);
            this.picHashableEndFade.TabIndex = 4;
            this.picHashableEndFade.TabStop = false;
            this.picHashableEndFade.Visible = false;
            // 
            // picCopyCalculatedHash
            // 
            this.picCopyCalculatedHash.BackgroundImage = global::HashToolGUI.Properties.Resources.clipboard_16x;
            this.picCopyCalculatedHash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picCopyCalculatedHash.Location = new System.Drawing.Point(254, 80);
            this.picCopyCalculatedHash.Name = "picCopyCalculatedHash";
            this.picCopyCalculatedHash.Size = new System.Drawing.Size(22, 22);
            this.picCopyCalculatedHash.TabIndex = 5;
            this.picCopyCalculatedHash.TabStop = false;
            this.picCopyCalculatedHash.Visible = false;
            this.picCopyCalculatedHash.Click += new System.EventHandler(this.picCopyCalculatedHash_Click);
            // 
            // picLogo
            // 
            this.picLogo.Image = global::HashToolGUI.Properties.Resources.icon_84x;
            this.picLogo.Location = new System.Drawing.Point(16, 16);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(84, 84);
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            // 
            // picTopSeperator
            // 
            this.picTopSeperator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.picTopSeperator.Dock = System.Windows.Forms.DockStyle.Top;
            this.picTopSeperator.Location = new System.Drawing.Point(0, 0);
            this.picTopSeperator.Name = "picTopSeperator";
            this.picTopSeperator.Size = new System.Drawing.Size(318, 1);
            this.picTopSeperator.TabIndex = 0;
            this.picTopSeperator.TabStop = false;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(318, 314);
            this.Controls.Add(this.groupHashing);
            this.Controls.Add(this.lblHelpInfo);
            this.Controls.Add(this.lblVer);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.picTopSeperator);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HashTool GUI | Loading...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.groupHashing.ResumeLayout(false);
            this.groupHashing.PerformLayout();
            this.pnlHashableNameBg.ResumeLayout(false);
            this.pnlHashableNameBg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHashableFileThumb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHashableEndFade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCopyCalculatedHash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTopSeperator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picTopSeperator;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblVer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupHashing;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Timer timerResetTitle;
        private System.Windows.Forms.ComboBox comboAlgorithms;
        private System.Windows.Forms.Label lblAlgorithm;
        private System.Windows.Forms.PictureBox picHashableFileThumb;
        private System.Windows.Forms.Panel pnlHashableNameBg;
        private System.Windows.Forms.Label lblHashableName;
        private System.Windows.Forms.PictureBox picHashableEndFade;
        private System.Windows.Forms.ToolTip hashableFileToolTip;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TextBox txtCompareHash;
        private System.Windows.Forms.Label lblCompare;
        private System.Windows.Forms.ProgressBar progressHash;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lblEstimatedHashingTime;
        private System.Windows.Forms.TextBox txtCalculatedHash;
        private System.Windows.Forms.Label lblCalculated;
        private System.Windows.Forms.PictureBox picCopyCalculatedHash;
        private System.Windows.Forms.Label lblHelpInfo;
        private System.Windows.Forms.Timer timerEstimate;
    }
}

