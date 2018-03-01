using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projectwerk.Vermeersch.f.Models
{
    public class Wedstrijd
    {
        public int Id { get; set; }

        public string Plaats { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Datum { get; set; }

        public bool Stayer { get; set; }

        public int AfstandId { get; set; }
        public virtual Afstand Afstand { get; set; }

        public int SportId { get; set; }
        public virtual Sport Sport { get; set; }

        public virtual ICollection<Putter> Deelnemers { get; set; }

        public virtual ICollection<Resultaat> Resultaten { get; set; }

        public Wedstrijd()
        {
            this.Deelnemers = new HashSet<Putter>();
        }

    }
}