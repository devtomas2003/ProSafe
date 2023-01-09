namespace ProSafe
{
    partial class VolumeCreateWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VolumeCreateWizard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.storageType = new System.Windows.Forms.ComboBox();
            this.sizeTxt = new System.Windows.Forms.TextBox();
            this.saveFile = new System.Windows.Forms.Button();
            this.filePath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.repassword = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.createContainer = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 94);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Volume Creation Wizard";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "ProSafe";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.storageType);
            this.groupBox1.Controls.Add(this.sizeTxt);
            this.groupBox1.Controls.Add(this.saveFile);
            this.groupBox1.Controls.Add(this.filePath);
            this.groupBox1.Location = new System.Drawing.Point(16, 101);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(764, 92);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Volume";
            // 
            // storageType
            // 
            this.storageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.storageType.FormattingEnabled = true;
            this.storageType.Items.AddRange(new object[] {
            "MB",
            "GB",
            "TB"});
            this.storageType.Location = new System.Drawing.Point(148, 55);
            this.storageType.Margin = new System.Windows.Forms.Padding(4);
            this.storageType.Name = "storageType";
            this.storageType.Size = new System.Drawing.Size(89, 24);
            this.storageType.TabIndex = 3;
            // 
            // sizeTxt
            // 
            this.sizeTxt.Location = new System.Drawing.Point(7, 55);
            this.sizeTxt.Margin = new System.Windows.Forms.Padding(4);
            this.sizeTxt.Name = "sizeTxt";
            this.sizeTxt.Size = new System.Drawing.Size(132, 22);
            this.sizeTxt.TabIndex = 2;
            // 
            // saveFile
            // 
            this.saveFile.Location = new System.Drawing.Point(638, 21);
            this.saveFile.Margin = new System.Windows.Forms.Padding(4);
            this.saveFile.Name = "saveFile";
            this.saveFile.Size = new System.Drawing.Size(118, 28);
            this.saveFile.TabIndex = 1;
            this.saveFile.Text = "Select File";
            this.saveFile.UseVisualStyleBackColor = true;
            this.saveFile.Click += new System.EventHandler(this.saveFile_Click);
            // 
            // filePath
            // 
            this.filePath.Location = new System.Drawing.Point(8, 23);
            this.filePath.Margin = new System.Windows.Forms.Padding(4);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(622, 22);
            this.filePath.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.repassword);
            this.groupBox2.Controls.Add(this.password);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(16, 201);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(764, 92);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Security";
            // 
            // repassword
            // 
            this.repassword.Location = new System.Drawing.Point(131, 57);
            this.repassword.Margin = new System.Windows.Forms.Padding(4);
            this.repassword.Name = "repassword";
            this.repassword.PasswordChar = '*';
            this.repassword.Size = new System.Drawing.Size(624, 22);
            this.repassword.TabIndex = 3;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(131, 27);
            this.password.Margin = new System.Windows.Forms.Padding(4);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(624, 22);
            this.password.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 60);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Repeat Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Password";
            // 
            // createContainer
            // 
            this.createContainer.Location = new System.Drawing.Point(680, 300);
            this.createContainer.Margin = new System.Windows.Forms.Padding(4);
            this.createContainer.Name = "createContainer";
            this.createContainer.Size = new System.Drawing.Size(100, 28);
            this.createContainer.TabIndex = 5;
            this.createContainer.Text = "Create";
            this.createContainer.UseVisualStyleBackColor = true;
            this.createContainer.Click += new System.EventHandler(this.createContainer_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(16, 300);
            this.cancel.Margin = new System.Windows.Forms.Padding(4);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(100, 28);
            this.cancel.TabIndex = 6;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // VolumeCreateWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 338);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.createContainer);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "VolumeCreateWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Volume Creation Wizard";
            this.Load += new System.EventHandler(this.VolumeCreateWizard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button saveFile;
        private System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.TextBox sizeTxt;
        private System.Windows.Forms.ComboBox storageType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox repassword;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button createContainer;
        private System.Windows.Forms.Button cancel;
    }
}