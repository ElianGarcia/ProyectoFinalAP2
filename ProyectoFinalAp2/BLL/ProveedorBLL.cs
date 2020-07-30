using Microsoft.EntityFrameworkCore;
using ProyectoFinalAp2.Data;
using ProyectoFinalAp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProyectoFinalAp2.BLL
{
    public class ProveedorBLL
    {
        public static bool Guardar(Proveedor proveedor)
        {
            if (!Existe(proveedor.ProveedorId))
                return Insertar(proveedor);
            else
                return Modificar(proveedor);
        }

        public static bool Insertar(Proveedor proveedor)
        {
            bool guardado = false;
            Context context = new Context();
            try
            {
                if (context.Proveedores.Add(proveedor) != null)
                    guardado = context.SaveChanges() > 0;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }

            return guardado;
        }

        private static bool Modificar(Proveedor proveedor)
        {
            bool modificado = false;
            Context context = new Context();

            try
            {
                context.Entry(proveedor).State = EntityState.Modified;
                modificado = context.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }

            return modificado;
        }

        public static bool Eliminar(int ID)
        {
            bool eliminado = false;
            Context context = new Context();
            try
            {
                var aux = context.Proveedores.Find(ID);
                if (aux != null)
                {
                    context.Proveedores.Remove(aux);
                    eliminado = context.SaveChanges() > 0;
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }


            return eliminado;
        }

        public static Proveedor Buscar(int ID)
        {
            Proveedor proveedor = new Proveedor();
            Context context = new Context();

            try
            {
                proveedor = context.Proveedores.Find(ID);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }

            return proveedor;
        }

        public static List<Proveedor> GetList(Expression<Func<Proveedor, bool>> expression)
        {
            Context context = new Context();
            List<Proveedor> lista = new List<Proveedor>();
            try
            {
                lista = context.Proveedores.Where(expression).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }

            return lista;
        }

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Context context = new Context();
            try
            {
                encontrado = context.Proveedores.Any(c => c.ProveedorId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
            return encontrado;
        }

        public static bool YaExiste(string expression, int opcion)
        {
            bool paso = false;
            Context context = new Context();
            try
            {
                if (opcion == 1) //nombre
                {
                    paso = context.Proveedores.Any(p => p.Nombre == expression);
                }
                if (opcion == 2) //rnc
                {
                    paso = context.Proveedores.Any(p => p.RNC == expression);
                }
                if (opcion == 3) //telefono
                {
                    paso = context.Proveedores.Any(p => p.Telefono == expression);
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
            return paso;
        }

        public static bool ExisteParaModificar(int id)
        {
            bool paso = false;
            Context context = new Context();
            try
            {
                var aux = context.Proveedores.Find(id);
                if (aux != null)
                    paso = true;
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }
    }
}
