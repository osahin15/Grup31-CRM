using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToptanciCRMApi.Domain
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public BaseResponse(bool succes, string message)
        {
            this.Success = succes;
            this.Message = message;
        }
    }
}
