using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToptanciCRMApi.Domain.Response
{
    public class UserResponse:BaseResponse
    {
        public Kullanici user { get; set; }
        public UserResponse(Boolean success, string message, Kullanici user) : base(success, message)
        {
            this.user = user;
        }

        //success
        public UserResponse(Kullanici user) : this(true, String.Empty, user) { }

        //fail
        public UserResponse(string message) : this(false, message, null) { }


    }
}
