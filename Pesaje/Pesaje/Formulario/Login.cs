using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pesaje.Formulario
{
    public partial class Login : Form
    {

        DataSet dts = new DataSet();
        public static string vs_User, vs_Area, vs_Mac, vs_idUser, vs_idArea, vs_idMac, vs_isADM, vs_iArea, vs_Host, vs_MacAddres, vs_sede;
        //public SqlConnection OCN = new SqlConnection();
        string connection_String = ConfigurationManager.ConnectionStrings["conexiondb"].ConnectionString;
        private SqlConnection OCN = new SqlConnection(ConfigurationManager.ConnectionStrings["conexiondb"].ConnectionString); // Reemplaza con tu cadena de conexión



        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand CMD = new SqlCommand("U_SP_lOGIN", OCN);
            CMD.CommandType = CommandType.StoredProcedure;

            CMD.Parameters.Add(new SqlParameter("@COD_EMP", SqlDbType.Text)).Value = cmbUser.SelectedValue.ToString(); // Cod Empleado
            CMD.Parameters.Add(new SqlParameter("@PWD", SqlDbType.Text)).Value = txtpsw.Text; // Password

            if (OCN.State == ConnectionState.Open)
                OCN.Close(); // Para el caso de que 2 usuarios quieran realizar el mantenimiento a la misma vez

            OCN.Open();
            try
            {
                SqlDataAdapter DAP = new SqlDataAdapter(CMD);
                DAP.Fill(dts, "Login");

                int INOUT = Convert.ToInt32(dts.Tables["Login"].Rows[0][0]);

                switch (INOUT)
                {
                    case 1:
                        vs_idMac = "01"; // cmbMac.SelectedValue.ToString();
                        vs_idArea = cmbArea.SelectedValue.ToString();
                        vs_idUser = cmbUser.SelectedValue.ToString();
                        vs_isADM = Label5.Text;
                        vs_Mac = "01"; // cmbMac.Text;
                        vs_User = cmbUser.Text;
                        MessageBox.Show("Acceso autorizado", "PROFIL", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Segunda llamada al procedimiento almacenado
                        SqlCommand CMD99 = new SqlCommand("U_SP_INOUTSESIONES", OCN)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        CMD99.Parameters.Add(new SqlParameter("@CODE", SqlDbType.VarChar)).Value = vs_idUser;
                        CMD99.Parameters.Add(new SqlParameter("@option", SqlDbType.VarChar)).Value = 1;
                        CMD99.ExecuteNonQuery();

                        //MDIPROFIL mdi = new MDIPROFIL();
                        mainForm mdi = new mainForm();
                        //mainForm

                        //mdi.ToolStripStatusLabel1.Text = "Area : " + vs_idArea;
                        //mdi.ToolStripStatusLabel2.Text = " Maquina : " + vs_Mac;
                        //mdi.ToolStripStatusLabel3.Text = " Usuario : " + vs_User + " [" + vs_isADM + "]";
                        mdi.ShowDialog();// Show();

                        this.Close();
                        break;

                    case 0:
                        MessageBox.Show("Contraseña incorrecta", "PROFIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 2:
                        MessageBox.Show("Este usuario ya tiene una sesión iniciada", "PROFIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    default:
                        MessageBox.Show("Usuario no registrado o no activo", "PROFIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Fibrafil", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                dts.Dispose();
                if (dts.Tables.Contains("Login"))
                    dts.Tables["Login"].Rows.Clear();

                OCN.Close();
            }


        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sqt1 = new SqlConnection(connection_String);
            
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = sqt1;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "U_SP_REGHOST";

                    // Agregar parámetros al comando
                    cmd.Parameters.Add(new SqlParameter("@namehost", SqlDbType.Text)).Value = Environment.MachineName;
                    cmd.Parameters.Add(new SqlParameter("@iphost", SqlDbType.Text)).Value = RetIPAddress(GetHostName());
                    cmd.Parameters.Add(new SqlParameter("@MAcAddres", SqlDbType.Text)).Value = getMacAddress();
                    cmd.Parameters.Add(new SqlParameter("@SOName", SqlDbType.Text)).Value = Environment.OSVersion.VersionString;
                    cmd.Parameters.Add(new SqlParameter("@Winver", SqlDbType.Text)).Value = Environment.OSVersion.Version.ToString();
                    cmd.Parameters.Add(new SqlParameter("@MSG", SqlDbType.VarChar, 250)).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@NERROR", SqlDbType.Int)).Direction = ParameterDirection.Output;

                    // Abrir la conexión si está cerrada
                    if (sqt1.State == ConnectionState.Closed)
                        sqt1.Open();

                    // Ejecutar el procedimiento almacenado
                    cmd.ExecuteNonQuery();

                    // Evaluar el parámetro de salida
                    if (cmd.Parameters["@NERROR"].Value.ToString() == "1")
                    {
                        MessageBox.Show(cmd.Parameters["@MSG"].Value.ToString(), "PROFIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Log.Error(cmd.Parameters["@MSG"].Value.ToString());
                        return;
                    }
                    else
                    {
                        Log.Error(cmd.Parameters["@MSG"].Value.ToString());
                        MessageBox.Show(cmd.Parameters["@MSG"].Value.ToString(), "PROFIL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Panel1.Visible = false;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex , ex.Message);
            }
            finally
            {
                if (sqt1.State == ConnectionState.Open)
                    sqt1.Close();
            }

        }

        
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

            SqlConnection sqt1 = new SqlConnection(connection_String);

            

            vs_Host = System.Environment.MachineName;
            vs_MacAddres = getMacAddress();

            //SqlCommand CMD = new SqlCommand("U_SP_LISVFHOST", OCN);
            SqlCommand CMD = new SqlCommand("U_SP_LISVFHOST", sqt1);

            CMD.Connection = sqt1;

            CMD.CommandType = CommandType.StoredProcedure;
            CMD.Parameters.Add(new SqlParameter("@namehost", SqlDbType.Text)).Value = System.Environment.MachineName;
            CMD.Parameters.Add(new SqlParameter("@MAcAddres", SqlDbType.Text)).Value = getMacAddress();
            CMD.Parameters.Add(new SqlParameter("@MSG", SqlDbType.VarChar, 250)).Direction = ParameterDirection.Output;
            CMD.Parameters.Add(new SqlParameter("@NERROR", SqlDbType.Int)).Direction = ParameterDirection.Output;

            if (sqt1.State == ConnectionState.Open)
                sqt1.Close();

            sqt1.Open();

            try
            {
                SqlDataAdapter DAP = new SqlDataAdapter(CMD);
                int XTSHOST;

                DAP.Fill(dts, "host");

                XTSHOST = Convert.ToInt32(dts.Tables["host"].Rows[0].ItemArray[0]);

                switch (XTSHOST)
                {
                    case 1:
                        TextBox1.Text = System.Environment.OSVersion.Platform.ToString();
                        TextBox2.Text = System.Environment.OSVersion.Version.ToString();
                        TextBox3.Text = vs_MacAddres;
                        TextBox4.Text = vs_Host;
                        TextBox5.Text = RetIPAddress(GetHostName());
                        Panel1.Visible = true;
                        break;
                    default:
                        SqlDataAdapter dap0 = new SqlDataAdapter("SELECT IDsede FROM ofibhost WHERE [MacAddres] = '" + vs_MacAddres + "' AND [NameHost] = '" + vs_Host + "'", sqt1);
                        dap0.SelectCommand.CommandType = CommandType.Text;
                        dap0.Fill(dts, "vIDSEDE");

                        DataTable dt0 = dts.Tables["vIDSEDE"];
                        lbl_sede.DataBindings.Add("Text", dts.Tables["vIDSEDE"], "IDsede");
                        vs_sede = lbl_sede.Text;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Log.Error(ex, ex.Message);
            }
            finally
            {
                //OCN.Close();
                sqt1.Close();
            }

            // Importación del código y nombre de empleados para el combobox de usuarios
            try
            {
                SqlDataAdapter DAP_User = new SqlDataAdapter("SELECT Code, Name AS 'Empleado', ISNULL(ISADM, '-') AS 'ISADM' FROM OFIBEMPL INNER JOIN OFIBUSER ON Code = Id_User WHERE ISNULL(INACTIVO, '') <> 'Y'", sqt1);
                DAP_User.SelectCommand.CommandType = CommandType.Text;
                DAP_User.Fill(dts, "tEmpl");

                cmbUser.DataSource = dts.Tables["tEmpl"];
                cmbUser.DisplayMember = "Empleado";
                cmbUser.ValueMember = "Code";

                vs_isADM = Label5.DataBindings.Add("Text", dts.Tables["tEmpl"], "ISADM").ToString();

                SqlDataAdapter DAP_Area = new SqlDataAdapter("SELECT Code, Descripcion AS 'Area' FROM OFIBAREA WHERE locked <> 'Y'", sqt1);
                DAP_Area.SelectCommand.CommandType = CommandType.Text;
                DAP_Area.Fill(dts, "tArea");

                cmbArea.DataSource = dts.Tables["tArea"];
                cmbArea.DisplayMember = "Area";
                cmbArea.ValueMember = "Code";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Log.Error(ex, ex.Message);
            }
        }

        // Métodos auxiliares (si los tienes definidos)
        private string getMacAddress()
        {
            // Implementación del método para obtener la dirección MAC
            return "00:00:00:00:00"; // Este es solo un ejemplo
        }

        private string RetIPAddress(string hostName)
        {
            // Implementación para obtener la IP (si es necesario)
            return "127.0.0.1"; // Este es solo un ejemplo
        }

        private string GetHostName()
        {
            // Implementación para obtener el nombre del host
            return "localhost"; // Este es solo un ejemplo
        }



    
    }
}
