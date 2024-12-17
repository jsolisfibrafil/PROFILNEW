using System;
using System.Windows.Forms;

namespace Pesaje
{
    public partial class mainForm : Form
    {
        public string Area { get; set; }
        public string Maquina { get; set; }
        public string Usuario { get; set; }
        public string Sede { get; set; }

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

            //Form1 frmEmpl = new Form1();
            //frmEmpl.MdiParent = this;
            //frmEmpl.Show();

            //pasar valores


            Form1 frm_prodmas = new Form1();

            frm_prodmas.Sede = Sede;
            frm_prodmas.Area = Area;

            frm_prodmas.MdiParent = this;
            frm_prodmas.Show();

        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text =    $" Área : {Area}";
            toolStripStatusLabel2.Text =    $" Maquina : {Maquina}";
            toolStripStatusLabel3.Text =    $" Usuario : {Usuario}";
            toolStripStatusLabel4.Text =    $" Sede :    {Sede}";

        }
    }
}
