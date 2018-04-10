using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projectwerk.Vermeersch.f.Viewmodels
{
    public class ResultaatViewModel
    {
        public int Id { get; set; }

        public string soortSport { get; set; }
        public string Plaats { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Only integers are allowed")]
        public int UitslagCategorie { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Only integers are allowed")]
        public int UitslagAlgemeen { get; set; }

        public int PutterId { get; set; }
        public int WedstrijdId { get; set; }

    }
}