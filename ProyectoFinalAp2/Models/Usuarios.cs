using Nest;
using ProyectoFinalAp2.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAp2.Models
{
    public class Usuarios
    {
        [Key]
        [Required(ErrorMessage = "El campo Id no puede estar vacío.")]
        [Range(0, 1000000, ErrorMessage = "El campo Id no puede ser menor que cero ni mayor a 1000000.")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "El campo nombre no puede estar vacío.")]
        [MinLength(3, ErrorMessage = "El nombre es muy corto.")]
        [MaxLength(30, ErrorMessage = "El nombre es muy largo.")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El nombre de usuario no puede estar vacío.")]
        [MinLength(3, ErrorMessage = "El nombre de Usuario es muy corto.")]
        [MaxLength(30, ErrorMessage = "El nombre de usuario es muy largo.")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "El correo no puede estar vacío.")]
        [MinLength(5, ErrorMessage = "El correo es muy corto.")]
        [MaxLength(40, ErrorMessage = "El correo es muy largo.")]
        [EmailAddress]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo clave no puede estar vacío")]
        [MinLength(4, ErrorMessage = "La clave es muy corta.")]
        [MaxLength(60, ErrorMessage = "La clave es muy larga.")]
        public string PassWord { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío.")]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        public DateTime FechaIngreso { get; set; }

        [Required(ErrorMessage = "El nivel de usuario no puede estar vacío.")]
        public string Nivel { get; set; }

        public bool IsAdministrator(int iD)
        {
            if (UsuariosBLL.Buscar(iD).Nivel == "Administrador")
            {
                return true;
            } 
            else
            {
                return false;
            }
        }

        public Usuarios()
        {
            UsuarioId = 0;
            Nombres = string.Empty;
            NombreUsuario = string.Empty;
            PassWord = string.Empty;
            FechaIngreso = DateTime.Now;
            Nivel = string.Empty;
            Correo = string.Empty;
        }
    }
}