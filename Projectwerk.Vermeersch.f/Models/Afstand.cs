using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projectwerk.Vermeersch.f.Models
{
    public class Afstand
    {
        public int Id { get; set; }
        [Display(Name = "Afstand")]
        public string Lengte { get; set; }

        public virtual ICollection<Wedstrijd> Wedstrijden { get; set; }
    }
}