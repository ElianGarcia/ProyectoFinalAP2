using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalAp2.Data;
using ProyectoFinalAp2.Models;


namespace ProyectoFinalAp2.Controllers
{
    public class FacturasBLL
    {
        public static bool Guardar(Facturas facturas)
        {
            if (!Existe(facturas.FacturaId))//si no existe insertamos
                return Insertar(facturas);
            else
                return Modificar(facturas);

        }

        private static bool Insertar(Facturas facturas)
        {
            bool paso = false;
            Context context = new Context();

            try
            {

                //le resto la cantidad de productos facturados
                foreach (var item in facturas.Detalles)
                {
                    var auxProducto = context.Productos.Find(item.ProductoId);
                    if (auxProducto != null)
                    {
                        auxProducto.Cantidad -= item.Cantidad;
                    }
                }
                context.Facturas.Add(facturas);
                paso = context.SaveChanges() > 0;
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

        private static bool Modificar(Facturas facturas)
        {
            bool paso = false;
            var Anterior = Buscar(facturas.FacturaId);
            Context context = new Context();

            try
            {
                //aqui borro del detalle y disminuyo el producto devuelto en inventario
                foreach (var item in Anterior.Detalles)
                {
                    var auxProducto = context.Productos.Find(item.ProductoId);
                    if (!facturas.Detalles.Exists(d => d.DetalleFacturaId == item.DetalleFacturaId))
                    {
                        if (auxProducto != null)
                        {
                            auxProducto.Cantidad += item.Cantidad;
                        }

                        context.Entry(item).State = EntityState.Deleted;
                    }

                }

                //aqui agrego lo nuevo al detalle
                foreach (var item in facturas.Detalles)
                {
                    var auxProducto = context.Productos.Find(item.ProductoId);
                    if (item.DetalleFacturaId == 0)
                    {
                        context.Entry(item).State = EntityState.Added;
                        if (auxProducto != null)
                        {
                            auxProducto.Cantidad -= item.Cantidad;
                        }

                    }
                    else
                        context.Entry(item).State = EntityState.Modified;
                }


                context.Entry(facturas).State = EntityState.Modified;
                paso = context.SaveChanges() > 0;

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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            var Anterior = Buscar(id);
            Context context = new Context();

            try
            {
                if (Existe(id))
                {
                    //aqui le resto las cantidades correspondientes a los producto
                    foreach (var item in Anterior.Detalles)
                    {
                        var auxProducto = context.Productos.Find(item.ProductoId);
                        if (auxProducto != null)
                        {
                            auxProducto.Cantidad += item.Cantidad;
                        }
                    }

                    //aqui remueve la entidad
                    var auxFactura = context.Facturas.Find(id);
                    if (auxFactura != null)
                    {
                        context.Facturas.Remove(auxFactura);
                        paso = context.SaveChanges() > 0;
                    }
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


        public static Facturas Buscar(int id)
        {
            Context context = new Context();
            Facturas facturas;

            try
            {
                facturas = context.Facturas.Where(f => f.FacturaId == id).Include(d => d.Detalles).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
            return facturas;

        }

        public static List<Facturas> GetList(Expression<Func<Facturas, bool>> expression)
        {
            List<Facturas> lista = new List<Facturas>();
            Context context = new Context();

            try
            {
                lista = context.Facturas.Where(expression).ToList();
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
            Context context = new Context();
            bool encontrado = false;

            try
            {
                encontrado = context.Facturas.Any(f => f.FacturaId == id);

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

        public static bool ExisteParaModificar(int id)
        {
            bool paso = false;
            Context context = new Context();
            try
            {
                var aux = context.Facturas.Find(id);
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
