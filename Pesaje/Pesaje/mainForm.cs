using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pesaje
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void InformeIntegradoToolStripMenuItem_Click(object sender, EventArgs e)
        {


            frmInformes finfo = new frmInformes();
            finfo.MdiParent = this;
            finfo.Show();
            


        }

        private void dATOSPRODUCCIONToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void producciónMasivaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form1 frmEmpl = new Form1();
            frmEmpl.MdiParent = this;
            frmEmpl.Show();

        }
    }
}
