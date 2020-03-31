using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgroVeterinariaSoft.Models
{
    public class Pagos
    {
        [Key]
        public int PagoId { get; set; }
        
        [Required(ErrorMessage = "Es necesario que seleccione una fecha")]
        [Range(typeof(DateTime), minimum: "1/1/2000", maximum: "1/1/2030", ErrorMessage = "La fecha esta fuera de rango")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Es necesario que se fije un valor")]
        [Range(typeof(decimal), minimum: "1", maximum: "10000000000", ErrorMessage = "El valor esta fuera de rango")]
        public decimal Valor { get; set; }
        [ForeignKey("PagoId")]
        public virtual List<PagosDetalle> Detalle { get; set; }

        public Pagos()
        {
            PagoId = 0;
            
            Fecha = DateTime.Now;
            Valor = 0;
            Detalle = new List<PagosDetalle>();
        }

    }
}
