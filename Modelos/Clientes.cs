using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Clientes
    {
        public int id { get; set; }
        public string dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public int genero { get; set; }// 1-hombre | 2-mujer
        public DateTime fechaNacimiento { get; set; }
        
    }
}
