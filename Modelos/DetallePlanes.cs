using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class DetallePlanes
    {
        public int id { get; set; }
        public Planes plan { get; set; }
        public Ejercicios ejercicio { get; set; }
    }
}
