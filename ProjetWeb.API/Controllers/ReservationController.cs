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
    public class ReservationController : ApiController
    {
        // on instancie un ReservationBL pour utiliser les méthodes
        private ReservationBL BLReservation = new ReservationBL();
        // GET: Utilisateur
        public List<ReservationModel> Get()
        {
            //On appelle la fonction GetLesReservations
            return BLReservation.GetLesReservation();
        }
        public ReservationModel Get(int id)
        {
            //On appelle la fonction GetUnUtilisateurById
            return BLReservation.GetUneReservationById(id);
        }
    }
}