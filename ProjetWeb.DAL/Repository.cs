using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetWeb.DAL
{
    public class Repository
    {
        Projet_GestionEntities context;
        public Repository()
        {
            context = new Projet_GestionEntities();
        }

        public Utilisateur getUtilisateur(string login, string password)
        {
            return context.Utilisateur.Where(p => p.mail == login && p.password == password).FirstOrDefault();
        }
    }
}
