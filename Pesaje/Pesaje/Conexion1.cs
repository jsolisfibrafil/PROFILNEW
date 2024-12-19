using System.Configuration;
using System.Data.SqlClient;

namespace Pesaje
{

    
    
    public class Conexion1
    {
        private static readonly string _connectionStringnew = ConfigurationManager.ConnectionStrings["conexiondb"].ConnectionString;
        public static string connectionStringnew = ConfigurationManager.ConnectionStrings["conexiondb"].ConnectionString;

        private static SqlConnection _conexion;


        public static SqlConnection ObtenerConexion()
        {
            if (_conexion == null)
            {
                _conexion = new SqlConnection(_connectionStringnew);
            }
            return _conexion;
        }

        public static void CerrarConexion()
        {
            if (_conexion != null && _conexion.State == System.Data.ConnectionState.Open)
            {
                _conexion.Close();
            }
        }

    }

   

}
