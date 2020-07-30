using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinalAp2.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using ProyectoFinalAp2.Models;

namespace ProyectoFinalAp2.BLL.Tests
{
    [TestClass()]
    public class ProveedorBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Proveedor proveedor = new Proveedor();
            proveedor.ProveedorId = 0;
            proveedor.Nombre = "DELL";
            proveedor.RNC = "1234568596";
            proveedor.Telefono = "8293831662";
            proveedor.Fecha = DateTime.Now;
            proveedor.Direccion = "Calle Mella";
            proveedor.TipoNegocio = "Servicios";
            Assert.IsTrue(ProveedorBLL.Guardar(proveedor));
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Assert.IsTrue(ProveedorBLL.Eliminar(2));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Assert.IsNotNull(ProveedorBLL.Buscar(2));
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.IsNotNull(ProveedorBLL.GetList(p => true));
        }

        [TestMethod()]
        public void ExisteTest()
        {
            Assert.IsTrue(ProveedorBLL.Existe(2));
        }

        [TestMethod()]
        public void YaExisteTest()
        {
            Assert.IsTrue(ProveedorBLL.YaExiste("DELL", 1));
        }

        [TestMethod()]
        public void ExisteParaModificarTest()
        {
            Assert.IsTrue(ProveedorBLL.ExisteParaModificar(2));
        }
    }
}