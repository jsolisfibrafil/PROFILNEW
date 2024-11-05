using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pesaje
{
    public class Form2Data
    {
        public string Valor1 { get; set; }
        public string Valor2 { get; set; }

        public Form2Data(string valor1, string valor2)
        {
            Valor1 = valor1;
            Valor2 = valor2;
        }
    }
}
