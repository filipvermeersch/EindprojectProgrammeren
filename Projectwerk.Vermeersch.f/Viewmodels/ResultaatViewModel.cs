using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projectwerk.Vermeersch.f.Viewmodels
{
    public class ResultaatViewModel
    {
        public int Id { get; set; }

        public string soortSport { get; set; }
        public string Plaats { get; set; }

        public int UitslagCategorie { get; set; }
        public int UitslagAlgemeen { get; set; }
        public int PutterId { get; set; }
        public int WedstrijdId { get; set; }

    }
}