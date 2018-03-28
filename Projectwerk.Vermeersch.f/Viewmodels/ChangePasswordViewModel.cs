using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projectwerk.Vermeersch.f.Viewmodels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Gelieve een {0} te kiezen")]
        public string Gebruikersnaam { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Paswoord")]
        public string Paswoord { get; set; }


        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Het {0} moet tussen de 3 en de 20 tekens liggen")]
        [DataType(DataType.Password)]
        [Display(Name = "Nieuw Paswoord")]
        public string NieuwPaswoord { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bevestig paswoord")]
        [Compare("NieuwPaswoord", ErrorMessage = "Paswoorden komen niet overeen")]
        public string Bevestigpaswoord { get; set; }

    }
}