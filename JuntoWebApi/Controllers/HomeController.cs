using JuntoWebApi.Login;
using System;
using System.Web.Mvc;

namespace JuntoWebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            string resp = string.Empty;

            var setConn = new LoginAutentica().pegaConnBd();

            try {

                ViewBag.Title = "Home Page";
                setConn.Open();
            }
            catch(Exception xp)
            {
                ViewBag.Title = "Conexão falhou!";
            }

            



            return View();
        }
    }
}
