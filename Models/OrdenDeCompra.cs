using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class OrdenDeCompra
    {
        [Key]
        public int NoOrden { get; set; }
        public int CodigoSuplidor { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Impuesto { get; set; }
        public string Telefono { get; set; }
        public decimal Total { get; set; }

        public virtual List<DetalleProductos> ListaProductos { get; set; }

        public OrdenDeCompra()
        {
            NoOrden = 0;
            CodigoSuplidor = 0;
            Fecha = DateTime.Now;
            Impuesto = 0;
            Telefono = string.Empty;
            ListaProductos = new List<DetalleProductos>();
            Total = 0;

        }
    }
}
