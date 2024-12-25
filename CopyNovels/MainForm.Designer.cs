namespace CopyNovel
{
    partial class formMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.fldSource = new System.Windows.Forms.TreeView();
            this.lstSubSource = new System.Windows.Forms.ListView();
            this.fldDest = new System.Windows.Forms.TreeView();
            this.lstSubDest = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lblSrc = new System.Windows.Forms.Label();
            this.lblDest = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnNoF = new System.Windows.Forms.Button();
            this.btnSrcBack = new System.Windows.Forms.Button();
            this.btnSourceUp = new System.Windows.Forms.Button();
            this.btnAlbum = new System.Windows.Forms.Button();
            this.btnDelNullFolder = new System.Windows.Forms.Button();
            this.btnMoveZip = new System.Windows.Forms.Button();
            this.btnMergeZip = new System.Windows.Forms.Button();
            this.btnRootZip = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fldSource
            // 
            this.fldSource.HideSelection = false;
            this.fldSource.Location = new System.Drawing.Point(12, 41);
            this.fldSource.Name = "fldSource";
            this.fldSource.Size = new System.Drawing.Size(373, 277);
            this.fldSource.TabIndex = 0;
            this.fldSource.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvFolders_AfterExpand);
            this.fldSource.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFolders_AfterSelect);
            // 
            // lstSubSource
            // 
            this.lstSubSource.HideSelection = false;
            this.lstSubSource.Location = new System.Drawing.Point(391, 41);
            this.lstSubSource.Name = "lstSubSource";
            this.lstSubSource.Size = new System.Drawing.Size(840, 277);
            this.lstSubSource.TabIndex = 1;
            this.lstSubSource.UseCompatibleStateImageBehavior = false;
            this.lstSubSource.View = System.Windows.Forms.View.List;
            this.lstSubSource.SelectedIndexChanged += new System.EventHandler(this.lstSubSource_SelectedIndexChanged);
            this.lstSubSource.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstSubSource_MouseDoubleClick);
            // 
            // fldDest
            // 
            this.fldDest.HideSelection = false;
            this.fldDest.Location = new System.Drawing.Point(10, 337);
            this.fldDest.Name = "fldDest";
            this.fldDest.Size = new System.Drawing.Size(373, 271);
            this.fldDest.TabIndex = 2;
            this.fldDest.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvFolders_AfterExpand);
            this.fldDest.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFolders_AfterSelect);
            // 
            // lstSubDest
            // 
            this.lstSubDest.HideSelection = false;
            this.lstSubDest.Location = new System.Drawing.Point(389, 337);
            this.lstSubDest.MultiSelect = false;
            this.lstSubDest.Name = "lstSubDest";
            this.lstSubDest.Size = new System.Drawing.Size(840, 271);
            this.lstSubDest.TabIndex = 3;
            this.lstSubDest.UseCompatibleStateImageBehavior = false;
            this.lstSubDest.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Source Folder:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 321);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Copy To Folder:";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(10, 614);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 6;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lblSrc
            // 
            this.lblSrc.AutoSize = true;
            this.lblSrc.Location = new System.Drawing.Point(388, 25);
            this.lblSrc.Name = "lblSrc";
            this.lblSrc.Size = new System.Drawing.Size(32, 13);
            this.lblSrc.TabIndex = 7;
            this.lblSrc.Text = "Path:";
            // 
            // lblDest
            // 
            this.lblDest.AutoSize = true;
            this.lblDest.Location = new System.Drawing.Point(388, 321);
            this.lblDest.Name = "lblDest";
            this.lblDest.Size = new System.Drawing.Size(32, 13);
            this.lblDest.TabIndex = 8;
            this.lblDest.Text = "Path:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(91, 614);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNoF
            // 
            this.btnNoF.Location = new System.Drawing.Point(172, 614);
            this.btnNoF.Name = "btnNoF";
            this.btnNoF.Size = new System.Drawing.Size(75, 23);
            this.btnNoF.TabIndex = 10;
            this.btnNoF.Text = "Remove \"f-\"";
            this.btnNoF.UseVisualStyleBackColor = true;
            this.btnNoF.Click += new System.EventHandler(this.btnNoF_Click);
            // 
            // btnSrcBack
            // 
            this.btnSrcBack.Enabled = false;
            this.btnSrcBack.Location = new System.Drawing.Point(354, 12);
            this.btnSrcBack.Name = "btnSrcBack";
            this.btnSrcBack.Size = new System.Drawing.Size(31, 23);
            this.btnSrcBack.TabIndex = 12;
            this.btnSrcBack.Text = "<<";
            this.btnSrcBack.UseVisualStyleBackColor = true;
            this.btnSrcBack.Click += new System.EventHandler(this.btnSrcBack_Click);
            // 
            // btnSourceUp
            // 
            this.btnSourceUp.Enabled = false;
            this.btnSourceUp.Location = new System.Drawing.Point(317, 12);
            this.btnSourceUp.Name = "btnSourceUp";
            this.btnSourceUp.Size = new System.Drawing.Size(31, 23);
            this.btnSourceUp.TabIndex = 13;
            this.btnSourceUp.Text = "up";
            this.btnSourceUp.UseVisualStyleBackColor = true;
            this.btnSourceUp.Click += new System.EventHandler(this.btnSourceUp_Click);
            // 
            // btnAlbum
            // 
            this.btnAlbum.Location = new System.Drawing.Point(253, 614);
            this.btnAlbum.Name = "btnAlbum";
            this.btnAlbum.Size = new System.Drawing.Size(75, 23);
            this.btnAlbum.TabIndex = 14;
            this.btnAlbum.Text = "Album";
            this.btnAlbum.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAlbum.UseVisualStyleBackColor = true;
            this.btnAlbum.Click += new System.EventHandler(this.btnAlbum_Click);
            // 
            // btnDelNullFolder
            // 
            this.btnDelNullFolder.Location = new System.Drawing.Point(334, 614);
            this.btnDelNullFolder.Name = "btnDelNullFolder";
            this.btnDelNullFolder.Size = new System.Drawing.Size(103, 23);
            this.btnDelNullFolder.TabIndex = 15;
            this.btnDelNullFolder.Text = "Del Empty Folder";
            this.btnDelNullFolder.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelNullFolder.UseVisualStyleBackColor = true;
            this.btnDelNullFolder.Click += new System.EventHandler(this.btnDelNullFolder_Click);
            // 
            // btnMoveZip
            // 
            this.btnMoveZip.Location = new System.Drawing.Point(443, 614);
            this.btnMoveZip.Name = "btnMoveZip";
            this.btnMoveZip.Size = new System.Drawing.Size(103, 23);
            this.btnMoveZip.TabIndex = 16;
            this.btnMoveZip.Text = "Move Unzipped";
            this.btnMoveZip.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMoveZip.UseVisualStyleBackColor = true;
            this.btnMoveZip.Click += new System.EventHandler(this.btnMoveZip_Click);
            // 
            // btnMergeZip
            // 
            this.btnMergeZip.Location = new System.Drawing.Point(552, 615);
            this.btnMergeZip.Name = "btnMergeZip";
            this.btnMergeZip.Size = new System.Drawing.Size(103, 23);
            this.btnMergeZip.TabIndex = 17;
            this.btnMergeZip.Text = "Merge Unzipped";
            this.btnMergeZip.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMergeZip.UseVisualStyleBackColor = true;
            this.btnMergeZip.Click += new System.EventHandler(this.btnMergeZip_Click);
            // 
            // btnRootZip
            // 
            this.btnRootZip.Location = new System.Drawing.Point(661, 614);
            this.btnRootZip.Name = "btnRootZip";
            this.btnRootZip.Size = new System.Drawing.Size(103, 23);
            this.btnRootZip.TabIndex = 18;
            this.btnRootZip.Text = "Root *.zip";
            this.btnRootZip.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRootZip.UseVisualStyleBackColor = true;
            this.btnRootZip.Click += new System.EventHandler(this.btnRootZip_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 649);
            this.Controls.Add(this.btnRootZip);
            this.Controls.Add(this.btnMergeZip);
            this.Controls.Add(this.btnMoveZip);
            this.Controls.Add(this.btnDelNullFolder);
            this.Controls.Add(this.btnAlbum);
            this.Controls.Add(this.btnSourceUp);
            this.Controls.Add(this.btnSrcBack);
            this.Controls.Add(this.btnNoF);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblDest);
            this.Controls.Add(this.lblSrc);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstSubDest);
            this.Controls.Add(this.fldDest);
            this.Controls.Add(this.lstSubSource);
            this.Controls.Add(this.fldSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "formMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Copy Novels";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView fldSource;
        private System.Windows.Forms.ListView lstSubSource;
        private System.Windows.Forms.TreeView fldDest;
        private System.Windows.Forms.ListView lstSubDest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lblSrc;
        private System.Windows.Forms.Label lblDest;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnNoF;
        private System.Windows.Forms.Button btnSrcBack;
        private System.Windows.Forms.Button btnSourceUp;
        private System.Windows.Forms.Button btnAlbum;
        private System.Windows.Forms.Button btnDelNullFolder;
        private System.Windows.Forms.Button btnMoveZip;
        private System.Windows.Forms.Button btnMergeZip;
        private System.Windows.Forms.Button btnRootZip;
    }
}

