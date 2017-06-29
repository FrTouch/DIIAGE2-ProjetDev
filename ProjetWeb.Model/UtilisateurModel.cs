using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetWeb.Model
{
    public class UtilisateurModel
    {
        public int id { get; set; }
        public int profil_id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public System.DateTime last_login { get; set; }
        public int deconnexion { get; set; }
        public bool purge { get; set; }

        public ProfilModel Profil { get; set; }

        public List<ReservationModel> LstReservation { get; set; }

        public UtilisateurModel() { }
    }
}
