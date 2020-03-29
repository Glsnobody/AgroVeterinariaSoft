using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgroVeterinariaSoft.Models
{
    public class Unidades
    {
        [Key]
        public int UnidadId { get; set; }
        [Required(ErrorMessage ="Es necesario establecer una descripcion")]
        [StringLength(maximumLength:50,MinimumLength =3,ErrorMessage ="La descripcion es muy corta")]
        public string Descripcion { get; set; }

        public Unidades()
        {
            UnidadId = 0;
            Descripcion = string.Empty;
        }
    }
}
