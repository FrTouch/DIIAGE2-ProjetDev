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
    public class ProfilBL
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

        public ProfilModel CreateProfil(string nomPr)
        {
            Profil CreerProfil = new Profil();

           
            CreerProfil.nom = nomPr;
            context.Profil.Add(CreerProfil);
            context.SaveChanges();
            ProfilModel ProfilMod = new ProfilModel();
            ProfilMod.nom = CreerProfil.nom;
            return ProfilMod;
        }

        public ProfilModel ModifierProfil(int idProf, string nomProf)
        {
            Profil ModifierProfil = new Profil();
            ModifierProfil.id = idProf;
            ModifierProfil.nom = nomProf;
            context.Entry(ModifierProfil).State = EntityState.Modified;
            context.SaveChanges();
            ProfilModel ProfilMod = new ProfilModel();
            ProfilMod.id = ModifierProfil.id;
            ProfilMod.nom = ModifierProfil.nom;
            return ProfilMod;
        }

        public void DeleteProfil(int idProf)
        {
            Profil SupprimerProfil = context.Profil.FirstOrDefault(v => v.id == idProf);

            context.Profil.Remove(SupprimerProfil);
            context.SaveChanges();
        }
    }
}
