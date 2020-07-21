using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinalAp2.Controllers;
using ProyectoFinalAp2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalAp2.Controllers.Tests
{
    [TestClass()]
    public class CategoriasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Categorias categorias = new Categorias();
            categorias.CategoriaId = 0;
            categorias.Descripcion = "Calzados";
            Assert.IsTrue(CategoriasBLL.Guardar(categorias));
        }

        [TestMethod()]
        public void ExisteTest()
        {
            Assert.IsTrue(CategoriasBLL.Existe(1));
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Categorias categorias = new Categorias();
            categorias.CategoriaId = 3;
            categorias.Descripcion = "Calzado";
            Assert.IsTrue(CategoriasBLL.Modificar(categorias));
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Assert.IsTrue(CategoriasBLL.Eliminar(3));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Assert.IsNotNull(CategoriasBLL.Buscar(1));
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.IsNotNull(CategoriasBLL.GetList(p => true));
        }
    }
}