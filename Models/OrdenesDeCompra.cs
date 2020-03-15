using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroVeterinariaSoft.Models
{
    public class OrdenesDeCompra
    {
        [Key]
        public int OrdenDeCompraId { get; set; }
        public int SuplidorId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Impuesto { get; set; }
        public string Telefono { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("OrdenDeCompraId")]
        public virtual List<DetalleProductos> ListaProductos { get; set; }

        public OrdenesDeCompra()
        {
            OrdenDeCompraId = 0;
            SuplidorId = 0;
            Fecha = DateTime.Now;
            Impuesto = 0;
            Telefono = string.Empty;
            ListaProductos = new List<DetalleProductos>();
            Total = 0;

        }
    }
}
