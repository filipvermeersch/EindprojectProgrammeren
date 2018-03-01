using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projectwerk.Vermeersch.f.Models
{
    public class Sport
    {
        public int Id { get; set; }
        [Display(Name = "Sport")]
        public string soortSport { get; set; }

        public virtual ICollection<Wedstrijd> Wedstrijden { get; set; }
    }
}