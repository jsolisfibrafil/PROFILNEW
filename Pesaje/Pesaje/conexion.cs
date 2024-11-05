using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pesaje
{
    public  class Conexion1
    {
        //public static string Cn = ConfigurationManager.ConnectionStrings["dbventasConnectionString"].ConnectionString;
        public static string connectionStringnew = ConfigurationManager.ConnectionStrings["conexiondb"].ConnectionString;

    }


}
