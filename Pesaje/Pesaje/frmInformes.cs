using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Pesaje
{
    public partial class frmInformes : Form
    {

        DataSet dts = new DataSet();
        string cnc1 = ConfigurationManager.ConnectionStrings["conexiondb"].ConnectionString;

        public frmInformes()
        {
            InitializeComponent();
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

            try
            {
                if (!string.IsNullOrEmpty(saveFileDialog1.FileName))
                {
                    switch (saveFileDialog1.FilterIndex)
                    {
                        case 1: // Excel File

                            
                            Excel.Application xlApp = new Excel.Application();
                            Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(Type.Missing);
                            Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];

                            int i, j;
                            for (i = 0; i < dataGridView1.RowCount - 1; i++)
                            {
                                for (j = 0; j < dataGridView1.ColumnCount; j++)
                                {
                                    xlWorkSheet.Cells[i + 1, j + 1] = dataGridView1[j, i].Value?.ToString();
                                }
                            }

                            xlWorkBook.SaveAs(saveFileDialog1.FileName, Excel.XlFileFormat.xlWorkbookNormal,
                                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing,
                                Type.Missing, Type.Missing, Type.Missing);
                            xlWorkBook.Close(true, Type.Missing, Type.Missing);
                            xlApp.Quit();

                            ReleaseObject(xlWorkSheet);
                            ReleaseObject(xlWorkBook);
                            ReleaseObject(xlApp);
                            break;

                        case 2: // Text File
                                // Implementar lógica para guardar como archivo de texto.
                            break;

                        case 3: // PDF File
                                // Implementar lógica para guardar como archivo PDF.
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }





        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void btnprocess_Click(object sender, EventArgs e)
        {
            ObtenerData();

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
            CMD.Parameters.Add(new SqlParameter("@Item1", SqlDbType.Text)).Value = txtItm1.Text;  // Item 01
            CMD.Parameters.Add(new SqlParameter("@Maq", SqlDbType.Text)).Value = txt_s_Maq.Text;  // Máquina
            CMD.Parameters.Add(new SqlParameter("@Fini", SqlDbType.SmallDateTime)).Value = dtpFini.Value; // Fecha 01
            CMD.Parameters.Add(new SqlParameter("@Ffin", SqlDbType.SmallDateTime)).Value = dtpFfin.Value; // Fecha 02
            CMD.Parameters.Add(new SqlParameter("@Sede", SqlDbType.Text)).Value = cmb_sede.SelectedValue;  // Sede

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
            }
            finally
            {
                OCN.Close();
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


