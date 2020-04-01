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
    public class UsuariosController
    {

        public static bool Guardar(Usuarios entity)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (!db.Usuarios.Any(A => A.UsuarioId == entity.UsuarioId))
                {
                    if (entity.UsuarioId == 0)
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
        private static bool Insertar(Usuarios entity)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                if(!ExisteUsuario(entity.Usuario))
                {
                    entity.Psw =Usuarios.Encriptar(entity.Psw);
                    db.Usuarios.Add(entity);
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

        private static bool Modificar(Usuarios entity)
        {
            Contexto db = new Contexto();
            bool paso = false;
            try
            {
                entity.Psw = Usuarios.Encriptar(entity.Psw);
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

        public static Usuarios Buscar(int Id)
        {
            Usuarios usuario;
            Contexto db = new Contexto();

            try
            {
                usuario = db.Usuarios.Where(A => A.UsuarioId == Id).FirstOrDefault();
                usuario.Psw = Usuarios.DesEncriptar(usuario.Psw);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }


            return usuario;
        }

        public static bool Eliminar(int Id)
        {
            bool paso = false;

            Contexto db = new Contexto();

            try
            {
                Usuarios usuario = Buscar(Id);
                if (usuario != null)
                {
                    db.Entry(usuario).State = EntityState.Deleted;
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

        public static List<Usuarios> GetList(Expression<Func<Usuarios, bool>> expression)
        {
            Contexto db = new Contexto();
            List<Usuarios> list = new List<Usuarios>();

            try
            {
                list = db.Usuarios.Where(expression).ToList();
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
                paso = db.Usuarios.Any(A => A.UsuarioId == id);
            }
            catch (Exception)
            {

                throw;
            }

            return paso;
        }

       

       

        public static bool ExisteUsuario( string nombre)
        {
            bool paso = false;
            Contexto db = new Contexto();


            try
            {
                paso = db.Usuarios.Any(A => A.Usuario.Contains(nombre));
            }
            catch (Exception)
            {

                throw;
            }

            return paso;
        }

        public static List<Usuarios> Paginacion(Paginacion paginacion, Expression<Func<Usuarios, bool>> expression)
        {
            Contexto db = new Contexto();
            List<Usuarios> lista = new List<Usuarios>();
            try
            {
                paginacion.TotalRegistro = db.Usuarios.Where(expression).Count();
                paginacion.CalcularPaginas();
                lista = db.Usuarios.Where(expression).Skip((paginacion.PaginaActual - 1) * paginacion.RegistroPorPagina)
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

        public static bool InicioSesion(string Usuario,string psw)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {

                paso = db.Usuarios.Any(A => A.Usuario.Equals(Usuario) && A.Psw.Equals(Usuarios.Encriptar(psw)));
            }
            catch (Exception)
            {

                throw;
            }

            return paso;
        }

        public static string GetRol(string Usuario)
        {
            string nivel = "Bajo";
            Contexto db = new Contexto();

            try
            {
                nivel = db.Usuarios.Where(A => A.Usuario.Equals(Usuario)).Select(A => A.NivelAcceso).FirstOrDefault();
               
            }
            catch (Exception)
            {

                throw;
            }

            return nivel;
        }


        public static bool InicializarUsuarios()
        {
            Contexto db = new Contexto();
            bool paso = false;
            try
            {
                if(db.Usuarios.Count() == 0)
                {
                   paso = Insertar(new Usuarios() { Usuario = "Admin",Psw="12345",NivelAcceso="Alto"});
                   
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
    }
}
