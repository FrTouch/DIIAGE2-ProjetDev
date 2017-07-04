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
    public class RessourceBL
    {
        private static Projet_GestionEntities context = new Projet_GestionEntities();
        public List<RessourceModel> GetLesRessource()
        {
            List<RessourceModel> lesRessource = new List<RessourceModel>();
            lesRessource = context.Ressource.Select(r => new RessourceModel()
            {
                id = r.id,
                type_id = r.type_id,
                nom = r.nom,
                dispo = r.dispo,
                description = r.description,
                date_achat = r.date_achat,
                qr_code = r.qr_code,
                purge = r.purge,
            }).ToList();
            return lesRessource;

        }

        public RessourceModel GetUneRessourceById(int idRe)
        {
            RessourceModel uneRessource = new RessourceModel();
            uneRessource = context.Ressource
                .Where(r => r.id == idRe)
                .Select(r => new RessourceModel()
                {
                    id = r.id,
                    type_id = r.type_id,
                    nom = r.nom,
                    dispo = r.dispo,
                    description = r.description,
                    date_achat = r.date_achat,
                    qr_code = r.qr_code,
                    purge = r.purge,

                }).FirstOrDefault();
            return uneRessource;
        }

        public RessourceModel CreateRessource(string nomRess, string descriptionRess, DateTime date_achatRess, string qr_codeRess,string typeRessource)
        {
            Ressource CreerRessource = new Ressource();

            CreerRessource.nom = nomRess;
            CreerRessource.description = descriptionRess;
            CreerRessource.date_achat = date_achatRess;
            CreerRessource.qr_code = qr_codeRess;
            CreerRessource.type_id = context.Type.Where(t => t.nom == typeRessource).FirstOrDefault().id;
            context.Ressource.Add(CreerRessource);
            context.SaveChanges();
            RessourceModel RessourceMod = new RessourceModel();
            
            RessourceMod.nom = CreerRessource.nom;
            RessourceMod.dispo = CreerRessource.dispo;
            RessourceMod.date_achat = CreerRessource.date_achat;
            RessourceMod.qr_code = CreerRessource.qr_code;
            RessourceMod.type_id = CreerRessource.type_id;
            return RessourceMod;
        }

        public RessourceModel ModifierRessource(int idRess, int type_idRess, string nomRess, bool dispoRess, string descriptionRess, DateTime date_achatRess, string qr_codeRess, bool purgeRess)
        {
            Ressource ModifierRessource = new Ressource();
            ModifierRessource.id = idRess;
            ModifierRessource.type_id = type_idRess;
            ModifierRessource.nom = nomRess;
            ModifierRessource.dispo = dispoRess;
            ModifierRessource.description = descriptionRess;
            ModifierRessource.date_achat = date_achatRess;
            ModifierRessource.qr_code = qr_codeRess;
            ModifierRessource.purge = purgeRess;
            context.Entry(ModifierRessource).State = EntityState.Modified;
            context.SaveChanges();
            RessourceModel RessourceMod = new RessourceModel();
            RessourceMod.id = ModifierRessource.id;
            RessourceMod.type_id = ModifierRessource.type_id;
            RessourceMod.nom = ModifierRessource.nom;
            RessourceMod.dispo = ModifierRessource.dispo;
            RessourceMod.description = ModifierRessource.description;
            RessourceMod.date_achat = ModifierRessource.date_achat;
            RessourceMod.qr_code = ModifierRessource.qr_code;
            RessourceMod.purge = ModifierRessource.purge;
            return RessourceMod;
        }

        public void DeleteRessource(int id)
        {
            Ressource SupprimerRessource = context.Ressource.FirstOrDefault(v => v.id == id);

            context.Ressource.Remove(SupprimerRessource);
            context.SaveChanges();
        }
    }
}
