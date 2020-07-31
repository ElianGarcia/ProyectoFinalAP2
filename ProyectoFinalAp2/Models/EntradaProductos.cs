using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAp2.Models
{
    public class EntradaProductos
    {
        [Key]
        public int EntradaProductoId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public int CantidadTotal { get; set; }

        [Range(1, 1000000, ErrorMessage = "Debe seleccionar un proveedor.")]
        [Required(ErrorMessage = "Debe seleccionar un proveedor")]
        public int ProveedorId { get; set; }

        [ForeignKey("EntradaProductoId")]
        public virtual List<DetalleEntradaProductos> DetalleEntrada { get; set; }
       
        public EntradaProductos()
        {
            EntradaProductoId = 0;
            UsuarioId = 0;
            Fecha = DateTime.Now;
            CantidadTotal = 0;
            DetalleEntrada = new List<DetalleEntradaProductos>();
        }

        public EntradaProductos(int entradaProductoId, int usuarioId, DateTime fecha, int cantidadTotal, List<DetalleEntradaProductos> detalleEntrada)
        {
            EntradaProductoId = entradaProductoId;
            UsuarioId = usuarioId;
            Fecha = fecha;
            CantidadTotal = cantidadTotal;
            DetalleEntrada = detalleEntrada ?? throw new ArgumentNullException(nameof(detalleEntrada));
        }
    }
}
