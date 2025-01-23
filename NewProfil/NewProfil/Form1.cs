using Serilog;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Text.RegularExpressions;
using static Pesaje.AreaCodeResolver;
using System.Text;
using System.Globalization;


namespace Pesaje
{


    public partial class Form1 : Form
    {

        string idarea = "TC";

        DataSet dts = new DataSet();
        public string scode, sname, sumed;
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd2 = new SqlCommand();

        static int contador1 = 0;
        static string lastvalue = string.Empty;

        public static SerialPort serialport2;
        public static Thread balanceThread;
        static Stopwatch stopwatch;
        string miVariable = string.Empty;

        string appConfigKey = string.Empty;
        string appConfigHabilitado = string.Empty;
        string appConfigUbicacion = string.Empty;
        string appConfigModelo = string.Empty;
        string appConfigFuncion = string.Empty;

        StringBuilder dataBuffer = new StringBuilder();

        string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

        //public string connection_String = ConfigurationManager.ConnectionStrings["logFile"].ConnectionString;

        string connection_String = ConfigurationManager.ConnectionStrings["conexiondb"].ConnectionString;

        public event EventHandler MiEvento;

        public string Sede { get; set; }
        public string Area { get; set; }
        //public string Operario { get; set; }




        private void Form1_Load(object sender, EventArgs e)
        {
            //

            tb_sede.Text = Sede;
            tb_area.Text = Area;
            

            //string ba23= va1_("102.0kg");

            Log.Information("ini load");

            CargarDatosEnComboBox();
            CargoDatos();

            miVariable = ConfigurationManager.AppSettings["cantidadCopia"];

            lb_cantCopia.Text = miVariable;

            iniciar_pesaje_click(this, EventArgs.Empty);
        }


        public Form1()
        {
            serialport2 = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);

            //Log.Logger = new LoggerConfiguration()
            //.WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
            //    .CreateLogger();

            Directory.CreateDirectory(logDirectory);

            Log.Logger = new LoggerConfiguration()
            .WriteTo.File(Path.Combine(logDirectory, "AppLog-.txt"), rollingInterval: RollingInterval.Day)
            .CreateLogger();

            InitializeComponent();

            //Log.Logger = new LoggerConfiguration()
            //.WriteTo. File("Logs/log.txt", rollingInterval: RollingInterval.Day)  // El archivo de logs será "log.txt" y se rotará por día
            //.CreateLogger();


            //CargarDatosEnComboBox();
            //CargoDatos();    

        }

