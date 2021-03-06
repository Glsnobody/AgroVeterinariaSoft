﻿using AgroVeterinariaSoft.Data;
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
                foreach (var producto in entity.Productos)
                {
                    var productos = ProductosController.Buscar(producto.ProductoId);
                    productos.Cantidad -= producto.Cantidad;
                    ProductosController.Guardar(productos);

                }

                var cliente = ClientesController.Buscar(entity.ClienteId);
                cliente.Balance += entity.Total;
                ClientesController.Guardar(cliente);

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
                    var productos = ProductosController.Buscar(producto.ProductoId);
                    productos.Cantidad -= producto.Cantidad;
                    ProductosController.Guardar(productos);

                }

                foreach (var producto in anterior.Productos)
                {
                    if (!entity.Productos.Any(A => A.VentaDetalleID == producto.VentaDetalleID))
                    {
                        db.Entry(producto).State = EntityState.Deleted;
                        var productos = ProductosController.Buscar(producto.ProductoId);
                        productos.Cantidad += producto.Cantidad;
                        ProductosController.Guardar(productos);
                    }
                }

                var cliente = ClientesController.Buscar(entity.ClienteId);
                cliente.Balance -= anterior.Total;
                cliente.Balance += entity.Total;
                ClientesController.Guardar(cliente);
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

                    foreach (var producto in venta.Productos)
                    {
                        var productos = ProductosController.Buscar(producto.ProductoId);
                        productos.Cantidad += producto.Cantidad;
                        ProductosController.Guardar(productos);

                    }

                    var cliente = ClientesController.Buscar(venta.ClienteId);
                    cliente.Balance -= venta.Total;
                    ClientesController.Guardar(cliente);

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
                list = db.Ventas.Where(expression).Include(A=> A.Productos).ToList();
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

        public static List<Ventas> Paginacion(Paginacion paginacion, Expression<Func<Ventas, bool>> expression)
        {
            Contexto db = new Contexto();
            List<Ventas> lista = new List<Ventas>();
            try
            {
                paginacion.TotalRegistro = db.Ventas.Where(expression).Count();
                paginacion.CalcularPaginas();
                lista = db.Ventas.Where(expression).Skip((paginacion.PaginaActual - 1) * paginacion.RegistroPorPagina)
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
    }
}
