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
    public class Ligne_resaBL
    {
        private static Projet_GestionEntities context = new Projet_GestionEntities();
        public List<Ligne_resaModel> GetLesLignesResa()
        {
            List<Ligne_resaModel> lesLignesResa = new List<Ligne_resaModel>();
            lesLignesResa = context.Ligne_resa.Select(l => new Ligne_resaModel()
            {
                id = l.id,
                reservation_id = l.reservation_id,
                ressource_id = l.ressource_id,
                date_debut = l.date_debut,
                date_fin = l.date_fin,
                purge = l.purge,
            }).ToList();
            return lesLignesResa;
        }

        public Ligne_resaModel GetUneLigneById(int idLigne)
        {
            Ligne_resaModel  uneLigne = new Ligne_resaModel();
            uneLigne = context.Ligne_resa
                .Where(l => l.id == idLigne)
                .Select(l => new Ligne_resaModel()
                {
                    id = l.id,
                    reservation_id = l.reservation_id,
                    ressource_id = l.ressource_id,
                    date_debut = l.date_debut,
                    date_fin = l.date_fin,
                    purge = l.purge,
                }).FirstOrDefault();
            return uneLigne;
        }

        public Ligne_resaModel CreateLigne(int reservation_idLigne, string ressourceLigne, DateTime date_debutLigne, DateTime date_finLigne, bool purgeLigne)
        {
            Ligne_resa CreerLigneResa = new Ligne_resa();

           
            CreerLigneResa.reservation_id = reservation_idLigne;
            CreerLigneResa.ressource_id = context.Ressource.Where(v => v.nom == ressourceLigne).FirstOrDefault().id;
            CreerLigneResa.date_debut = date_debutLigne;
            CreerLigneResa.date_fin = date_finLigne;
            CreerLigneResa.purge = purgeLigne;
            context.Ligne_resa.Add(CreerLigneResa);
            context.SaveChanges();
            Ligne_resaModel LigneResaMod = new Ligne_resaModel();
            LigneResaMod.reservation_id = CreerLigneResa.reservation_id;
            LigneResaMod.ressource_id = CreerLigneResa.ressource_id;
            LigneResaMod.date_debut = CreerLigneResa.date_debut;
            LigneResaMod.date_fin = CreerLigneResa.date_fin;
            LigneResaMod.purge = CreerLigneResa.purge;
            return LigneResaMod;
        }

        public Ligne_resaModel ModifierLigne(int idLigne, int reservation_idLigne, int ressource_idLigne, DateTime date_debutLigne, DateTime date_finLigne, bool purgeLigne)
        {
            Ligne_resa ModifierLigneResa = new Ligne_resa();

            ModifierLigneResa.id = idLigne;
            ModifierLigneResa.reservation_id = reservation_idLigne;
            ModifierLigneResa.ressource_id = ressource_idLigne;
            ModifierLigneResa.date_debut = date_debutLigne;
            ModifierLigneResa.date_fin = date_finLigne;
            ModifierLigneResa.purge = purgeLigne;
            context.Entry(ModifierLigneResa).State = EntityState.Modified;
            context.SaveChanges();
            Ligne_resaModel LigneResaMod = new Ligne_resaModel();
            LigneResaMod.id = ModifierLigneResa.id;
            LigneResaMod.reservation_id = ModifierLigneResa.reservation_id;
            LigneResaMod.reservation_id = ModifierLigneResa.ressource_id;
            LigneResaMod.date_debut = ModifierLigneResa.date_debut;
            LigneResaMod.date_fin = ModifierLigneResa.date_fin;
            LigneResaMod.purge = ModifierLigneResa.purge;
            return LigneResaMod;
        }

        public void DeleteLigne(int idLigne)
        {
            Ligne_resa SupprimerLigne = context.Ligne_resa.FirstOrDefault(v => v.id == idLigne);

            context.Ligne_resa.Remove(SupprimerLigne);
            context.SaveChanges();
        }
    }
}
