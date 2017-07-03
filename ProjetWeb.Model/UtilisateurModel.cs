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
        public string profil_nom { get; set; }

        //public ProfilModel Profil { get; set; }

        public List<FonctionnaliteModel> LstReservation { get; set; }

        public UtilisateurModel() { }

        public UtilisateurModel(int idUser, int profil_idUser, string nomUser, string prenomUser, string mailUser, string passwordUser, DateTime last_loginUser, int deconnexionUser, bool purgeUser, string profilUser)
        {
            id = idUser;
            profil_id = profil_idUser;
            nom = nomUser;
            prenom = prenomUser;
            mail = mailUser;
            password = passwordUser;
            last_login = last_loginUser;
            deconnexion = deconnexionUser;
            purge = purgeUser;
            profil_nom = profilUser;
        }
    }
}
