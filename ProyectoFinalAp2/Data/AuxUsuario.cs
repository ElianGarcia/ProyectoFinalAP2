using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAp2.Data
{
    public class AuxUsuario
    {
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Nombre_Usuario { get; set; }
        public DateTime Fecha_Ingreso { get; set; }

        public AuxUsuario()
        {
            ID = 0;
            Nombres = string.Empty;
            Nombre_Usuario = string.Empty;
            Fecha_Ingreso = DateTime.Now;
        }

    }
}
