using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProSafe
{
    public partial class VolumeCreateWizard : Form
    {

        public VolumeCreateWizard()
        {
            InitializeComponent();
        }

        private void VolumeCreateWizard_Load(object sender, EventArgs e)
        {
            storageType.SelectedIndex = 1;
        }

        private void saveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Container File Location";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = sfd.FileName;
                filePath.Text = selectedFileName;
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createContainer_Click(object sender, EventArgs e)
        {
            if (filePath.Text == "")
            {
                MessageBox.Show("Please select a location to save the container.", "Volume Creation Wizard - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (sizeTxt.Text == "")
            {
                MessageBox.Show("Please input a size to the container.", "Volume Creation Wizard - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (password.Text == "")
            {
                MessageBox.Show("Password can't be empty.", "Volume Creation Wizard - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                repassword.Text = "";
                return;
            }
            if (password.Text != repassword.Text)
            {
                MessageBox.Show("Passwords don't match.", "Volume Creation Wizard - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                password.Text = "";
                repassword.Text = "";
                return;
            }
            if (password.Text.Length < 4)
            {
                MessageBox.Show("Password can't be less than 3 characters.", "Volume Creation Wizard - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                password.Text = "";
                repassword.Text = "";
                return;
            }
            if (password.Text.Length < 8)
            {
                DialogResult minPass = MessageBox.Show("It is recommended that the password be no less than 8 characters long. Do you want to continue?", "Volume Creation Wizard - Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if(minPass == DialogResult.OK)
                {
                    createNewContainer();
                }
                else
                {
                    password.Text = "";
                    repassword.Text = "";
                }
            }
            else
            {
                createNewContainer();
            }
        }
        Load load = new Load();
        private void createNewContainer()
        {
            string pass = password.Text;
            password.Text = "";
            repassword.Text = "";
            string storageTypeResult = storageType.Text;
            int size = 0;
            if (storageTypeResult == "MB")
            {
                size = (int)Convert.ToInt32(sizeTxt.Text);
            }
            else if (storageTypeResult == "GB")
            {
                size = (int)Convert.ToInt32(sizeTxt.Text) * 1024;
            }
            else
            {
                size = (int)Convert.ToInt32(sizeTxt.Text) * 1048576;
            }
            load.Show();
            Process process = new Process();
            process.StartInfo.FileName = "diskpart.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            process.StandardInput.WriteLine("create vdisk file=" + Path.GetTempPath() + "storagedisk.vhd" + " maximum=" + size + " type=fixed");
            process.StandardInput.WriteLine("select vdisk file=" + Path.GetTempPath() + "storagedisk.vhd");
            process.StandardInput.WriteLine("attach vdisk");
            process.StandardInput.WriteLine("convert gpt");
            process.StandardInput.WriteLine("create partition primary");
            process.StandardInput.WriteLine("format fs=ntfs label=\"ProSafe Disk\" quick");
            process.StandardInput.WriteLine("detach vdisk");
            process.StandardInput.WriteLine("exit");
            process.WaitForExit();
            FileEncrypt(Path.GetTempPath() + "storagedisk.vhd", pass);
            File.Delete(Path.GetTempPath() + "storagedisk.vhd");
            load.Hide();
            MessageBox.Show("Volume created with successfully!", "Volume Creation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        private static byte[] GenerateRandomSalt()
        {
            byte[] data = new byte[32];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                for (int i = 0; i < 10; i++)
                {
                    rng.GetBytes(data);
                }
            }
            return data;
        }
        private void FileEncrypt(string inputFile, string password)
        {
            byte[] salt = GenerateRandomSalt();
            FileStream fsCrypt = new FileStream(filePath.Text, FileMode.Create);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Padding = PaddingMode.PKCS7;
            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            AES.Mode = CipherMode.CFB;
            fsCrypt.Write(salt, 0, salt.Length);
            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);
            FileStream fsIn = new FileStream(inputFile, FileMode.Open);
            byte[] buffer = new byte[1048576];
            int read;
            try
            {
                while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                {
                    Application.DoEvents();
                    cs.Write(buffer, 0, read);
                }
                fsIn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Unmount Encryption - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cs.Close();
                fsCrypt.Close();
            }
        }
    }
}
