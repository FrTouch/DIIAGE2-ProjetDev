using ProjetWeb.DAL;
using ProjetWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetWeb.BL
{
    class TypeBL
    {

        private static Projet_GestionEntities context = new Projet_GestionEntities();
        public List<TypeModel> GetLesType()
        {
            List<TypeModel> lesTypes = new List<TypeModel>();
            lesTypes = context.Type.Select(t => new TypeModel()
            {
                id = t.id,
                nom = t.nom,
                description = t.description,
                purge = t.purge,
            }).ToList();
            return lesTypes;

        }

        public TypeModel GetUneTypeById(int idTy)
        {
            TypeModel unType = new TypeModel();
            unType = context.Type
                .Where(t => t.id == idTy)
                .Select(t => new TypeModel()
                {
                    id = t.id,
                    nom = t.nom,
                    description = t.description,
                    purge = t.purge,

                }).FirstOrDefault();
            return unType;
        }

        public TypeModel CreateType(int idTy, string nomType, string descriptionTy, bool purgeTy)
        {
            DAL.Type CreerType = new DAL.Type();

            CreerType.id = idTy;
            CreerType.nom = nomType;
            CreerType.description = descriptionTy;
            CreerType.purge = purgeTy;
            context.Type.Add(CreerType);
            context.SaveChanges();
            TypeModel TypeMod = new TypeModel();
            TypeMod.id = CreerType.id;
            TypeMod.nom = CreerType.nom;
            TypeMod.description = CreerType.description;
            TypeMod.purge = CreerType.purge;
            return TypeMod;
        }
    }
}
