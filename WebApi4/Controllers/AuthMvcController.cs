using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApi4.Models;

namespace WebApi4.Controllers
{
    public class AuthMvcController : Controller
    {
        // GET: AuthMvc
        //public ActionResult Index()
        //{
        //    BasicsEntities DbContext = new BasicsEntities();
        //    IEnumerable<UserAuth> user = null;
        //    IList<UserAuth> User = DbContext.UserAuths.OrderBy(c => c.Id).ToList();
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("http://localhost:57825/api/");
        //    var response = client.GetAsync("Auth");
        //    response.Wait();
        //    var rep_result = response.Result;
        //    var read = rep_result.Content.ReadAsAsync<IList<UserAuth>>();
        //    read.Wait();
        //    user = read.Result;
        //    return View(user);
        //}
    }
}