        // Método para leer los datos de la balanza en un subproceso
        private void ListenToBalance()
        {
            string dataIn = string.Empty;
            DateTime lastReceivedTime = DateTime.Now;
            DateTime lastDataTime = DateTime.Now;
            string lastValidData = string.Empty;

            string data2 = string.Empty;
            string datosrespo = string.Empty;



            // INI

            var balanzasConfig = ConfigurationManager.GetSection("BalanzasConfig") as NameValueCollection;

            if (balanzasConfig != null)
            {
                foreach (string key in balanzasConfig.AllKeys)
                {
                    string value = balanzasConfig[key];
                    var attributes = value.Split(';')
                                          .Select(attr => attr.Split('='))
                                          .ToDictionary(parts => parts[0], parts => parts[1]);

                    //Console.WriteLine($"Balanza: {key}, Habilitado: {attributes["habilitado"]}, Ubicación: {attributes["ubicacion"]}, Modelo: {attributes["modelo"]}, Función: {attributes["funcion"]}");

                    // Si "habilitado" es igual a 'Y', ejecuta un método
                    if (attributes["habilitado"].ToUpper() == "Y")
                    {
                        //EjecutarAccionBalanza(key, attributes["ubicacion"], attributes["modelo"], attributes["funcion"]);
                        appConfigKey = key;
                        appConfigHabilitado = attributes["habilitado"];
                        appConfigUbicacion = attributes["ubicacion"];
                        appConfigModelo = attributes["modelo"];
                        appConfigFuncion = attributes["funcion"];

                        Log.Information($"Balanza configurado en APPCONFIG : {key}, Habilitado: {attributes["habilitado"]}, Ubicación: {attributes["ubicacion"]}, Modelo: {attributes["modelo"]}, Función: {attributes["funcion"]}");

                    }


                }
            }


            //FIN
            try
            {


                if (!serialport2.IsOpen)
                {
                    serialport2.Open();
                    Log.Information("Puerto COM abierto. ");
                }

                Log.Information("Iniciar a escuchar datos desde la balanza. ");

                //AL 02/01/2025 esta balanza se usa en CABOS, LURIN.
                if (appConfigHabilitado == "Y" && appConfigUbicacion == "LURIN" && appConfigModelo == "METTLER_TOLEDO_BBA231")
                {

                    Log.Information("en METTLER_TOLEDO_BBA231");

                    while (true)
                    {

                        data2 = serialport2.ReadExisting();
                        //string data2 = serialport2.by ;

                        //Log.Information(data2);
                        dataIn = data2;

                        //if (!string.IsNullOrEmpty(data2))
                        //if (true)
                        if (!string.IsNullOrEmpty(data2))
                        {
                            ////// Llamar al hilo principal para actualizar la interfaz de usuario

                            //if (dataIn != string.Empty)
                            //if (true)
                            if (dataIn != string.Empty)
                            {

                                string[] lines1 = dataIn.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                                ///ini

                                bool balanzaLurinToledo = true;
                                double temp1 = 0;

                                foreach (var linea in lines1)
                                {
                                    if (linea.StartsWith("Net"))
                                    {

                                        Regex regex = new Regex(@"[-+]?\d*\.\d+|\d+");
                                        Match match = regex.Match(linea);  // Buscamos el patrón en la cadena

                                        if (match.Success)
                                        {
                                            // Convertimos la cadena del número a un double y la devolvemos
                                            temp1 = Convert.ToDouble(match.Value);
                                        }

                                        // Extraer el valor numérico de la línea "Net"


                                        if (temp1 > 1)
                                        {
                                            Log.Information("Data leida por ultima vez " + data2);
                                            Log.Information(data2);
                                            Log.Information("UpdateUI(" + temp1.ToString() + ")");

                                            UpdateUI(temp1.ToString());
                                            //SetText(temp1.ToString());


                                            // vlistBox1,string vlbl_item
                                            contador1 = 0;
                                        }

                                    }
                                }

                                ///fin

                            }

                            datosrespo = dataIn;
                            string[] lines = datosrespo.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                            Thread.Sleep(100);

                        }


                    }

                }

                if (appConfigHabilitado == "Y" && appConfigUbicacion == "CHILCA02" && appConfigModelo == "SUMICO_PRECIX_WEIGHT_MODELO_8513")
                {
                    Log.Information("en SUMICO_PRECIX_WEIGHT_MODELO_8513");

                    while (true)
                    {

                        data2 = serialport2.ReadExisting();

                        Log.Information("data2.. - " + data2.ToString());
                        //string data2 = serialport2.by ;

                        //Log.Information(data2);
                        dataIn = data2;

                        //if (!string.IsNullOrEmpty(data2))
                        //if (true)
                        if (!string.IsNullOrEmpty(data2))
                        {
                            ////// Llamar al hilo principal para actualizar la interfaz de usuario

                            //if (dataIn != string.Empty)
                            //if (true)
                            if (dataIn != string.Empty)
                            {

                                string[] lines1 = dataIn.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                                //
                                //if (true)
                                if (contador1 == 1 && lastvalue == "S")
                                {
                                    //if (contador1 == 1 && lastvalue == "S")

                                    //eliminar


                                    //codigo si va
                                    string[] lines2 = dataIn.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                                    //lines2


                                    if (lines2 != null && lines2.Length > 1)
                                    {
                                        datosrespo = lines2[1].Replace(" ", ""); // Reemplaza los espacios
                                        datosrespo = datosrespo.Replace("GS", "");
                                        datosrespo = datosrespo.Replace("NT", "");

                                        if (Convert.ToDouble(datosrespo) > 1)
                                        {
                                            Log.Information("Data leida por ultima vez " + data2);
                                            Log.Information(data2);
                                            Log.Information("UpdateUI(" + datosrespo.ToString() + ")");
                                            UpdateUI(datosrespo);
                                            contador1 = 0;
                                        }

                                    }


                                }


                                if (lines1 != null && lines1.Length > 0 && !string.IsNullOrEmpty(lines1[0]) && lines1[0] == "S" && contador1 == 0)
                                {
                                    contador1++;
                                    lastvalue = "S";
                                }
                                else
                                {
                                    contador1 = 0;
                                    lastvalue = string.Empty;
                                }



                            }

                            datosrespo = dataIn;


                            string[] lines = datosrespo.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                            Thread.Sleep(100);

                        }


                    }

                }

                //AL 13/01/2025 esta balanza se usa en telares, LURIN.
                if (appConfigHabilitado == "Y" && appConfigUbicacion == "LURIN" && appConfigModelo == "METTLER_TOLEDO_BBA221-3BB60C")
                {
                    Log.Information("en METTLER_TOLEDO_BBA221-3BB60C");

                    while (true)
                    {

                        data2 = serialport2.ReadExisting();


                        //Log.Information("data3x. - " + data2.ToString());
                        //  09012025_1654
                        //ini   09012025_1544

                        string data3 = data2.Trim();

                        if (!string.IsNullOrWhiteSpace(data3))
                        {
                            //Log.Information("data3xx. - " + data3.ToString());
                            dataBuffer.Append(data3); // Acumula los datos

                            // Procesa los datos si están completos (por ejemplo, contienen un número y "kg")
                            if (dataBuffer.ToString().Contains("kg"))
                            {
                                Log.Information("data3.xxx - " + dataBuffer.ToString());

                                string input = dataBuffer.ToString();
                                dataBuffer.Clear(); // Limpia el buffer para el próximo dato


                                //ini
                                Regex regex = new Regex(@"[-+]?\d*\.\d+|\d+");
                                Match match = regex.Match(input);  // Buscamos el patrón en la cadena



                                if (match.Success)
                                {
                                    string value = match.Value;

                                    if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
                                    {

                                        Log.Information("input.ToString() " + input.ToString());
                                        UpdateUI(value.ToString());
                                        //Console.WriteLine($"El valor convertido es: {result}");
                                    }
                                    else
                                    {
                                        Log.Error("error ehn lectura en telares");
                                    }
                                }

                                //fin


                            }
                        }


                    }

                }


            }
            catch (Exception ex)
            {

                Log.Error(ex, "Error en Inicio de pesaje : " + ex.Message + " - " + data2);
                MessageBox.Show($"Error al leer la balanza: {ex.Message}" + " - " + data2);
            }
            finally
            {
                serialport2.Close();
            }
        
        }

        public string va1_ (string g1)
        {

            string vval1 = string.Empty;

            //ini
            Regex regex = new Regex(@"[-+]?\d*\.\d+|\d+");
            Match match = regex.Match(g1);  // Buscamos el patrón en la cadena
            


            if (match.Success)
            {
                string value = match.Value;

                if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
                {


                    UpdateUI(g1.ToString());
                    //Console.WriteLine($"El valor convertido es: {result}");
                }
                else
                {
                    Console.WriteLine("No se pudo convertir el valor a double.");
                }
            }




            //fin

            return vval1;

        }


        // Método para actualizar la interfaz de usuario desde el subproceso
        private static void UpdateUI(string data)
        {

            if (Application.OpenForms["Form1"] != null && Application.OpenForms["Form1"].InvokeRequired)
            {
                Application.OpenForms["Form1"].Invoke(new Action<string>(UpdateUI), data);
            }
            else
            {
                if (Application.OpenForms["Form1"] != null)
                {
                    var form = Application.OpenForms["Form1"];
                    System.Windows.Forms.TextBox textBox = form.Controls["tb_pesoobtenido"] as System.Windows.Forms.TextBox;

                    if (textBox != null)
                    {
                        textBox.Text = data;  // Asigna el valor recibido al TextBox
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el TextBox.");
                    }
                }
            }


        }

        private void CargoDatos()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conexiondb"].ConnectionString;
            idarea = tb_area.Text;

            //CHILCA 2
            tb_sede.Text = Sede;

