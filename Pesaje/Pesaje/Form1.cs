﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;


namespace Pesaje
{




    public partial class Form1 : Form
        {

        string  idarea = "TC";

        DataSet dts = new DataSet();
            public string scode, sname, sumed;
            SqlCommand cmd = new SqlCommand();
        SqlCommand cmd2 = new SqlCommand();



        public Form1()
        {
                InitializeComponent();

                //CargarDatosEnComboBox();
                //CargoDatos();    

        }

        private void CargoDatos()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conexiondb"].ConnectionString;
            idarea = tb_area.Text;

            //CHILCA 2
            tb_sede.Text = "02";


            string sentencia = "Select ItemNo, ItemName from OPROM0 " +
                        "inner join SBO_Fibrafil..OITM on Itemcode collate SQL_Latin1_General_CP850_CI_AS = ItemNo collate SQL_Latin1_General_CP850_CI_AS " +
                        "where U_FIB_AREA = '" + idarea + "' and U_FIB_SEDE = '" + tb_sede.Text + "' and U_fib_telar = '" + cbMaquinaria.SelectedValue + "' " +
                        "order by RECORDKEY";

                SqlDataAdapter dap1 = new SqlDataAdapter(sentencia, connectionString);

                dap1.SelectCommand.CommandType = CommandType.Text;

                if (dts.Tables.Contains("vLISTTMP"))
                {
                    dts.Tables["vLISTTMP"].Clear();
                }
                dap1.Fill(dts, "vLISTTMP");

                // Referenciamos el objeto DataTable
                DataTable dt = dts.Tables["vLISTTMP"];

               

                var withBlock = listBox1;
                withBlock.DataSource = dt;
                withBlock.DisplayMember = "ItemName";
                withBlock.ValueMember = "Itemno";

