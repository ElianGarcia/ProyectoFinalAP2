using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinalAp2.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using ProyectoFinalAp2.BLL;
using ProyectoFinalAp2.Models;

namespace ProyectoFinalAp2.BLL.Tests
{
    [TestClass()]
    public class MarcasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Marcas marca = new Marcas(2, "Coca-Cola");
            bool guardado = MarcasBLL.Guardar(marca);
            Assert.IsTrue(guardado);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool existe = MarcasBLL.Existe(2);
            Assert.IsNotNull(existe);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Marcas marca = new Marcas(2, "Pepsi");
            bool guardado = MarcasBLL.Modificar(marca);
            Assert.IsTrue(guardado);
        }

        [TestMethod()]
        public void ExisteParaModificarTest()
        {
            bool existe = MarcasBLL.ExisteParaModificar(2);
            Assert.IsNotNull(existe);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool eliminar = MarcasBLL.Eliminar(2);
            Assert.IsTrue(eliminar);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Marcas existe = MarcasBLL.Buscar(2);
            Assert.IsNotNull(existe);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var lista = MarcasBLL.GetList(p => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void YaExiteTest()
        {
            bool existe = MarcasBLL.YaExite("Pepsi");
            Assert.IsNotNull(existe);
        }
    }
}