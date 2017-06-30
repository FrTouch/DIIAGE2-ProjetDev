using ProjetWeb.BL;
using ProjetWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ProjetWeb.API.Controllers
{
    public class UtilisateurController : ApiController
    {
        // on instancie un UtilisateurBL pour utiliser les méthodes
        private UtilisateurBL BLUser = new UtilisateurBL();
        // GET: Utilisateur
        public List<UtilisateurModel> Get()
        {
            //On appelle la fonction GetLesUtilisateurs
            return BLUser.GetLesUtilisateur();
        }
        public UtilisateurModel Get(int id)
        {
            //On appelle la fonction GetUnUtilisateurById
            return BLUser.GetUnUtilisateurById(id);
        }
    }
}