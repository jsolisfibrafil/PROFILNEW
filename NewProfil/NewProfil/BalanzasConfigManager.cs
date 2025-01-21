using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProfil
{
    public static class BalanzasConfigManager
    {
        public static string AppConfigKey { get; private set; }
        public static string AppConfigHabilitado { get; private set; }
        public static string AppConfigUbicacion { get; private set; }
        public static string AppConfigModelo { get; private set; }
        public static string AppConfigFuncion { get; private set; }

        private static bool isInitialized = false;

        public static void InitializeConfig()
        {
            if (isInitialized) return; // Asegura que se ejecute solo una vez.

            var balanzasConfig = ConfigurationManager.GetSection("BalanzasConfig") as NameValueCollection;

            if (balanzasConfig != null)
            {
                foreach (string key in balanzasConfig.AllKeys)
                {
                    string value = balanzasConfig[key];
                    var attributes = value.Split(';')
                                          .Select(attr => attr.Split('='))
                                          .ToDictionary(parts => parts[0], parts => parts[1]);

                    if (attributes["habilitado"].ToUpper() == "Y")
                    {
                        AppConfigKey = key;
                        AppConfigHabilitado = attributes["habilitado"];
                        AppConfigUbicacion = attributes["ubicacion"];
                        AppConfigModelo = attributes["modelo"];
                        AppConfigFuncion = attributes["funcion"];

                        Log.Information($"Balanza configurado en APPCONFIG : {key}, Habilitado: {attributes["habilitado"]}, Ubicación: {attributes["ubicacion"]}, Modelo: {attributes["modelo"]}, Función: {attributes["funcion"]}");
                    }
                }
            }

            isInitialized = true; // Marcar como inicializado.
        }
    }
}
