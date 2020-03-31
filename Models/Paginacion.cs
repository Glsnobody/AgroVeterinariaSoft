using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgroVeterinariaSoft.Models
{
    public class Paginacion
    {

        public int PaginaActual { get; set; }
        public int RegistroPorPagina { get; set; }
        public int TotalRegistro { get; set; }
        public int TotalPaginas { get; set; }
        public int Radio { get; set; }

        public Paginacion()
        {
            PaginaActual = 1;
            RegistroPorPagina = 10;
            TotalRegistro = 0;
            TotalPaginas = 0;
            Radio = 3;
        }

        public void CalcularPaginas()
        {
           TotalPaginas = TotalRegistro /RegistroPorPagina;
            if(RegistroPorPagina * TotalPaginas != TotalRegistro )
            {
                TotalPaginas++;
            }
        }
    }
}
