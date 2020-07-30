using Entidades;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalAp2.Controllers;
using ProyectoFinalAp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAp2.Data
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server = .\SqlExpress; Database = ButterSoftDB; Trusted_Connection = True; ");
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Categorias>().HasData(new Categorias
            {
                CategoriaId = 1,
                Descripcion = "CALZADOS"
            });

            model.Entity<Marcas>().HasData(new Marcas
            {
                MarcaId = 1,
                NombreMarca = "Coca-Cola"
            });

            model.Entity<Usuarios>().HasData(new Usuarios
            {
                UsuarioId = 1,
                Nombres = "Elian Garcia",
                NombreUsuario = "Rguez12",
                PassWord = UsuariosBLL.encode("uMbRelLa1772"),
                FechaIngreso = DateTime.Now,
                Nivel = "Administrador",
                Correo = "eliangarciarguez@gmail.com"
            });

            model.Entity<Usuarios>().HasData(new Usuarios
            {
                UsuarioId = 2,
                Nombres = "Rehani Cordero",
                NombreUsuario = "rehani97",
                PassWord = UsuariosBLL.encode("1234"),
                FechaIngreso = DateTime.Now,
                Nivel = "Administrador",
                Correo = "rehanicordero@gmail.com"
            });

            model.Entity<Usuarios>().HasData(new Usuarios
            {
                UsuarioId = 3,
                Nombres = "Usuario Invitado",
                NombreUsuario = "Invitado",
                PassWord = UsuariosBLL.encode("Buttersoft"),
                FechaIngreso = DateTime.Now,
                Nivel = "Usuario",
                Correo = "invitado@gmail.com"
            });

            model.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 1,
                CategoriaiD = 1,
                MarcaiD = 1,
                Descripcion = "Zapato",
                Reorden = 50,
                Costo = Convert.ToDecimal(100.00),
                Precio = Convert.ToDecimal(150.00),
                Ganancia = Convert.ToDecimal(50.00),
                Fecha = DateTime.Now,
                Cantidad = 25
            });
        }

        public DbSet<Facturas> Facturas { get; set; }
        public DbSet<EntradaProductos> EntradaProductos { get; set; }
        public DbSet<Clientes> Clientes {get; set;}
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Marcas> Marcas { get; set; }
    }
}
