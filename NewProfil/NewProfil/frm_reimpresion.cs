using Pesaje;
using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace NewProfil
{
    public partial class frm_reimpresion : Form
    {
        DataSet dts = new DataSet();

        public frm_reimpresion()
        {
            InitializeComponent();
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Obtener_Data();
                LlenarData();
                txt_codebar.Text = string.Empty;
                txt_codebar.Focus();
            }

        }

        private void Obtener_Data()
        {
            SqlConnection OCN = Conexion1.ObtenerConexion();

            // Verificar si existe la tabla "vOP" y limpiarla si es necesario
            if (dts.Tables["vOP"] != null)
            {
                dts.Tables["vOP"].Clear();
            }

            // Crear el SqlDataAdapter con el procedimiento almacenado
            using (SqlDataAdapter dap4 = new SqlDataAdapter("U_SP_REIMPRIMECODEBAR",  OCN))
            {
                dap4.SelectCommand.CommandType = CommandType.StoredProcedure;
                dap4.SelectCommand.Parameters.Add(new SqlParameter("@CODEBAR", SqlDbType.VarChar)).Value = txt_codebar.Text;

                // Llenar el DataSet
                dap4.Fill(dts, "vOP");
            }
        }

        public void LlenarData()
        {
            try
            {
                // Limpiar las uniones de datos para los controles de tipo Label dentro del GroupBox
                foreach (Control controlLabel in this.groupBox1.Controls)
                {
                    if (controlLabel is Label)
                    {
                        controlLabel.DataBindings.Clear();
                    }
                }

                //string a = dts.Tables["vop"];

                // Vincular los controles Label a los datos de la tabla "vop"
                lbl_npd.DataBindings.Add("Text", dts.Tables["vop"], "NPD");
                lbl_fp.DataBindings.Add("Text", dts.Tables["vop"], "FCH");
                lbl_codebar.DataBindings.Add("Text", dts.Tables["vop"], "IDBAR");
                lbl_iditm.DataBindings.Add("Text", dts.Tables["vop"], "IDITM");
                lbl_dscitm.DataBindings.Add("Text", dts.Tables["vop"], "DSCITM");
                lbl_peso.DataBindings.Add("Text", dts.Tables["vop"], "PESO");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Print_ReEtiquetado(object sender, EventArgs e)
        {
            // INI
            //string v12 = BalanzasConfigManager.AppConfigModelo;

            //FIN
            if (BalanzasConfigManager.AppConfigHabilitado == "Y" &&  (BalanzasConfigManager.AppConfigModelo == "METTLER_TOLEDO_BBA231" || BalanzasConfigManager.AppConfigModelo == "METTLER_TOLEDO_BBA221-3BB60C"))
            //if (appConfigHabilitado == "Y" && appConfigUbicacion == "LURIN" && (appConfigModelo == "METTLER_TOLEDO_BBA231" || appConfigModelo == "METTLER_TOLEDO_BBA221-3BB60C"))
            {
                
                Log.Information(" Print_ReEtiquetado ");

                ////    // RUTA DEL ARCHIVO DE ETIQUETA
                string ruta = string.Empty;

                if (rdb_no.Checked)
                {
                    ruta = System.Windows.Forms.Application.StartupPath + "\\" + "eti_SPeso.prn";
                }
                else
                {
                    ruta = System.Windows.Forms.Application.StartupPath + "\\" + "eti_CPeso.prn";
                }

                // LECTURA DEL ARCHIVO PARA GUARDARLO EN UN STRING
                string etiqueta;
                using (StreamReader arc1 = new StreamReader(ruta))
                {
                    etiqueta = arc1.ReadToEnd();
                }

                // REEMPLAZA LOS VALORES DE LA ETIQUETA
                etiqueta = etiqueta.Replace("[NPD]", lbl_npd.Text);
                etiqueta = etiqueta.Replace("[FP]", lbl_fp.Text);
                etiqueta = etiqueta.Replace("[IDITEM]", lbl_iditm.Text);
                etiqueta = etiqueta.Replace("[DESPRO]", lbl_dscitm.Text);
                etiqueta = etiqueta.Replace("[codbar]", lbl_codebar.Text);

                if (rdb_si.Checked)
                {
                    etiqueta = etiqueta.Replace("[PESO]", lbl_peso.Text);
                }

                etiqueta = etiqueta.Replace("\\[\"\"]", "''");

                // IMPRIME USANDO DLL DE IMPRESIÓN OPCIÓN SendStringToPrinter()
                if (clsprinter.Class1.SendStringToPrinter("PROFIL", etiqueta))
                {

                    MessageBox.Show("Etiqueta Impresa", "FIBRAFIL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                //ImprimeCodebar1(retorno2, Convert.ToDecimal(text), listBox1.SelectedValue.ToString(), lbl_item.Text, lb_cantCopia.Text);//listBox1.SelectedValue.ToString() , lbl_item.Text) ;

            }
            else
            {


                

                // mauqina de CHILCA - ENTRADA
                string mensajeLinea1 = "NPD : PM                                                                          FP : " + lbl_fp.Text;
                string mensajeLinea2 = lbl_codebar.Text;
                string mensajeLinea3 = lbl_codebar.Text;

                string mensajeLinea4 = string.Empty;
                    
                    //text.ToString() + " KG";

                if (rdb_si.Checked)
                {
                    mensajeLinea4 =  lbl_peso.Text + " KG";
                }


                string mensajeLinea5 = "ID ITEM   : " + lbl_iditm.Text;
                string mensajeLinea6 = "DSC ITEM  : " + lbl_dscitm.Text;

                // Crear la instancia de TicketPrinter y pasar las dos líneas de texto
                TicketPrinter ticketPrinter = new TicketPrinter(mensajeLinea1,
                                                                mensajeLinea2,
                                                                mensajeLinea3,
                                                                mensajeLinea4,
                                                                mensajeLinea5,
                                                                mensajeLinea6
                                                                );

                // Imprimir el ticket directamente sin mostrar la ventana
                ticketPrinter.PrintTicket();


            }


        }

        //ini




        //fin





    }



}
