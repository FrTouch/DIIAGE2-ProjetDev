namespace ProjetWeb.Model
{
    public class Ligne_resaModel
    {
        public int id { get; set; }
        public int reservation_id { get; set; }
        public int ressource_id { get; set; }
        public System.DateTime date_debut { get; set; }
        public System.DateTime date_fin { get; set; }
        public bool purge { get; set; }
        public string ressourceLigne { get; set; }

        public RessourceModel Ressource { get; set; }
        public ReservationModel Reservation { get; set; }
       

        public Ligne_resaModel() { }
    }
}