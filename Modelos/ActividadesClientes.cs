using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
   
    public class ActividadesClientes
    {
        public int Id { get; set; }
        public Actividades Actividad { get; set; }
        public Clientes Cliente { get; set; }
        public DateTime FechaInicio { get; set; }
        public int Vigente { get; set; }
    }
}