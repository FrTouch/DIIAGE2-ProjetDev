using ProjetWeb.DAL;
using ProjetWeb.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetWeb.BL
{
    public class UtilisateurBL
    {
        private static Projet_GestionEntities context = new Projet_GestionEntities();
        public List<UtilisateurModel> GetLesUtilisateur()
        {           
            List<UtilisateurModel> lesUtilisateur = new List<UtilisateurModel>();
            lesUtilisateur = context.Utilisateur.Select(u=>new UtilisateurModel()
            {
                id = u.id,
                nom = u.nom,
                prenom = u.prenom,
                mail = u.mail,
                profil_id = u.profil_id
            }).ToList();
            return lesUtilisateur;
        }

        public  UtilisateurModel GetUnUtilisateurById(int idUser)
        {
            UtilisateurModel unUtilisateur = new UtilisateurModel();
            unUtilisateur = context.Utilisateur
                .Where(u => u.id == idUser)
                .Select(u => new UtilisateurModel()
            {
                id = u.id,
                nom = u.nom,
                prenom = u.prenom,
                mail = u.mail,
                profil_id = u.profil_id

                }).FirstOrDefault();
            return unUtilisateur;
        }

        public UtilisateurModel CreateUtilisateur(int idUser, int profil_idUser, string nomUser, string prenomUser, string mailUser, string passwordUser, DateTime last_loginUser, int deconnexionUser, bool purgeUser)
        {
            Utilisateur CreerUtilisateur = new Utilisateur();

            CreerUtilisateur.id = idUser;
            CreerUtilisateur.profil_id = profil_idUser;
            CreerUtilisateur.nom = nomUser;
            CreerUtilisateur.prenom = prenomUser;
            CreerUtilisateur.mail = mailUser;
            CreerUtilisateur.password = passwordUser;
            CreerUtilisateur.last_login = last_loginUser;
            CreerUtilisateur.deconnexion = deconnexionUser;
            CreerUtilisateur.purge = purgeUser;

            context.Utilisateur.Add(CreerUtilisateur);
            context.SaveChanges();
            UtilisateurModel UtilisateurMod = new UtilisateurModel();
            UtilisateurMod.id = CreerUtilisateur.id;
            UtilisateurMod.profil_id = CreerUtilisateur.profil_id;
            UtilisateurMod.nom = CreerUtilisateur.nom;
            UtilisateurMod.prenom = CreerUtilisateur.prenom;
            UtilisateurMod.mail = CreerUtilisateur.mail;
            UtilisateurMod.password = CreerUtilisateur.password;
            UtilisateurMod.last_login = CreerUtilisateur.last_login;
            UtilisateurMod.deconnexion = CreerUtilisateur.deconnexion;
            UtilisateurMod.purge = CreerUtilisateur.purge;
            return UtilisateurMod;
        }

        public UtilisateurModel ModifierUtilisateur(int idUser, int profil_idUser, string nomUser, string prenomUser, string mailUser, string passwordUser, DateTime last_loginUser, int deconnexionUser, bool purgeUser)
        {
            Utilisateur ModifierUtilisateur = new Utilisateur();
            ModifierUtilisateur.id = idUser;
            ModifierUtilisateur.profil_id = profil_idUser;
            ModifierUtilisateur.nom = nomUser;
            ModifierUtilisateur.prenom = prenomUser;
            ModifierUtilisateur.mail = mailUser;
            ModifierUtilisateur.password = passwordUser;
            ModifierUtilisateur.last_login = last_loginUser;
            ModifierUtilisateur.deconnexion = deconnexionUser;
            ModifierUtilisateur.purge = purgeUser;

            context.Entry(ModifierUtilisateur).State = EntityState.Modified;
            context.SaveChanges();
            UtilisateurModel UtilisateurMod = new UtilisateurModel();
            UtilisateurMod.id = ModifierUtilisateur.id;
            UtilisateurMod.profil_id = ModifierUtilisateur.profil_id;
            UtilisateurMod.nom = ModifierUtilisateur.nom;
            UtilisateurMod.prenom = ModifierUtilisateur.prenom;
            UtilisateurMod.mail = ModifierUtilisateur.mail;
            UtilisateurMod.password = ModifierUtilisateur.password;
            UtilisateurMod.last_login = ModifierUtilisateur.last_login;
            UtilisateurMod.deconnexion = ModifierUtilisateur.deconnexion;
            UtilisateurMod.purge = ModifierUtilisateur.purge;
            return UtilisateurMod;
        }

        public UtilisateurModel DeleteUtilisateur(int idUser)
        {
            Utilisateur SupprimerUtilisateur = new Utilisateur();

            SupprimerUtilisateur.id = idUser;
            //SupprimerUtilisateur.profil_id = profil_idUser;
            //SupprimerUtilisateur.nom = nomUser;
            //SupprimerUtilisateur.prenom = prenomUser;
            //SupprimerUtilisateur.mail = mailUser;
            //SupprimerUtilisateur.password = passwordUser;
            //SupprimerUtilisateur.last_login = last_loginUser;
            //SupprimerUtilisateur.deconnexion = deconnexionUser;
            //SupprimerUtilisateur.purge = purgeUser;

            context.Utilisateur.Remove(SupprimerUtilisateur);
            context.SaveChanges();
            UtilisateurModel UtilisateurMod = new UtilisateurModel();
            UtilisateurMod.id = SupprimerUtilisateur.id;
            //UtilisateurMod.profil_id = SupprimerUtilisateur.profil_id;
            //UtilisateurMod.nom = SupprimerUtilisateur.nom;
            //UtilisateurMod.prenom = SupprimerUtilisateur.prenom;
            //UtilisateurMod.mail = SupprimerUtilisateur.mail;
            //UtilisateurMod.password = SupprimerUtilisateur.password;
            //UtilisateurMod.last_login = SupprimerUtilisateur.last_login;
            //UtilisateurMod.deconnexion = SupprimerUtilisateur.deconnexion;
            //UtilisateurMod.purge = SupprimerUtilisateur.purge;
            return UtilisateurMod;
        }
    }
}
