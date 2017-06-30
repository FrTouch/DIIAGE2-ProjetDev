using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetWeb.BL;
using ProjetWeb.Model;

namespace ProjetWeb.API.Controllers
{
    public class RessourceController : Controller
    {
        // on instancie un RessourceBL pour utiliser les méthodes
        private RessourceBL BLRessource = new RessourceBL();
        // GET: Utilisateur
        public List<RessourceModel> Get()
        {
            //On appelle la fonction GetLesRessources
            return BLRessource.GetLesRessource();
        }
        public RessourceModel Get(int id)
        {
            //On appelle la fonction GetUnRessourceById
            return BLRessource.GetUneRessourceById(id);
        }
    }
}