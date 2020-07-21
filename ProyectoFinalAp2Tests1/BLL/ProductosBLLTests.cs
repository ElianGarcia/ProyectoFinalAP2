using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinalAp2.Controllers;
using ProyectoFinalAp2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalAp2.Controllers.Tests
{
    [TestClass()]
    public class ProductosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Productos producto = new Productos(0, 1, "Zapato abierto", Convert.ToDecimal(345.89), Convert.ToDecimal(395.89), Convert.ToDecimal(45), DateTime.Now, 10, 5);
            bool guardado = ProductosBLL.Guardar(producto);
            Assert.AreEqual(guardado, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Productos producto = new Productos(1, 1, "Zapato abierto rojo", Convert.ToDecimal(345.89), Convert.ToDecimal(395.89), Convert.ToDecimal(45), DateTime.Now, 10, 5);
            bool guardado = ProductosBLL.Modificar(producto);
            Assert.AreEqual(guardado, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            var encontrado = ProductosBLL.Buscar(1);
            Assert.IsNotNull(encontrado);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Productos> lista = new List<Productos>();
            lista = ProductosBLL.GetList(l => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            var encontrado = ProductosBLL.Existe(1);
            Assert.IsNotNull(encontrado);
        }

        [TestMethod()]
        public void GetProductoTest()
        {
            List<Productos> lista = new List<Productos>();
            lista = ProductosBLL.GetProducto();
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            var eliminado = ProductosBLL.Eliminar(1);
            Assert.IsNotNull(eliminado);
        }
    }
}