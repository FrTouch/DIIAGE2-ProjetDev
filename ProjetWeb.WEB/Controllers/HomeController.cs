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

        // Méthode pour la connexion à la page des réservations
        public ActionResult Reservation()
        {
            // On redirige vers l'index en cas d'appel d'utilisateur non connecté
            if (Session["Utilisateur"] == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Message = "Page des réservations.";

            return View();
        }

        // Méthode pour la connexion à la page d'administration
        public ActionResult Administration()
        {
            // On redirige vers l'index en cas d'appel d'utilisateur non connecté
            if (Session["Utilisateur"] == null)
            {
                return RedirectToAction("Index");
            }

            // On redirige vers l'index si l'utilisateur connecté n'est pas administrateur
            if ((int)Session["Profil"] != 1)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Page d'administration.";

            return View();
        }

        // Méthode qui permet aux utilisateurs de se déconnecter
        public ActionResult Deconnexion()
        {
            // On redirige vers l'index en cas d'appel d'utilisateur non connecté
            if (Session["Utilisateur"] == null)
            {
                return RedirectToAction("Index");
            }

            // On détruit la session
            Session.Abandon();
            return RedirectToAction("Index");
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
                // Récupération du nom d'utilisateur
                Session["Utilisateur"] = pLogin;
                // Récupération du status de l'utilisateur ==> 1: Administrateur; 2: Lecteur; 3: Utilisateur
                Session["Profil"] = r.getUtilisateur(pLogin,pPassword).profil_id;
                return 1;
            }
            
        }

    }
}