using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgroVeterinariaSoft.Shared.Componente
{
    public class PaginacionButtons<T> : InputBase<T> where T : class
    {


        protected override bool TryParseValueFromString(string value, out T result, out string validationErrorMessage)
        {
            throw new NotImplementedException();
        }
    }
}
