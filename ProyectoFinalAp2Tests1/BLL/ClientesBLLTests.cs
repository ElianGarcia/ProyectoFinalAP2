using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinalAp2.Controllers;
using ProyectoFinalAp2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalAp2.Controllers.Tests
{
    [TestClass()]
    public class ClientesBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Clientes clientes = new Clientes();
            clientes.ClienteId = 0;
            clientes.Nombre = "Juan";
            clientes.Direccion = "Calle Duarte";
            clientes.RNC = "1234569696";
            clientes.Telefono = "8299639696";
            clientes.Email = "juan@gmail.com";
            clientes.Fecha = DateTime.Now;
            Assert.IsTrue(ClientesBLL.Guardar(clientes));
        }

        [TestMethod()]
        public void InsertarTest()
        {
            Clientes clientes = new Clientes();
            clientes.ClienteId = 0;
            clientes.Nombre = "Maria";
            clientes.Direccion = "Calle Duarte";
            clientes.RNC = "1234569696";
            clientes.Telefono = "8298968574";
            clientes.Email = "Maria@gmail.com";
            clientes.Fecha = DateTime.Now;
            Assert.IsTrue(ClientesBLL.Guardar(clientes));
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Assert.IsTrue(ClientesBLL.Eliminar(3));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Assert.IsNotNull(ClientesBLL.Buscar(2));
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.IsNotNull(ClientesBLL.GetList(p => true));
        }

        [TestMethod()]
        public void ExisteTest()
        {
            Assert.IsTrue(ClientesBLL.Existe(2));
        }
    }
}