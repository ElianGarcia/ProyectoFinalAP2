using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAp2.Models
{
    public class DetalleFacturas
    {
        [Key]
        public int DetalleFacturaId { get; set; }
        public int FacturaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
       
        public DetalleFacturas()
        {
            DetalleFacturaId = 0;
            FacturaId = 0;
            ProductoId = 0;
            Cantidad = 0;
            Precio = 0;

        }
    }
}
