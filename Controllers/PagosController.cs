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
    public class PagosController
    {

        public static bool Guardar(Pagos entity)
        {
            bool paso = false;


            if (!Existe(entity.PagoId))
            {
                if (entity.PagoId == 0)
                {
                    paso = Insertar(entity);
                }
            }
            else
            {
                paso = Modificar(entity);
            }



            return paso;
        }
        private static bool Insertar(Pagos entity)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {

                foreach (var pago in entity.Detalle)
                {
                    var compra = ComprasController.Buscar(pago.CompraId);
                    compra.Balance -= pago.ValorPagado;
                    ComprasController.Guardar(compra);
                    
                }


                db.Pagos.Add(entity);
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

        private static bool Modificar(Pagos entity)
        {
            Contexto db = new Contexto();
            bool paso = false;
            try
            {
                var anterior = Buscar(entity.PagoId);

                foreach (var pago in entity.Detalle)
                {
                    if (pago.PagoDetalleId == 0)
                    {
                        db.Entry(pago).State = EntityState.Added;
                        var compra = ComprasController.Buscar(pago.CompraId);
                        compra.Balance -= pago.ValorPagado;
                        ComprasController.Guardar(compra);
                    }
                       

                }

                foreach (var pago in anterior.Detalle)
                {
                    if (!entity.Detalle.Any(A => A.PagoDetalleId == pago.PagoDetalleId))
                    {
                        db.Entry(pago).State = EntityState.Deleted;
                        var compra = ComprasController.Buscar(pago.CompraId);
                        compra.Balance += pago.ValorPagado;
                        ComprasController.Guardar(compra);
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

        public static Pagos Buscar(int Id)
        {
            Pagos pago;
            Contexto db = new Contexto();

            try
            {
                pago = db.Pagos.Where(A => A.PagoId == Id).Include(A => A.Detalle).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }


            return pago;
        }

        public static bool Eliminar(int Id)
        {
            bool paso = false;

            Contexto db = new Contexto();

            try
            {
                Pagos pago = Buscar(Id);
                if (pago != null)
                {

                    foreach (var pagos in pago.Detalle)
                    {
                        var compra = ComprasController.Buscar(pagos.CompraId);
                        compra.Balance += pagos.ValorPagado;
                        ComprasController.Guardar(compra);

                    }

                    db.Entry(pago).State = EntityState.Deleted;
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

        public static List<Pagos> GetList(Expression<Func<Pagos, bool>> expression)
        {
            Contexto db = new Contexto();
            List<Pagos> list = new List<Pagos>();

            try
            {
                list = db.Pagos.Where(expression).Include(A => A.PagoId).ToList();
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
                paso = db.Pagos.Any(A => A.PagoId == id);
            }
            catch (Exception)
            {

                throw;
            }

            return paso;
        }

        public static List<Pagos> Paginacion(Paginacion paginacion, Expression<Func<Pagos, bool>> expression)
        {
            Contexto db = new Contexto();
            List<Pagos> lista = new List<Pagos>();
            try
            {
                paginacion.TotalRegistro = db.Pagos.Where(expression).Count();
                paginacion.CalcularPaginas();
                lista = db.Pagos.Where(expression).Skip((paginacion.PaginaActual - 1) * paginacion.RegistroPorPagina)
                     .Take(paginacion.RegistroPorPagina).Include(A=> A.Detalle).ToList();
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
