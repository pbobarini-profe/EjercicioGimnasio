using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class MovimientosAsientos
    {
         public int id { get; set; }
        public ActividadesClientes movimiento { get; set; }
        public Clientes asiento { get; set; }
    }
}
