using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projectwerk.Vermeersch.f.Viewmodels
{
    public class ChangeUsernameViewModel
    {
        [Required(ErrorMessage = "Gelieve een {0} te kiezen")]
        public string Gebruikersnaam { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Paswoord")]
        public string Paswoord { get; set; }

        [Required(ErrorMessage = "Gelieve een {0} te kiezen")]
        [Display(Name = "Nieuwe gebruikersnaam")]
        public string NewUsername { get; set; }

        [Display(Name = "Bevestig gebruikersnaam")]
        [Compare("NewUsername", ErrorMessage = "Gebruikersnamen komen niet overeen")]
        public string BevestigUsername { get; set; }


    }
}