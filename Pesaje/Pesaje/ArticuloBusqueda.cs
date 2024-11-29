using Serilog;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Pesaje
{
    public partial class frmArticuloBusqueda : Form
    {

        public event EventHandler<Form2Data> OnValueSubmitted;

        private DataView dataView;
        string connectionString = Conexion1.connectionStringnew;
        string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
        public frmArticuloBusqueda()
        {

            Directory.CreateDirectory(logDirectory);

            Log.Logger = new LoggerConfiguration()
            .WriteTo.File(Path.Combine(logDirectory, "AppLog-.txt"), rollingInterval: RollingInterval.Day)
            .CreateLogger();

            InitializeComponent();
        }

        private void frmArticuloBusqueda_Load(object sender, EventArgs e)
        {
            this.obtenerListaArticulo();
        }


        private void obtenerListaArticulo()
        {



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
                // Obtener la fila actual
                //DataGridViewRow filaActual = dataGridView1.CurrentRow;

                // Acceder al valor de una celda
                //string valor = filaActual.Cells["CODE"].Value?.ToString();
                //string v12a;

                //if (dataGridView1.SelectedRows.Count > 0)
                //{
                //    // Obtener la primera fila seleccionada
                //    DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

                //    // Obtener el índice de la fila
                //    int indiceFila = filaSeleccionada.Index;
                //    //indiceFila = indiceFila - 1;

                //    //// Acceder a valores de las celdas
                //    //var valorCelda1 = filaSeleccionada.Cells["NombreColumna1"].Value?.ToString();
                //    //var valorCelda2 = filaSeleccionada.Cells[1].Value?.ToString(); // Por índice



                //    string code, name, um;
                //    //code = Convert.ToString(this.dataGridView1.CurrentRow.Cells["CODE"].Value);
                //    code = Convert.ToString(filaSeleccionada.Cells["CODE"].Value?.ToString());
                //    name = Convert.ToString(this.dataGridView1.CurrentRow.Cells["NAME"].Value);
                //    um = Convert.ToString(this.dataGridView1.CurrentRow.Cells["UM"].Value);


                //    // Creamos una instancia de Form2Data con los valores de txtInput1 y txtInput2
                //    var data = new Form2Data(code, name);

                //    // Invocamos el evento, enviando la instancia de Form2Data
                //    OnValueSubmitted?.Invoke(this, data);

                //    this.Close();

                //    //MessageBox.Show($"Índice de la fila: {indiceFila}\nColumna1: {valorCelda1}\nColumna2: {valorCelda2}");

                //}




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



        }

        private void button1_Click(object sender, EventArgs e)
        {

            string code, name, um;

            try
            {
                // Verifica si hay alguna fila seleccionada
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Obtener la primera fila seleccionada
                    DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];

                    // Acceder a los valores de las celdas por nombre de columna o índice
                    code = filaSeleccionada.Cells["CODE"].Value?.ToString();
                    name = filaSeleccionada.Cells["NAME"].Value?.ToString();
                    um = filaSeleccionada.Cells["UM"].Value?.ToString();

                    // Creamos una instancia de Form2Data con los valores de txtInput1 y txtInput2
                    var data = new Form2Data(code, name);

                    // Invocamos el evento, enviando la instancia de Form2Data
                    OnValueSubmitted?.Invoke(this, data);

                    this.Close();

                }
                else
                {
                    Log.Information("[DEVFIL] Error de Seleccion");
                }

            }
            catch (Exception ex)
            {
                Log.Information(ex, "[DEVFIL] Error de Seleccion " + ex.Message.ToString());
                throw;
            }



        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string code, name, um;

            if (e.RowIndex >= 0)
            {
                // Obtener la fila sobre la que se hizo doble clic
                DataGridViewRow filaSeleccionada = dataGridView1.Rows[e.RowIndex];

                ////// Acceder a los valores de las celdas por nombre de columna o índice
                ////string valorColumna1 = filaSeleccionada.Cells["NombreColumna1"].Value?.ToString();
                ////string valorColumna2 = filaSeleccionada.Cells[1].Value?.ToString(); // Por índice


                // Acceder a los valores de las celdas por nombre de columna o índice
                code = filaSeleccionada.Cells["CODE"].Value?.ToString();
                name = filaSeleccionada.Cells["NAME"].Value?.ToString();
                um = filaSeleccionada.Cells["UM"].Value?.ToString();

                // Creamos una instancia de Form2Data con los valores de txtInput1 y txtInput2
                var data = new Form2Data(code, name);

                // Invocamos el evento, enviando la instancia de Form2Data
                OnValueSubmitted?.Invoke(this, data);

                this.Close();

            }


        }
    }
}