            Contadores();

        }
        private void Contadores()
        {
            int in_pesos = 0;
            int in_pesosS = 0;


            //Dim in_pesos As Integer = 0
            //Dim in_pesosS As Integer = 0

            
            for (int x = 0; x < listBox2.Items.Count; x++)
            {
                if (Convert.ToDecimal(listBox2.GetItemText(listBox2.Items[x])) > 0)
                {
                    in_pesos++;
                }
            }

            for (int X = 0; X < listBox3.Items.Count; X++)
            {
                if (Convert.ToDouble(listBox3.GetItemText(listBox3.Items[X])) > 0)
                {
                    in_pesosS += 1;
                }
            }


            double db_sumpeso = 0;
            double db_sumpesoS = 0;

            // Suma de todos los elementos en ListBox2
            for (int X = 0; X < listBox2.Items.Count; X++)
            {
                db_sumpeso += Convert.ToDouble(listBox2.GetItemText(listBox2.Items[X]));
            }

            // Suma de todos los elementos en ListBox3
            for (int X = 0; X < listBox3.Items.Count; X++)
            {
                db_sumpesoS += Convert.ToDouble(listBox3.GetItemText(listBox3.Items[X]));
            }




            lbl_count.Text = listBox1.Items.Count.ToString();
            lbl_countbul.Text = in_pesos.ToString();
            lbl_pesotot.Text = db_sumpeso.ToString();

            lbl_countbul_s.Text = in_pesosS.ToString();
            lbl_pesotot_s.Text = db_sumpesoS.ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Verifica si el puerto serial está abierto y lo cierra si es necesario

            if (sppuerto.IsOpen)
            {
                sppuerto.Close();
            }

            // Configura el nombre del puerto
            sppuerto.PortName = "COM1";
            try
            {
                // Intenta abrir el puerto serial
                sppuerto.Open();
                MessageBox.Show("Conexión con balanza satisfactoria", "FIBRAFIL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Manejo de error en caso de que el puerto no esté disponible
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }



            CargarDatosEnComboBox();
            CargoDatos();

        }

        private void iniciar_pesaje_click(object sender, EventArgs e)
        {




        }

            private void Form2_OnValueSubmitted(object sender, Form2Data data)
            {
           
                tb_codigoarticulo.Text = data.Valor1;
                tb_descArticulo.Text = data.Valor2;

            }

            private void CargarDatosEnComboBox()
            {
                // 1. Obtener la cadena de conexión desde App.config
                string connectionString = ConfigurationManager.ConnectionStrings["conexiondb"].ConnectionString;

            ////// 2. Crear la consulta SQL
            ////string query = "Select Code, Descripcion As 'Maquina' from  OFIBMAC where STDMAC='A' and u_fib_sede = '02'"; // Ajusta 'NombreTabla', 'Id' y 'Nombre' según tu base de datos

            ////// 3. Conectarse a la base de datos y obtener los datos
            ////using (SqlConnection connection = new SqlConnection(connectionString))
            ////{
            ////    try
            ////    {
            ////        connection.Open();
            ////        using (SqlCommand command = new SqlCommand(query, connection))
            ////        {
            ////            using (SqlDataReader reader = command.ExecuteReader())
            ////            {
            ////                // 4. Cargar los datos en el ComboBox
            ////                while (reader.Read())
            ////                {
            ////                    // Añade cada ítem al ComboBox. Asocia el valor (Id) y el texto a mostrar (Nombre)
            ////                    cbMaquinaria.Items.Add(new ComboBoxItem
            ////                    {
            ////                        Text = reader["Maquina"].ToString(),
            ////                        Value = reader["Code"]
            ////                    });
            ////                }
            ////            }
            ////        }
            ////    }
            ////    catch (Exception ex)
            ////    {
            ////        MessageBox.Show("Error al cargar datos: " + ex.Message);
            ////    }
            ////}

            DataSet ds = new DataSet();

            string sentencia1 = string.Empty;
            sentencia1 = "SELECT Code, Descripcion AS Maquina FROM OFIBMAC WHERE STDMAC = 'A' AND u_fib_sede = '" + tb_sede.Text + "'";
            // COMBO MAQUINA
            SqlDataAdapter dapMac = new SqlDataAdapter(sentencia1, connectionString);
            dapMac.Fill(ds, "tMac");
            cbMaquinaria.DataSource = ds.Tables["tMac"];
            cbMaquinaria.DisplayMember = "Maquina";
            cbMaquinaria.ValueMember = "Code";


        }

        private void event_clickAnadirItem(object sender, EventArgs e)
            {



            }

        private void bt_anadir_Click(object sender, EventArgs e)
        {
            string cnc3 = ConfigurationManager.ConnectionStrings["conexiondb"].ConnectionString;
            SqlConnection sqt3 = new SqlConnection(cnc3);

            if (listBox1.Items.Count > 19)
            {
                MessageBox.Show("Límite de items (20) excedido", "PROFIL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                if (dts.Tables.Contains("vLISTTMP"))
                {
                    DataRow[] foundRow;
                    foundRow = dts.Tables["vLISTTMP"].Select("ItemNo = '" + tb_codigoarticulo.Text + "'");
                    
                    //valida que no tenga escogido el mismo equipo en el ListBox
                    if (foundRow.Length > 0)
                    {
                        MessageBox.Show("Item ya ingresado", "PROFIL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        DatosInsUpd("U_SP_FIB_INS_OPROM0", 0, false);
                        if (sqt3.State == ConnectionState.Closed) sqt3.Open();
                        try
                        {
                            cmd.Connection = sqt3;
                            cmd.ExecuteNonQuery();

                            if (cmd.Parameters["@msg"].Value.ToString() != "")
                            {
                                MessageBox.Show(cmd.Parameters["@msg"].Value.ToString(), "PROFIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "FIBRAFIL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        CargoDatos();
                    }
                }

                tb_codigoarticulo.Text = string.Empty;
                tb_descArticulo.Text = string.Empty;
                tb_codigoarticulo.Focus();
            }

        }

        public void DatosInsUpd(string NameProced, double db_peso, bool is_Scrap)
        {
            if (NameProced == "U_SP_FIB_INS_OPROM0")
            {
                string cnc3 = ConfigurationManager.ConnectionStrings["conexiondb"].ConnectionString;
                SqlConnection sqt3 = new SqlConnection(cnc3);

                try
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = sqt3;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = NameProced;
                    cmd.Parameters.Add(new SqlParameter("@ItemNo", SqlDbType.Text)).Value = tb_codigoarticulo.Text ; // Código de item
                    cmd.Parameters.Add(new SqlParameter("@ProducQuantity", SqlDbType.Decimal)).Value = 0; // Cant producida, se manda 0
                    cmd.Parameters.Add(new SqlParameter("@ProducWeight", SqlDbType.Decimal)).Value = 0; // Peso producido, se manda 0
                    cmd.Parameters.Add(new SqlParameter("@COMMENT", SqlDbType.Text)).Value = string.Empty; // Comentario no implementado
                    cmd.Parameters.Add(new SqlParameter("@U_FIB_OPERARIO", SqlDbType.Text)).Value = tb_codeOperario.Text;  // ComboBox5.SelectedValue() //codigo de operario    // hardcode                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     ", SqlDbType.Text)).Value = cmb_ope.SelectedValue;
                    cmd.Parameters.Add(new SqlParameter("@U_FIB_AYUDANTE", SqlDbType.Text)).Value = "647";
                    cmd.Parameters.Add(new SqlParameter("@U_FIB_TELAR", SqlDbType.Text)).Value = cbMaquinaria.SelectedValue;
                    cmd.Parameters.Add(new SqlParameter("@U_FIB_AREA", SqlDbType.Text)).Value = tb_area.Text;
                    cmd.Parameters.Add(new SqlParameter("@U_FIB_SEDE", SqlDbType.Text)).Value = tb_sede.Text;
                    cmd.Parameters.Add(new SqlParameter("@HOST", SqlDbType.Text)).Value = Environment.MachineName;
                    cmd.Parameters.Add(new SqlParameter("@Createfor", SqlDbType.Text)).Value = "152";
                    cmd.Parameters.Add(new SqlParameter("@MSG", SqlDbType.VarChar, 250)).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@FK", SqlDbType.BigInt)).Direction = ParameterDirection.Output;
                
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (NameProced == "U_SP_FIB_DEL_OPROM")
            {
                string cnc5 = ConfigurationManager.ConnectionStrings["conexiondb"].ConnectionString;
                SqlConnection sqt5 = new SqlConnection(cnc5);

                cmd.Parameters.Clear();
                cmd.Connection = sqt5;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = NameProced;

                decimal d_peso=0;
                long i_nline;

                try
                {
                    //// valor enviado es false, asi que va al else
                    if (is_Scrap)
                    {
                        

                        //i_nline = string.IsNullOrEmpty(lbl_linS.Text) ? 0 : Convert.ToInt64(lbl_linS.Text);
                        //d_peso = ListBox3.SelectedValue == null ? 0 : Convert.ToDecimal(ListBox3.SelectedValue);
                    }
                    else
                    {
                        //i_nline = string.IsNullOrEmpty(lbl_idlin.Text) ? 0 : Convert.ToInt64(lbl_idlin.Text);
                        d_peso = listBox2.SelectedValue == null ? 0 : Convert.ToDecimal(listBox2.SelectedValue);
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de excepción opcional
                }

                cmd.Parameters.Add(new SqlParameter("@ItemNo", SqlDbType.Text)).Value = listBox1.SelectedValue.ToString();

                if (db_peso == 1)
                {
                    cmd.Parameters.Add(new SqlParameter("@ProducWeight", SqlDbType.Decimal)).Value = 0;
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@ProducWeight", SqlDbType.Decimal)).Value = d_peso;
                }


                //cmd.Parameters.Add(new SqlParameter("@IndexPeso", SqlDbType.Int)).Value = i_nline;
                cmd.Parameters.Add(new SqlParameter("@IndexPeso", SqlDbType.Int)).Value = 0;
                cmd.Parameters.Add(new SqlParameter("@U_FIB_SEDE", SqlDbType.Text)).Value = tb_sede.Text;
                cmd.Parameters.Add(new SqlParameter("@U_FIB_TELAR", SqlDbType.VarChar)).Value = cbMaquinaria.SelectedValue;

                var outputParam = new SqlParameter("@MSG", SqlDbType.VarChar, 250) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(outputParam);

                cmd.Parameters.Add(new SqlParameter("@opt", SqlDbType.Int)).Value = db_peso;
            }

            if (NameProced == "U_SP_FIB_INS_OPROM1")
            {
                string cnc8 = ConfigurationManager.ConnectionStrings["conexiondb"].ConnectionString;
                SqlConnection sqt8= new SqlConnection(cnc8);

                try
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = sqt8;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = NameProced;

                    // Configuración de los parámetros
                    cmd.Parameters.Add(new SqlParameter("@ItemNo", SqlDbType.Text)).Value = listBox1.SelectedValue.ToString(); // Código de item
                    cmd.Parameters.Add(new SqlParameter("@ProducWeight", SqlDbType.Decimal)).Value = db_peso; // Peso producido, se manda 0 para registrar items
                    cmd.Parameters.Add(new SqlParameter("@U_FIB_SEDE", SqlDbType.VarChar)).Value = tb_sede.Text;
                    cmd.Parameters.Add(new SqlParameter("@U_FIB_TELAR", SqlDbType.VarChar)).Value = cbMaquinaria.SelectedValue;// cmb_maq.SelectedValue;
                    cmd.Parameters.Add(new SqlParameter("@MSG", SqlDbType.VarChar, 250)).Direction = ParameterDirection.Output;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_item.Text = listBox1.Text;
                CargaPesos();
            }
            catch (Exception ex)
            {

            }


        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Delete)
            {
                DelItem();


            }

        }

        private void DelItem()
        {
            string cnc4 = ConfigurationManager.ConnectionStrings["conexiondb"].ConnectionString;
            SqlConnection sqt4 = new SqlConnection(cnc4);


            // Verifica si ListBox2 tiene elementos
            if (listBox2.Items.Count > 0)
            {
                MessageBox.Show("Para eliminar un ítem, primero elimine todos sus pesos asociados.",
                                "PROFIL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                DatosInsUpd("U_SP_FIB_DEL_OPROM", 1, false); // Llama a la función para inicializar cmd

                if (sqt4.State == ConnectionState.Closed)
                    sqt4.Open();

                try
                {
                    cmd.Connection = sqt4;
                    // Ejecuta el comando SQL
                    cmd.ExecuteNonQuery();

                    // Verifica el mensaje de resultado
                    if (cmd.Parameters["@msg"].Value.ToString() != "")
                    {
                        MessageBox.Show(cmd.Parameters["@msg"].Value.ToString(), "PROFIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "FIBRAFIL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                // Llama a la función para cargar datos
                CargoDatos();

                // Habilita el campo de código si el conteo es igual o superior a 20
                if (20 <= Convert.ToInt32(lbl_count.Text))
                {
                    tb_codeOperario.Enabled = true;
                    //txt_code.Enabled = true;
                }
            }
        }


        private void CargaPesos()
        {


            string cnc6 = ConfigurationManager.ConnectionStrings["conexiondb"].ConnectionString;
            SqlConnection sqt6 = new SqlConnection(cnc6);


            try
            {

                string query4 = string.Empty;

                query4 = "Select Isnull(Convert(decimal(14,2), pesobob,2),0.0) As 'PesoBob', idlin as 'Lin' " +
                    "from OPROM1 T1 inner join OPROM0 T0 on T1.recordkey = T0.recordkey " +
                    "where Isnull(isScrap,'')<>'Y' and T0.ItemNo = '" + listBox1.SelectedValue.ToString() +
                    "' and U_FIB_SEDE = '" + tb_sede.Text + "' and U_fib_telar = '" + cbMaquinaria.SelectedValue + "' order by idlin asc";

                // Configuración del primer SqlDataAdapter para ListBox2
                SqlDataAdapter dap1 = new SqlDataAdapter(query4, sqt6);
                dap1.SelectCommand.CommandType = CommandType.Text;

                if (dts.Tables.Contains("vLISPESOS"))
                {
                    dts.Tables["vLISPESOS"].Clear();
                }

                dap1.Fill(dts, "vLISPESOS");

                // Asignamos el DataTable a ListBox2
                DataTable dt = dts.Tables["vLISPESOS"];
                listBox2.DataSource = dt;
                listBox2.DisplayMember = "PesoBob";
                listBox2.ValueMember = "PesoBob";

                string query5 = string.Empty;
                // Configuración del segundo SqlDataAdapter para ListBox3

                query5 = "Select Isnull(Convert(decimal(14,2), pesobob,2),0.0) As 'PesoBob', idlin as 'Lin' " +
                    "from OPROM1 T1 inner join OPROM0 T0 on T1.recordkey = T0.recordkey " +
                    "where Isnull(isScrap,'')='Y' and T0.ItemNo = '" + listBox1.SelectedValue.ToString() +
                    "' and U_FIB_SEDE = '" + tb_sede.Text + "' and U_fib_telar = '" + cbMaquinaria.SelectedValue + "' order by idlin asc";


                SqlDataAdapter dap2 = new SqlDataAdapter(query5, sqt6);
                dap2.SelectCommand.CommandType = CommandType.Text;

                if (dts.Tables.Contains("vLISPESOSS"))
                {
                    dts.Tables["vLISPESOSS"].Clear();
                }

                dap2.Fill(dts, "vLISPESOSS");

                // Asignamos el DataTable a ListBox3
                DataTable dt2 = dts.Tables["vLISPESOSS"];
                listBox3.DataSource = dt2;
                listBox3.DisplayMember = "PesoBob";
                listBox3.ValueMember = "PesoBob";

                // Llamada al método Contadores
                Contadores();

                lbl_idlin.DataBindings.Clear();
                lbl_linS.DataBindings.Clear();

                // Configuración de DataBindings para los labels
                lbl_idlin.DataBindings.Add("Text", dts.Tables["vLISPESOS"], "Lin");
                lbl_linS.DataBindings.Add("Text", dts.Tables["vLISPESOSS"], "Lin");



            }
            catch (Exception ex)
            {
                // Manejo opcional de excepciones
                // MessageBox.Show(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


        }

        private void imprimirticket_Click(object sender, EventArgs e)
        {
            

            string DataIn = string.Empty;
            //datos recibidos por la balanza y listos para imprimir.
            DataIn = "770.02";

            try
            {
                if (tb_sede.Text == "02")
                {
                    SetText(DataIn);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SetText(string text)
        {
            string cnc7 = ConfigurationManager.ConnectionStrings["conexiondb"].ConnectionString;
            SqlConnection sqt7 = new SqlConnection(cnc7);

            if (listBox1.SelectedIndex >= 0)
            {
                try
                {

                    if (tb_sede.Text == "01")
                    {
                        text = text.Replace("kg", "");
                    }
                    else
                    {
                        if (text.Length > 0) //&& te|xt.Contains("kg") && text.Contains("Net"))
                        {
                            text = text.Replace("Net", "");
                            text = text.Replace("kg", "");

                        }

                    }

                    DatosInsUpd("U_SP_FIB_INS_OPROM1", Convert.ToDouble(text), false);

                    cmd.Parameters.Clear();
                    cmd.Connection = sqt7;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "U_SP_FIB_INS_OPROM1";


                    cmd.Parameters.Add(new SqlParameter("@ItemNo", SqlDbType.Text)).Value = listBox1.SelectedValue.ToString(); // Código de item
                    // por el momento no va scrap
                    // false = scrap
                    // 
                    //if (rb_pofic.Checked == true)
                    if (true)
                    {
                        cmd.Parameters.Add(new SqlParameter("@ProducWeight", SqlDbType.Decimal)).Value = Convert.ToDecimal(text.Trim());
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@ProducWeight", SqlDbType.Decimal)).Value = Convert.ToDecimal(text.Trim()) * -1;
                    }

                    cmd.Parameters.Add(new SqlParameter("@U_FIB_SEDE", SqlDbType.Text)).Value = tb_sede.Text;
                    cmd.Parameters.Add(new SqlParameter("@U_FIB_TELAR", SqlDbType.VarChar)).Value = cbMaquinaria.SelectedValue;
                    cmd.Parameters.Add(new SqlParameter("@MSG", SqlDbType.VarChar, 250)).Direction = ParameterDirection.Output;

                    

                    // Parámetros para el comando
                    // Ejecutar comando
                    if (sqt7.State == ConnectionState.Closed)
                        sqt7.Open();
                    cmd.ExecuteNonQuery();
                    CargaPesos();

                    string retorno2 = cmd.Parameters["@MSG"].Value.ToString();
                    //retorno2 = "012410156806300";

                    //if (rb_pofic.Checked)
                    if (true)
                    {
                        //Imprime_Codebar(cmd.Parameters["@MSG"].Value.ToString(), Convert.ToDecimal(text.Trim()));

                        string mensajeLinea1 = "NPD : PM                                                                          FP : " + DateTime.Now.ToString();
                        string mensajeLinea2 = retorno2;
                        string mensajeLinea3 = retorno2;
                        string mensajeLinea4 = text.ToString() + " KG";
                        string mensajeLinea5 = "ID ITEM     : " + listBox1.SelectedValue.ToString();
                        string mensajeLinea6 = "DSC ITEM  :  " + lbl_item.Text;

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
                catch (Exception)
                {

                    //throw;
                }

            }
            else
            {
                MessageBox.Show("Antes de pesar debe seleccionar un ítem.", "PROFIL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }


        public class ComboBoxItem
            {
                public string Text { get; set; }
                public object Value { get; set; }

                public override string ToString()
                {
                    return Text; // Lo que se mostrará en el ComboBox
                }
            }

            private void event_buscarArticulo(object sender, EventArgs e)
            {

                //frmArticuloBusqueda vista3 = new frmArticuloBusqueda();
                //vista3.ShowDialog();


                frmArticuloBusqueda form2 = new frmArticuloBusqueda();

                // Nos suscribimos al evento OnValueSubmitted para recibir el valor
                form2.OnValueSubmitted += Form2_OnValueSubmitted;

                // Mostramos Form2
                form2.ShowDialog(); ;

            }

        }
}
