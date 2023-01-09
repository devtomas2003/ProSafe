using CredentialManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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
                    "",
                    "",
                    ""
                });
            }
            if (File.Exists(Path.GetTempPath() + "drives.csv"))
            {
                string history = File.ReadAllText(Path.GetTempPath() + "drives.csv");
                string[] drivesLineHist = history.Split('\n');
                for (int l = 0; l <= drivesLineHist.Length - 1; l++)
                {
                    string[] itens = drivesLineHist[l].Split(',');
                    if (itens.Length > 1)
                    {
                        itens[0] = itens[0].ToUpper() + ":";
                        drives.Rows.Add(itens);
                    }
                }
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
            selectBucket.Title = "Select Container";
            if (selectBucket.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string selectedFileName = selectBucket.FileName;
                filePath.Text = selectedFileName;
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult close = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(close == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void createVolume_Click(object sender, EventArgs e)
        {
            drives.ClearSelection();
            VolumeCreateWizard vcw = new VolumeCreateWizard();
            vcw.ShowDialog();
        }

        private void mount_Click(object sender, EventArgs e)
        {
            if (filePath.Text == "")
            {
                MessageBox.Show("Please select a container location.", "Volume Mount - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPass.Text = "";
                return;
            }
            if (!File.Exists(filePath.Text))
            {
                MessageBox.Show("The file selected does not exists.", "Volume Mount - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPass.Text = "";
                return;
            }
            if (drives.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a letter to open the container.", "Volume Mount - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPass.Text = "";
                return;
            }
            if (drives.SelectedRows[0].Cells[1].Value.ToString() != "")
            {
                MessageBox.Show("There is a container mounted on this drive.", "Volume Mount - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPass.Text = "";
                return;
            }
            for (int g = 0; g <= drives.RowCount - 1; g++)
            {
                if (drives.Rows[g].Cells[1].Value.ToString() == filePath.Text)
                {
                    txtPass.Text = "";
                    MessageBox.Show("This container is already mounted.", "Volume Mount - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (txtPass.Text == "")
            {
                MessageBox.Show("Password can't be empty.", "Volume Mount - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            load.Show();
            string nowTag = RandomString(10);
            FileDecrypt(filePath.Text, Path.GetTempPath() + "disk" + nowTag + ".vhd", txtPass.Text);
            Process process = new Process();
            process.StartInfo.FileName = "diskpart.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            process.StandardInput.WriteLine("select vdisk file=" + Path.GetTempPath() + "disk" + nowTag + ".vhd");
            process.StandardInput.WriteLine("attach vdisk");
            process.StandardInput.WriteLine("list volume");
            process.StandardInput.WriteLine("exit");
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            if (output.Contains("corrupted"))
            {
                txtPass.Text = "";
                drives.ClearSelection();
                File.Delete(Path.GetTempPath() + "disk" + nowTag + ".vhd");
                MessageBox.Show("Password invalid or container is corrupted.", "Volume Mount - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                load.Hide();
            }
            else
            {
                string[] listContent = output.Split('\n');
                string[] lineList = listContent[listContent.Length - 5].Split(' ');
                string[] letterList = drives.SelectedRows[0].Cells[0].Value.ToString().Split(':');
                Process processMount = new Process();
                processMount.StartInfo.FileName = "diskpart.exe";
                processMount.StartInfo.UseShellExecute = false;
                processMount.StartInfo.CreateNoWindow = true;
                processMount.StartInfo.RedirectStandardInput = true;
                processMount.StartInfo.RedirectStandardOutput = true;
                processMount.Start();
                processMount.StandardInput.WriteLine("select volume " + lineList[3]);
                processMount.StandardInput.WriteLine("assign letter=" + letterList[0].ToLower());
                processMount.StandardInput.WriteLine("exit");
                processMount.WaitForExit();
                drives.SelectedRows[0].Cells[1].Value = filePath.Text;
                drives.SelectedRows[0].Cells[2].Value = lineList[lineList.Length - 16] + " " + lineList[lineList.Length-15];
                drives.SelectedRows[0].Cells[3].Value = "Normal";
                drives.SelectedRows[0].Cells[4].Value = lineList[3];
                drives.SelectedRows[0].Cells[5].Value = nowTag;
                SaveCredentials(drives.SelectedRows[0].Cells[0].Value.ToString(), txtPass.Text);
                if (File.Exists(Path.GetTempPath() + "drives.csv"))
                {
                    string history = File.ReadAllText(Path.GetTempPath() + "drives.csv");
                    File.Delete(Path.GetTempPath() + "drives.csv");
                    List<string> drivesLineHist = history.Split('\n').ToList();
                    drivesLineHist.Add(letterList[0].ToLower() + "," + filePath.Text + "," + lineList[lineList.Length - 16] + " " + lineList[lineList.Length - 15] + ",Normal," + lineList[3] + "," + nowTag);
                    TextWriter tw = new StreamWriter(Path.GetTempPath() + "drives.csv");
                    string[] newHistList = drivesLineHist.ToArray();
                    for (int l = 0; l <= newHistList.Length-1; l++)
                    {
                        tw.WriteLine(drivesLineHist[l]);
                    }
                    tw.Close();
                }
                else
                {
                    TextWriter tw = new StreamWriter(Path.GetTempPath() + "drives.csv");
                    tw.WriteLine(letterList[0].ToLower() + "," + filePath.Text + "," + lineList[lineList.Length - 16] + " " + lineList[lineList.Length - 15] + ",Normal," + lineList[3] + "," + nowTag);
                    tw.Close();
                }
                filePath.Text = "";
                txtPass.Text = "";
                drives.ClearSelection();
                load.Hide();
            }
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
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
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
                Console.WriteLine("CryptographicException Error: " + ex_CryptographicException.Message);
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
                Console.WriteLine("CryptoStream Error: " + ex.Message);
            }
            finally
            {
                fsOut.Close();
                fsCrypt.Close();
            }
        }

        private void unmount_Click(object sender, EventArgs e)
        {
            if (drives.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a letter to close the container.", "Volume Unmount - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(drives.SelectedRows[0].Cells[1].Value.ToString() == "")
            {
                MessageBox.Show("This drive is empty!", "Volume Unmount - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            System.Windows.Forms.DialogResult qrm = MessageBox.Show("Do you want to close this volume? Any work unsaved in this volume will be lost!", "Unmount Volume", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (qrm == System.Windows.Forms.DialogResult.Yes)
            {
                load.Show();
                string filePath = drives.SelectedRows[0].Cells[1].Value.ToString();
                Process process = new Process();
                process.StartInfo.FileName = "diskpart.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();
                char[] invalidChars = Path.GetInvalidFileNameChars();
                string correctedFormatTime = drives.SelectedRows[0].Cells[5].Value.ToString();
                foreach (char c in invalidChars)
                {
                    correctedFormatTime = correctedFormatTime.Replace(c.ToString(), "");
                }
                process.StandardInput.WriteLine("select vdisk file=" + Path.GetTempPath() + "disk" + correctedFormatTime + ".vhd");
                process.StandardInput.WriteLine("select volume " + drives.SelectedRows[0].Cells[4].Value.ToString());
                process.StandardInput.WriteLine("remove letter=" + drives.SelectedRows[0].Cells[0].Value.ToString().ToLower());
                process.StandardInput.WriteLine("detach vdisk");
                process.StandardInput.WriteLine("exit");
                process.WaitForExit();
                FileEncrypt(filePath, GetPass(drives.SelectedRows[0].Cells[0].Value.ToString()), drives.SelectedRows[0].Cells[5].Value.ToString());
                File.Delete(Path.GetTempPath() + "disk" + correctedFormatTime + ".vhd");
                drives.SelectedRows[0].Cells[1].Value = "";
                drives.SelectedRows[0].Cells[2].Value = "";
                drives.SelectedRows[0].Cells[3].Value = "";
                drives.SelectedRows[0].Cells[4].Value = "";
                drives.SelectedRows[0].Cells[5].Value = "";
                RemoveCredentials(drives.SelectedRows[0].Cells[0].Value.ToString());
                string history = File.ReadAllText(Path.GetTempPath() + "drives.csv");
                string[] drivesLineHist = history.Split('\n');
                List<string> listDrives = new List<string>(); ;
                for (int l = 0; l <= drivesLineHist.Length - 1; l++)
                {
                    string[] itens = drivesLineHist[l].Split(',');
                    if(itens.Length > 0)
                    {
                        if (itens[0].ToUpper() + ":" != drives.SelectedRows[0].Cells[0].Value.ToString())
                        {
                            listDrives.Add(drivesLineHist[l]);
                        }
                    }
                }
                string[] drivesList = listDrives.ToArray();
                File.Delete(Path.GetTempPath() + "drives.csv");
                TextWriter tw = new StreamWriter(Path.GetTempPath() + "drives.csv");
                for (int a = 0; a <= drivesList.Length - 1; a++){
                    tw.WriteLine(drivesList[a]);
                }
                tw.Close();
                drives.ClearSelection();
                load.Hide();
                MessageBox.Show("Volume unmounted with successfully!", "Volume Unmount", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
        private void FileEncrypt(string outFile, string password, string time)
        {
            byte[] salt = GenerateRandomSalt();
            FileStream fsCrypt = new FileStream(outFile, FileMode.Create);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Padding = PaddingMode.PKCS7;
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            AES.Mode = CipherMode.CFB;
            fsCrypt.Write(salt, 0, salt.Length);
            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);
            char[] invalidChars = Path.GetInvalidFileNameChars();
            string correctedFormatTime = time;
            foreach (char c in invalidChars)
            {
                correctedFormatTime = correctedFormatTime.Replace(c.ToString(), "");
            }
            FileStream fsIn = new FileStream(Path.GetTempPath() + "disk" + correctedFormatTime + ".vhd", FileMode.Open);
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

        private void createNewVolumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drives.ClearSelection();
            VolumeCreateWizard vcw = new VolumeCreateWizard();
            vcw.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About abt = new About();
            abt.ShowDialog();
        }

        private void unmountAll_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult qrm = MessageBox.Show("Do you want to close all volumes? Any work unsaved in this volumes will be lost!", "Unmount Containers", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(qrm == System.Windows.Forms.DialogResult.Yes)
            {
                for (int a = 0; a <= drives.RowCount - 1; a++)
                {
                    if (drives.Rows[a].Cells[1].Value.ToString() != "")
                    {
                        load.Show();
                        string filePath = drives.Rows[a].Cells[1].Value.ToString();
                        Process process = new Process();
                        process.StartInfo.FileName = "diskpart.exe";
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.CreateNoWindow = true;
                        process.StartInfo.RedirectStandardInput = true;
                        process.StartInfo.RedirectStandardOutput = true;
                        process.Start();
                        char[] invalidChars = Path.GetInvalidFileNameChars();
                        string correctedFormatTime = drives.Rows[a].Cells[5].Value.ToString();
                        foreach (char c in invalidChars)
                        {
                            correctedFormatTime = correctedFormatTime.Replace(c.ToString(), "");
                        }
                        process.StandardInput.WriteLine("select vdisk file=" + Path.GetTempPath() + "disk" + correctedFormatTime + ".vhd");
                        process.StandardInput.WriteLine("select volume " + drives.Rows[a].Cells[4].Value.ToString());
                        process.StandardInput.WriteLine("remove letter=" + drives.Rows[a].Cells[0].Value.ToString().ToLower());
                        process.StandardInput.WriteLine("detach vdisk");
                        process.StandardInput.WriteLine("exit");
                        process.WaitForExit();
                        FileEncrypt(filePath, GetPass(drives.Rows[a].Cells[0].Value.ToString()), drives.Rows[a].Cells[5].Value.ToString());
                        File.Delete(Path.GetTempPath() + "disk" + correctedFormatTime + ".vhd");
                        drives.Rows[a].Cells[1].Value = "";
                        drives.Rows[a].Cells[2].Value = "";
                        drives.Rows[a].Cells[3].Value = "";
                        drives.Rows[a].Cells[4].Value = "";
                        drives.Rows[a].Cells[5].Value = "";
                        RemoveCredentials(drives.Rows[a].Cells[0].Value.ToString());
                        string history = File.ReadAllText(Path.GetTempPath() + "drives.csv");
                        string[] drivesLineHist = history.Split('\n');
                        List<string> listDrives = new List<string>(); ;
                        for (int l = 0; l <= drivesLineHist.Length - 1; l++)
                        {
                            string[] itens = drivesLineHist[l].Split(',');
                            if (itens.Length > 0)
                            {
                                if (itens[0].ToUpper() + ":" != drives.Rows[a].Cells[0].Value.ToString())
                                {
                                    listDrives.Add(drivesLineHist[l]);
                                }
                            }
                        }
                        File.Delete(Path.GetTempPath() + "drives.csv");
                        TextWriter tw = new StreamWriter(Path.GetTempPath() + "drives.csv");
                        string[] drivesList = listDrives.ToArray();
                        for (int b = 0; b <= drivesList.Length - 1; b++)
                        {
                            tw.WriteLine(listDrives[b]);
                        }
                        tw.Close();
                        load.Hide();
                    }
                }
                drives.ClearSelection();
                MessageBox.Show("All volumes unmounted with success!", "Volumes Containers", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void SaveCredentials(string drive, string password)
        {
            new Credential
            {
                Target = drive,
                Username = drive,
                Password = password,
                PersistanceType = PersistanceType.LocalComputer
            }.Save();
        }
        private string GetPass(string drive)
        {
            using (var cred = new Credential())
            {
                cred.Target = drive;
                cred.Load();
                return cred.Password;
            }
        }
        private void RemoveCredentials(string target)
        {
            new Credential { Target = target }.Delete();
        }
        private string RandomString(int length)
        {
            Random rand = new Random();
            int randValue;
            string str = "";
            char letter;
            for (int i = 0; i < length; i++)
            {
                randValue = rand.Next(0, 26);
                letter = Convert.ToChar(randValue + 65);
                str = str + letter;
            }
            return str;
        }
    }
}