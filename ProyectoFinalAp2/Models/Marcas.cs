using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAp2.Models
{
    public class Marcas
    {
        [Key]
        [Range(0, 1000000, ErrorMessage = "El campo Id no puede ser menor a cero ni mayor a 1000000.")]
        [Required(ErrorMessage = "El campo Id debe ser numerico.")]
        public int MarcaId { get; set; }

        [Required(ErrorMessage = "El campo nombre de marca no puede estar vacio.")]
        [MinLength(2, ErrorMessage = "El nombre de marca es muy corta.")]
        [MaxLength(30, ErrorMessage = "El nombre de marca es muy larga.")]
        public string NombreMarca { get; set; }

        public Marcas(int marcaId, string nombreMarca)
        {
            MarcaId = marcaId;
            NombreMarca = nombreMarca ?? throw new ArgumentNullException(nameof(nombreMarca));
        }

        public Marcas()
        {
            MarcaId = 0;
            NombreMarca = string.Empty;
        }
    }
}
