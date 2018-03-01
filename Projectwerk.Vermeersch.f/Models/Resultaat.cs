namespace Projectwerk.Vermeersch.f.Models
{
    public class Resultaat
    {
        public int Id { get; set; }
        public int UitslagCategorie { get; set; }
        public int UitslagAlgemeen { get; set; }

        public int PutterID { get; set; }
        public virtual Putter Putter { get; set; }

        public int WedstrijdId { get; set; }
        public virtual Wedstrijd Wedstrijd { get; set; }


    }
}