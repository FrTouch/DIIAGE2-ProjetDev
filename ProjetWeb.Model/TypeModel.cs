using System.Collections.Generic;

namespace ProjetWeb.Model
{
    public class TypeModel
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string description { get; set; }
        public bool purge { get; set; }

        private List<RessourceModel> lstRessource { get; set; }

        public TypeModel () { }
    }
}