            try
            {

                AreaCodeResolver resolver = new AreaCodeResolver();

                //string sentencia = "Select ItemNo, ItemName from OPROM0 " +
                //            "inner join SBO_Fibrafil..OITM on Itemcode collate SQL_Latin1_General_CP850_CI_AS = ItemNo collate SQL_Latin1_General_CP850_CI_AS " +
                //            "where U_FIB_AREA = '" + resolver.GetCodeByDescripcion(tb_area.Text) + "' and U_FIB_SEDE = '" + tb_sede.Text + "' and U_fib_telar = '" + cbMaquinaria.SelectedValue + "' " +
                //            "order by RECORDKEY";

                string sentencia = "Select ItemNo, ItemName from OPROM0 " +
                            "inner join SBO_FIBRAFIL_TEST_23_12_24..OITM on Itemcode collate SQL_Latin1_General_CP850_CI_AS = ItemNo collate SQL_Latin1_General_CP850_CI_AS " +
                            "where U_FIB_AREA = '" + resolver.GetCodeByDescripcion(tb_area.Text) + "' and U_FIB_SEDE = '" + tb_sede.Text + "' and U_fib_telar = '" + cbMaquinaria.SelectedValue + "' " +
                            "order by RECORDKEY";


                //string sentencia = "Select ItemNo, ItemName from OPROM0 " +
                //            "inner join SBO_Fibrafil..OITM on Itemcode collate SQL_Latin1_General_CP850_CI_AS = ItemNo collate SQL_Latin1_General_CP850_CI_AS " +
                //            "where U_FIB_AREA = '" + idarea + "' and U_FIB_SEDE = '" + tb_sede.Text + "' and U_fib_telar = '" + cbMaquinaria.SelectedValue + "' " +
                //            "order by RECORDKEY";



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
            catch (Exception ex)
            {

                Log.Error(ex, ex.Message);
            }


        }
        private void Contadores()
        {
            try
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
            catch (Exception ex)
            {
                Log.Error(ex, ex.ToString());

            }



        }


        private void conectarPuertoCom()
        {




        }


        private void iniciar_pesaje_click(object sender, EventArgs e)
        {
            Log.Information("Iniciar pesaje");

            // Crea y comienza el subproceso para escuchar continuamente
            balanceThread = new Thread(new ThreadStart(ListenToBalance));
            balanceThread.IsBackground = true; // Asegura que el subproceso termine cuando la app se cierre
            balanceThread.Start();



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


            DataSet ds = new DataSet();

            string sentencia1 = string.Empty;
            sentencia1 = "SELECT Code, Descripcion AS Maquina FROM OFIBMAC WHERE STDMAC = 'A' AND u_fib_sede = '" + tb_sede.Text + "'";
            // COMBO MAQUINA
            SqlDataAdapter dapMac = new SqlDataAdapter(sentencia1, connectionString);
            dapMac.Fill(ds, "tMac");
            cbMaquinaria.DataSource = ds.Tables["tMac"];
            cbMaquinaria.DisplayMember = "Maquina";
            cbMaquinaria.ValueMember = "Code";

            //INI _ nuevo 17122024

            SqlDataAdapter dap_ope = new SqlDataAdapter(
            "SELECT T0.Code, T0.Name FROM OFIBEMPL T0 " +
            "INNER JOIN OFIBAREA T1 ON T0.U_FIB_AREA = T1.CODE " +
            "WHERE T0.u_FIB_CARGO = 'O' AND T1.PP = 'Y' AND ISNULL(T0.INACTIVO, 'N') <> 'Y'",connectionString);

            dap_ope.Fill(ds, "Operario");
            cmb_ope.DataSource = ds.Tables["Operario"];
            cmb_ope.DisplayMember = "Name";
            cmb_ope.ValueMember = "Code";

            // COMBOBOX AYUDANTE
            SqlDataAdapter dap_ayud = new SqlDataAdapter(
                "SELECT T0.Code, T0.Name FROM OFIBEMPL T0 " +
                "INNER JOIN OFIBAREA T1 ON T0.U_FIB_AREA = T1.CODE " +
                "WHERE T0.u_FIB_CARGO = 'A' AND T1.PP = 'Y' AND ISNULL(T0.INACTIVO, 'N') <> 'Y'",connectionString);


            dap_ayud.Fill(ds, "Ayudante");
            cmb_ayud.DataSource = ds.Tables["Ayudante"];
            cmb_ayud.DisplayMember = "Name";
            cmb_ayud.ValueMember = "Code";

            //FIN _ nuevo 17122024

        }

        private void event_clickAnadirItem(object sender, EventArgs e)
        {



        }

        private void bt_anadir_Click(object sender, EventArgs e)
        {
            try
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
                            if (tb_codigoarticulo.Text.Trim() == string.Empty || tb_descArticulo.Text.Trim() == string.Empty)
                            {
                                MessageBox.Show("Codigo de Item inválido", "PROFIL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {


                                DatosInsUpd("U_SP_FIB_INS_OPROM0", 0, false);
                                if (sqt3.State == ConnectionState.Closed) sqt3.Open();
                                try
                                {
                                    cmd.Connection = sqt3;
                                    cmd.ExecuteNonQuery();

                                    Log.Information("dato devuelto cmd.Parameters[msg].Value.ToString() = " + cmd.Parameters["@msg"].Value.ToString());

                                    if (cmd.Parameters["@msg"].Value.ToString() != "")
                                    {
                                        MessageBox.Show(cmd.Parameters["@msg"].Value.ToString(), "PROFIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        Log.Error(cmd.Parameters["@msg"].Value.ToString());
                                    }

                                    Log.Information("Se agrego item con exito");
                                }
                                catch (Exception ex)
                                {
                                    Log.Error(ex, ex.Message);
                                    MessageBox.Show(ex.Message, "FIBRAFIL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                }

                                CargoDatos();
                            }



                        }
                    }

                    tb_codigoarticulo.Text = string.Empty;
                    tb_descArticulo.Text = string.Empty;
                    tb_codigoarticulo.Focus();
                    tb_pesoobtenido.Text = string.Empty;

                }

            }
            catch (Exception ex)
            {

                Log.Error(ex, " Error : " + ex.Message);
            }

        }

