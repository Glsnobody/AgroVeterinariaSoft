using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgroVeterinariaSoft.Data;
using AgroVeterinariaSoft.Models;
using Microsoft.EntityFrameworkCore;

namespace AgroVeterinariaSoft.Controllers
{
    public class SuplidoresController
    {
        public virtual bool Insertar(Suplidores Suplidor)
        {
            Contexto Database = new Contexto(); 
            bool paso = false;

            try
            {
                Database.Suplidores.Add(Suplidor);
                paso = Database.SaveChanges() > 0;

            }
            catch (Exception)
            {

                throw;
            }

            return paso;
        }

        public virtual bool Modificar(Suplidores Suplidor)
        {
            Contexto Database = new Contexto();
            bool paso = false;
            try
            {
                Database.Entry(Suplidor).State = EntityState.Modified;
                paso = Database.SaveChanges()>0;
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }
    }
}
