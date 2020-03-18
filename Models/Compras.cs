using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroVeterinariaSoft.Models
{
    public class Compras
    {
        [Key]
        public int CompraId { get; set; }
        [Required(ErrorMessage ="Es necesario introducir un suplidor")]
        [Range(typeof(int), minimum: "0", maximum: "100", ErrorMessage = "El suplidorId esta fuera de rango")]
        public int SuplidorId { get; set; }

        [Required(ErrorMessage = "Es necesario introducir la fecha actual")]
        [Range(typeof(DateTime), minimum: "1/1/1990", maximum: "1/1/2030", ErrorMessage = "La fecha de compra esta fuera de rango")]
        public DateTime Fecha { get; set; }

        //[Required(ErrorMessage = "Es necesario Agregar ")]
        [Range(typeof(decimal), minimum: "0", maximum: "100", ErrorMessage = "El impuesto esta fuera de rango")]
        public decimal Impuesto { get; set; }

        [Required(ErrorMessage = "Esnecesario tener un Total")]
        [Range(typeof(decimal), minimum: "0", maximum: "100", ErrorMessage = "El total esta fuera de rango")]
        public decimal Total { get; set; }
        

        [ForeignKey("CompraId")]
        public virtual List<DetalleProductos> ListaProductos { get; set; }

        public Compras()
        {
            CompraId = 0;
            SuplidorId = 0;
            Fecha = DateTime.Now;
            Impuesto = 0;
            ListaProductos = new List<DetalleProductos>();
            Total = 0;

        }
    }
}
