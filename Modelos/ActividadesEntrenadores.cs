using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class ActividadesEntrenadores
    {
        public int id { get; set; }
        public Actividades actividad { get; set; }
        public Entrenadores entrenador { get; set; }
        public DateTime fechaInicio { get; set; }
        public int vigente { get; set; } // 1-Vigente | 2-Caducado
    }
}
