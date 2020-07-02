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
            optionsBuilder.UseSqlite(@"Data Source = VeteSoft.db");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>().HasData(new Models.Usuarios {
                UsuarioId = 2,
            Nombres = "admin",
            Usuario = "admin",
            Psw =  Models.Usuarios.Encriptar("admin"),
            Correo = string.Empty,
            NivelAcceso = "admin",
            Fecha = DateTime.Now
        });
        }
    }
}
