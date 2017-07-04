using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetWeb.Model
{
    public class ReservationModel
    {

        public int id { get; set; }
        public int utilisateur_id { get; set; }
        public System.DateTime date_resa { get; set; }
        public bool purge { get; set; }

        public UtilisateurModel Utilisateur { get; set; }

        public ReservationModel() { }

        public ReservationModel(int idReservation, int utilisateur_idReservation, DateTime date_resaReservation, bool purgeReservation)
        {
            id = idReservation;
            utilisateur_id = utilisateur_idReservation;
            date_resa = date_resaReservation;
            purge = purgeReservation;
        }
    }
}