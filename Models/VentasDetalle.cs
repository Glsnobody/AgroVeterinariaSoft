using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgroVeterinariaSoft.Models
{
    public class VentasDetalle
    {
        [Key]
        public int VentaDetalleID { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        public VentasDetalle()
        {
            VentaDetalleID = 0;
            VentaId = 0;
            ProductoId = 0;
            Descripcion = string.Empty;
            Precio = 0;
            Cantidad = 0;
        }
        
    }
}
