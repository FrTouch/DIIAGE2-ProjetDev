using ProjetWeb.DAL;
using ProjetWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetWeb.BL
{
    class RessourceBL
    {
        private static Projet_GestionEntities context = new Projet_GestionEntities();
        public List<RessourceModel> GetLesReservation()
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

        public RessourceModel CreateRessource(int idRess, int type_idRess, string nomRess, bool dispoRess, string descriptionRess, DateTime date_achatRess, string qr_codeRess,bool purgeRess)
        {
            Ressource CreerRessource = new Ressource();

            CreerRessource.id = idRess;
            CreerRessource.type_id = type_idRess;
            CreerRessource.nom = nomRess;
            CreerRessource.dispo = dispoRess;
            CreerRessource.description = descriptionRess;
            CreerRessource.date_achat = date_achatRess;
            CreerRessource.qr_code = qr_codeRess;
            CreerRessource.purge = purgeRess;
            context.Ressource.Add(CreerRessource);
            context.SaveChanges();
            RessourceModel RessourceMod = new RessourceModel();
            RessourceMod.id = CreerRessource.id;
            RessourceMod.type_id = CreerRessource.type_id;
            RessourceMod.nom = CreerRessource.nom;
            RessourceMod.dispo = CreerRessource.dispo;
            RessourceMod.date_achat = CreerRessource.date_achat;
            RessourceMod.qr_code = CreerRessource.qr_code;
            RessourceMod.purge = CreerRessource.purge;
            return RessourceMod;
        }
    }
}
