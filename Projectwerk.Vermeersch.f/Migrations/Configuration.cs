namespace Projectwerk.Vermeersch.f.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Projectwerk.Vermeersch.f.Data.TriatlonContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Projectwerk.Vermeersch.f.Data.TriatlonContext";
        }

        protected override void Seed(Projectwerk.Vermeersch.f.Data.TriatlonContext context)
        {
            var role1 = new Role { Rolenaam = "Gast" };
            var role2 = new Role { Rolenaam = "Lid" };
            var role3 = new Role { Rolenaam = "Admin" };
            var roles = new List<Role> { role1, role2, role3 };
            roles.ForEach(r => context.Roles.AddOrUpdate(x => x.Rolenaam, r));
            context.SaveChanges();


            var sex1 = new Sex { Geslacht = "M" };
            var sex2 = new Sex { Geslacht = "V" };
            var sexes = new List<Sex> { sex1, sex2 };
            sexes.ForEach(s => context.Sexes.AddOrUpdate(x => x.Geslacht, s));
            context.SaveChanges();

            var afstand1 = new Afstand { Lengte = "Sprint" };
            var afstand2 = new Afstand { Lengte = "Kwart" };
            var afstand3 = new Afstand { Lengte = "Half" };
            var afstand4 = new Afstand { Lengte = "Volledig" };
            var afstanden = new List<Afstand> { afstand1, afstand2, afstand3, afstand4 };
            afstanden.ForEach(a => context.Afstanden.AddOrUpdate(x => x.Lengte, a));
            context.SaveChanges();

            var sport1 = new Sport { soortSport = "Triatlon" };
            var sport2 = new Sport { soortSport = "Duatlon" };
            var sporten = new List<Sport> { sport1, sport2 };
            sporten.ForEach(s => context.Sporten.AddOrUpdate(x => x.soortSport, s));
            context.SaveChanges();


            var wedstrijd1 = new Wedstrijd
            {
                Plaats = "oostkamp",
                Datum = DateTime.Parse("15-01-2018"),
                AfstandId = afstanden.Single(a => a.Lengte == "Kwart").Id,
                SportId = sporten.Single(s => s.soortSport == "Triatlon").Id,
                Stayer = false
                //Deelnemers = new List<Putter>(),
                //Resultaten = new List<Resultaat>()
            };

            var wedstrijd2 = new Wedstrijd
            {
                Plaats = "oostkamp",
                Datum = DateTime.Parse("15-01-2018"),
                Stayer = true,
                AfstandId = afstand1.Id,
                SportId = sporten.Single(s => s.soortSport == "Triatlon").Id

            };

            var wedstrijd3 = new Wedstrijd
            {
                Plaats = "moerbrugge",
                Datum = DateTime.Parse("18-02-2018"),
                Stayer = false,
                AfstandId = afstand3.Id,
                SportId = sporten.Single(s => s.soortSport == "Triatlon").Id

            };

            var wedstrijd4 = new Wedstrijd
            {
                Plaats = "waardamme",
                Datum = DateTime.Parse("25-02-2018"),
                Stayer = true,
                AfstandId = afstand2.Id,
                SportId = sporten.Single(s => s.soortSport == "Triatlon").Id

            };

            var wedstrijd5 = new Wedstrijd
            {
                Plaats = "waardamme",
                Datum = DateTime.Parse("25-02-2018"),
                Stayer = true,
                AfstandId = afstand2.Id,
                SportId = sporten.Single(s => s.soortSport == "Duatlon").Id
            };

            var wedstrijden = new List<Wedstrijd> { wedstrijd1, wedstrijd2, wedstrijd3, wedstrijd4, wedstrijd5 };
            wedstrijden.ForEach(w => context.Wedstrijden.AddOrUpdate(x => new { x.Plaats, x.AfstandId, x.SportId }, w));
            context.SaveChanges();


            var p1 =
                new Putter
                {
                    SexID = sexes.Single(s => s.Geslacht == "M").Id,
                    RoleID = roles.Single(r => r.Rolenaam == "Admin").Id,
                    Naam = "Vermeersch",
                    Voornaam = "Filip",
                    Licentie = true,
                    Paswoord = "fluppe",
                    Gebruikersnaam = "fluppe",
                    Email = "filip.vermeersch3@telenet.be",
                    Woonplaats = "Brugge",
                    Geboortedatum = DateTime.Parse("16-02-1972"),
                    Wedstrijden = new List<Wedstrijd>() { wedstrijd1, wedstrijd3, wedstrijd4 }
                };


            var p2 =
                new Putter
                {
                    SexID = sexes.Single(s => s.Geslacht == "M").Id,
                    RoleID = roles.Single(r => r.Rolenaam == "Lid").Id,
                    Naam = "Bonamie",
                    Voornaam = "Davey",
                    Licentie = false,
                    Woonplaats = "Oostkamp",
                    Wedstrijden = new List<Wedstrijd>() { wedstrijd1, wedstrijd3, wedstrijd4 },
                    Geboortedatum = DateTime.Parse("14-10-1986"),
                    Paswoord = "davey",
                    Gebruikersnaam = "davey",
                    //  Resultaten = new List<Resultaat>() { }
                };

            var p3 =
                 new Putter
                 {
                     SexID = sexes.Single(s => s.Geslacht == "V").Id,
                     RoleID = roles.Single(r => r.Rolenaam == "Lid").Id,
                     Naam = "Dufour",
                     Voornaam = "Sjoukje",
                     Licentie = true,
                     Woonplaats = "Brugge",
                     Wedstrijden = new List<Wedstrijd>() { wedstrijd5 },
                     Geboortedatum = DateTime.Parse("05-10-1987"),
                     Paswoord = "sjoukje",
                     Gebruikersnaam = "sjoukje"

                 };

            var p4 =
                     new Putter
                     {
                         SexID = sexes.Single(s => s.Geslacht == "M").Id,
                         RoleID = roles.Single(r => r.Rolenaam == "Lid").Id,
                         Naam = "Hillewaere",
                         Voornaam = "Dries",
                         Licentie = true,
                         Woonplaats = "Oostkamp",
                         Wedstrijden = new List<Wedstrijd>() { wedstrijd2 },
                         Geboortedatum = DateTime.Parse("26-02-1977"),
                         Paswoord = "dries",
                         Gebruikersnaam = "dries"

                     };

            var p5 =
                      new Putter
                      {
                          SexID = sexes.Single(s => s.Geslacht == "M").Id,
                          RoleID = roles.Single(r => r.Rolenaam == "Lid").Id,
                          Naam = "Pollet",
                          Voornaam = "Marc",
                          Licentie = true,
                          Woonplaats = "Varsenare",
                          Wedstrijden = new List<Wedstrijd>() { wedstrijd2, wedstrijd3 },
                          Geboortedatum = DateTime.Parse("19-08-1969"),
                          Paswoord = "marc",
                          Gebruikersnaam = "marc"

                      };

            var p6 =
                      new Putter
                      {

                          SexID = sexes.Single(s => s.Geslacht == "V").Id,
                          RoleID = roles.Single(r => r.Rolenaam == "Lid").Id,
                          Naam = "Sap",
                          Voornaam = "Julie",
                          Licentie = true,
                          Woonplaats = "Beernem",
                          //    Wedstrijden = new List<Wedstrijd>(),
                          Geboortedatum = DateTime.Parse("10-06-1992"),
                          Paswoord = "julie",
                          Gebruikersnaam = "julie"

                      };

            var p7 =
                       new Putter
                       {
                           SexID = sexes.Single(s => s.Geslacht == "M").Id,
                           RoleID = roles.Single(r => r.Rolenaam == "Lid").Id,
                           Naam = "Buffel",
                           Voornaam = "Bruno",
                           Licentie = true,
                           Woonplaats = "Baliebrugge",
                           //Wedstrijden = new List<Wedstrijd>(),
                           Geboortedatum = DateTime.Parse("14-10-1976"),
                           Paswoord = "bruno",
                           Gebruikersnaam = "bruno"

                       };

            var p8 =
                        new Putter
                        {
                            SexID = sexes.Single(s => s.Geslacht == "M").Id,
                            RoleID = roles.Single(r => r.Rolenaam == "Lid").Id,
                            Naam = "Stubbe",
                            Voornaam = "Joeri",
                            Licentie = true,
                            Woonplaats = "Oostkamp",
                            // Wedstrijden = new List<Wedstrijd>(),
                            Geboortedatum = DateTime.Parse("04-10-1978"),
                            Paswoord = "joeri",
                            Gebruikersnaam = "joeri"

                        };

            var p9 =
                         new Putter
                         {
                             SexID = sexes.Single(s => s.Geslacht == "M").Id,
                             RoleID = roles.Single(r => r.Rolenaam == "Lid").Id,
                             Naam = "Vandenberghe",
                             Voornaam = "Nico",
                             Licentie = true,
                             Woonplaats = "Dudzele",
                             //    Wedstrijden = new List<Wedstrijd>(),
                             Geboortedatum = DateTime.Parse("05-11-1978"),
                             Paswoord = "nico",
                             Gebruikersnaam = "nico"

                         };

            var p10 =

                          new Putter
                          {
                              SexID = sexes.Single(s => s.Geslacht == "M").Id,
                              RoleID = roles.Single(r => r.Rolenaam == "Lid").Id,
                              Naam = "Van Ryckeghem",
                              Voornaam = "Guy",
                              Licentie = true,
                              Woonplaats = "Oostkamp",
                              //       Wedstrijden = new List<Wedstrijd>(),
                              Paswoord = "guy",
                              Gebruikersnaam = "guy"

                          };

            var putters = new List<Putter> { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };
            putters.ForEach(p => context.Putters.AddOrUpdate(x => new { x.Voornaam, x.Naam }, p));
            context.SaveChanges();



            var r1 = new Resultaat
            {
                PutterID = p1.Id,
                UitslagAlgemeen = 40,
                UitslagCategorie = 3,
                WedstrijdId = wedstrijd1.Id
            };

            var r2 = new Resultaat
            {
                PutterID = p2.Id,
                UitslagAlgemeen = 30,
                UitslagCategorie = 7,
                WedstrijdId = wedstrijd1.Id
            };
            var r3 = new Resultaat
            {
                PutterID = p4.Id,
                UitslagAlgemeen = 20,
                UitslagCategorie = 4,
                WedstrijdId = wedstrijd2.Id
            };
            var r4 = new Resultaat
            {
                PutterID = p5.Id,
                UitslagAlgemeen = 25,
                UitslagCategorie = 6,
                WedstrijdId = wedstrijd2.Id
            };
            var r5 = new Resultaat
            {
                PutterID = p1.Id,
                UitslagAlgemeen = 18,
                UitslagCategorie = 2,
                WedstrijdId = wedstrijd3.Id

            };
            var r6 = new Resultaat
            {
                PutterID = p2.Id,
                UitslagAlgemeen = 16,
                UitslagCategorie = 4,
                WedstrijdId = wedstrijd3.Id
            };
            var r7 = new Resultaat
            {
                PutterID = p5.Id,
                UitslagAlgemeen = 11,
                UitslagCategorie = 2,
                WedstrijdId = wedstrijd3.Id
            };
            var r8 = new Resultaat
            {
                PutterID = p1.Id,
                UitslagAlgemeen = 24,
                UitslagCategorie = 3,
                WedstrijdId = wedstrijd4.Id
            };
            var r9 = new Resultaat
            {
                PutterID = p2.Id,
                UitslagAlgemeen = 44,
                UitslagCategorie = 3,
                WedstrijdId = wedstrijd4.Id
            };
            var r10 = new Resultaat
            {
                PutterID = p3.Id,
                UitslagAlgemeen = 33,
                UitslagCategorie = 1,
                WedstrijdId = wedstrijd5.Id
            };


            var resultaten = new List<Resultaat> { r1, r2, r3, r4, r5, r6, r7, r8, r9, r10 };
            resultaten.ForEach(r => context.Resultaten.AddOrUpdate(x => new { x.PutterID, x.WedstrijdId }, r));
            context.SaveChanges();

        }
    }
}
