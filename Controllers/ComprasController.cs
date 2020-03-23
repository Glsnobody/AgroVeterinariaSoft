using AgroVeterinariaSoft.Data;
using AgroVeterinariaSoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AgroVeterinariaSoft.Controllers
{
    public class ComprasController
    {
        public static bool Insertar(Compras Compra)
        {
            Contexto Database = new Contexto();
            bool paso = false;
            try
            {
                foreach (var item in Compra.ListaProductos)
                {
                    var productos = ProductosController.Buscar(item.ProductoId);
                    productos.Cantidad += item.Cantidad;
                    ProductosController.Guardar(productos);
                }

                Database.Compras.Add(Compra);
                paso = Database.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Database.Dispose();
            }
            return paso;

        }

        public static bool Guardar(Compras Compra)
        {
            bool paso = false;
            Contexto Database = new Contexto();
            try
            {
                if (!Database.Compras.Any(A => A.CompraId == Compra.CompraId))
                {
                    if (Compra.CompraId == 0)
                    {
                        paso = Insertar(Compra);
                    }
                }
                else
                {
                    paso = Modificar(Compra);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Database.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Compras Compra)
        {
            Contexto Database = new Contexto();
            bool paso = false;

            try
            {
                var anterior = ComprasController.Buscar(Compra.CompraId);

                foreach (var item in Compra.ListaProductos)
                {
                    if (item.ID == 0)
                    {
                        Database.Entry(item).State = EntityState.Added;
                        var productos = ProductosController.Buscar(item.ProductoId);
                        productos.Cantidad += item.Cantidad;
                        ProductosController.Guardar(productos);
                    }
                }

                foreach (var item in anterior.ListaProductos)
                {
                    if (!Compra.ListaProductos.Any(Q => Q.ID == item.ID))
                    {
                        Database.Entry(item).State = EntityState.Deleted;
                        var productos = ProductosController.Buscar(item.ProductoId);
                        productos.Cantidad -= item.Cantidad;
                        ProductosController.Guardar(productos);
                    }

                }

                Database.Entry(Compra).State = EntityState.Modified;
                paso = Database.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Database.Dispose();
            }

            return paso;

        }

        public static Compras Buscar(int Id)
        {
            Compras Compra;
            Contexto Database = new Contexto();

            try
            {
                Compra = Database.Compras.Where(A => A.CompraId == Id).Include(A => A.ListaProductos).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Database.Dispose();
            }

            return Compra;
        }

        public static bool Eliminar(int Id)
        {
            bool paso = false;
            Contexto Database = new Contexto();

            try
            {
                Compras Compra = Database.Compras.Find(Id);
                if (Compra != null)
                {
                    foreach (var item in Compra.ListaProductos)
                    {
                        var producto = ProductosController.Buscar(item.ProductoId);
                        producto.Cantidad -= item.Cantidad;
                        ProductosController.Guardar(producto);
                    }
                    Database.Compras.Remove(Compra);
                    paso = Database.SaveChanges() > 0;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Database.Dispose();
            }

            return paso;

        }

        public static List<Compras> GetList(Expression<Func<Compras, bool>> expression)
        {
            Contexto Database = new Contexto();
            List<Compras> Lista;

            try
            {
                Lista = Database.Compras.Where(expression).Include(A => A.ListaProductos).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Database.Dispose();
            }
            return Lista;
        }

        public static List<Compras> Paginacion(Paginacion paginacion)
        {
            Contexto db = new Contexto();
            List<Compras> lista = new List<Compras>();
            paginacion = new Paginacion();
            try
            {
                paginacion.TotalRegistro = db.Compras.Where(A => true).Count();
                paginacion.TotalPaginas = paginacion.TotalRegistro / paginacion.RegistroPorPagina;
                lista = db.Compras.Skip((paginacion.PaginaActual - 1) * paginacion.RegistroPorPagina)
                     .Take(paginacion.RegistroPorPagina).Include(A=> A.ListaProductos).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return lista;

        }

    }
}
