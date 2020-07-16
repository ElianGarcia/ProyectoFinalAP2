﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoFinalAp2.Data;

namespace ProyectoFinalAp2.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("Entidades.DetalleEntradaProductos", b =>
                {
                    b.Property<int>("DetalleEntradaProductosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EntradaProductoId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EntradaProductosEntradaProductoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DetalleEntradaProductosId");

                    b.HasIndex("EntradaProductosEntradaProductoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("DetalleEntradaProductos");
                });

            modelBuilder.Entity("ProyectoFinalAp2.Models.Categorias", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(30);

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            CategoriaId = 1,
                            Descripcion = "CALZADOS"
                        });
                });

            modelBuilder.Entity("ProyectoFinalAp2.Models.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(40);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("RNC")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(10);

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ProyectoFinalAp2.Models.DetalleFacturas", b =>
                {
                    b.Property<int>("DetalleFacturaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FacturaId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Precio")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DetalleFacturaId");

                    b.HasIndex("FacturaId");

                    b.ToTable("DetalleFacturas");
                });

            modelBuilder.Entity("ProyectoFinalAp2.Models.EntradaProductos", b =>
                {
                    b.Property<int>("EntradaProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("CantidadTotal")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EntradaProductoId");

                    b.ToTable("EntradaProductos");
                });

            modelBuilder.Entity("ProyectoFinalAp2.Models.Facturas", b =>
                {
                    b.Property<int>("FacturaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.HasKey("FacturaId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("ProyectoFinalAp2.Models.Productos", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoriaiD")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Costo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Ganancia")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Precio")
                        .HasColumnType("TEXT");

                    b.Property<int>("Reorden")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductoId");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            ProductoId = 1,
                            Cantidad = 25,
                            CategoriaiD = 1,
                            Costo = 100m,
                            Descripcion = "Zapato",
                            Fecha = new DateTime(2020, 7, 15, 17, 34, 43, 59, DateTimeKind.Local).AddTicks(621),
                            Ganancia = 50m,
                            Precio = 150m,
                            Reorden = 50
                        });
                });

            modelBuilder.Entity("ProyectoFinalAp2.Models.Usuarios", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(40);

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nivel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(30);

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(30);

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(60);

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            UsuarioId = 1,
                            Correo = "eliangarciarguez@gmail.com",
                            FechaIngreso = new DateTime(2020, 7, 15, 17, 34, 43, 57, DateTimeKind.Local).AddTicks(4138),
                            Nivel = "Administrador",
                            NombreUsuario = "Rguez12",
                            Nombres = "Elian Garcia",
                            PassWord = "dQBNAGIAUgBlAGwATABhADEANwA3ADIA"
                        },
                        new
                        {
                            UsuarioId = 2,
                            Correo = "rehanicordero@gmail.com",
                            FechaIngreso = new DateTime(2020, 7, 15, 17, 34, 43, 57, DateTimeKind.Local).AddTicks(5283),
                            Nivel = "Administrador",
                            NombreUsuario = "rehani97",
                            Nombres = "Rehani Cordero",
                            PassWord = "MQAyADMANAA="
                        });
                });

            modelBuilder.Entity("Entidades.DetalleEntradaProductos", b =>
                {
                    b.HasOne("ProyectoFinalAp2.Models.EntradaProductos", null)
                        .WithMany("DetalleEntrada")
                        .HasForeignKey("EntradaProductosEntradaProductoId");

                    b.HasOne("ProyectoFinalAp2.Models.Productos", "Productos")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoFinalAp2.Models.DetalleFacturas", b =>
                {
                    b.HasOne("ProyectoFinalAp2.Models.Facturas", null)
                        .WithMany("Detalles")
                        .HasForeignKey("FacturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoFinalAp2.Models.Facturas", b =>
                {
                    b.HasOne("ProyectoFinalAp2.Models.Clientes", "Clientes")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
