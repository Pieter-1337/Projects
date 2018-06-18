using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma
{
    class Planten
    {
        public List<Plant> getPlanten()
        {
            Plant Tulp = new Plant() { PlantId = 1, PlantenNaam = "Tulp", Kleur = "Rood", Prijs = 0.5M, Soort = "Bol" };
            Plant Krokus = new Plant() { PlantId = 2, PlantenNaam = "Krokus", Kleur = "Wit", Prijs = 0.2M, Soort = "Bol" };
            Plant Narcis = new Plant() { PlantId = 3, PlantenNaam = "Narcis", Kleur = "Geel", Prijs = 0.3M, Soort = "Bol" };
            Plant Blauw_Druifje = new Plant() { PlantId = 4, PlantenNaam = "Blauw druifje", Kleur = "Blauw", Prijs = 0.2M, Soort = "Bol" };
            Plant Azalea = new Plant() { PlantId = 5, PlantenNaam = "Azalea", Kleur = "Rood", Prijs = 3.0M, Soort = "Heester" };
            Plant Forsythia = new Plant() { PlantId = 6, PlantenNaam = "Forsythia", Kleur = "Geel", Prijs = 2.0M, Soort = "Heester" };
            Plant Magnolia = new Plant() { PlantId = 7, PlantenNaam = "Magnolia", Kleur = "Wit", Prijs = 4.0m, Soort = "Heester" };
            Plant WaterLelie = new Plant() { PlantId = 8, PlantenNaam = "Waterlelie", Kleur = "Wit", Prijs = 2.0M, Soort = "Water" };
            Plant Lisdodde = new Plant() { PlantId = 9, PlantenNaam = "Lisdodde", Kleur = "Geel", Prijs = 3.0M, Soort = "Water" };
            Plant Kalmoes = new Plant() { PlantId = 10, PlantenNaam = "Kalmoes", Kleur = "Geel", Prijs = 2.5M, Soort = "Water" };
            Plant BiesLook = new Plant() { PlantId = 11, PlantenNaam = "Bieslook", Kleur = "Paars", Prijs = 1.5M, Soort = "Kruid" };
            Plant Rozemarijn = new Plant() { PlantId = 12, PlantenNaam = "Rozemarijn", Kleur = "Blauw", Prijs = 1.25M, Soort = "Kruid" };
            Plant Munt = new Plant() { PlantId = 13, PlantenNaam = "Munt", Kleur = "Wit", Prijs = 1.1M, Soort = "Kruid" };
            Plant Dragon = new Plant() { PlantId = 14, PlantenNaam = "Dragon", Kleur = "Wit", Prijs = 1.3M, Soort = "Kruid" };
            Plant Basilicum = new Plant() { PlantId = 15, PlantenNaam = "Basilicum", Kleur = "Wit", Prijs = 1.5M, Soort = "Kruid" };

            return new List<Plant> { Tulp, Krokus, Narcis, Blauw_Druifje, Azalea, Forsythia, Magnolia, WaterLelie, Lisdodde, Kalmoes, BiesLook, Rozemarijn, Munt, Dragon, Basilicum};
        }
    }
}
