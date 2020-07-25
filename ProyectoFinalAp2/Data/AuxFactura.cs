using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAp2.Data
{
    public class AuxFactura
    {
        public int ID { get; set; }
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public AuxFactura()
        {
            ID = 0;
            Cliente = string.Empty;
            Fecha = DateTime.Now;
            Total = 0;
        }
    }
}
