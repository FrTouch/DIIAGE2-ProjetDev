using System.Collections.Generic;

namespace ProjetWeb.Model
{
    public class FonctionnaliteModel
    {
        public int id { get; set; }
        public string nom { get; set; }

        public List<ProfilModel> LstProfil { get; set; }

        public FonctionnaliteModel() { }
    }
}