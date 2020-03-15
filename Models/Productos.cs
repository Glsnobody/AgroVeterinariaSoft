using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroVeterinariaSoft.Models
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int Minimo { get; set; }
        public string Unidad { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
        public decimal Ganancia { get; set; }

        public Productos()
        {
            ProductoId = 0;
            Fecha = DateTime.Now;
            Descripcion = string.Empty;
            Cantidad = 0;
            Minimo = 0;
            Unidad = string.Empty;
            Costo = 0;
            Precio = 0;
            Ganancia = 0;

        }
    }


}
