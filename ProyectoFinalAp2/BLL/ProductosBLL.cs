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
    public class ProductosBLL
    {
        public static bool Guardar(Productos productos)
        {
            if (!Existe(productos.ProductoId))
                return Insertar(productos);
            else
                return Modificar(productos);
        }

        private static bool Insertar(Productos producto)
        {
            bool paso = false;
            Context contexto = new Context();

            try
            {
                contexto.Productos.Add(producto);
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

        public static bool Modificar(Productos producto)
        {
            bool paso = false;
            Context contexto = new Context();

            try
            {
                contexto.Entry(producto).State = EntityState.Modified;
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

        public static Productos Buscar(int id)
        {
            Context contexto = new Context();
            Productos producto;

            try
            {
                producto = contexto.Productos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return producto;
        }

        public static List<Productos> GetList(Expression<Func<Productos, bool>> criterio)
        {
            List<Productos> lista = new List<Productos>();
            Context contexto = new Context();
            try
            {
                lista = contexto.Productos.Where(criterio).ToList();
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
                encontrado = contexto.Productos.Any(e => e.ProductoId == id);
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

        public static bool ExisteParaModificar(int id)
        {
            bool paso = false;
            Context context = new Context();

            try
            {
                var aux = context.Usuarios.Find(id);
                if (aux != null)
                    paso = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
            return paso;
        }

        public static bool VerificarExistenciaDelProducto(string descripcion)
        {
            bool paso = false;
            Context contexto = new Context();

            try
            {
                if (contexto.Productos.Any(A => A.Descripcion == descripcion))
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

        public static List<Productos> GetProducto()
        {
            List<Productos> lista = new List<Productos>();
            Context contexto = new Context();
            try
            {
                lista = contexto.Productos.ToList();
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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Context contexto = new Context();
            try
            {
                var producto = contexto.Productos.Find(id);

                if (producto != null)
                {
                    contexto.Productos.Remove(producto);
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
    }
}
