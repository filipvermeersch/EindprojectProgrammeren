using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projectwerk.Vermeersch.f.Models
{
    public class Putter
    {
        [Key]
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string VolledigeNaam
        {
            get
            {
                return Voornaam + " " + Naam;
            }
        }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Geboortedatum { get; set; }
        public string Leeftijd
        {
            get
            {
                if (Geboortedatum.HasValue)
                {
                    var today = DateTime.UtcNow;
                    var age = today.Year - Geboortedatum.Value.Year;
                    if (Geboortedatum > today.AddYears(-age))
                    {
                        age--;
                    }
                    return age.ToString();
                }
                else
                {
                    return "N/A";
                }

            }
        }

        public string Gebruikersnaam { get; set; }
        public string Woonplaats { get; set; }
        public string Paswoord { get; set; }
        public string Email { get; set; }
        public string AfbeeldingsURL
        {
            get
            {
                return Id.ToString() + ".png";
            }
        }
        public bool Licentie { get; set; }

        public int RoleID { get; set; }
        public virtual Role Role { get; set; }

        public string Categorie
        {
            get
            {
                if (Geboortedatum.HasValue)
                {
                    int leeftijd = DateTime.UtcNow.Year - Geboortedatum.Value.Year;

                    if (leeftijd >= 20 && leeftijd <= 23)
                        return "Belofte";
                    else if (leeftijd > 23 && leeftijd < 40)
                        return "Senior";
                    else if (leeftijd >= 40 && leeftijd < 50)
                        return "Master A";
                    else if (leeftijd >= 50 && leeftijd < 60)
                        return "Master B";
                    else if (leeftijd >= 60)
                        return "Master C";
                    else return "N/A";
                }
                else
                {
                    return "N/A";
                }

            }

        }

        public int SexID { get; set; }
        public virtual Sex Sex { get; set; }

        public virtual ICollection<Wedstrijd> Wedstrijden { get; set; }
        public virtual ICollection<Resultaat> Resultaten { get; set; }

        public Putter()
        {
            this.Wedstrijden = new HashSet<Wedstrijd>();
        }


    }
}