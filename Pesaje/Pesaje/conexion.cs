using System.Configuration;

namespace Pesaje
{
    public class Conexion1
    {
        //public static string Cn = ConfigurationManager.ConnectionStrings["dbventasConnectionString"].ConnectionString;
        public static string connectionStringnew = ConfigurationManager.ConnectionStrings["conexiondb"].ConnectionString;

    }


}
