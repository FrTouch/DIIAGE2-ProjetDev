using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetWeb.BL;
using ProjetWeb.Model;
using System.Web.Http;

namespace ProjetWeb.API.Controllers
{
    public class Ligne_resaController : ApiController
    {
        // on instancie un Ligne_resaBL pour utiliser les méthodes
        private Ligne_resaBL BLLigne_resa = new Ligne_resaBL();
        // GET: UtLigne_resa
        public List<Ligne_resaModel> Get()
        {
            //On appelle la fonction GetLesLigneresas
            return BLLigne_resa.GetLesLignesResa();
        }
        public Ligne_resaModel Get(int id)
        {
            //On appelle la fonction GetUnLigneresaById
            return BLLigne_resa.GetUneLigneById(id);
        }
    }
}