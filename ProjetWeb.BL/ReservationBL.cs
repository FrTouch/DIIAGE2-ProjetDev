using ProjetWeb.DAL;
using ProjetWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetWeb.BL
{
    public class ReservationBL
    {
        private static Projet_GestionEntities context = new Projet_GestionEntities();
        public static List<ReservationModel> GetLesReservation()
        {
            List<ReservationModel> lesReservation = new List<ReservationModel>();
            lesReservation = context.Reservation.Select(r => new ReservationModel()
            {
                id = r.id,
                utilisateur_id = r.utilisateur_id,
                date_resa = r.date_resa,
                purge = r.purge,
            }).ToList();
            return lesReservation;

        }

        public static ReservationModel GetUneReservationById(int idRes)
        {
            ReservationModel uneReservation = new ReservationModel();
            uneReservation = context.Reservation
                .Where(r => r.id == idRes)
                .Select(r => new ReservationModel()
                {
                    id = r.id,
                    utilisateur_id = r.utilisateur_id,
                    date_resa = r.date_resa,
                    purge = r.purge,

                }).FirstOrDefault();
            return uneReservation;
        }

        public ReservationModel CreateReservation(int idRes, int id_utilisateurResa, DateTime date_resaResa, bool purgeResa)
        {
            Reservation CreerReservation = new Reservation();

            CreerReservation.id = idRes;
            CreerReservation.utilisateur_id = id_utilisateurResa;
            CreerReservation.date_resa = date_resaResa;
            CreerReservation.purge = purgeResa;
            context.Reservation.Add(CreerReservation);
            context.SaveChanges();
            ReservationModel ReservationMod = new ReservationModel();
            ReservationMod.id = CreerReservation.id;
            ReservationMod.utilisateur_id = CreerReservation.utilisateur_id;
            ReservationMod.date_resa = CreerReservation.date_resa;
            ReservationMod.purge = CreerReservation.purge;
            return ReservationMod;
        }
    }
}
