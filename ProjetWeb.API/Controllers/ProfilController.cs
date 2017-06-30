using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetWeb.BL;
using ProjetWeb.Model;

namespace ProjetWeb.API.Controllers
{
    public class ProfilController : Controller
    {
        // on instancie un ProfilBL pour utiliser les méthodes
        private ProfilBL BLProfil = new ProfilBL();
        // GET: Profil
        public List<ProfilModel> Get()
        {
            //On appelle la fonction GetLesProfil
            return BLProfil.GetLesProfil();
        }
        public ProfilModel Get(int id)
        {
            //On appelle la fonction GetUnProfilById
            return BLProfil.GetUneProfilById(id);
        }
    }
}