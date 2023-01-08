using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProSafe
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void linkGit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process openGit = new Process();
            openGit.StartInfo.UseShellExecute = true;
            openGit.StartInfo.FileName = "https://github.com/devtomas2003/ProSafe";
            openGit.Start();
        }
    }
}
