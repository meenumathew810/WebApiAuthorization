using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi4.Models;

namespace WebApi4
{
    public class BusinessService
    {
        public UserAuth GenerateToken(int UserId, string Password)
        {
            string token = Guid.NewGuid().ToString();
            //DateTime issuedOn = DateTime.Now;
            DateTime expiredOn = DateTime.Now.AddSeconds(1000000);
            var tokendomain = new UserAuth
            {
                UserId = UserId,
                Password = Password,
                AuthToken= token,
                ExpiryTime= expiredOn

            };

            UserAuth ua = new UserAuth();
            BasicsEntities sd = new BasicsEntities();
            ua = sd.UserAuths.Where(x => x.UserId == UserId & x.Password == Password).FirstOrDefault();
            if (ua.UserId != null)
            {
                ua.AuthToken = tokendomain.AuthToken;
                //ua.IssuedOn = tokendomain.IssuedOn;
                ua.ExpiryTime = tokendomain.ExpiryTime;
                sd.SaveChanges();
            }
            return tokendomain;
        }

        public bool ValidateToken(string tokenValue)
        {
            
            BasicsEntities DbContext = new BasicsEntities();
            
             UserAuth token= DbContext.UserAuths.Where(c => c.AuthToken == tokenValue).FirstOrDefault();
            if (token != null)
            {
                return true;
            }
            else
            { 
                return false;
            }
            //throw new NotImplementedException();
        }
    }
}