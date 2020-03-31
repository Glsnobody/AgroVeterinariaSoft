using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgroVeterinariaSoft.Models
{
    public class PagosDetalle
    {
        [Key]
        public int PagoDetalleId { get; set; }
        public int PagoId { get; set; }        
        public int CompraId { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal ValorPagado { get; set; }

        public PagosDetalle()
        {
            PagoDetalleId = 0;
            PagoId = 0;
            CompraId = 0;
            FechaPago = DateTime.Now;
            ValorPagado = 0;

        }
    }
}
