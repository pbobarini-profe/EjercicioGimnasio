using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Planes
    {
        public int id { get; set; }
        public Clientes cliente { get; set; }
        public Periodos periodo { get; set; }
        public Entrenadores entrenador { get; set; }
    }
}
