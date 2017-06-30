using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetWeb.BL;
using ProjetWeb.Model;

namespace ProjetWeb.API.Controllers
{
    public class FonctionnaliteController : Controller
    {
        // on instancie un FonctionnaliteBL pour utiliser les méthodes
        private FonctionnaliteBL BLFonctionnalite = new FonctionnaliteBL();
        // GET: Fonctionnalite
        public List<FonctionnaliteModel> Get()
        {
            //On appelle la fonction GetLesLigne_resas
            return BLFonctionnalite.GetLesFonctionnalite();
        }
        public FonctionnaliteModel Get(int id)
        {
            //On appelle la fonction GetUnFonctionnaliteById
            return BLFonctionnalite.GetUneFonctionnaliteById(id);
        }
    }
}