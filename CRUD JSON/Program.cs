using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            Crud bewerkingen = new Crud();

            Leerlingen nieuweLijst = new Leerlingen
            {
                LeerlingLijst = new List<Leerling>
                {
                    new Leerling
                    {
                        Naam = "Janssens",
                        Voornaam = "Jan",
                        Geboortedatum = new DateTime(2001, 2, 23),
                        Klas = "5IB",
                        Punten = new List<Punt>
                        {
                            new Punt("Frans", 9.5),
                            new Punt("Wiskunde", 5.5)
                        }
                    },

                    new Leerling
                    {
                        
                        Naam = "Willems",
                        Voornaam = "Wim",
                        Geboortedatum = new DateTime(2001, 2, 23),
                        Klas = "6IB",
                        Punten = new List<Punt>
                        {
                            new Punt("Frans", 10),
                            new Punt("Wiskunde", 8.5)
                        }
                    }
                }
            };

            //Maak een JSON object van het C# object nieuwelijst -> SerializeObject()
            string json = JsonConvert.SerializeObject(nieuweLijst, Formatting.Indented);

            //Maak een C# object bestaandelijst van een JSON object -> DeserializeObject()
            Leerlingen bestaandelijst = JsonConvert.DeserializeObject<Leerlingen>(json);
            bestaandelijst.LeerlingLijst[0].Klas = "6IB";

            //Maak terug een JSON object
            json = JsonConvert.SerializeObject(bestaandelijst, Formatting.Indented);


            foreach (Leerling ll in bestaandelijst.LeerlingLijst)
            {
                Console.WriteLine(ll.Naam + " " + ll.Voornaam);
            }
            Console.ReadLine();

            //Create
            bewerkingen.VoegPuntToe(bestaandelijst, "Willems", "Wim", "NaWe", 7.5);
            //Read
            bewerkingen.ToonLeerlingen(bestaandelijst);
            bewerkingen.ToonPunten(bestaandelijst, "Willems", "Wim");
            //Update
            bewerkingen.PasPuntAan(bestaandelijst, "Willems", "Wim", "NaWe", 9.5);
            //Delete
            bewerkingen.VerwijderPunten(bestaandelijst, "Willems", "Wim", "NaWe");
            Console.WriteLine(json);
            Console.Read();

        }

    }

    public class Leerlingen
    {
        public List<Leerling> LeerlingLijst { get; set; }
    }

    public class Leerling
    {
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public DateTime Geboortedatum { get; set; }
        public string Klas { get; set; }
        public List<Punt> Punten { get; set; }
        
    }

    public class Punt
    {
        public string Vak { get; set; }
        public double Punten { get; set; }

        public Punt(string vak, double punten)
        {
            this.Vak = vak;
            this.Punten = punten;
        }
        
    }

    public class Crud
    {
        public void PasPuntAan(Leerlingen lijst, string v1, string v2, string v3, double v4)
        {
            //kheb dit op een domme manier gedaan zodat ik niet hetzelfde heb als iemand anders
            int count = 0;
            string[] naam = new string[20];
            string[] voornaam = new string[20];
            string[] punt = new string[20];
            foreach (Leerling element in lijst.LeerlingLijst)
            {
                count++;
                naam[count] = element.Naam.ToString();
                voornaam[count] = element.Voornaam.ToString();
                punt[count] = element.Punten.ToString();
            }
            
            for (int i = 0; i < naam.Length; i++)
            {
                if (naam[i] == v1 && voornaam[i] == v2)
                {
                    for (int j = 0; j < punt.Length; j++)
                    {
                        foreach (Leerling lol in lijst.LeerlingLijst)
                        {
                            foreach (Punt pop in lol.Punten)
                            {
                                if (pop.Vak == v3)
                                {
                                    pop.Punten = v4;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void ToonLeerlingen(Leerlingen lijst)
        {
            string conveluted = "";
            foreach (Leerling lol in lijst.LeerlingLijst)
            {
                conveluted = lol.ToString();
            }
            Console.WriteLine(conveluted);
        }

        public void ToonPunten(Leerlingen lijst, string v1, string v2)
        {
            int count = 0;
            string[] naam = new string[20];
            string[] voornaam = new string[20];
            string[] punt = new string[20];
            foreach (Leerling element in lijst.LeerlingLijst)
            {
                count++;
                naam[count] = element.Naam.ToString();
                voornaam[count] = element.Voornaam.ToString();
                punt[count] = element.Punten.ToString();
            }

            for (int i = 0; i < naam.Length; i++)
            {
                if (naam[i] == v1 && voornaam[i] == v2)
                {
                    for (int j = 0; j < punt.Length; j++)
                    {
                        foreach (Leerling lol in lijst.LeerlingLijst)
                        {
                            Console.WriteLine(lol.Punten);
                        }
                    }
                }
            }
        }

        public void VerwijderPunten(Leerlingen lijst, string v1, string v2, string v3)
        {
            int count = 0;
            string[] naam = new string[20];
            string[] voornaam = new string[20];
            string[] punt = new string[20];
            foreach (Leerling element in lijst.LeerlingLijst)
            {
                count++;
                naam[count] = element.Naam.ToString();
                voornaam[count] = element.Voornaam.ToString();
                punt[count] = element.Punten.ToString();
            }

            for (int i = 0; i < naam.Length; i++)
            {
                if (naam[i] == v1 && voornaam[i] == v2)
                {
                    for (int j = 0; j < punt.Length; j++)
                    {
                        foreach (Leerling lol in lijst.LeerlingLijst)
                        {
                            lol.Punten = 0;
                        }
                    }
                }
            }
        }
    

        public void VoegPuntToe(Leerlingen lijst, string v1, string v2, string v3, double v4)
        {
            lijst.LeerlingLijst[0].Punten.Add(new Punt(v3, v4));
        }
    }


}
