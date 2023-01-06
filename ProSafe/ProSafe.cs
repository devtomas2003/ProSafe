using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProSafe
{
    public partial class prosafe : Form
    {
        public prosafe()
        {
            InitializeComponent();
        }
        Load load = new Load();
        private void prosafe_Load(object sender, EventArgs e)
        {
            this.unmount.Location = new Point((this.panel1.Width - this.unmount.Width) / 2, 3);
            char[] listAvailable = getAvailableDriveLetters();
            for(int i = 0; i <= listAvailable.Length-1; i++)
            {
                drives.Rows.Add(new Object[]{
                    listAvailable[i] + ":",
                    "",
                    "",
                    ""
                });
            }
            drives.ClearSelection();
        }
        public char[] getAvailableDriveLetters()
        {
            List<char> availableDriveLetters = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            DriveInfo[] drives = DriveInfo.GetDrives();

            for (int i = 0; i < drives.Length; i++)
            {
                availableDriveLetters.Remove(drives[i].Name[0]);
            }

            return availableDriveLetters.ToArray();
        }

        private void btnSelectBucket_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectBucket = new OpenFileDialog();
            selectBucket.Title = "Select Bucket";
            if (selectBucket.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = selectBucket.FileName;
                filePath.Text = selectedFileName;
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            DialogResult close = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(close == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void createVolume_Click(object sender, EventArgs e)
        {
            VolumeCreateWizard vcw = new VolumeCreateWizard();
            vcw.ShowDialog();
        }

        private void mount_Click(object sender, EventArgs e)
        {
            if (filePath.Text == "")
            {
                MessageBox.Show("Please select a container location.", "Volume Mount - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!File.Exists(filePath.Text))
            {
                MessageBox.Show("The file selected does not exists.", "Volume Mount - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (drives.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a letter to open the container.", "Volume Mount - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtPass.Text == "")
            {
                MessageBox.Show("Password can't be empty.", "Volume Mount - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            load.Show();
            //MessageBox.Show(drives.SelectedRows[0].Cells[0].Value.ToString());
            FileDecrypt(filePath.Text, Path.GetTempPath() + "storagedisk.vhd", txtPass.Text);
        }
        private void FileDecrypt(string inputFile, string outputFile, string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] salt = new byte[32];

            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
            fsCrypt.Read(salt, 0, salt.Length);

            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CFB;

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);

            FileStream fsOut = new FileStream(outputFile, FileMode.Create);

            int read;
            byte[] buffer = new byte[1048576];

            try
            {
                while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    Application.DoEvents();
                    fsOut.Write(buffer, 0, read);
                }
            }
            catch (CryptographicException ex_CryptographicException)
            {
                Console.WriteLine("CryptographicException error: " + ex_CryptographicException.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            try
            {
                cs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error by closing CryptoStream: " + ex.Message);
            }
            finally
            {
                fsOut.Close();
                fsCrypt.Close();
                load.Close();
            }
        }
    }
}
