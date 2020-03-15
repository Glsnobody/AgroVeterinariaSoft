using AgroVeterinariaSoft.Data;
using AgroVeterinariaSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                Database.Compras.Add(Compra);

                foreach (var item in Compra.ListaProductos)
                {

                }
            }
            catch (Exception)
            {

                throw;
            }
            Database.Dispose();
            return paso;

        }

    }
}
