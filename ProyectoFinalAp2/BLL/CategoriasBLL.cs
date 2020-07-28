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
    public class CategoriasBLL
    {
        public static bool Guardar(Categorias categoria)
        {
            if (!Existe(categoria.CategoriaId))
                return Insertar(categoria);
            else
                return Modificar(categoria);
        }

        private static bool Insertar(Categorias categoria)
        {
            bool paso = false;
            Context db = new Context();
            try
            {
                if (db.Categorias.Add(categoria) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static bool Existe(int id)
        {
            Context contexto = new Context();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Categorias.Any(e => e.CategoriaId == id);
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

        public static bool Modificar(Categorias categorias)
        {
            bool paso = false;

            if (ExisteParaModificar(categorias.CategoriaId))
            {

                Context db = new Context();
                try
                {
                    db.Entry(categorias).State = EntityState.Modified;
                    paso = db.SaveChanges() > 0;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    db.Dispose();
                }
            }
          
            return paso;
        }

        public static bool ExisteParaModificar(int id)
        {
            bool paso = false;
            Context context = new Context();
            try
            {
                var aux = context.Categorias.Find(id);
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

        public static bool Eliminar(int ID)
        {
            bool paso = false;
            Context db = new Context();

            try
            {
                var aux = db.Categorias.Find(ID);
                if (aux != null)
                {
                    db.Categorias.Remove(aux);
                    paso = db.SaveChanges() > 0;
                }
               
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static Categorias Buscar(int ID)
        {
            Categorias categorias = new Categorias();
            Context db = new Context();

            try
            {
                categorias = db.Categorias.Find(ID);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return categorias;
        }

        public static List<Categorias> GetList(Expression<Func<Categorias, bool>> criterio)
        {
            List<Categorias> lista = new List<Categorias>();
            Context contexto = new Context();
            try
            {
                lista = contexto.Categorias.Where(criterio).ToList();
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

        public static bool YaExite(string expresion)
        {
            bool paso = false;
            Context context = new Context();

            try
            {
                paso = context.Categorias.Any(p => p.Descripcion == expresion);
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
    }
}
