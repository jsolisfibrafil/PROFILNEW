using Pesaje.Formulario;
using System;
using System.Windows.Forms;

namespace Pesaje
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //              Application.Run(new Form1());
            //              Application.Run(new mainForm());
            Application.Run(new Login());

        }
    }
}
