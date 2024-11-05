using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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

                CargarDatosEnComboBox();
                CargoDatos();    

        }

        private void CargoDatos()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conexiondb"].ConnectionString;
             idarea = "TC";

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
            //for (int X = 0; X < listBox2.Items.Count; X++)
            //{
            //    if (Convert.ToDouble(ListBox2.Items[X].ToString()) > 0)
            //    {
            //        in_pesos += 1;
            //    }
            //} 

            lbl_count.Text = listBox1.Items.Count.ToString();
            //lbl_countbul.Text = in_pesos.ToString();
            //lbl_pesotot.Text = db_sumpeso.ToString();

            //lbl_countbul_s.Text = in_pesosS.ToString();
            //lbl_pesotot_s.Text = db_sumpesoS.ToString();

        }

            private void Form1_Load(object sender, EventArgs e)
            {

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

                // 2. Crear la consulta SQL
                string query = "Select Code, Descripcion As 'Maquina' from  OFIBMAC where STDMAC='A' and u_fib_sede = '02'"; // Ajusta 'NombreTabla', 'Id' y 'Nombre' según tu base de datos

                // 3. Conectarse a la base de datos y obtener los datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                // 4. Cargar los datos en el ComboBox
                                while (reader.Read())
                                {
                                    // Añade cada ítem al ComboBox. Asocia el valor (Id) y el texto a mostrar (Nombre)
                                    cbMaquinaria.Items.Add(new ComboBoxItem
                                    {
                                        Text = reader["Maquina"].ToString(),
                                        Value = reader["Code"]
                                    });
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar datos: " + ex.Message);
                    }
                }
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
            if (NameProced == NameProced)
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
                    cmd.Parameters.Add(new SqlParameter("@U_FIB_OPERARIO", SqlDbType.Text)).Value = "152";  // ComboBox5.SelectedValue() //codigo de operario                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         ", SqlDbType.Text)).Value = cmb_ope.SelectedValue;
                    cmd.Parameters.Add(new SqlParameter("@U_FIB_AYUDANTE", SqlDbType.Text)).Value = "647";
                    cmd.Parameters.Add(new SqlParameter("@U_FIB_TELAR", SqlDbType.Text)).Value = "47";
                    cmd.Parameters.Add(new SqlParameter("@U_FIB_AREA", SqlDbType.Text)).Value = "TC";
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
