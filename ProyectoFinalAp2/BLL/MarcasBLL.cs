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
    public class MarcasBLL
    {
        public static bool Guardar(Marcas marca)
        {
            if (!Existe(marca.MarcaId))
                return Insertar(marca);
            else
                return Modificar(marca);
        }

        private static bool Insertar(Marcas marca)
        {
            bool paso = false;
            Context db = new Context();
            try
            {
                if (db.Marcas.Add(marca) != null)
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
                encontrado = contexto.Marcas.Any(e => e.MarcaId == id);
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

        public static bool Modificar(Marcas marca)
        {
            bool paso = false;

            if (ExisteParaModificar(marca.MarcaId))
            {

                Context db = new Context();
                try
                {
                    db.Entry(marca).State = EntityState.Modified;
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
                var aux = context.Marcas.Find(id);
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
                var aux = db.Marcas.Find(ID);
                if (aux != null)
                {
                    db.Marcas.Remove(aux);
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

        public static Marcas Buscar(int ID)
        {
            Marcas marca = new Marcas();
            Context db = new Context();

            try
            {
                marca = db.Marcas.Find(ID);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return marca;
        }

        public static List<Marcas> GetList(Expression<Func<Marcas, bool>> criterio)
        {
            List<Marcas> lista = new List<Marcas>();
            Context contexto = new Context();
            try
            {
                lista = contexto.Marcas.Where(criterio).ToList();
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
                paso = context.Marcas.Any(p => p.NombreMarca == expresion);
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
