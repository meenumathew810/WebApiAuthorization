using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi4.Controllers
{
    public class AuthController : ApiController
    {
        
        private HttpResponseMessage GetAuthToken(int UserId,string Password)
        {
            BusinessService bs = new BusinessService();
            var token = bs.GenerateToken(UserId, Password);
            var response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");
            response.Headers.Add("Token", token.AuthToken);
            response.Headers.Add("TokenExpiry", DateTime.Now.AddHours(2).ToString());
            response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");

            return response;

        }

        //[Route("Authenticating")]
        [HttpGet]
        public HttpResponseMessage Authenticate(int UserId, string Password)
        {
            return GetAuthToken(UserId, Password);
        }


        //[AuthorizationRequired]
        [Route("GetUserAgain")]
        public string GetUserDetails(string Password)
        {
            return "Invalid";
        }
    }
}
