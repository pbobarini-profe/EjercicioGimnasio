using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class DtoInformePagos
    {
        public int idReporte { get; set; }
        public int IdPago { get; set; }
        public DateTime FechaPago { get; set; }
        public string NombreCliente { get; set; }
        public string PlanCliente { get; set; }
        public string Descripcion { get; set; }
        public string Periodo { get; set; }
        public decimal Monto { get; set; }
    }
}
