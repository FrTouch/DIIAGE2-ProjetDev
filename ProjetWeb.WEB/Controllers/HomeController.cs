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

        /// <summary>
        /// Méthode de vérification du compte lors de la connexion
        /// </summary>
        /// <param name="pLogin">Adresse mail pour la connexion</param>
        /// <param name="pPassword">Mot de passe de l'utilisateur</param>
        /// <returns>0 ou 1 selon le succès de la fonction</returns>
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