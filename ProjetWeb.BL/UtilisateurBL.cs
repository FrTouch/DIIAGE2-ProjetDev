using ProjetWeb.DAL;
using ProjetWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetWeb.BL
{
    public class UtilisateurBL
    {
        private static Projet_GestionEntities context = new Projet_GestionEntities();
        public static List<UtilisateurModel> GetLesUtilisateur()
        {           
            List<UtilisateurModel> lesUtilisateur = new List<UtilisateurModel>();
            lesUtilisateur = context.Utilisateur.Select(u=>new UtilisateurModel()
            {
                id = u.id,
                nom = u.nom,
                prenom = u.prenom,
                mail = u.mail
            }).ToList();
            return lesUtilisateur;
        }

        public static UtilisateurModel GetUnUtilisateurById(int idUser)
        {
            UtilisateurModel unUtilisateur = new UtilisateurModel();
            unUtilisateur = context.Utilisateur
                .Where(u => u.id == idUser)
                .Select(u => new UtilisateurModel()
            {
                id = u.id,
                nom = u.nom,
                prenom = u.prenom,
                mail = u.mail
            }).FirstOrDefault();
            return unUtilisateur;
        }
    }
}
