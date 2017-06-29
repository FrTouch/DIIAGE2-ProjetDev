using System.Collections.Generic;

namespace ProjetWeb.Model
{
    public class ProfilModel
    {
        public int id { get; set; }
        public string nom { get; set; }

        public List<FonctionnaliteModel> LstFonctionnalite { get; set; }

        public List<UtilisateurModel> LstUtilisateur { get; set; }

        public ProfilModel() { }
    }
}