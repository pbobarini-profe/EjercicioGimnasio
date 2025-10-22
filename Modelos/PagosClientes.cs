using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class PagosClientes
    {
        public int id { get; set; }
        public DateTime fechaPago { get; set; }
        public Clientes cliente{ get; set; }
        public ActividadesClientes planCliente { get; set; }
        public string descripcion { get; set; }
        public Periodos periodo { get; set; }
    }
}
