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

        public TypeModel Type { get; set; }

        public List<Ligne_resaModel> LstLigne_resa { get; set; }

        public RessourceModel() { }
    }
}
