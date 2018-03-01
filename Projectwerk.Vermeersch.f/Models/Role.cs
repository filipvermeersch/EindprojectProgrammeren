using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projectwerk.Vermeersch.f.Models
{
    public class Role
    {
        public int Id { get; set; }
        [Display(Name = "Role")]
        public string Rolenaam { get; set; }

        public virtual ICollection<Putter> Putters { get; set; }
    }
}