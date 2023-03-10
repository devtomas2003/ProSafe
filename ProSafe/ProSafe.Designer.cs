using System.Drawing;
using System.Windows.Forms;

namespace ProSafe
{
    partial class prosafe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(prosafe));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.volumesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewVolumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permanentlyDecryptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createRescueDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verifyRescueDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.volumeExpandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trevelerDiskSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateKeysPairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drives = new System.Windows.Forms.DataGridView();
            this.drive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createVolume = new System.Windows.Forms.Button();
            this.unmount = new System.Windows.Forms.Button();
            this.unmountAll = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.exit = new System.Windows.Forms.Button();
            this.mount = new System.Windows.Forms.Button();
            this.btnSelectBucket = new System.Windows.Forms.Button();
            this.filePath = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drives)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.volumesToolStripMenuItem,
            this.systemToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menu.Size = new System.Drawing.Size(964, 28);
            this.menu.TabIndex = 0;
            this.menu.Text = "menu";
            // 
            // volumesToolStripMenuItem
            // 
            this.volumesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewVolumeToolStripMenuItem,
            this.permanentlyDecryptToolStripMenuItem});
            this.volumesToolStripMenuItem.Name = "volumesToolStripMenuItem";
            this.volumesToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.volumesToolStripMenuItem.Text = "Volumes";
            // 
            // createNewVolumeToolStripMenuItem
            // 
            this.createNewVolumeToolStripMenuItem.Name = "createNewVolumeToolStripMenuItem";
            this.createNewVolumeToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.createNewVolumeToolStripMenuItem.Text = "Create New Volume";
            this.createNewVolumeToolStripMenuItem.Click += new System.EventHandler(this.createNewVolumeToolStripMenuItem_Click);
            // 
            // permanentlyDecryptToolStripMenuItem
            // 
            this.permanentlyDecryptToolStripMenuItem.Name = "permanentlyDecryptToolStripMenuItem";
            this.permanentlyDecryptToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.permanentlyDecryptToolStripMenuItem.Text = "Permanently Decrypt";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createRescueDiskToolStripMenuItem,
            this.verifyRescueDiskToolStripMenuItem,
            this.changePasswordToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // createRescueDiskToolStripMenuItem
            // 
            this.createRescueDiskToolStripMenuItem.Name = "createRescueDiskToolStripMenuItem";
            this.createRescueDiskToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.createRescueDiskToolStripMenuItem.Text = "Create Rescue Disk";
            // 
            // verifyRescueDiskToolStripMenuItem
            // 
            this.verifyRescueDiskToolStripMenuItem.Name = "verifyRescueDiskToolStripMenuItem";
            this.verifyRescueDiskToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.verifyRescueDiskToolStripMenuItem.Text = "Verify Rescue Disk";
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.volumeExpandToolStripMenuItem,
            this.trevelerDiskSetupToolStripMenuItem,
            this.generateKeysPairToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // volumeExpandToolStripMenuItem
            // 
            this.volumeExpandToolStripMenuItem.Name = "volumeExpandToolStripMenuItem";
            this.volumeExpandToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.volumeExpandToolStripMenuItem.Text = "Volume Expand";
            // 
            // trevelerDiskSetupToolStripMenuItem
            // 
            this.trevelerDiskSetupToolStripMenuItem.Name = "trevelerDiskSetupToolStripMenuItem";
            this.trevelerDiskSetupToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.trevelerDiskSetupToolStripMenuItem.Text = "Treveler Disk Setup";
            // 
            // generateKeysPairToolStripMenuItem
            // 
            this.generateKeysPairToolStripMenuItem.Name = "generateKeysPairToolStripMenuItem";
            this.generateKeysPairToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.generateKeysPairToolStripMenuItem.Text = "Generate Keys Pair";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.usersGuideToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // usersGuideToolStripMenuItem
            // 
            this.usersGuideToolStripMenuItem.Name = "usersGuideToolStripMenuItem";
            this.usersGuideToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.usersGuideToolStripMenuItem.Text = "User\'s Guide";
            // 
            // drives
            // 
            this.drives.AllowUserToAddRows = false;
            this.drives.AllowUserToDeleteRows = false;
            this.drives.AllowUserToResizeRows = false;
            this.drives.BackgroundColor = System.Drawing.Color.White;
            this.drives.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.drives.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.drives.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.drives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drives.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.drive,
            this.volume,
            this.size,
            this.type,
            this.volId,
            this.time});
            this.drives.Location = new System.Drawing.Point(3, 2);
            this.drives.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.drives.MultiSelect = false;
            this.drives.Name = "drives";
            this.drives.ReadOnly = true;
            this.drives.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.drives.RowHeadersVisible = false;
            this.drives.RowHeadersWidth = 51;
            this.drives.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.drives.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.drives.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.drives.ShowEditingIcon = false;
            this.drives.Size = new System.Drawing.Size(940, 399);
            this.drives.TabIndex = 1;
            // 
            // drive
            // 
            this.drive.HeaderText = "Drive";
            this.drive.MinimumWidth = 6;
            this.drive.Name = "drive";
            this.drive.ReadOnly = true;
            this.drive.Width = 50;
            // 
            // volume
            // 
            this.volume.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.volume.HeaderText = "Volume";
            this.volume.MinimumWidth = 6;
            this.volume.Name = "volume";
            this.volume.ReadOnly = true;
            // 
            // size
            // 
            this.size.HeaderText = "Size";
            this.size.MinimumWidth = 6;
            this.size.Name = "size";
            this.size.ReadOnly = true;
            this.size.Width = 80;
            // 
            // type
            // 
            this.type.HeaderText = "Type";
            this.type.MinimumWidth = 6;
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Width = 70;
            // 
            // volId
            // 
            this.volId.HeaderText = "volId";
            this.volId.MinimumWidth = 6;
            this.volId.Name = "volId";
            this.volId.ReadOnly = true;
            this.volId.Visible = false;
            this.volId.Width = 125;
            // 
            // time
            // 
            this.time.HeaderText = "time";
            this.time.MinimumWidth = 6;
            this.time.Name = "time";
            this.time.ReadOnly = true;
            this.time.Visible = false;
            this.time.Width = 125;
            // 
            // createVolume
            // 
            this.createVolume.Location = new System.Drawing.Point(4, 4);
            this.createVolume.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.createVolume.Name = "createVolume";
            this.createVolume.Size = new System.Drawing.Size(157, 34);
            this.createVolume.TabIndex = 2;
            this.createVolume.Text = "Create Volume";
            this.createVolume.UseVisualStyleBackColor = true;
            this.createVolume.Click += new System.EventHandler(this.createVolume_Click);
            // 
            // unmount
            // 
            this.unmount.Location = new System.Drawing.Point(391, 4);
            this.unmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.unmount.Name = "unmount";
            this.unmount.Size = new System.Drawing.Size(184, 34);
            this.unmount.TabIndex = 3;
            this.unmount.Text = "Unmount";
            this.unmount.UseVisualStyleBackColor = true;
            this.unmount.Click += new System.EventHandler(this.unmount_Click);
            // 
            // unmountAll
            // 
            this.unmountAll.Location = new System.Drawing.Point(755, 2);
            this.unmountAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.unmountAll.Name = "unmountAll";
            this.unmountAll.Size = new System.Drawing.Size(184, 34);
            this.unmountAll.TabIndex = 4;
            this.unmountAll.Text = "Unmount All";
            this.unmountAll.UseVisualStyleBackColor = true;
            this.unmountAll.Click += new System.EventHandler(this.unmountAll_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.createVolume);
            this.panel1.Controls.Add(this.unmountAll);
            this.panel1.Controls.Add(this.unmount);
            this.panel1.Location = new System.Drawing.Point(8, 447);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(947, 201);
            this.panel1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.exit);
            this.groupBox1.Controls.Add(this.mount);
            this.groupBox1.Controls.Add(this.btnSelectBucket);
            this.groupBox1.Controls.Add(this.filePath);
            this.groupBox1.Location = new System.Drawing.Point(7, 44);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(932, 151);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Volume";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Password";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(8, 71);
            this.txtPass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(915, 22);
            this.txtPass.TabIndex = 10;
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(8, 106);
            this.exit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(147, 34);
            this.exit.TabIndex = 9;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // mount
            // 
            this.mount.Location = new System.Drawing.Point(748, 106);
            this.mount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mount.Name = "mount";
            this.mount.Size = new System.Drawing.Size(176, 34);
            this.mount.TabIndex = 8;
            this.mount.Text = "Mount";
            this.mount.UseVisualStyleBackColor = true;
            this.mount.Click += new System.EventHandler(this.mount_Click);
            // 
            // btnSelectBucket
            // 
            this.btnSelectBucket.Location = new System.Drawing.Point(777, 22);
            this.btnSelectBucket.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectBucket.Name = "btnSelectBucket";
            this.btnSelectBucket.Size = new System.Drawing.Size(147, 28);
            this.btnSelectBucket.TabIndex = 1;
            this.btnSelectBucket.Text = "Select Container";
            this.btnSelectBucket.UseVisualStyleBackColor = true;
            this.btnSelectBucket.Click += new System.EventHandler(this.btnSelectBucket_Click);
            // 
            // filePath
            // 
            this.filePath.Location = new System.Drawing.Point(8, 23);
            this.filePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(760, 22);
            this.filePath.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.drives);
            this.panel2.Location = new System.Drawing.Point(8, 33);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(947, 406);
            this.panel2.TabIndex = 6;
            // 
            // prosafe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 657);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "prosafe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProSafe";
            this.Load += new System.EventHandler(this.prosafe_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drives)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem volumesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewVolumeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem permanentlyDecryptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createRescueDiskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verifyRescueDiskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem volumeExpandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trevelerDiskSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateKeysPairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersGuideToolStripMenuItem;
        private System.Windows.Forms.DataGridView drives;
        private Button createVolume;
        private Button unmount;
        private Button unmountAll;
        private Panel panel1;
        private Panel panel2;
        private GroupBox groupBox1;
        private Button btnSelectBucket;
        private TextBox filePath;
        private Button exit;
        private Button mount;
        private Label label1;
        private TextBox txtPass;
        private DataGridViewTextBoxColumn drive;
        private DataGridViewTextBoxColumn volume;
        private DataGridViewTextBoxColumn size;
        private DataGridViewTextBoxColumn type;
        private DataGridViewTextBoxColumn volId;
        private DataGridViewTextBoxColumn time;
    }
}

