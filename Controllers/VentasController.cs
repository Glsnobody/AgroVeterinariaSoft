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
    public class VentasController
    {
        public static bool Guardar(Ventas entity)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (!db.Ventas.Any(A => A.VentaId == entity.VentaId))
                {
                    if (entity.VentaId == 0)
                    {
                        paso = Insertar(entity);
                    }
                }
                else
                {
                    paso = Modificar(entity);
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
        private static bool Insertar(Ventas entity)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Ventas.Add(entity);
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

        private static bool Modificar(Ventas entity)
        {
            Contexto db = new Contexto();
            bool paso = false;
            try
            {
                var anterior = Buscar(entity.VentaId);

                foreach (var producto in entity.Productos)
                {
                    if(producto.VentaDetalleID == 0)
                        db.Entry(producto).State = EntityState.Added;
                }

                foreach (var producto in anterior.Productos)
                {
                    if (!entity.Productos.Any(A => A.ProductoId == producto.ProductoId))
                    {
                        db.Entry(producto).State = EntityState.Deleted;
                    }
                }


                db.Entry(entity).State = EntityState.Modified;
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

        public static Ventas Buscar(int Id)
        {
            Ventas venta;
            Contexto db = new Contexto();

            try
            {
                venta = db.Ventas.Where(A => A.VentaId == Id).Include(A=> A.Productos).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }


            return venta;
        }

        public static bool Eliminar(int Id)
        {
            bool paso = false;

            Contexto db = new Contexto();

            try
            {
                Ventas venta = Buscar(Id);
                if (venta != null)
                {
                    db.Entry(venta).State = EntityState.Deleted;
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

        public static List<Ventas> GetList(Expression<Func<Ventas, bool>> expression)
        {
            Contexto db = new Contexto();
            List<Ventas> list = new List<Ventas>();

            try
            {
                list = db.Ventas.Where(expression).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return list;
        }

        public static bool Existe(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();


            try
            {
                paso = db.Ventas.Any(A => A.VentaId == id);
            }
            catch (Exception)
            {

                throw;
            }

            return paso;
        }
    }
}
