using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private void mount_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Teste", "Teste Title", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
