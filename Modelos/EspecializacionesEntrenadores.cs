using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class EspecializacionesEntrenadores
    {
        public int id { get; set; }
        public Entrenadores entrengador { get; set; }
        public Especializaciones especializacion { get; set; }
    }
}
