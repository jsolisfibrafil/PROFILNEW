﻿using NewProfil;
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

        public string BaseDatos { get; set; }
        public string Version { get; set; }


        public string Balanza { get; set; }



        public mainForm()
        {
            InitializeComponent();
        }

        private void InformeIntegradoToolStripMenuItem_Click(object sender, EventArgs e)
        {


            frmInformes finfo = new frmInformes();

            finfo.Sede = Sede;

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
            toolStripStatusLabel4.Text =    $" Sede : {Sede.Trim()}";

            toolStripStatusLabel5.Text = $" BaseDatos : {BaseDatos.Trim()}";

            toolStripStatusLabel6.Text = $" Versión : { Version.Trim()}";

            toolStripStatusLabel7.Text = $" Balanza : {Balanza.Trim()}";

        }

        private void ExportacionOrdenProduccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_OP_to_SAP f_toSAP1 = new frm_OP_to_SAP();

            // Mostrar el formulario
            f_toSAP1.Show();

            // Configurar el formulario como hijo MDI
            f_toSAP1.MdiParent = this;
        }

        private void MDIPROFIL_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MDIPROFIL_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult i_cierre = MessageBox.Show(
              "Está procediendo a cerrar la aplicación. ¿Está seguro de esta acción?",
              "FIBRAFIL",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Exclamation,
              MessageBoxDefaultButton.Button2);

            e.Cancel = CierraForm(i_cierre);

        }

        private bool CierraForm(DialogResult resultado)
        {
            return resultado == DialogResult.No; // Devuelve true si se cancela el cierre
        }

        private void oPERACIONESToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ReEtiquetarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reEtiquetarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void RtiquetarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frm_reimpresion f_rim = new frm_reimpresion();

            // Mostrar el formulario
            f_rim.Show();

            // Configurar el formulario como hijo MDI
            f_rim.MdiParent = this;

        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("calc.exe");


        }
    }
}
