using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinalAp2.Controllers;
using ProyectoFinalAp2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalAp2.Controllers.Tests
{
    [TestClass()]
    public class UsuariosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Usuarios usuario = new Usuarios(1, "Alberto Cortez", "Acort34", "acortez34@gmail.com", "Acortezsd34", DateTime.Now, "Administrador");
            bool guardado = UsuariosBLL.Guardar(usuario);
            Assert.AreEqual(guardado, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Usuarios usuario = new Usuarios(1, "Alberto Cortez", "Acort34", "acortez34@gmail.com", "Acortezsd34", DateTime.Now, "Usuario");
            bool guardado = UsuariosBLL.Modificar(usuario);
            Assert.AreEqual(guardado, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            var encontrado = UsuariosBLL.Buscar(1);
            Assert.IsNotNull(encontrado);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Usuarios> lista = new List<Usuarios>();
            lista = UsuariosBLL.GetList(l => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            var existe = UsuariosBLL.Existe(1);
            Assert.IsNotNull(existe);
        }

        [TestMethod()]
        public void GetUsuarioTest()
        {
            List<Usuarios> lista = new List<Usuarios>();
            lista = UsuariosBLL.GetUsuario();
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            var eliminado = UsuariosBLL.Eliminar(1);
            Assert.IsNotNull(eliminado);
        }
    }
}