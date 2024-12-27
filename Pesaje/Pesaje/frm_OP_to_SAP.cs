using SAPbobsCOM;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pesaje
{
    public partial class frm_OP_to_SAP : Form
    {
        public frm_OP_to_SAP()
        {
            InitializeComponent();
        }

        DateTime fecha = new DateTime(2000, 1, 1);
        DataSet dts_NR = new DataSet();
        DataSet dts_SD = new DataSet();


        DataView Dvlista = null;
        DataView Dvlista1 = null;

        public static SAPbouiCOM.Application SBO_Application = null;
        public static SAPbobsCOM.Company oCompany = null;
        public static SAPbouiCOM.Application oApplication = null;
        public static SAPbobsCOM.Company myCompany = null;


        private void frm_OP_to_SAP_Load(object sender, EventArgs e)
        {
            Log.Information("Iniciar_frm_OP_to_SAP_Load");
            Obtener_DATA(1, "", 0, fecha, "");
        }

        public void Obtener_DATA(int opcion, string Item, decimal Cant, DateTime Fecha, string Telar)
        {
            SqlConnection OCN = Conexion1.ObtenerConexion();

            if (OCN.State == System.Data.ConnectionState.Closed)
            {
                OCN.Open();
            }

            //if (OCN.State == ConnectionState.Closed) OCN.Open();

            try
            {
                if (!dts_NR.Tables.Contains("tNormR"))
                {
                    //var obj_NORMR = new SqlDataAdapter("select OcrCode As 'ID', OcrName As 'NAME' from SBO_FIBRAFIL..OOCR order by OcrName", OCN);
                    var obj_NORMR = new SqlDataAdapter("select OcrCode As 'ID', OcrName As 'NAME' from SBO_FIBRAFIL_TEST_23_12_24..OOCR order by OcrName", OCN);


                    obj_NORMR.Fill(dts_NR, "ID");
                    obj_NORMR.Fill(dts_NR, "NAME");

                    obj_NORMR.SelectCommand.CommandType = CommandType.Text;
                    obj_NORMR.Fill(dts_NR, "tNormR");

                    cmb_normr.DataSource = dts_NR.Tables["tNormR"].DefaultView;
                    cmb_normr.DisplayMember = "NAME";
                    cmb_normr.ValueMember = "ID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Error al cargar normas de reparto.");
                Log.Error(ex, ex.Message.ToString());
            }

            try
            {
                if (!dts_SD.Tables.Contains("tSede"))
                {
                    var obj_SD = new SqlDataAdapter(
                        "select ID_SEDE As 'ID', DSCPSD As 'NAME' from OFIBSEDE order by ID_SEDE", OCN);

                    obj_SD.Fill(dts_SD, "ID");
                    obj_SD.Fill(dts_SD, "NAME");

                    obj_SD.SelectCommand.CommandType = CommandType.Text;
                    obj_SD.Fill(dts_SD, "tSede");

                    cmb_sede.DataSource = dts_SD.Tables["tSede"].DefaultView;
                    cmb_sede.DisplayMember = "NAME";
                    cmb_sede.ValueMember = "ID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Error al cargar sedes.");
            }

            try
            {
                // Preparación de datos
                var cmd = new SqlCommand("U_SP_ListOPtoSAP", OCN)
                {
                    CommandType = CommandType.StoredProcedure
                };

                var dap = new SqlDataAdapter();
                dap.SelectCommand = cmd;

                cmd.Parameters.Add(new SqlParameter("@OPCION", SqlDbType.Int) { Value = opcion });
                cmd.Parameters.Add(new SqlParameter("@Itemcode", SqlDbType.VarChar) { Value = Item });
                cmd.Parameters.Add(new SqlParameter("@Cant", SqlDbType.Decimal) { Value = Cant });
                cmd.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.SmallDateTime) { Value = Fecha });
                cmd.Parameters.Add(new SqlParameter("@TELAR", SqlDbType.VarChar) { Value = Telar });
                cmd.Parameters.Add(new SqlParameter("@SEDE", SqlDbType.VarChar) { Value = cmb_sede.SelectedValue.ToString() });

                var dts = new DataSet();


                if (opcion != 2)
                {
                    //ini
                    if (DataGridView2.RowCount > 0 |  (Dvlista1 != null && Dvlista1.Table != null)  )
                    {
                        //DataGridView2.Rows.Clear();
                        Dvlista1.Table.Clear();
                    }

                    //fin

                    dap.Fill(dts, "vLIST");

                    Dvlista = dts.Tables["vLIST"].DefaultView;
                    DataGridView1.DataSource = Dvlista;
                    Dvlista.AllowEdit = false;
                    Dvlista.AllowNew = false;

                    //
                    lbl_cant.Text = Convert.ToString( Dvlista.Count);
                    //Dvlista1.Table.Clear();


                }
                else
                {
                    
                    dap.Fill(dts, "vLIST");

                    Dvlista1 = dts.Tables["vLIST"].DefaultView;
                    DataGridView2.DataSource = Dvlista1;
                    Dvlista1.AllowEdit = false;
                    Dvlista1.AllowNew = false;

                    //
                    lbl_cantdetalle.Text = Convert.ToString(Dvlista1.Count);

                }

            }
            catch (Exception ex)
            {
                Log.Error(ex,ex.Message.ToString());
                MessageBox.Show(ex.Message);
            }
            finally
            {
                OCN.Close();
            }

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmb_sede_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Log.Information("Obtener_DATA");
                Obtener_DATA(1, "", 0, new DateTime(2000, 1, 1), "");
            }
            catch (Exception ex)
            {
                Log.Error (ex,ex.Message.ToString());   
                // Opcional: Loguear o manejar el error
                // MessageBox.Show(ex.Message);
            }

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegura que no se haga clic en el encabezado
            {
                try
                {
                    string codigo = DataGridView1.Rows[e.RowIndex].Cells["CODIGO"].Value.ToString();
                    decimal cant = Convert.ToDecimal( DataGridView1.Rows[e.RowIndex].Cells["CANT"].Value);
                    DateTime date1 = Convert.ToDateTime( DataGridView1.Rows[e.RowIndex].Cells["Fecha"].Value);
                    string telar = DataGridView1.Rows[e.RowIndex].Cells["Telar"].Value.ToString();

                    Obtener_DATA(2, codigo, cant, date1, telar);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }


        }

        private void Button2_Click_1(object sender, EventArgs e)
        {

            lbl_prod.Text = DataGridView1.Rows[DataGridView1.CurrentRow.Index].Cells["descripcion"].Value.ToString();
            lbl_peso.Text = DataGridView1.Rows[DataGridView1.CurrentRow.Index].Cells["peso"].Value.ToString();
            lbl_cant.Text = DataGridView1.Rows[DataGridView1.CurrentRow.Index].Cells["cant"].Value.ToString();

            rb_kilos.Checked = false;
            rb_unid.Checked = false;
            btn_SAP.Enabled = false;

            GroupBox1.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            int X;
            int PP = 0;
            decimal peso = 0;

            // Iterar a través de las filas del DataGridView2
            for (X = 0; X < DataGridView2.RowCount; X++)
            {
                if (DataGridView2.Rows[X].Cells["WareHouse"].Value.ToString() == "PP")
                {
                    PP = PP + 1;
                }
            }

            // Si PP no es mayor a 1, calcular el peso
            if (PP <= 1)
            {
                decimal pesoActual = Convert.ToDecimal(DataGridView1.Rows[DataGridView1.CurrentRow.Index].Cells["Peso"].Value);
                decimal cantidad = Convert.ToDecimal(DataGridView1.Rows[DataGridView1.CurrentRow.Index].Cells["Cant"].Value);

                peso = pesoActual - (cantidad * 0.75m);
            }

            // Mostrar el resultado en un MessageBox
            MessageBox.Show(peso.ToString(), "fib", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        private void Button1_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("Seguro de procesar esta elección.", "PROFIL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                // Creación de archivos de texto para exportación de datos
                var filePath = Path.Combine(Application.StartupPath, "Temp", "OP0.txt");
                var filePath2 = Path.Combine(Application.StartupPath, "Temp", "OP1.txt");

                using (var file = new StreamWriter(filePath, false, Encoding.Unicode))
                using (var file2 = new StreamWriter(filePath2, false, Encoding.Unicode))
                {
                    try
                    {
                        string sLine0, sLine = "";

                        // Exportación del DataGridView1
                        for (int r = -2; r < DataGridView1.Rows.Count; r++)
                        {
                            if (r <= -1)
                            {
                                sLine0 = "AbsoluteEntry\tProductionOrderStatus\tProductionOrderType\tItemNo\tPlannedQuantity\tPostingDate\tDuedate\tDistributionRule\tU_FIB_PProfil\tU_FIB_Telar\tWarehouse";
                                file.WriteLine(sLine0);
                            }
                            else
                            {
                                int itemSelec = DataGridView1.CurrentRow.Index;
                                string dc_unidxpros;
                                string dc_pesoFDU = "0";

                                if (r == itemSelec)
                                {
                                    if (rb_kilos.Checked)
                                    {
                                        if (rb_AddSi.Checked)
                                        {
                                            dc_unidxpros = (Convert.ToDecimal(DataGridView1.Rows[r].Cells["peso"].Value) + Convert.ToDecimal(DataGridView1.Rows[r].Cells["scrap"].Value)).ToString();
                                        }
                                        else
                                        {
                                            dc_unidxpros = DataGridView1.Rows[r].Cells["peso"].Value.ToString();
                                        }
                                        dc_pesoFDU = dc_unidxpros;
                                    }
                                    else
                                    {
                                        dc_unidxpros = DataGridView1.Rows[r].Cells["cant"].Value.ToString();

                                        if (rb_AddSi.Checked)
                                        {
                                            dc_pesoFDU = (Convert.ToDecimal(DataGridView1.Rows[r].Cells["peso"].Value) + Convert.ToDecimal(DataGridView1.Rows[r].Cells["scrap"].Value)).ToString();
                                        }
                                        else
                                        {
                                            dc_pesoFDU = DataGridView1.Rows[r].Cells["peso"].Value.ToString();
                                        }
                                    }

                                    sLine = "1\tP\tP\t" +
                                            DataGridView1.Rows[r].Cells["codigo"].Value.ToString() + "\t" +
                                            dc_unidxpros + "\t" +
                                            Convert.ToDateTime(DataGridView1.Rows[r].Cells["fecha"].Value).ToString("yyyyMMdd") + "\t" +
                                            DateTime.Today.ToString("yyyyMMdd") + "\t" +
                                            cmb_normr.SelectedValue + "\t" +
                                            dc_pesoFDU + "\t" +
                                            DataGridView1.Rows[r].Cells["TELAR"].Value.ToString() + "\t" +
                                            DataGridView1.Rows[r].Cells["WHS"].Value.ToString();

                                    file.WriteLine(sLine);
                                }
                            }
                        }

                        string sLine01, sLine02;

                        // Exportación del DataGridView2
                        for (int r = -2; r < DataGridView2.Rows.Count; r++)
                        {
                            if (r <= -1)
                            {
                                sLine01 = "ParentKey\tLinenum\tItemNo\tBaseQuantity\tProductionOrderIssueType\tWarehouse";
                                file2.WriteLine(sLine01);
                            }
                            else
                            {
                                sLine02 = "1\t" +
                                          DataGridView2.Rows[r].Cells["linenum"].Value.ToString() + "\t" +
                                          DataGridView2.Rows[r].Cells["ItemNo"].Value.ToString() + "\t" +
                                          DataGridView2.Rows[r].Cells["BaseQuantity"].Value.ToString() + "\t" +
                                          DataGridView2.Rows[r].Cells["ProductionOrderIssueType"].Value.ToString() + "\t" +
                                          DataGridView2.Rows[r].Cells["Warehouse"].Value.ToString();

                                file2.WriteLine(sLine02);
                            }
                        }

                        MessageBox.Show("Export Complete.", "Program Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


                if (ConexionUIAPI())
                {
                    //cabecera 
                    // Crear la Orden de Fabricación
                    ProductionOrders oProductionOrder = (ProductionOrders)myCompany.GetBusinessObject(BoObjectTypes.oProductionOrders);

                    oProductionOrder.ProductionOrderType = BoProductionOrderTypeEnum.bopotStandard; // Tipo de orden: Estándar
                    oProductionOrder.ProductionOrderStatus = BoProductionOrderStatusEnum.boposPlanned; // Estado: Planeada
                    oProductionOrder.ItemNo = "PTCABAZ1/43P"; // Código del artículo final
                    oProductionOrder.PlannedQuantity = 34.20; // Cantidad planeada
                    oProductionOrder.PostingDate = DateTime.Now; // Fecha de vencimiento
                    oProductionOrder.DueDate = DateTime.Now.AddDays(7); // Fecha de vencimiento
                    oProductionOrder.DistributionRule  = "ALM"; // Fecha de vencimiento
                    oProductionOrder.Warehouse = "PT";

                    oProductionOrder.UserFields.Fields.Item("U_FIB_PProfil").Value = 34.2;
                    oProductionOrder.UserFields.Fields.Item("U_FIB_TELAR").Value = "37";


                    //oProductionOrder.ProductionOrderStatus = BoProductionOrderStatusEnum.boposPlanned; // Estado: Planeada
                    //oProductionOrder.Warehouse = "ALMACEN"; // Código de almacén


                    //detalle 

                    // Agregar líneas (materiales necesarios)
                    oProductionOrder.Lines.SetCurrentLine(0);
                    oProductionOrder.Lines.ItemNo = "HHC"; // Código del componente
                    oProductionOrder.Lines.BaseQuantity = 1.2;
                    oProductionOrder.Lines.ProductionOrderIssueType = BoIssueMethod.im_Backflush;
                    oProductionOrder.Lines.Warehouse = "PT";




                    oProductionOrder.Lines.Add(); // Agregar otra línea
                    oProductionOrder.Lines.SetCurrentLine(1);
                    oProductionOrder.Lines.ItemNo = "ANET00-017";
                    oProductionOrder.Lines.BaseQuantity = 0.061;
                    oProductionOrder.Lines.ProductionOrderIssueType = BoIssueMethod.im_Manual;
                    oProductionOrder.Lines.Warehouse = "SELLTE"; 



                    //oProductionOrder.Lines.PlannedQuantity = 30;
                    //oProductionOrder.Lines.Warehouse = "ALMACEN";
                    //oProductionOrder.Lines.ProductionOrderIssueType = BoIssueMethod.im_Manual; // Emisión manual



                    //oProductionOrder.Lines.PlannedQuantity = 50; // Cantidad planeada del componente
                    //oProductionOrder.Lines.Warehouse = "ALMACEN";

                    //oProductionOrder.Lines.Add(); // Agregar otra línea
                    //oProductionOrder.Lines.SetCurrentLine(1);
                    //oProductionOrder.Lines.ItemNo = "COMPONENTE_2";
                    //oProductionOrder.Lines.PlannedQuantity = 30;
                    //oProductionOrder.Lines.Warehouse = "ALMACEN";

                    // Intentar agregar la Orden de Fabricación
                    if (oProductionOrder.Add() != 0)
                    {
                        myCompany.GetLastError(out int errCode, out string errMsg);
                        Console.WriteLine($"Error al crear la Orden de Fabricación: {errCode} - {errMsg}");
                    }
                    else
                    {
                        Console.WriteLine($"Orden de Fabricación creada exitosamente. ID: {myCompany.GetNewObjectKey()}");
                    }


                }

                ////// Proceso de migración mediante DTW
                ////try
                ////{
                ////    var process = new Process();
                ////    process.StartInfo.FileName = "cmd.exe";
                ////    process.StartInfo.Arguments = "/c " + Path.Combine(Application.StartupPath, "DTW", "DTW.exe") + " -s " +
                ////                                  Path.Combine(Application.StartupPath, "Temp", "Transfer_OP.xml");

                ////    process.StartInfo.RedirectStandardError = true;
                ////    process.StartInfo.RedirectStandardOutput = true;
                ////    process.StartInfo.UseShellExecute = false;
                ////    process.StartInfo.CreateNoWindow = false;

                ////    process.Start();
                ////    string output = process.StandardOutput.ReadToEnd() + Environment.NewLine + process.StandardError.ReadToEnd();

                ////    DateTime date1 = Convert.ToDateTime(DataGridView1.CurrentRow.Cells["Fecha"].Value);


                ////    // Actualizar datos
                ////    GroupBox1.Visible = false;
                ////    Obtener_DATA(3,
                ////                DataGridView1.CurrentRow.Cells["CODIGO"].Value.ToString(),
                ////                0,
                ////                date1,
                ////                DataGridView1.CurrentRow.Cells["Telar"].Value.ToString()
                ////                );
                ////}
                ////catch (Exception ex)
                ////{
                ////    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ////}


            }
            else
            {
                GroupBox1.Visible = false;
                return;
            }


        }

        public static bool ConexionUIAPI()
        {
            bool val = false;

            myCompany = new SAPbobsCOM.Company();
            myCompany.Server = "SRVBDLUR1"; //"192.168.150.4";SERVERSAP // ADDON_JESUS_BD
            myCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012; //.BoDataServerTypes.dst_MSSQL2008; //.dst_MSSQL2014; //dst_MSSQL2012;
            myCompany.CompanyDB = "SBO_FIBRAFIL_TEST_23_12_24"; //"SBO_DAMOQUI_FE_AN";

            myCompany.DbUserName = "sa";
            myCompany.DbPassword = "cuerda$12";

            myCompany.UserName = "manager";   //"manager";
            myCompany.Password = "2521";   //"m1r1";
            myCompany.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;// .BoSuppLangs.ln_Spanish_La;




            int error = myCompany.Connect();


            if (error == 0)
            {
                ////Respuesta = true;
                ////MessageBox.Show(“Mensaje solo informativo con botón Aceptar”,”Titulo Ventana”);
                //MessageBox.Show("Conexión exitosa ", "Mensaje Conexion");
                ////SBO_Application.StatusBar.SetText("EXITO - Conexion API API Exitosa", BoMessageTime.bmt_Medium, BoStatusBarMessageType.smt_Success);
                Console.WriteLine("EXITO - Conexion SAP DI-API  Exitosa");
                Log.Information("EXITO - Conexion API  Exitosa ");
                val = true;
                //log_1(DateTime.Now + " EXITO - Conexion API  Exitosa  ");
            }
            else
            {
                ////Javascript.Alert("Error - " + myCompany.GetLastErrorDescription().ToString());
                //MessageBox.Show("error ", "Error Conexion");
                string outresponse = myCompany.GetLastErrorDescription().ToString();
                oCompany.GetLastError(out int errCode, out string errMsg);
                Console.WriteLine($"Error conectando a SAP: {errCode} - {errMsg}");
                //Log.Error(" error - Conexion API  -  " + outresponse);
                val = false;

            }

            return val;
        }

        private void rb_AddNO_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void frm_OP_to_SAP_Resize(object sender, EventArgs e)
        {

            Control c = GroupBox1;

            // Establece la posición superior (Top) y la izquierda (Left) dentro del control contenedor (Parent)
            c.Top = (c.Parent.ClientSize.Height - c.Height) / 2;
            c.Left = (c.Parent.ClientSize.Width - c.Width) / 2;

        }

        private void rb_unid_CheckedChanged(object sender, EventArgs e)
        {

            btn_SAP.Enabled = true;

        }






    }



}
