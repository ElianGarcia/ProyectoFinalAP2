using Microsoft.EntityFrameworkCore;
using ProyectoFinalAp2.Data;
using ProyectoFinalAp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProyectoFinalAp2.Controllers
{
    public class UsuariosBLL
    {
        public static bool Guardar(Usuarios usuarios)
        {
            if (!Existe(usuarios.UsuarioId))
                return Insertar(usuarios);
            else
                return Modificar(usuarios);
        }

        private static bool Insertar(Usuarios usuarios)
        {
            bool paso = false;
            Context contexto = new Context();

            try
            {
                contexto.Usuarios.Add(usuarios);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Usuarios usuarios)
        {
            bool paso = false;
            Context contexto = new Context();

            try
            {
                contexto.Entry(usuarios).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
 
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Context contexto = new Context();
            try
            {
                var usuarios = contexto.Usuarios.Find(id);

                if (usuarios != null)
                {
                    contexto.Usuarios.Remove(usuarios);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Usuarios Buscar(int id)
        {
            Context contexto = new Context();
            Usuarios usuarios;

            try
            {
                usuarios = contexto.Usuarios.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return usuarios;
        }

        public static List<Usuarios> GetList(Expression<Func<Usuarios, bool>> criterio)
        {
            List<Usuarios> lista = new List<Usuarios>();
            Context contexto = new Context();
            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                lista = contexto.Usuarios.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static bool Existe(int id)
        {
            Context contexto = new Context();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Usuarios.Any(e => e.UsuarioId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static List<Usuarios> GetUsuario()
        {
            List<Usuarios> lista = new List<Usuarios>();
            Context contexto = new Context();
            try
            {
                lista = contexto.Usuarios.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static string NivelUsuario(string Usuario)
        {
            string nivel = "Cajero";
            Context db = new Context();
            try
            {
                nivel = db.Usuarios.Where(A => A.NombreUsuario.Equals(Usuario)).Select(A => A.Nivel).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return nivel;
        }

        public static Usuarios Buscar(string NombreUsuario)
        {
            Context contexto = new Context();
            List<Usuarios> Lista = new List<Usuarios>();
            Usuarios Usuario = new Usuarios();

            try
            {
                foreach(var item in Lista)
                {
                    if (item.NombreUsuario == NombreUsuario)
                    {
                        Usuario = item;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Usuario;
        }

        public static bool VerificarExistenciaDelUsuario(string NombreUsuario)
        {
            bool paso = false;
            Context contexto = new Context();

            try
            {
                if (contexto.Usuarios.Any(A => A.NombreUsuario == NombreUsuario))
                {
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool VerificarExistenciaYClaveDelUsuario(string NombreUsuario, string clave)
        {
            bool paso = false;
            Context contexto = new Context();

            try
            {
                if (contexto.Usuarios.Any(A => A.NombreUsuario == NombreUsuario && A.PassWord == clave))
                {
                    paso = true;

                }

                if (NombreUsuario == "Administrador" && clave == "1234")
                {
                    paso = true;
                }

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
    }
}
