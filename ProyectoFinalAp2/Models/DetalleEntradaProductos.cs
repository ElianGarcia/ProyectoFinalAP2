using ProyectoFinalAp2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleEntradaProductos
    {
        public int DetalleEntradaProductosId { get; set; }
        public int EntradaProductoId { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Productos Productos { get; set; }
        public int Cantidad { get; set; }
        public DetalleEntradaProductos()
        {
            DetalleEntradaProductosId = 0;
            EntradaProductoId = 0;
            Productos = new Productos();
            Cantidad = 0;
        }

        public DetalleEntradaProductos(int detalleEntradaProductosId, int entradaProductoId, Productos productos, int cantidad)
        {
            DetalleEntradaProductosId = detalleEntradaProductosId;
            EntradaProductoId = entradaProductoId;
            Productos = productos ?? throw new ArgumentNullException(nameof(productos));
            Cantidad = cantidad;
        }
    }
}