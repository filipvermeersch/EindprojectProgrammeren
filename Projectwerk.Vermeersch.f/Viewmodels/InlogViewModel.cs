using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projectwerk.Vermeersch.f.Viewmodels
{
    public class InlogViewModel
    {
        [Required(ErrorMessage = "Gelieve een {0} te kiezen")]
        public string Gebruikersnaam { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Paswoord")]
        public string Paswoord { get; set; }

        [Display(Name = "Onthouden ?")]
        public bool Onthouden { get; set; }

    }
}