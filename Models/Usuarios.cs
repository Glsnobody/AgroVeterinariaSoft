using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroVeterinariaSoft.Models
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "Es necesario introducir una fecha")]
        [Range(typeof(DateTime), minimum: "1/1/2000", maximum: "1/1/2030", ErrorMessage = "La fecha esta fuera de rango")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Es necesario introducir un nombre")]
        [StringLength(maximumLength:50,ErrorMessage ="El nombre es muy largo")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Es necesario introducir un usuario")]
        [StringLength(maximumLength: 30, ErrorMessage = "El usuario es muy largo")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Es necesario introducir un correo")]
        [StringLength(maximumLength: 80, ErrorMessage = "El correo es muy largo")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Es necesario introducir una Contraseña")]
        [StringLength(maximumLength: 15, ErrorMessage = "La Contraseña es muy larga")]
        public string Psw { get; set; }
        [Required(ErrorMessage = "Es necesario introducir un nivel de acceso")]
        public string NivelAcceso { get; set; }

        public Usuarios()
        {
            UsuarioId = 0;
            Nombres = string.Empty;
            Usuario = string.Empty;
            Psw = string.Empty;
            Correo = string.Empty;
            NivelAcceso = string.Empty;
            Fecha = DateTime.Now;
        }



    }
}
