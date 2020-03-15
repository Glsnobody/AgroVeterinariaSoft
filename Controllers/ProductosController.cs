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
    public class ProductosController
    {
        public static bool Guardar(Productos Producto)
        {
            bool paso = false;
            Contexto Database = new Contexto();
            try
            {
                if (Producto.ProductoId == 0)
                {
                    Insertar(Producto);
                }
                else
                {
                    Modificar(Producto);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }
        public static bool Insertar(Productos Producto)
        {
            Contexto Database = new Contexto();
            bool paso = false;

            try
            {
                Database.Productos.Add(Producto);
                paso = Database.SaveChanges() > 0;

            }
            catch (Exception)
            {

                throw;
            }
            Database.Dispose();

            return paso;
        }

        public static bool Modificar(Productos Producto)
        {
            Contexto Database = new Contexto();
            bool paso = false;
            try
            {
                Database.Entry(Producto).State = EntityState.Modified;
                paso = Database.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            Database.Dispose();

            return paso;

        }

        public static Productos Buscar(int Id)
        {
            Productos Producto;
            Contexto Database = new Contexto();

            try
            {
                Producto = Database.Productos.Find(Id);
            }
            catch (Exception)
            {

                throw;
            }
            Database.Dispose();

            return Producto;
        }

        public static bool Eliminar(int Id)
        {
            bool paso = false;

            Contexto Database = new Contexto();

            try
            {
                Productos Producto = Database.Productos.Find(Id);
                Database.Productos.Remove(Producto);
                if (Database.SaveChanges() > 0)
                {
                    paso = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            Database.Dispose();

            return paso;

        }

        public static List<Productos> GetList(Expression<Func<Productos, bool>> expression)
        {
            Contexto Database = new Contexto();
            List<Productos> Lista;

            try
            {
                Lista = Database.Productos.Where(expression).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return Lista;
        }
    }
}
