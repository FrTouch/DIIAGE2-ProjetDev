using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetWeb.WEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public int Login(string pLogin, string pPassword)
        {
            ProjetWeb.DAL.Repository r = new DAL.Repository();

            if (r.getUtilisateur(pLogin,pPassword) == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
            
        }

    }
}