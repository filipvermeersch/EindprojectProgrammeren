using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projectwerk.Vermeersch.f.Viewmodels
{
    public class WedstrijdViewModel
    {
        public int Id { get; set; }

        public string Putternaam { get; set; }

        public int PutterId { get; set; }

        public string Plaats { get; set; }

        [Required(ErrorMessage = "Gelieve een {0} te kiezen")]

        [DataType(DataType.Date)]

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]

        public DateTime Datum { get; set; }

        //[Required(ErrorMessage = "Gelieve een {0} te kiezen")]

        // public string Test { get; set; }

        public string Afstand { get; set; }

        public string Sport { get; set; }

        public bool Stayer { get; set; }

        public string AfbeeldingsURL

        {

            get

            {

                return PutterId.ToString() + ".png";

            }

        }

        public bool Result { get; set; }
    }
}