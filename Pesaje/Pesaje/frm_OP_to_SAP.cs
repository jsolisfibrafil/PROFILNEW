using Serilog;
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
    public partial class frm_OP_to_SAP : Form
    {
        public frm_OP_to_SAP()
        {
            InitializeComponent();
        }

        DateTime fecha = new DateTime(2000, 1, 1);
        DataSet dts_NR = new DataSet();
        DataSet dts_SD = new DataSet();

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
                    var obj_NORMR = new SqlDataAdapter(
                        "select OcrCode As 'ID', OcrName As 'NAME' from SBO_FIBRAFIL..OOCR order by OcrName", OCN);

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
                    DataView Dvlista;
                    dap.Fill(dts, "vLIST");

                    Dvlista = dts.Tables["vLIST"].DefaultView;
                    DataGridView1.DataSource = Dvlista;
                    Dvlista.AllowEdit = false;
                    Dvlista.AllowNew = false;
                }
                else
                {
                    DataView Dvlista1;
                    dap.Fill(dts, "vLIST");

                    Dvlista1 = dts.Tables["vLIST"].DefaultView;
                    DataGridView2.DataSource = Dvlista1;
                    Dvlista1.AllowEdit = false;
                    Dvlista1.AllowNew = false;
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
                Obtener_DATA(1, "", 0, new DateTime(2000, 1, 1), "");
            }
            catch (Exception ex)
            {
                // Opcional: Loguear o manejar el error
                // MessageBox.Show(ex.Message);
            }

        }
    }



}
