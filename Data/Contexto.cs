using AgroVeterinariaSoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgroVeterinariaSoft.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Suplidores> Suplidores { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Compras> Compras { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Unidades> Unidades { get; set; }
        public DbSet<Pagos> Pagos { get; set; }
        public DbSet<PagosDetalle> PagosDetalles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = tcp:agroveterinariasoftdbserver.database.windows.net, 1433; Initial Catalog = AgroVeterinariaSoft_db; Persist Security Info = False; User ID = administrador; Password =Admin12345; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

        }
    }
}
