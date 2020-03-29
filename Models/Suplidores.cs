using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroVeterinariaSoft.Models
{
    public class Suplidores
    {
        [Key]
        public int SuplidorId { get; set; }
        [Required(ErrorMessage = "Es necesario introducir un Nombre")]
        [StringLength(maximumLength: 50, ErrorMessage = "El nombre esta fuera de rango")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Es necesario introducir una Direccion")]
        [StringLength(maximumLength: 50, ErrorMessage = "La direccion esta fuera de rango")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Es necesario introducir un numero de Telefono")]
        [StringLength(maximumLength: 11, ErrorMessage = "El numero de telefono esta fuera de rango")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Por favor ingrese un No. de telefono valido")]
        public string  Telefono { get; set; }
        [Required(ErrorMessage = "Es necesario introducir un numero de Telefono")]
        [StringLength(maximumLength: 9, ErrorMessage = "El numero de telefono esta fuera de rango")]
        public string RNC { get; set; }
        [Required(ErrorMessage = "Es necesario introducir la fecha")]
        [Range(typeof(DateTime), minimum: "1/1/1990", maximum: "1/1/2030", ErrorMessage = "La fecha esta fuera de rango")]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        public DateTime FechaCreacion { get; set; }
        
        public Suplidores()
        {
            SuplidorId = 0;
            Nombre = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            RNC = string.Empty;
            FechaCreacion = DateTime.Now;
        }
    }
}
