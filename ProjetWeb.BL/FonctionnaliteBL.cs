﻿using ProjetWeb.DAL;
using ProjetWeb.Model;
using System;
using System.Collections.Generic;
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
    }
}
