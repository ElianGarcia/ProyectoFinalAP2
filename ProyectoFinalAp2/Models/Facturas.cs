using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAp2.Models
{
    public class Facturas
    {
        [Key]
        [Required(ErrorMessage = "El Id debe ser un numero.")]
        [Range(0, 100000000, ErrorMessage = "El campo Id no puede ser menor que cero ni mayor a 1000000.")]
        public int FacturaId { get; set; }

        [Range(1, 1000000, ErrorMessage = "Debe elegir un cliente.")]
        public int ClienteId { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío.")]
        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }

        [ForeignKey("FacturaId")]
        public virtual List<DetalleFacturas> Detalles { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Clientes Clientes { get; set; }



        public Facturas()
        {
            FacturaId = 0;
            ClienteId = 0;
            Fecha = DateTime.Now;
            Total = 0;
            Detalles = new List<DetalleFacturas>();
        }

    }
}
