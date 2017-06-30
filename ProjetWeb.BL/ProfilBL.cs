using ProjetWeb.DAL;
using ProjetWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetWeb.BL
{
    class ProfilBL
    {
        private static Projet_GestionEntities context = new Projet_GestionEntities();
        public List<ProfilModel> GetLesProfil()
        {
            List<ProfilModel> lesProfils = new List<ProfilModel>();
            lesProfils = context.Profil.Select(p => new ProfilModel()
            {
                id = p.id,
                nom = p.nom
            }).ToList();
            return lesProfils;

        }

        public ProfilModel GetUnProfilById(int idPr)
        {
            ProfilModel unProfil = new ProfilModel();
            unProfil = context.Profil
                .Where(p => p.id == idPr)
                .Select(p => new ProfilModel()
                {
                   id = p.id,
                   nom = p.nom,

                }).FirstOrDefault();
            return unProfil;
        }

        public ProfilModel CreateProfil(int idPr, string nomPr)
        {
            Profil CreerProfil = new Profil();

            CreerProfil.id = idPr;
            CreerProfil.nom = nomPr;
            context.Profil.Add(CreerProfil);
            context.SaveChanges();
            ProfilModel ProfilMod = new ProfilModel();
            ProfilMod.id = CreerProfil.id;
            ProfilMod.nom = CreerProfil.nom;
            return ProfilMod;
        }
    }
}
