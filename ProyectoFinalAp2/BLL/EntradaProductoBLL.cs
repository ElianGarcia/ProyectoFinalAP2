using Entidades;
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
    public class EntradaProductoBLL
    {
        public static bool Existe(int id)
        {
            Context contexto = new Context();
            bool encontrado = false;

            try
            {
                encontrado = contexto.EntradaProductos.Any(e => e.EntradaProductoId == id);
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

        public static bool Guardar(EntradaProductos entity)
        {
            if (!Existe(entity.EntradaProductoId))
                return Insertar(entity);
            else
                return Modificar(entity);
        } 

        public static bool Insertar(EntradaProductos entity)
        {
            bool paso = false;
            Context db = new Context();

            try
            {
                foreach (var item in entity.DetalleEntrada)
                {
                    var producto = db.Productos.Find(item.ProductoId);
                    if (producto != null)
                        producto.Cantidad += item.Cantidad;
                }

                if (db.EntradaProductos.Add(entity) != null)
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

        public static bool Modificar(EntradaProductos entity)
        {
            bool paso = false;
            var Anterior = Buscar(entity.EntradaProductoId);
            Context db = new Context();

            try
            {
                //aqui elimino los productos que tal vez removieron del detalle y lo disminuyo en la tabla producto 
                foreach (var item in Anterior.DetalleEntrada)
                {
                    var producto = db.Productos.Find(item.ProductoId);
                    if (!entity.DetalleEntrada.Exists(d => d.DetalleEntradaProductosId == item.DetalleEntradaProductosId))
                    {
                        if (producto != null)
                            producto.Cantidad -= item.Cantidad;
                        db.Entry(item).State = EntityState.Deleted;
                    }

                }

                //agregar nuevos detalles o modificarlo
                foreach (var item in entity.DetalleEntrada)
                {

                    if (item.DetalleEntradaProductosId == 0)
                    {
                        var producto = db.Productos.Find(item.ProductoId);
                        db.Entry(item).State = EntityState.Added;
                        if (producto != null)
                        {
                            producto.Cantidad += item.Cantidad;
                        }

                    }
                    else
                        db.Entry(item).State = EntityState.Modified;
                }

                db.Entry(entity).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
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

        public static EntradaProductos Buscar(int ID)
        {
            EntradaProductos entrada = new EntradaProductos();

            Context db = new Context();

            try
            {
                entrada = db.EntradaProductos.Where(e => e.EntradaProductoId == ID).Include(d => d.DetalleEntrada).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return entrada;
        }

        public static List<EntradaProductos> GetList(Expression<Func<EntradaProductos, bool>> expression)
        {
            List<EntradaProductos> lista = new List<EntradaProductos>();
            Context context = new Context();

            try
            {
                lista = context.EntradaProductos.Where(expression).ToList();
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

        public static bool Eliminar(int ID)
        {
            bool paso = false;
            var Anterior = Buscar(ID);
            Context db = new Context();
            try
            {
                if (Existe(ID))
                {
                    foreach (var item in Anterior.DetalleEntrada)
                    {
                        var Producto = db.Productos.Find(item.ProductoId);
                        if (Producto != null)
                            Producto.Cantidad -= item.Cantidad;
                    }

                    var eliminar = db.EntradaProductos.Find(ID);
                    if (eliminar != null)
                    {
                        db.Entry(eliminar).State = EntityState.Deleted;
                        paso = db.SaveChanges() > 0;
                    }
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
        public static bool ExisteParaModificar(int id)
        {
            bool paso = false;
            Context context = new Context();
            try
            {
                var aux = context.EntradaProductos.Find(id);
                if (aux != null)
                    paso = true;
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
