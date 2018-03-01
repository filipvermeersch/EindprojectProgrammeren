using System.Collections.Generic;

namespace Projectwerk.Vermeersch.f.Models
{
    public class Sex
    {
        public int Id { get; set; }
        public string Geslacht { get; set; }

        public virtual ICollection<Putter> Putters { get; set; }
    }
}