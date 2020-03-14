using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroVeterinariaSoft.Models
{
    public class DetalleProductos
    {
        [Key]
        public int ID { get; set; }
        public int NoProducto { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }

        public DetalleProductos(int iD, int noProducto, string descripcion, int cantidad, decimal precio, decimal importe)
        {
            ID = iD;
            NoProducto = noProducto;
            Descripcion = descripcion;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }
    }
}
