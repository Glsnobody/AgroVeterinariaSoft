using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgroVeterinariaSoft.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Es necesario introducir un nombre")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Es necesario introducir una direccion")]
        [StringLength(maximumLength:100,ErrorMessage ="La direccion esta fuera de rango")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Es necesario introducir un telefono")]
        [StringLength(maximumLength: 10, ErrorMessage = "El telefono esta fuera de rango")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Es necesario introducir una fecha de creacion")]
        [Range(typeof(DateTime), minimum: "1/1/2000", maximum: "1/1/2030", ErrorMessage = "La fecha de creacion esta fuera de rango")]
        public DateTime FechaCreacion { get; set; }
        [Required(ErrorMessage = "Es necesario introducir una fecha de nacimiento")]
        [Range(typeof(DateTime), minimum: "1/1/1990", maximum: "1/1/2030", ErrorMessage = "La fecha de nacimiento esta fuera de rango")]
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "Es necesario introducir una cedula")]
        [StringLength(maximumLength:13,MinimumLength =13,ErrorMessage ="La cedula es muy pequena o muy grande")]
        public string Cedula { get; set; }
        public decimal Balance { get; set; }

        public Clientes()
        {
            ClienteId = 0;
            Nombres = string.Empty;
            FechaCreacion = DateTime.Now;
            FechaNacimiento = DateTime.Now;
            Cedula = string.Empty;
            Balance = 0;
        }

    }
}
