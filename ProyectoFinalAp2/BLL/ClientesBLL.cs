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
    public class ClientesBLL
    {
        public static bool Guardar(Clientes clientes)
        {
            if (!Existe(clientes.ClienteId))
                return Insertar(clientes);
            else
                return Modificar(clientes);
        }
       
        public static bool Insertar(Clientes clientes)
        {
            bool guardado = false;
            Context context = new Context();
            try
            {
                if (context.Clientes.Add(clientes) != null)
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

        private static bool Modificar(Clientes clientes)
        {
            bool modificado = false;
            Context context = new Context();

            try
            {
                context.Entry(clientes).State = EntityState.Modified;
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
                var aux = context.Clientes.Find(ID);
                if (aux != null)
                {
                    context.Clientes.Remove(aux);
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

        public static Clientes Buscar(int ID)
        {
            Clientes clientes = new Clientes();
            Context context = new Context();

            try
            {
                clientes = context.Clientes.Find(ID);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }

            return clientes;
        }

        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> expression)
        {
            Context context = new Context();
            List<Clientes> lista = new List<Clientes>();
            try
            {
                lista = context.Clientes.Where(expression).ToList();
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
                encontrado = context.Clientes.Any(c => c.ClienteId == id);
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
                if(opcion == 1) //nombre
                {
                    paso = context.Clientes.Any(p => p.Nombre == expression);
                }
                if(opcion == 2) //rnc
                {
                    paso = context.Clientes.Any(p => p.RNC == expression);
                }
                if(opcion == 3) //telefono
                {
                    paso = context.Clientes.Any(p => p.Telefono == expression);
                }
                if (opcion == 4) //email
                {
                    paso = context.Clientes.Any(p => p.Email == expression);
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
                var aux = context.Clientes.Find(id);
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
