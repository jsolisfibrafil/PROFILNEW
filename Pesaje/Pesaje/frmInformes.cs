using Serilog;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Pesaje
{
    public partial class frmInformes : Form
    {

        DataSet dts = new DataSet();
        string cnc1 = ConfigurationManager.ConnectionStrings["conexiondb"].ConnectionString;
        int i_ninforme = 0;
        SqlDataAdapter dap = new SqlDataAdapter();

        DataView dtPlan = new DataView();
        DataView dtProd = new DataView();
        DataView dtDespacho = new DataView();
        DataView dtKardex = new DataView();
        DataView dtProdDiario = new DataView();
        DataView dtCodebar = new DataView();
        DataView dtProdMes = new DataView();
        DataView dtDetProd = new DataView();


        public frmInformes()
        {
            InitializeComponent();

            optPlan.CheckedChanged += op_INFORMES;
            optProd.CheckedChanged += op_INFORMES;
            optDespacho.CheckedChanged += op_INFORMES;
            optKardex.CheckedChanged += op_INFORMES;
            optDiario.CheckedChanged += op_INFORMES;
            optCodebar.CheckedChanged += op_INFORMES;
            optProdMes.CheckedChanged += op_INFORMES;
            optdetprod.CheckedChanged += op_INFORMES;


        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnexport_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Archivo de Excel|*.xls|Archivo de Texto|*.txt|Archivo PDF|*.pdf";
            saveFileDialog1.Title = "Save a File";
            saveFileDialog1.ShowDialog();


            if (!string.IsNullOrEmpty(saveFileDialog1.FileName))
            {
                switch (saveFileDialog1.FilterIndex)
                {
                    ////case 1: // Excel File


                    ////    Excel.Application xlApp = new Excel.Application();
                    ////    Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(Type.Missing);
                    ////    Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];

                    ////    int i, j;
                    ////    for (i = 0; i < dataGridView1.RowCount - 1; i++)
                    ////    {
                    ////        for (j = 0; j < dataGridView1.ColumnCount; j++)
                    ////        {
                    ////            xlWorkSheet.Cells[i + 1, j + 1] = dataGridView1[j, i].Value?.ToString();
                    ////        }
                    ////    }

                    ////    xlWorkBook.SaveAs(saveFileDialog1.FileName, Excel.XlFileFormat.xlWorkbookNormal,
                    ////        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    ////        Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing,
                    ////        Type.Missing, Type.Missing, Type.Missing);
                    ////    xlWorkBook.Close(true, Type.Missing, Type.Missing);
                    ////    xlApp.Quit();

                    ////    ReleaseObject(xlWorkSheet);
                    ////    ReleaseObject(xlWorkBook);
                    ////    ReleaseObject(xlApp);
                    ////    break;
                    ///

                    case 1: // Excel File
                        {
                            try
                            {
                                // Crear una nueva aplicación de Excel
                                Excel.Application xlApp = new Excel.Application();
                                Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(Type.Missing);
                                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];

                                // Llenar el Excel con los datos del DataGridView
                                int i, j;
                                for (i = 0; i < dataGridView1.RowCount - 1; i++)
                                {
                                    for (j = 0; j < dataGridView1.ColumnCount; j++)
                                    {
                                        xlWorkSheet.Cells[i + 1, j + 1] = dataGridView1[j, i].Value?.ToString();
                                    }
                                }

                                // Guardar el archivo de Excel
                                string filePath = saveFileDialog1.FileName;
                                xlWorkBook.SaveAs(filePath, Excel.XlFileFormat.xlWorkbookNormal,
                                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                    Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing,
                                    Type.Missing, Type.Missing, Type.Missing);

                                // Cerrar y liberar los recursos de Excel
                                xlWorkBook.Close(true, Type.Missing, Type.Missing);
                                xlApp.Quit();

                                ReleaseObject(xlWorkSheet);
                                ReleaseObject(xlWorkBook);
                                ReleaseObject(xlApp);

                                // Verificar si el archivo Excel se creó correctamente
                                if (System.IO.File.Exists(filePath))
                                {
                                    MessageBox.Show("El archivo Excel se creó exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Hubo un error al guardar el archivo Excel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                // Si ocurre un error, mostrar un mensaje
                                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;

                        }

                    case 2: // Text File
                            // Implementar lógica para guardar como archivo de texto.
                        break;

                    case 3: // PDF File
                            // Implementar lógica para guardar como archivo PDF.
                        break;
                }
            }




        }




        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void btnprocess_Click(object sender, EventArgs e)
        {
            //int var = i_ninforme;


            ObtenerData();

        }


        private void op_INFORMES(object sender, EventArgs e)
        {
            if (optPlan.Checked) i_ninforme = 1;
            if (optProd.Checked) i_ninforme = 2;
            if (optDespacho.Checked) i_ninforme = 3;
            if (optKardex.Checked) i_ninforme = 4;
            if (optDiario.Checked) i_ninforme = 5;
            if (optCodebar.Checked) i_ninforme = 6;
            if (optProdMes.Checked) i_ninforme = 7;
            if (optdetprod.Checked) i_ninforme = 8;
        }



        private void ObtenerData()
        {
            // Eliminar filas del DataGridView comentado por problemas de rendimiento.
            /*
            try
            {
                if (dataGridView1.RowCount >= 1)
                {
                    for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                    {
                        dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Esta fila no se puede eliminar", "Operación inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */

            dts.Clear();
            SqlConnection sqt1 = new SqlConnection(cnc1);


            dataGridView1.DataSource = null;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            if (sqt1.State == ConnectionState.Closed)
                sqt1.Open();

            // Configuración del comando SQL
            SqlCommand CMD = new SqlCommand("U_SP_INF_INTEGRADO", sqt1)
            {
                CommandType = CommandType.StoredProcedure
            };

            CMD.Parameters.Add(new SqlParameter("@Ninforme", SqlDbType.Int)).Value = i_ninforme;  // Número informe
            //CMD.Parameters.Add(new SqlParameter("@Item1", SqlDbType.Text)).Value = "01";//txtItm1.Text;  // Item 01
            CMD.Parameters.Add(new SqlParameter("@Item1", SqlDbType.Text)).Value = txtItm1.Text;
            CMD.Parameters.Add(new SqlParameter("@Maq", SqlDbType.Text)).Value = txt_s_Maq.Text;//CMD.Parameters.Add(new SqlParameter("@Maq", SqlDbType.Text)).Value = "01";//txt_s_Maq.Text;  // Máquina
            CMD.Parameters.Add(new SqlParameter("@Fini", SqlDbType.SmallDateTime)).Value = dtpFini.Value; // Fecha 01
            CMD.Parameters.Add(new SqlParameter("@Ffin", SqlDbType.SmallDateTime)).Value = dtpFfin.Value; // Fecha 02
            CMD.Parameters.Add(new SqlParameter("@Sede", SqlDbType.Text)).Value = lb_sede.Text;// cmb_sede.SelectedValue;  // Sede

            dap.SelectCommand = CMD;

            try
            {
                switch (i_ninforme)
                {
                    case 1:
                        dap.Fill(dts, "dtPlan");
                        dtPlan = dts.Tables["dtPlan"].DefaultView;
                        dataGridView1.DataSource = dtPlan;
                        return;

                    case 2:
                        dap.Fill(dts, "dtProd");
                        dtProd = dts.Tables["dtProd"].DefaultView;
                        int cantidadFilas = dts.Tables["dtProd"].Rows.Count;

                        cantFilas.Text = cantidadFilas.ToString();
                        dataGridView1.DataSource = dtProd;



                        return;

                    case 3:
                        dap.Fill(dts, "dtDespacho");
                        dtDespacho = dts.Tables["dtDespacho"].DefaultView;
                        dataGridView1.DataSource = dtDespacho;
                        return;

                    case 4:
                        dap.Fill(dts, "dtKardex");
                        dtKardex = dts.Tables["dtKardex"].DefaultView;
                        dataGridView1.DataSource = dtKardex;
                        return;

                    case 5:
                        dap.Fill(dts, "dtProdDiario");
                        dtProdDiario = dts.Tables["dtProdDiario"].DefaultView;
                        dataGridView1.DataSource = dtProdDiario;
                        return;

                    case 6:
                        dap.Fill(dts, "dtCodebar");
                        dtCodebar = dts.Tables["dtCodebar"].DefaultView;
                        dataGridView1.DataSource = dtCodebar;
                        return;

                    case 7:
                        dap.Fill(dts, "dtProdMes");
                        dtProdMes = dts.Tables["dtProdMes"].DefaultView;
                        dataGridView1.DataSource = dtProdMes;
                        return;

                    case 8:
                        dap.Fill(dts, "dtDetProd");
                        dtDetProd = dts.Tables["dtDetProd"].DefaultView;
                        dataGridView1.DataSource = dtDetProd;
                        return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Log.Error(ex, ex.Message.ToString());
            }
            finally
            {
                sqt1.Close();
            }


        }

        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Error releasing object: " + ex.Message);
            }
            finally
            {
                GC.Collect();
            }
        }


    }



}


