﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Actividades
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public TipoActividades tipoPlan { get; set; }
        public decimal monto{ get; set; }
    }
}
