using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToptanciCRMApi.Extencions
{
    public static class ModelStateExtencions
    {
        public static List<string> GetErrorMessage(this ModelStateDictionary dictionary)
        {
            return dictionary.SelectMany(m => m.Value.Errors).Select(x => x.ErrorMessage).ToList();
        }
    }
}
