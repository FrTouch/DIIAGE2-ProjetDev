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
    public class FonctionnaliteBL
    {
        private static Projet_GestionEntities context = new Projet_GestionEntities();
        public List<FonctionnaliteModel> GetLesFonctionnalite()
        {
            List<FonctionnaliteModel> lesFonctionnalite = new List<FonctionnaliteModel>();
            lesFonctionnalite = context.Fonctionnalite.Select(f => new FonctionnaliteModel()
            {
                id = f.id,
                nom = f.nom,
                
            }).ToList();
            return lesFonctionnalite;
        }

        public FonctionnaliteModel GetUneFonctionnaliteById(int idFon)
        {
            FonctionnaliteModel uneFonctionnalite = new FonctionnaliteModel();
            uneFonctionnalite = context.Fonctionnalite
                .Where(f => f.id == idFon)
                .Select(f => new FonctionnaliteModel()
                {
                    id = f.id,
                    nom = f.nom
                }).FirstOrDefault();
            return uneFonctionnalite;
        }

        public FonctionnaliteModel CreateFonction(string nomFonc)
        {
            Fonctionnalite CreerFonction = new Fonctionnalite();

            CreerFonction.nom = nomFonc;
            context.Fonctionnalite.Add(CreerFonction);
            context.SaveChanges();
            FonctionnaliteModel FonctionMod = new FonctionnaliteModel();
            FonctionMod.nom = CreerFonction.nom;
            return FonctionMod;
        }

        public FonctionnaliteModel ModifierFonctionnalite(int idFonc, string nomFonc)
        {
            Fonctionnalite ModifierFonction = new Fonctionnalite();
            ModifierFonction.id = idFonc;
            ModifierFonction.nom = nomFonc;
            context.Entry(ModifierFonction).State = EntityState.Modified;
            context.SaveChanges();
            FonctionnaliteModel FonctionMod = new FonctionnaliteModel();
            FonctionMod.id = ModifierFonction.id;
            FonctionMod.nom = ModifierFonction.nom;
            return FonctionMod;
        }

        public void DeleteFonction(int idFonc)
        {
            Fonctionnalite SupprimerFonction = context.Fonctionnalite.FirstOrDefault(v => v.id == idFonc);

            context.Fonctionnalite.Remove(SupprimerFonction);
            context.SaveChanges();
        }
    }
}
