using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetWeb.BL;
using ProjetWeb.Model;

namespace ProjetWeb.API.Controllers
{
    public class Ligne_resaController : Controller
    {
        // on instancie un Ligne_resaBL pour utiliser les méthodes
        private Ligne_resaBL BLLigne_resa = new Ligne_resaBL();
        // GET: UtLigne_resa
        public List<Ligne_resaModel> Get()
        {
            //On appelle la fonction GetLesLigne_resas
            return BLLigne_resa.GetLesLigne_resa();
        }
        public Ligne_resaModel Get(int id)
        {
            //On appelle la fonction GetUnLigne_resaById
            return BLLigne_resa.GetUneLigne_resaById(id);
        }
    }
}