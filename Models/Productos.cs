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
        public int NoProducto { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int Minimo { get; set; }
        public string Unidad { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
        public decimal Ganancia { get; set; }

    }
}