        public void DatosInsUpd(string NameProced, double db_peso, bool is_Scrap)
        {
            //U_FIB_PROD_MAS


            if (NameProced == "U_SP_FIB_INS_OPROM0")
            {
                Log.Information("usando SP U_SP_FIB_INS_OPROM0");


                string cnc3 = ConfigurationManager.ConnectionStrings["conexiondb"].ConnectionString;
                SqlConnection sqt3 = new SqlConnection(cnc3);

                try
                {

                    AreaCodeResolver resolver = new AreaCodeResolver();


                    //string code = resolver.GetCodeByDescripcion(descripcion);


                    cmd.Parameters.Clear();
                    cmd.Connection = sqt3;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = NameProced;
                    cmd.Parameters.Add(new SqlParameter("@ItemNo", SqlDbType.Text)).Value = tb_codigoarticulo.Text; // Código de item
                    cmd.Parameters.Add(new SqlParameter("@ProducQuantity", SqlDbType.Decimal)).Value = 0; // Cant producida, se manda 0
                    cmd.Parameters.Add(new SqlParameter("@ProducWeight", SqlDbType.Decimal)).Value = 0; // Peso producido, se manda 0
                    cmd.Parameters.Add(new SqlParameter("@COMMENT", SqlDbType.Text)).Value = string.Empty; // Comentario no implementado

                    ////cmd.Parameters.Add(new SqlParameter("@U_FIB_OPERARIO", SqlDbType.Text)).Value = tb_codeOperario.Text;  // ComboBox5.SelectedValue() //codigo de operario    // hardcode
                    ////cmd.Parameters.Add(new SqlParameter("@U_FIB_AYUDANTE", SqlDbType.Text)).Value = "647";

                    // ", SqlDbType.Text)).Value = cmb_ope.SelectedValue;


                    cmd.Parameters.Add(new SqlParameter("@U_FIB_OPERARIO", SqlDbType.Text)).Value = cmb_ope.SelectedValue;
                    cmd.Parameters.Add(new SqlParameter("@U_FIB_AYUDANTE", SqlDbType.Text)).Value = cmb_ayud.SelectedValue;



                    cmd.Parameters.Add(new SqlParameter("@U_FIB_TELAR", SqlDbType.Text)).Value = cbMaquinaria.SelectedValue;
                    //quizas caiga
                    cmd.Parameters.Add(new SqlParameter("@U_FIB_AREA", SqlDbType.Text)).Value = resolver.GetCodeByDescripcion(tb_area.Text);
                    cmd.Parameters.Add(new SqlParameter("@U_FIB_SEDE", SqlDbType.Text)).Value = tb_sede.Text;
                    cmd.Parameters.Add(new SqlParameter("@HOST", SqlDbType.Text)).Value = Environment.MachineName;
                    cmd.Parameters.Add(new SqlParameter("@Createfor", SqlDbType.Text)).Value = "152";
                    cmd.Parameters.Add(new SqlParameter("@MSG", SqlDbType.VarChar, 250)).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@FK", SqlDbType.BigInt)).Direction = ParameterDirection.Output;

                }
                catch (Exception ex)
                {
                    Log.Error(ex, " Error : " + ex.Message);
                    MessageBox.Show(ex.Message);
                }
            }

            if (NameProced == "U_SP_FIB_DEL_OPROM")
            {
                Log.Information("usando SP U_SP_FIB_DEL_OPROM");

                string cnc5 = ConfigurationManager.ConnectionStrings["conexiondb"].ConnectionString;
                SqlConnection sqt5 = new SqlConnection(cnc5);

                cmd.Parameters.Clear();
                cmd.Connection = sqt5;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = NameProced;

                decimal d_peso = 0;
                long i_nline=0;

                try
                {
                    //// valor enviado es false, asi que va al else
                    if (is_Scrap)
                    {


                        i_nline = string.IsNullOrEmpty(lbl_linS.Text) ? 0 : Convert.ToInt64(lbl_linS.Text);
                        d_peso = listBox3.SelectedValue == null ? 0 : Convert.ToDecimal(listBox3.SelectedValue);
                    }
                    else
                    {
                        i_nline = string.IsNullOrEmpty(lbl_idlin.Text) ? 0 : Convert.ToInt64(lbl_idlin.Text);
                        d_peso = listBox2.SelectedValue == null ? 0 : Convert.ToDecimal(listBox2.SelectedValue);
                    }
                }
                catch (Exception ex)
                {

                    Log.Error(ex, "Error : " + ex.Message);
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


                cmd.Parameters.Add(new SqlParameter("@IndexPeso", SqlDbType.Int)).Value = i_nline;
                //cmd.Parameters.Add(new SqlParameter("@IndexPeso", SqlDbType.Int)).Value = 0;
                cmd.Parameters.Add(new SqlParameter("@U_FIB_SEDE", SqlDbType.Text)).Value = tb_sede.Text;
                cmd.Parameters.Add(new SqlParameter("@U_FIB_TELAR", SqlDbType.VarChar)).Value = cbMaquinaria.SelectedValue;

                var outputParam = new SqlParameter("@MSG", SqlDbType.VarChar, 250) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(outputParam);

                cmd.Parameters.Add(new SqlParameter("@opt", SqlDbType.Int)).Value = db_peso;



            }

            if (NameProced == "U_SP_FIB_INS_OPROM1")
            {
                Log.Information("usando SP U_SP_FIB_INS_OPROM1");

                string cnc8 = ConfigurationManager.ConnectionStrings["conexiondb"].ConnectionString;
                SqlConnection sqt8 = new SqlConnection(cnc8);

                try
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = sqt8;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = NameProced;

                    //string descrItemNo = GetSelectedValue()?.ToString();
                    //string invokergetComboBoxMaquinaria =  GetComboBoxSelectedValue().ToString();
                    //string invokerSede = GetTextBoxText();

                    //// Configuración de los parámetros
                    //cmd.Parameters.Add(new SqlParameter("@ItemNo", SqlDbType.Text)).Value = listBox1.SelectedValue.ToString(); // Código de item
                    cmd.Parameters.Add(new SqlParameter("@ItemNo", SqlDbType.Text)).Value = listBox1.SelectedValue.ToString(); //descrItemNo;
                    cmd.Parameters.Add(new SqlParameter("@ProducWeight", SqlDbType.Decimal)).Value = db_peso; // Peso producido, se manda 0 para registrar items
                    cmd.Parameters.Add(new SqlParameter("@U_FIB_SEDE", SqlDbType.VarChar)).Value = tb_sede.Text;// invokerSede;
                    cmd.Parameters.Add(new SqlParameter("@U_FIB_TELAR", SqlDbType.VarChar)).Value = cbMaquinaria.SelectedValue;
                    cmd.Parameters.Add(new SqlParameter("@MSG", SqlDbType.VarChar, 250)).Direction = ParameterDirection.Output;
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error : " + ex.Message);
                    MessageBox.Show(ex.Message);
                }
            }

            if (NameProced == "U_FIB_PROD_MAS")
            {
                Log.Information("usando SP U_FIB_PROD_MAS");

                //string cnc8 = ConfigurationManager.ConnectionStrings["conexiondb"].ConnectionString;
                SqlConnection sqt8 = new SqlConnection(connection_String);

                try
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = sqt8;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = NameProced;


                    //cmd.Parameters.Add(new SqlParameter("@U_FIB_OPERARIO", SqlDbType.Text)).Value = cmb_ope.SelectedValue;
                    //cmd.Parameters.Add(new SqlParameter("@U_FIB_AYUDANTE", SqlDbType.Text)).Value = cmb_ayud.SelectedValue;

                    cmd.Parameters.Add(new SqlParameter("@Item", SqlDbType.Text)).Value = listBox1.SelectedValue.ToString(); // Código de ítem


                    cmd.Parameters.Add(new SqlParameter("@Operario", SqlDbType.VarChar)).Value = cmb_ope.SelectedValue; // Operario seleccionado
                    cmd.Parameters.Add(new SqlParameter("@Ayudante", SqlDbType.VarChar)).Value = cmb_ayud.SelectedValue;//cmb_ayud.SelectedValue; // Ayudante seleccionado



                    cmd.Parameters.Add(new SqlParameter("@Maquina", SqlDbType.VarChar)).Value = cbMaquinaria.SelectedValue; // Máquina seleccionada
                    cmd.Parameters.Add(new SqlParameter("@sede", SqlDbType.VarChar)).Value = tb_sede.Text; // Sede
                    cmd.Parameters.Add(new SqlParameter("@MSG", SqlDbType.VarChar, 250)).Direction = ParameterDirection.Output; // Mensaje de salida
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error : " + ex.Message.ToString());
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }



        private string GetTextBoxText()
        {
            if (tb_sede.InvokeRequired)
            {
                // Usamos Invoke para obtener Text en el subproceso de la interfaz de usuario
                return (string)tb_sede.Invoke(new Func<string>(() => tb_sede.Text));
            }
            else
            {
                // Si estamos en el subproceso de la interfaz de usuario, obtenemos directamente
                return tb_sede.Text;
            }
        }

        private object GetComboBoxSelectedValue()
        {
            if (cbMaquinaria.InvokeRequired)
            {
                // Usamos Invoke para obtener SelectedValue en el subproceso de la interfaz de usuario
                return cbMaquinaria.Invoke(new Func<object>(() => cbMaquinaria.SelectedValue));
            }
            else
            {
                // Si estamos en el subproceso de la interfaz de usuario, obtenemos directamente
                return cbMaquinaria.SelectedValue;
            }
        }

        private object GetSelectedValue()
        {
            if (listBox1.InvokeRequired)
            {
                // Usamos Invoke para obtener SelectedValue en el subproceso de la interfaz de usuario
                return listBox1.Invoke(new Func<object>(() => listBox1.SelectedValue));
            }
            else
            {
                // Si estamos en el subproceso de la interfaz de usuario, obtenemos directamente
                return listBox1.SelectedValue;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // asdasd123111
                //lbl_item.Text = listBox1.Text;
                lbl_item.Text = listBox1.Text != null ? listBox1.Text : string.Empty;
                CargaPesos();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error  : " + ex.Message);
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

            Log.Information("DelItem Eliminación de Item ...");

            // Verifica si ListBox2 tiene elementos
            if (listBox2.Items.Count > 0)
            {
                Log.Information("Para eliminar un ítem, primero elimine todos sus pesos asociados. ");

                MessageBox.Show("Para eliminar un ítem, primero elimine todos sus pesos asociados.",
                                "PROFIL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                Log.Information("DatosInsUpd U_SP_FIB_DEL_OPROM ");

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

                string value = listBox1.SelectedValue != null
                ? listBox1.SelectedValue.ToString()
                : string.Empty;

                string query4 = string.Empty;

                query4 = "Select Isnull(Convert(decimal(14,2), pesobob,2),0.0) As 'PesoBob', idlin as 'Lin' " +
                    "from OPROM1 T1 inner join OPROM0 T0 on T1.recordkey = T0.recordkey " +
                    "where Isnull(isScrap,'')<>'Y' and T0.ItemNo = '" + value +
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

                string value2 = listBox1.SelectedValue != null
                ? listBox1.SelectedValue.ToString()
                : string.Empty;

                string query5 = string.Empty;
                // Configuración del segundo SqlDataAdapter para ListBox3

                query5 = "Select Isnull(Convert(decimal(14,2), pesobob,2),0.0) As 'PesoBob', idlin as 'Lin' " +
                    "from OPROM1 T1 inner join OPROM0 T0 on T1.recordkey = T0.recordkey " +
                    "where Isnull(isScrap,'')='Y' and T0.ItemNo = '" + value2 +
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

                Log.Error(ex, "Error en cargar peso : " + ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


        }

        private void imprimirticket_Click(object sender, EventArgs e)
        {


            //string DataIn = string.Empty;
            ////datos recibidos por la balanza y listos para imprimir.
            //DataIn = "770.02";

            //try
            //{
            //    if (tb_sede.Text == "02")
            //    {
            //        SetText(DataIn);
            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        private int GetSelectedIndex()
        {
            if (listBox1.InvokeRequired)
            {
                // Usamos Invoke para obtener SelectedIndex en el subproceso de la interfaz de usuario
                return (int)listBox1.Invoke(new Func<int>(() => listBox1.SelectedIndex));
            }
            else
            {
                // Si estamos en el subproceso de la interfaz de usuario, obtenemos directamente
                return listBox1.SelectedIndex;
            }
        }

        private void SetText(string text)
        {
            string cnc7 = ConfigurationManager.ConnectionStrings["conexiondb"].ConnectionString;
            SqlConnection sqt7 = new SqlConnection(cnc7);
            //GetSelectedIndex()


            if (listBox1.SelectedIndex >= 0)
            {
                // Lógica para manejar el índice seleccionado

                if (listBox1.SelectedIndex >= 0)
                //if (GetSelectedIndex() >= 0)
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

                        //DatosInsUpd("U_SP_FIB_INS_OPROM1", Convert.ToDouble(text), false);
                        DatosInsUpd("U_SP_FIB_INS_OPROM1", Convert.ToDouble(text), false);

                        cmd.Parameters.Clear();
                        cmd.Connection = sqt7;
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.CommandText = "U_SP_FIB_INS_OPROM1";
                        cmd.CommandText = "U_SP_FIB_INS_OPROM1";


                        ////GetSelectedValue()?.ToString()
                        cmd.Parameters.Add(new SqlParameter("@ItemNo", SqlDbType.VarChar)).Value = listBox1.SelectedValue.ToString(); // Código de item
                                                                                                                                      //cmd.Parameters.Add(new SqlParameter("@ItemNo", SqlDbType.Text)).Value = GetSelectedValue()?.ToString(); // Código de item

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

                        cmd.Parameters.Add(new SqlParameter("@U_FIB_SEDE", SqlDbType.VarChar)).Value = tb_sede.Text;
                        cmd.Parameters.Add(new SqlParameter("@U_FIB_TELAR", SqlDbType.VarChar)).Value = cbMaquinaria.SelectedValue;
                        cmd.Parameters.Add(new SqlParameter("@MSG", SqlDbType.VarChar, 250)).Direction = ParameterDirection.Output;

                        string a = string.Empty;
                        a = cmd.Parameters["@ItemNo"].Value + "-";
                        a = cmd.Parameters["@ProducWeight"].Value + "-" + a;
                        a = cmd.Parameters["@U_FIB_SEDE"].Value + "-" + a;
                        a = cmd.Parameters["@U_FIB_TELAR"].Value + "-" + a;
                        a = cmd.Parameters["@MSG"].Value + "-" + a;



                        // Parámetros para el comando
                        // Ejecutar comando
                        if (sqt7.State == ConnectionState.Closed)
                            sqt7.Open();
                        cmd.ExecuteNonQuery();
                        CargaPesos();

                        string retorno2 = cmd.Parameters["@MSG"].Value.ToString();
                        Log.Information("retorno : " + retorno2);

                        if (retorno2.ToString().Trim() == string.Empty)
                        {

                            //LURIN CABOS o TELARES -- impresora TSC MODEL : TE200
                            if (appConfigHabilitado == "Y" && (appConfigUbicacion == "LURIN") && (appConfigModelo == "METTLER_TOLEDO_BBA231" || appConfigModelo == "METTLER_TOLEDO_BBA221-3BB60C"))
                            {
                                Log.Information("ImprimeCodebar1 : " + retorno2);

                                ImprimeCodebar1_sinCodBarr(retorno2, Convert.ToDecimal(text), listBox1.SelectedValue.ToString(), lbl_item.Text);//listBox1.SelectedValue.ToString() , lbl_item.Text) ;

                            }
                            else
                            {

                                retorno2 = "BD : NO SE OBTUVO CODIGO";

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
                                                                                mensajeLinea6,
                                                                                retorno2
                                                                                );

                                // Imprimir el ticket directamente sin mostrar la ventana
                                ticketPrinter.PrintTicket2();

                            }


                        }
                        else
                        {
                            //if (rb_pofic.Checked)

                            //
                            //LURIN CABOS o TELARES -- impresora TSC MODEL : TE200
                            if (appConfigHabilitado == "Y" && appConfigUbicacion == "LURIN" && (appConfigModelo == "METTLER_TOLEDO_BBA231" || appConfigModelo == "METTLER_TOLEDO_BBA221-3BB60C"))
                            {
                                Log.Information("ImprimeCodebar1 : " + retorno2);

                                ImprimeCodebar1(retorno2, Convert.ToDecimal(text), listBox1.SelectedValue.ToString(), lbl_item.Text, lb_cantCopia.Text);//listBox1.SelectedValue.ToString() , lbl_item.Text) ;

                            }
                            else
                            {

                                if (true)
                                {
                                    //Imprime_Codebar(cmd.Parameters["@MSG"].Value.ToString(), Convert.ToDecimal(text.Trim()));

                                    int numeroDeCopiast = ConvertirACantidadValida(lb_cantCopia.Text, 1);

                                    for (int i = 0; i < numeroDeCopiast; i++)
                                    {
                                        Log.Information($"Imprimiendo copia {i + 1} de {numeroDeCopiast}");
                                        // clsprinter.Class1.SendStringToPrinter("PROFIL", etiqueta); // Llamada al método de impresión

                                        string mensajeLinea1 = "NPD : PM                                                                          FP : " + DateTime.Now.ToString();
                                        string mensajeLinea2 = retorno2;
                                        string mensajeLinea3 = retorno2;
                                        string mensajeLinea4 = text.ToString() + " KG";
                                        string mensajeLinea5 = "ID ITEM   : " + listBox1.SelectedValue.ToString();
                                        string mensajeLinea6 = "DSC ITEM  : " + lbl_item.Text;

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

                            }





                        }
                        //retorno2 = "012410156806300";

                    }
                    catch (Exception ex)
                    {

                        Log.Error(ex, " - " + ex.Message);
                    }

                }
                else
                {
                    MessageBox.Show("Antes de pesar debe seleccionar un ítem.", "PROFIL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }



            }

        }

        private static void ImprimeCodebar1(string codebar, decimal peso, string vlistBox1, string vlbl_item, string cantCopiat)
        {
            try
            {
                // Ruta del archivo de etiqueta
                string ruta;

                // Verificar la selección del radio button

                //if (rdb_no.Checked)
                if (false)
                {
                    ruta = Application.StartupPath + "\\eti_SPeso.prn";
                }
                else
                {
                    ruta = Application.StartupPath + "\\eti_CPeso.prn";
                }

                // Leer el contenido del archivo
                string etiqueta;
                using (StreamReader sr = new StreamReader(ruta))
                {
                    etiqueta = sr.ReadToEnd();
                }

                // Reemplazar los valores de la etiqueta
                etiqueta = etiqueta.Replace("[NPD]", "PM");
                etiqueta = etiqueta.Replace("[FP]", DateTime.Today.ToShortDateString());
                etiqueta = etiqueta.Replace("[IDITEM]", vlistBox1);//"Item1");//listBox1.SelectedValue.ToString()); //.SelectedValue.ToString()); 


                //INI 
                // Dividir la descripción en líneas de hasta 35 caracteres
                string descripcionCompleta = vlbl_item.Trim();
                int maxCharsPerLine = 35;
                var lineasDescripcion = Regex.Matches(descripcionCompleta, ".{1," + maxCharsPerLine + "}")
                                             .Cast<Match>()
                                             .Select(m => m.Value.Trim())
                                             .ToList();

                // Reemplazar dinámicamente las líneas en la etiqueta
                etiqueta = etiqueta.Replace("[DESPRO1]", lineasDescripcion.ElementAtOrDefault(0) ?? "");
                etiqueta = etiqueta.Replace("[DESPRO2]", lineasDescripcion.ElementAtOrDefault(1) ?? "");

                Log.Information(etiqueta);
                //FIN

                etiqueta = etiqueta.Replace("[codbar]", codebar);

                // Para el área de cabos
                //if (rdb_si.Checked)
                if (true)
                {
                    etiqueta = etiqueta.Replace("[PESO]", peso.ToString("F2"));
                }

                etiqueta = etiqueta.Replace("\\[\"\"]", "''");

                // Imprimir usando la DLL clsprinter y SendStringToPrinter
                Log.Information("Inicio imprimir ");
                Log.Information(etiqueta);


                int numeroDeCopias = ConvertirACantidadValida(cantCopiat, 1);

                for (int i = 0; i < numeroDeCopias; i++)
                {
                    // Log de la copia actual
                    Log.Information($"Imprimiendo copia {i + 1} de {numeroDeCopias}");

                    // Enviar la etiqueta a la impresora
                    clsprinter.Class1.SendStringToPrinter("PROFIL", etiqueta);
                }
                

                // Mensaje opcional
                // MessageBox.Show("Etiqueta Impresa", "FIBRAFIL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Log.Information(ex, ex.ToString());
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static int ConvertirACantidadValida(string cantidadTexto, int valorPorDefecto)
        {
            try
            {
                // Intentar convertir directamente si es un número
                if (int.TryParse(cantidadTexto, out int resultado))
                {
                    return resultado;
                }

                // Intentar convertir texto en palabras a números
                switch (cantidadTexto.Trim().ToLower())
                {
                    case "uno": return 1;
                    case "dos": return 2;
                    case "tres": return 3;
                    case "cuatro": return 4;
                    case "cinco": return 5;
                    case "seis": return 6;
                    case "siete": return 7;
                    case "ocho": return 8;
                    case "nueve": return 9;
                    case "diez": return 10;
                    default:
                        Log.Information($"Valor inválido en configuración: {cantidadTexto}. Usando valor por defecto ({valorPorDefecto}).");
                        return valorPorDefecto;
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Error al procesar la cantidad de copias: {ex.Message}. Usando valor por defecto ({valorPorDefecto}).");
                return valorPorDefecto;
            }
        }

        private static void ImprimeCodebar1_sinCodBarr(string codebar, decimal peso, string vlistBox1, string vlbl_item)
        {
            try
            {
                // Ruta del archivo de etiqueta
                string ruta;

                // Verificar la selección del radio button

                //if (rdb_no.Checked)
                if (false)
                {
                    ruta = Application.StartupPath + "\\eti_SPeso.prn";
                }
                else
                {
                    ruta = Application.StartupPath + "\\eti_CPeso.prn";
                }

                // Leer el contenido del archivo
                string etiqueta;
                using (StreamReader sr = new StreamReader(ruta))
                {
                    etiqueta = sr.ReadToEnd();
                }

                // Reemplazar los valores de la etiqueta
                etiqueta = etiqueta.Replace("[NPD]", "PM");
                etiqueta = etiqueta.Replace("[FP]", DateTime.Today.ToShortDateString());
                etiqueta = etiqueta.Replace("[IDITEM]", "SIN CODIGO DE BARRA");//"Item1");//listBox1.SelectedValue.ToString()); //.SelectedValue.ToString()); 
                etiqueta = etiqueta.Replace("[DESPRO]", "SIN CODIGO DE BARRA");// lbl_item.Text);
                etiqueta = etiqueta.Replace("[codbar]", "0");

                // Para el área de cabos
                //if (rdb_si.Checked)
                if (true)
                {
                    etiqueta = etiqueta.Replace("[PESO]", peso.ToString());
                }

                etiqueta = etiqueta.Replace("\\[\"\"]", "''");

                // Imprimir usando la DLL clsprinter y SendStringToPrinter
                Log.Information("Inicio imprimir ");
                clsprinter.Class1.SendStringToPrinter("PROFIL", etiqueta);

                // Mensaje opcional
                // MessageBox.Show("Etiqueta Impresa", "FIBRAFIL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Log.Information(ex, ex.ToString());
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void listBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Log.Information("Eliminación de Peso... ");

                DelPeso(false);
            }


        }

        private void DelPeso(bool is_Scrap)
        {
            string cnc7 = ConfigurationManager.ConnectionStrings["conexiondb"].ConnectionString;
            SqlConnection sqt7 = new SqlConnection(cnc7);

            DialogResult result = MessageBox.Show("Seguro de eliminar peso?", "PROFIL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                Log.Information("DatosInsUpd U_SP_FIB_DEL_OPROM");

                DatosInsUpd("U_SP_FIB_DEL_OPROM", 2, is_Scrap);

                if (sqt7.State == ConnectionState.Closed) sqt7.Open();
                try
                {
                    cmd.Connection = sqt7;
                    string sq = string.Empty;
                    foreach (SqlParameter param in cmd.Parameters)
                    {
                        sq = ($"{param.ParameterName}: {param.Value}") + " - " + sq;
                    }


                    var itemNoValue = cmd.Parameters["@ItemNo"].Value.ToString();
                    var producWeightValue = cmd.Parameters["@ProducWeight"].Value;
                    var indexPesoValue = cmd.Parameters["@IndexPeso"].Value;
                    var uFIBSEDEValue = cmd.Parameters["@U_FIB_SEDE"].Value.ToString();
                    var uFIBTELARValue = cmd.Parameters["@U_FIB_TELAR"].Value.ToString();
                    //var outputMessage = cmd.Parameters["@msg"].Value.ToString();
                    var optValue = cmd.Parameters["@opt"].Value;

                    cmd.ExecuteNonQuery();

                    Log.Information("DelPeso -  msg " + cmd.Parameters["@msg"].Value.ToString());

                    if (!string.IsNullOrEmpty(cmd.Parameters["@msg"].Value.ToString()))
                    {
                        MessageBox.Show(cmd.Parameters["@msg"].Value.ToString(), "PROFIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    Log.Information(ex, ex.Message.ToString());

                    MessageBox.Show(ex.Message, "FIBRAFIL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                CargaPesos();
            }
        }

        private void tb_pesoobtenido_TextChanged(object sender, EventArgs e)
        {
            if (tb_pesoobtenido.Text == string.Empty)
            {

                return;
            }
            else
            {
                //
                if (Convert.ToDouble(tb_pesoobtenido.Text) > 1)
                {
                    SetText(tb_pesoobtenido.Text);
                    tb_pesoobtenido.Text = string.Empty;
                }

            }
        }

        private void btnBorrarPesos_Click(object sender, EventArgs e)
        {
            

            //string cnc3 = ConfigurationManager.ConnectionStrings["conexiondb"].ConnectionString;
            SqlConnection sqt = new SqlConnection(connection_String);

            int respuesta = Convert.ToInt32(MessageBox.Show("Desea eliminar todos los pesos?", "PROFIL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)); //("¿Desea eliminar todos los pesos?","PROFIL",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);


            if (respuesta == (int)DialogResult.Yes)
            {


                int confirmacion = Convert.ToInt32(MessageBox.Show("Recuerde, de eliminar todos los pesos no podrá recuperarlos, ¿procederá con eliminarlos?",
                        "PROFIL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2));

                //int confirmacion = MessageBox.Show(
                //    "Recuerde, de eliminar todos los pesos no podrá recuperarlos, ¿procederá con eliminarlos?",
                //    "PROFIL",
                //    MessageBoxButtons.YesNo,
                //    MessageBoxIcon.Question,
                //    MessageBoxDefaultButton.Button2
                //);

                if (confirmacion == (int)DialogResult.Yes)
                {
                    // Llamar al método de eliminación de datos
                    DatosInsUpd("U_SP_FIB_DEL_OPROM", 3, false);

                    if (sqt.State == ConnectionState.Closed)
                    {
                        sqt.Open();
                    }

                    try
                    {

                        cmd.Connection = sqt;
                        cmd.ExecuteNonQuery();


                        Log.Information("Borrar los pesos");

                        string temp = cmd.Parameters["@msg"].Value.ToString();
                        // Verifica si el parámetro de salida @msg tiene contenido
                        if (!string.IsNullOrEmpty(cmd.Parameters["@msg"].Value.ToString()))
                        {
                            Log.Information("[DEVFIL] : " + cmd.Parameters["@msg"].Value.ToString());
                            MessageBox.Show(cmd.Parameters["@msg"].Value.ToString(), "PROFIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex, "[DEVFIL] : " + ex.Message.ToString());
                        MessageBox.Show(ex.Message, "FIBRAFIL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    CargoDatos();

                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            ////if (!string.IsNullOrEmpty(lbl_item.Text))
            ////{
            ////    if (lbl_countbul.Text == "0" || lbl_pesotot.Text == "0")
            ////    {
            ////        Log.Error("[DEVFIL] Por favor, revisar. No hay items por procesar.");
            ////        MessageBox.Show("Por favor, revisar. No hay items por procesar.", "PROFIL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            ////    }
            ////    else
            ////    {
            ////        if (!grp_combos.Visible)
            ////        {
            ////            grp_combos.Visible = true;
            ////        }
            ////    }
            ////}
            ////else
            ////{
            ////    Log.Error("[DEVFIL] Por favor, seleccione un Item correctamente.");
            ////    MessageBox.Show("Por favor, seleccione un Item correctamente.", "PROFIL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            ////}


            if (!grp_combos.Visible)
            {
                grp_combos.Visible = true;
            }


            ////    If lbl_item.Text<> "" Then
            ////    If lbl_countbul.Text = 0 Or lbl_pesotot.Text = 0 Then
            ////        MsgBox("Por favor, revisar. No hay items por procesar.", MsgBoxStyle.Exclamation, "PROFIL")
            ////    Else
            ////        If grp_combos.Visible = False Then
            ////            grp_combos.Visible = True
            ////        End If
            ////    End If
            ////Else
            ////    MsgBox("Por favor, seleccione un Item correctamente.", MsgBoxStyle.Exclamation, "PROFIL")
            ////End If


        }

        private void event_confirmar(object sender, EventArgs e)
        {
            SqlConnection sqt = new SqlConnection(connection_String);


            DatosInsUpd("U_FIB_PROD_MAS", 0, false);

            if (sqt.State == ConnectionState.Closed)
            {
                sqt.Open();
            }

            cmd.Connection = sqt;

            try
            {
                cmd.ExecuteNonQuery();
                if (!string.IsNullOrEmpty(cmd.Parameters["@msg"].Value.ToString()))
                {
                    MessageBox.Show(cmd.Parameters["@msg"].Value.ToString(), "PROFIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("OK");
                    Log.Information("Evento confirmar");
                    CargoDatos();//* CargaDatos();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FIBRAFIL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Log.Error(ex,ex.Message.ToString());
            }
            finally
            {
                grp_combos.Visible = false;
            }



        }

        private void cmb_maq_Validated(object sender, System.ComponentModel.CancelEventArgs e)
        {

            CargoDatos();

        }

        private void cmb_maq_Click(object sender, EventArgs e)
        {




        }

        private void cbMaquinaria_TextChanged(object sender, EventArgs e)
        {
            CargoDatos();
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
