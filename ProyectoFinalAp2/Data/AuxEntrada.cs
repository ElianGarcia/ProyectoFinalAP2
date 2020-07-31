using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAp2.Data
{
    public class AuxEntrada
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public int ProveedorId { get; set; }
        public int Cantidad_Total { get; set; }

        public AuxEntrada()
        {
            ID = 0;
            Fecha = DateTime.Now;
            ProveedorId = 0;
            Cantidad_Total = 0;
        }
    }
}
