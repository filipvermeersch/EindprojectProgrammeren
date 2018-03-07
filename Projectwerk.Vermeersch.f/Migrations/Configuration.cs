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
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            context.Roles.AddOrUpdate(r => r.Id,
                new Role { Id = 1, Rolenaam = "Gast" },
                new Role { Id = 2, Rolenaam = "Lid" },
                new Role { Id = 3, Rolenaam = "Admin" }
                );

            context.Sexes.AddOrUpdate(s => s.Id,
                new Sex { Id = 1, Geslacht = "M" },
                new Sex { Id = 2, Geslacht = "F" }
                );

            context.Afstanden.AddOrUpdate(a => a.Id,
                new Afstand { Id = 1, Lengte = "Sprint" },
                new Afstand { Id = 2, Lengte = "Kwart" },
                new Afstand { Id = 3, Lengte = "Half" },
                new Afstand { Id = 4, Lengte = "Volledig" }
                );

            context.Sporten.AddOrUpdate(s => s.Id,
                new Sport { Id = 1, soortSport = "Triatlon" },
                new Sport { Id = 2, soortSport = "Duatlon" }
                );

            var wedstrijd1 = new Wedstrijd { Id = 1, Plaats = "oostkamp", Datum = DateTime.Parse("15-01-2018"), AfstandId = 2,
                SportId = 1, Stayer = false, Deelnemers = new List<Putter>(), Resultaten = new List<Resultaat>() };

            var wedstrijd2 = new Wedstrijd { Id = 2, Plaats = "oostkamp", Datum = DateTime.Parse("15-01-2018"), AfstandId = 1,
                SportId = 1, Stayer = true, Deelnemers = new List<Putter>(), Resultaten = new List<Resultaat>() };

            var wedstrijd3 = new Wedstrijd { Id = 3, Plaats = "moerbrugge", Datum = DateTime.Parse("18-02-2018"), AfstandId = 3,
                SportId = 1, Stayer = false, Deelnemers = new List<Putter>(), Resultaten = new List<Resultaat>() };

            var wedstrijd4 = new Wedstrijd { Id = 4, Plaats = "waardamme", Datum = DateTime.Parse("25-02-2018"), AfstandId = 2,
                SportId = 1, Stayer = true, Deelnemers = new List<Putter>(), Resultaten = new List<Resultaat>() };

            var wedstrijd5 = new Wedstrijd { Id = 5, Plaats = "waardamme", Datum = DateTime.Parse("25-02-2018"), AfstandId = 2,
                SportId = 2, Stayer = true, Deelnemers = new List<Putter>(), Resultaten = new List<Resultaat>() };

            var wedstrijden = new List<Wedstrijd> { wedstrijd1, wedstrijd2, wedstrijd3, wedstrijd4, wedstrijd5 };
            wedstrijden.ForEach(w => context.Wedstrijden.Add(w));


            context.Resultaten.AddOrUpdate(r => r.Id,
                new Resultaat
                {
                    Id = 1,
                    PutterID = 1,
                    UitslagAlgemeen = 40,
                    UitslagCategorie = 3,
                    WedstrijdId = 1
                },
                 new Resultaat
                 {
                     Id = 2,
                     PutterID = 2,
                     UitslagAlgemeen = 50,
                     UitslagCategorie = 2,
                     WedstrijdId = 1
                 },
                  new Resultaat
                  {
                      Id = 3,
                      PutterID = 3,
                      UitslagAlgemeen = 30,
                      UitslagCategorie = 7,
                      WedstrijdId = 1
                  },
                   new Resultaat
                   {
                       Id = 4,
                       PutterID = 4,
                       UitslagAlgemeen = 20,
                       UitslagCategorie = 4,
                       WedstrijdId = 2
                   },
                    new Resultaat
                    {
                        Id = 5,
                        PutterID = 5,
                        UitslagAlgemeen = 25,
                        UitslagCategorie = 6,
                        WedstrijdId = 2
                    },
                     new Resultaat
                     {
                         Id = 6,
                         PutterID = 1,
                         UitslagAlgemeen = 18,
                         UitslagCategorie = 2,
                         WedstrijdId = 3
                     },
                          new Resultaat
                          {
                              Id = 7,
                              PutterID = 2,
                              UitslagAlgemeen = 33,
                              UitslagCategorie = 1,
                              WedstrijdId = 3
                          }, new Resultaat
                          {
                              Id = 8,
                              PutterID = 3,
                              UitslagAlgemeen = 16,
                              UitslagCategorie = 4,
                              WedstrijdId = 3
                          }, new Resultaat
                          {
                              Id = 9,
                              PutterID = 1,
                              UitslagAlgemeen = 24,
                              UitslagCategorie = 3,
                              WedstrijdId = 4
                          },new Resultaat
                          {
                              Id = 10,
                              PutterID = 2,
                              UitslagAlgemeen = 44,
                              UitslagCategorie = 3,
                              WedstrijdId = 4
                          }, new Resultaat
                          {
                              Id = 11,
                              PutterID = 3,
                              UitslagAlgemeen = 43,
                              UitslagCategorie = 6,
                              WedstrijdId = 5
                          }, new Resultaat
                          {
                              Id = 12,
                              PutterID = 4,
                              UitslagAlgemeen = 55,
                              UitslagCategorie = 11,
                              WedstrijdId = 5
                          }

                );
            context.Putters.AddOrUpdate(p => p.Id,
                new Putter
                {
                    Id = 1,
                    SexID = 1,
                    RoleID = 3,
                    Naam = "Vermeersch",
                    Voornaam = "Filip",
                    Licentie = true,
                    Paswoord = "fluppe",
                    Gebruikersnaam = "fluppe",
                    Email = "filip.vermeersch3@telenet.be",
                    Woonplaats = "Brugge",
                    Geboortedatum = DateTime.Parse("16-02-1972"),
                    Wedstrijden = new List<Wedstrijd>() { wedstrijd1, wedstrijd3, wedstrijd4 }
                },
                new Putter
                {
                    Id = 2,
                    SexID = 1,
                    RoleID = 2,
                    Naam = "Bonamie",
                    Voornaam = "Davey",
                    Licentie = false,
                    Woonplaats = "Oostkamp",
                    Wedstrijden = new List<Wedstrijd>() { wedstrijd1, wedstrijd3, wedstrijd4 },
                    Geboortedatum = DateTime.Parse("14-10-1986"),
                    Paswoord = "davey",
                    Gebruikersnaam = "davey"


                },
                 new Putter
                 {
                     Id = 3,
                     SexID = 2,
                     RoleID = 2,
                     Naam = "Dufour",
                     Voornaam = "Sjoukje",
                     Licentie = true,
                     Woonplaats = "Brugge",
                     Wedstrijden = new List<Wedstrijd>() { wedstrijd1, wedstrijd5 },
                     Geboortedatum = DateTime.Parse("05-10-1987"),
                     Paswoord = "sjoukje",
                     Gebruikersnaam = "sjoukje"

                 },

                     new Putter
                     {
                         Id = 4,
                         SexID = 1,
                         RoleID = 2,
                         Naam = "Hillewaere",
                         Voornaam = "Dries",
                         Licentie = true,
                         Woonplaats = "Oostkamp",
                         Wedstrijden = new List<Wedstrijd>() { wedstrijd2, wedstrijd5 },
                         Geboortedatum = DateTime.Parse("26-02-1977"),
                         Paswoord = "dries",
                         Gebruikersnaam = "dries"

                     },
                      new Putter
                      {
                          Id = 5,
                          SexID = 1,
                          RoleID = 2,
                          Naam = "Pollet",
                          Voornaam = "Marc",
                          Licentie = true,
                          Woonplaats = "Varsenare",
                          Wedstrijden = new List<Wedstrijd>() { wedstrijd2, wedstrijd3 },
                          Geboortedatum = DateTime.Parse("19-08-1969"),
                          Paswoord = "marc",
                          Gebruikersnaam = "marc"

                      },
                      new Putter
                      {
                          Id = 6,
                          SexID = 2,
                          RoleID = 2,
                          Naam = "Sap",
                          Voornaam = "Julie",
                          Licentie = true,
                          Woonplaats = "Beernem",
                          Wedstrijden = new List<Wedstrijd>(),
                          Geboortedatum = DateTime.Parse("10-06-1992"),
                          Paswoord = "julie",
                          Gebruikersnaam = "julie"

                      },
                       new Putter
                       {
                           Id = 7,
                           SexID = 1,
                           RoleID = 2,
                           Naam = "Buffel",
                           Voornaam = "Bruno",
                           Licentie = true,
                           Woonplaats = "Baliebrugge",
                           Wedstrijden = new List<Wedstrijd>(),
                           Geboortedatum = DateTime.Parse("14-10-1976"),
                           Paswoord = "bruno",
                           Gebruikersnaam = "bruno"

                       },
                        new Putter
                        {
                            Id = 8,
                            SexID = 1,
                            RoleID = 2,
                            Naam = "Stubbe",
                            Voornaam = "Joeri",
                            Licentie = true,
                            Woonplaats = "Oostkamp",
                            Wedstrijden = new List<Wedstrijd>(),
                            Geboortedatum = DateTime.Parse("04-10-1978"),
                            Paswoord = "joeri",
                            Gebruikersnaam = "joeri"

                        },
                         new Putter
                         {
                             Id = 9,
                             SexID = 1,
                             RoleID = 2,
                             Naam = "Vandenberghe",
                             Voornaam = "Nico",
                             Licentie = true,
                             Woonplaats = "Dudzele",
                             Wedstrijden = new List<Wedstrijd>(),
                             Geboortedatum = DateTime.Parse("05-11-1978"),
                             Paswoord = "nico",
                             Gebruikersnaam = "nico"

                         },

                          new Putter
                          {
                              Id = 10,
                              SexID = 1,
                              RoleID = 2,
                              Naam = "Van Ryckeghem",
                              Voornaam = "Guy",
                              Licentie = true,
                              Woonplaats = "Oostkamp",
                              Wedstrijden = new List<Wedstrijd>(),
                              Paswoord = "guy",
                              Gebruikersnaam = "guy"

                          }


                );


        }

    }
}

