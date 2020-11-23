using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToptanciCRMApi.Security;

namespace ToptanciCRMApi.Domain.Response
{
    public class AccessTokenResponse : BaseResponse
    {

        public AccessToken accessToken { get; set; }

        private AccessTokenResponse(bool success, string message, AccessToken accessToken) : base(success, message)
        {
            this.accessToken = accessToken;
        }


        //if do  success
        public AccessTokenResponse(AccessToken accessToken) : this(true, string.Empty, accessToken) { }


        //if do failed        
        public AccessTokenResponse(string message) : this(false, message, null) { }



    }
}
