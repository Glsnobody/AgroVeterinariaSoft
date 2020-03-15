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
    public class ClientesController
    {
        public static bool Guardar(Clientes entity)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (!db.Clientes.Any(A => A.ClienteId == entity.ClienteId))
                {
                    if (entity.ClienteId == 0)
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
        private static bool Insertar(Clientes entity)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Clientes.Add(entity);
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

        private static bool Modificar(Clientes entity)
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

        public static Clientes Buscar(int Id)
        {
            Clientes cliente;
            Contexto db = new Contexto();

            try
            {
                cliente = db.Clientes.Where(A => A.ClienteId == Id).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }


            return cliente;
        }

        public static bool Eliminar(int Id)
        {
            bool paso = false;

            Contexto db = new Contexto();

            try
            {
                Clientes cliente = Buscar(Id);
                if (cliente != null)
                {
                    db.Entry(cliente).State = EntityState.Deleted;
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

        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> expression)
        {
            Contexto db = new Contexto();
            List<Clientes> list = new List<Clientes>();

            try
            {
                list = db.Clientes.Where(expression).ToList();
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
                paso = db.Clientes.Any(A => A.ClienteId == id);
            }
            catch (Exception)
            {

                throw;
            }

            return paso;
        }
    }
}
