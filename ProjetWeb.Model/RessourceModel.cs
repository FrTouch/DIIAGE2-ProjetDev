using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetWeb.Model
{
    public class RessourceModel
    {
        public int id { get; set; }
        public int type_id { get; set; }
        public string nom { get; set; }
        public bool dispo { get; set; }
        public string description { get; set; }
        public System.DateTime date_achat { get; set; }
        public string qr_code { get; set; }
        public bool purge { get; set; }
        public string typeRes { get; set; }

        //public TypeModel Type { get; set; }
        
        public List<Ligne_resaModel> LstLigne_resa { get; set; }

        public RessourceModel() { }

        public RessourceModel(int idRessource, int type_idRessource, string nomRessource, bool dispoRessource, string descriptionRessource, DateTime date_achatRessource, string qr_codeRessource, bool purgeRessource, string typeRessource) {
            id = idRessource;
            type_id = type_idRessource;
            nom = nomRessource;
            dispo = dispoRessource;
            description = descriptionRessource;
            date_achat = date_achatRessource;
            qr_code = qr_codeRessource;
            purge = purgeRessource;
            typeRes = typeRessource;
        }
    }
}
