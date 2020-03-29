using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgroVeterinariaSoft.Models
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        [Required(ErrorMessage = "Es necesario especificar un Cliente")]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Es necesario establecer una fecha")]
        [Range(typeof(DateTime),minimum:"1/1/2018",maximum:"1/1/2025",ErrorMessage ="La fecha esta fuera de rango")]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        public DateTime Fecha { get; set; }
        [StringLength(maximumLength:100,ErrorMessage ="La observacion es muy larga")]
        public string Observacion { get; set; }
        [Required(ErrorMessage = "Es necesario establecer un total")]
        [Range(typeof(decimal),minimum:"0",maximum:"1000000000000000",ErrorMessage ="Total esta fuera de rango")]
        public decimal Total { get; set; }
        [Required(ErrorMessage = "Es necesario especificar la cantidad de Itbis")]
        [Range(typeof(decimal), minimum: "0", maximum: "1000000000000000", ErrorMessage = "Itbis esta fuera de rango")]
        public decimal Itbis { get; set; }
        [Required(ErrorMessage = "Es necesario definir un tipo de compra")]
        [Range(typeof(int), minimum: "1", maximum: "2", ErrorMessage = " El tipo de compra es incorrecto")]
        public int TipoVenta { get; set; }
        [ForeignKey("VentaId")]
        public List<VentasDetalle> Productos { get; set; }

        public Ventas()
        {
            VentaId = 0;
            ClienteId = 0;
            Fecha = DateTime.Now;
            Observacion = string.Empty;
            Total = 0;
            Itbis = 0;
            TipoVenta = 1;
            Productos = new List<VentasDetalle>();
        }
    }
}
