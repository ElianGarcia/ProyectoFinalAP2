using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinalAp2.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using ProyectoFinalAp2.Models;
using Entidades;

namespace ProyectoFinalAp2.Controllers.Tests
{
    [TestClass()]
    public class EntradaProductoBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            DetalleEntradaProductos m = new DetalleEntradaProductos
            {
                DetalleEntradaProductosId = 0,
                ProductoId = 1,
                Cantidad = 100
            };

            List<DetalleEntradaProductos> lista = new List<DetalleEntradaProductos>();
            lista.Add(m);
            EntradaProductos entrada = new EntradaProductos(0, 1, DateTime.Now, Convert.ToInt32(1500.25), lista);
            Assert.IsTrue(EntradaProductoBLL.Guardar(entrada));
        }

        [TestMethod()]
        public void ModificarTest()
        {
            DetalleEntradaProductos m = new DetalleEntradaProductos
            {
                DetalleEntradaProductosId = 0,
                ProductoId = 1,
                Cantidad = 150
            };

            List<DetalleEntradaProductos> lista = new List<DetalleEntradaProductos>();
            lista.Add(m);
            EntradaProductos entrada = new EntradaProductos(0, 1, DateTime.Now, Convert.ToInt32(1750.25), lista);
            Assert.IsTrue(EntradaProductoBLL.Guardar(entrada));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            var encontrado = EntradaProductoBLL.Buscar(1);
            Assert.IsNotNull(encontrado);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var lista = new List<EntradaProductos>();
            lista = EntradaProductoBLL.GetList(p => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            var eliminado = EntradaProductoBLL.Eliminar(1);
            Assert.IsTrue(eliminado);
        }
    }
}