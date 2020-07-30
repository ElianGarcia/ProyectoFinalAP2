using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinalAp2.Controllers;
using ProyectoFinalAp2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalAp2.Controllers.Tests
{
    [TestClass()]
    public class FacturasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Facturas facturas = new Facturas();
            facturas.FacturaId = 0;
            facturas.ClienteId = 2;
            facturas.Fecha = DateTime.Now;
            facturas.Total = 200;
            facturas.Detalles.Add(new DetalleFacturas
            {
                DetalleFacturaId = 0,
                FacturaId = 0,
                ProductoId = 2,
                Cantidad = 1,
                Precio = 200,
            });
            Assert.IsTrue(FacturasBLL.Guardar(facturas));
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Assert.IsTrue(FacturasBLL.Eliminar(2));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Assert.IsNotNull(FacturasBLL.Buscar(2));
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.IsNotNull(FacturasBLL.GetList(p => true));
        }

        [TestMethod()]
        public void ExisteTest()
        {
            Assert.IsTrue(FacturasBLL.Existe(2));
        }

        [TestMethod()]
        public void ExisteParaModificarTest()
        {
            Assert.IsTrue(FacturasBLL.ExisteParaModificar(1));
        }
    }
}