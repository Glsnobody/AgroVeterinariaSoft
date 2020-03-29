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
    public class UnidadController
    {

        public static bool Guardar(Unidades entity)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (entity.UnidadId == 0)
                {
                    paso = Insertar(entity);
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
        public static bool Insertar(Unidades entity)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Unidades.Add(entity);
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

        public static bool Modificar(Unidades entity)
        {
            Contexto db = new Contexto();
            bool paso = false;
            try
            {
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

        public static Unidades Buscar(int Id)
        {
            Unidades unidad;
            Contexto db = new Contexto();

            try
            {
                unidad = db.Unidades.Where(A => A.UnidadId == Id).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return unidad;
        }

        public static bool Eliminar(int Id)
        {
            bool paso = false;

            Contexto db = new Contexto();

            try
            {
                Unidades unidad = db.Unidades.Find(Id);

                if (unidad != null)
                {
                    db.Unidades.Remove(unidad);
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

        public static List<Unidades> GetList(Expression<Func<Unidades, bool>> expression)
        {
            Contexto db = new Contexto();
            List<Unidades> Lista;

            try
            {
                Lista = db.Unidades.Where(expression).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;
        }

        public static List<Unidades> Paginacion(Paginacion paginacion)
        {
            Contexto db = new Contexto();
            List<Unidades> lista = new List<Unidades>();
            try
            {
                paginacion.TotalRegistro = db.Unidades.Where(A => true).Count();
                paginacion.TotalPaginas = paginacion.TotalRegistro / paginacion.RegistroPorPagina;
                lista = db.Unidades.Skip((paginacion.PaginaActual - 1) * paginacion.RegistroPorPagina)
                     .Take(paginacion.RegistroPorPagina).ToList();
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

        public static bool ExisteNombre(int id, string nombre)
        {
            bool paso = false;
            Contexto db = new Contexto();


            try
            {
                paso = db.Unidades.Where(A => A.UnidadId == id).Any(A => A.Descripcion.Contains(nombre));
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
    }
}
