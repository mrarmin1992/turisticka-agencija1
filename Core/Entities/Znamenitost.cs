namespace Core.Entities
{
    public class Znamenitost : BaseEntity
    {
        
        public string Naziv { get; set; }

        public string Opis { get; set; }

        public bool Aktivan { get; set; }

        public string Koordinate { get; set; }

        public string PictureUrl { get; set; }
 
        public Veomaznamenito Veomaznamenito { get; set; }
        public int VeomaznamenitoId { get; set; }

        public Nezaobilazno Nezaobilazno { get; set; }

        public int NezaobilaznoId { get; set; }
        
       
    }
}