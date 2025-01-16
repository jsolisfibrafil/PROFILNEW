using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pesaje
{
    public class AreaCodeResolver
    {

        public class Area
        {
            public string Code { get; set; }
            public string Descripcion { get; set; }
        }

        // Lista que almacena los datos de las áreas
        private List<Area> areas = new List<Area>()
        {
            new Area { Code = "A", Descripcion = "Almacen" },
            new Area { Code = "C", Descripcion = "Cabos" },
            new Area { Code = "EG", Descripcion = "Estrusora globo" },
            new Area { Code = "EP", Descripcion = "Estrusora plana" },
            new Area { Code = "M", Descripcion = "Molino" },
            new Area { Code = "ME", Descripcion = "Mallas Extruidas" },
            new Area { Code = "MT", Descripcion = "Mallas Tejidas" },
            new Area { Code = "S", Descripcion = "Sistemas" },
            new Area { Code = "T", Descripcion = "Telares" },
            new Area { Code = "TC", Descripcion = "Telar circular" }
        };

        // Método para obtener el código basado en la descripción
        public string GetCodeByDescripcion(string descripcion)
        {
            var area = areas.FirstOrDefault(a => a.Descripcion.Equals(descripcion, StringComparison.OrdinalIgnoreCase));

            if (area != null)
                return area.Code;
            else
                return "Descripción no encontrada.";
        }
    }
}
