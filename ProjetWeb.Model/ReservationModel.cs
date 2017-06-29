namespace ProjetWeb.Model
{
    public class ReservationModel
    {

        public int id { get; set; }
        public int utilisateur_id { get; set; }
        public System.DateTime date_resa { get; set; }
        public bool purge { get; set; }

        public UtilisateurModel Utilisateur { get; set; }

        public ReservationModel() { }
    }
}