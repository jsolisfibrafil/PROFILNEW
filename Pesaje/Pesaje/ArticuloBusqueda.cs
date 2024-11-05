using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pesaje
{
    public partial class frmArticuloBusqueda : Form
    {

        public event EventHandler<Form2Data> OnValueSubmitted;

        private DataView dataView;
        string connectionString = Conexion1.connectionStringnew;
        public frmArticuloBusqueda()
        {
            InitializeComponent();
        }

        private void frmArticuloBusqueda_Load(object sender, EventArgs e)
        {
            this.obtenerListaArticulo();
        }

        
        private void obtenerListaArticulo() {

            

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                try
                {

                    // Abrir la conexión
                    conn.Open();

                    // Configurar el comando para ejecutar el procedimiento almacenado
                    using (SqlCommand cmd = new SqlCommand("U_SP_QUERY", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Definir y añadir el parámetro de entrada
                        cmd.Parameters.Add(new SqlParameter("@vTAB", SqlDbType.VarChar)).Value = '2';

                        // Crear un adaptador para llenar el DataTable
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        

                        // Llenar el DataTable con los resultados
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Asignar el DataTable a un DataView
                        dataView = new DataView(dt);


                        // Asignar el DataTable como la fuente de datos del DataGridView
                        dataGridView1.DataSource = dataView;
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void textchanged_articuloBusqueda(object sender, EventArgs e)
        {

            //BuscarDatos(tb_codigo.Text);

            dataView.RowFilter = $"CODE LIKE '%{tb_codigo.Text}%'";

        }

       

        private void tc_descripcion_articuloBusqueda(object sender, EventArgs e)
        {
            dataView.RowFilter = $"NAME LIKE '%{tb_Descripcion.Text}%'";
        }

        private void keyPress_dgv1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                string code, name, um;
                code = Convert.ToString(this.dataGridView1.CurrentRow.Cells["CODE"].Value);
                name = Convert.ToString(this.dataGridView1.CurrentRow.Cells["NAME"].Value);
                um = Convert.ToString(this.dataGridView1.CurrentRow.Cells["UM"].Value);


                // Creamos una instancia de Form2Data con los valores de txtInput1 y txtInput2
                var data = new Form2Data(code, name);

                // Invocamos el evento, enviando la instancia de Form2Data
                OnValueSubmitted?.Invoke(this, data);

                this.Close();


                //Aceptar();
            }
        }

        private void Aceptar()
        {

            //Form1.sco    

            //frm_prodMasiva.scode = Dvlista.Item(X)("code").ToString
            //frm_prodMasiva.sname = Dvlista.Item(X)("name").ToString
            //frm_prodMasiva.sumed = Dvlista.Item(X)("um").ToString

            ////Form1 form = Form1.GetInstancia();
            ////string code, name, um;
            ////code = Convert.ToString(this.dataGridView1.CurrentRow.Cells["CODE"].Value);
            ////name = Convert.ToString(this.dataGridView1.CurrentRow.Cells["NAME"].Value);
            ////um = Convert.ToString(this.dataGridView1.CurrentRow.Cells["UM"].Value);

            ////form.setArticulo(code, name, um);

            //    Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            //form.setCliente(par1, par2);
            //this.Close();

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            ////Form1 formp = Form1.GetInstancia();
            ////string code2, name2, um2;
            ////code2 = Convert.ToString(this.dataGridView1.CurrentRow.Cells["CODE"].Value);
            ////name2 = Convert.ToString(this.dataGridView1.CurrentRow.Cells["NAME"].Value);
            ////um2 = Convert.ToString(this.dataGridView1.CurrentRow.Cells["UM"].Value);

            ////formp.setArticulo(code2, name2, um2);


            ////this.Close();

        }
    }
}
