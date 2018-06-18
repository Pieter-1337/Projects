using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.Data.Common;
using System.Configuration;
using System.Windows.Forms;


namespace DbManagers
{
    public class PlantenManager
    {
        public int EindejaarsKortingPlanten()
        {
            var dbManager = new TuinCentrumDbManager();

            using(var conTuinCentrum = dbManager.GetConnection())
            {
                using(var conEindejaarsKorting = conTuinCentrum.CreateCommand())
                {
                    conEindejaarsKorting.CommandType = CommandType.StoredProcedure;
                    conEindejaarsKorting.CommandText = "EindejaarsKorting";

                    conTuinCentrum.Open();
                    return conEindejaarsKorting.ExecuteNonQuery();
                }
            }

        }

        public string GemiddeldeKostprijsSoort(string soort)
        {
            var dbManager = new TuinCentrumDbManager();

            using(var conTuinCentrum = dbManager.GetConnection())
            {
                using(var conGemiddeldeSoort = conTuinCentrum.CreateCommand())
                {
                    conGemiddeldeSoort.CommandType = CommandType.StoredProcedure;
                    conGemiddeldeSoort.CommandText = "BerekenGemiddeldeVanSoort";

                    var ParamSoort = conGemiddeldeSoort.CreateParameter();
                    ParamSoort.ParameterName = "@Soort";
                    ParamSoort.Value = soort;
                    conGemiddeldeSoort.Parameters.Add(ParamSoort);

                    conTuinCentrum.Open();
                     string Resultaat = conGemiddeldeSoort.ExecuteScalar().ToString();

                    if(Resultaat == string.Empty)
                    {
                        throw new Exception("Deze soort is niet terug te vinden in de database");
                    }
                    else
                    {
                        return Resultaat;
                    }
                }
            }
        }

        public Plant GetPlantInfoByPlantNr(string PlantNummer)
        {
            var dbManager = new TuinCentrumDbManager();
            using(var conTuinCentrum = dbManager.GetConnection())
            {
                using(var conPlantInfo = conTuinCentrum.CreateCommand())
                {
                    conPlantInfo.CommandType = CommandType.StoredProcedure;
                    conPlantInfo.CommandText = "GetPlantInfo";

                    //Plantnummer
                    var PlantNummerParam = conPlantInfo.CreateParameter();
                    PlantNummerParam.ParameterName = "@PlantNummer";
                    PlantNummerParam.Value = Convert.ToInt32(PlantNummer);
                    conPlantInfo.Parameters.Add(PlantNummerParam);

                    //Naam
                    var PlantNaamParam = conPlantInfo.CreateParameter();
                    PlantNaamParam.ParameterName = "@PlantNaam";
                    PlantNaamParam.DbType = DbType.String;
                    PlantNaamParam.Size = 50;
                    PlantNaamParam.Direction = ParameterDirection.Output;
                    conPlantInfo.Parameters.Add(PlantNaamParam);

                    //Soort
                    var PlantSoortParam = conPlantInfo.CreateParameter();
                    PlantSoortParam.ParameterName = "@PlantSoort";
                    PlantSoortParam.DbType = DbType.String;
                    PlantSoortParam.Size = 50;
                    PlantSoortParam.Direction = ParameterDirection.Output;
                    conPlantInfo.Parameters.Add(PlantSoortParam);

                    //Leverancier
                    var LeverancierParam = conPlantInfo.CreateParameter();
                    LeverancierParam.ParameterName = "@Leverancier";
                    LeverancierParam.DbType = DbType.String;
                    LeverancierParam.Size = 50;
                    LeverancierParam.Direction = ParameterDirection.Output;
                    conPlantInfo.Parameters.Add(LeverancierParam);

                    //Kleur
                    var KleurParam = conPlantInfo.CreateParameter();
                    KleurParam.ParameterName = "@Kleur";
                    KleurParam.DbType = DbType.String;
                    KleurParam.Size = 50;
                    KleurParam.Direction = ParameterDirection.Output;
                    conPlantInfo.Parameters.Add(KleurParam);

                    //Kostprijs
                    var KostPrijsParam = conPlantInfo.CreateParameter();
                    KostPrijsParam.ParameterName = "@KostPrijs";
                    KostPrijsParam.DbType = DbType.Currency;
                    KostPrijsParam.Size = 50;
                    KostPrijsParam.Direction = ParameterDirection.Output;
                    conPlantInfo.Parameters.Add(KostPrijsParam);

                    conTuinCentrum.Open();
                    conPlantInfo.ExecuteNonQuery();
                    if (PlantNaamParam.Value.Equals(DBNull.Value))
                    {
                        throw new Exception("\nPlantnummer niet terug gevonden in onze database");
                    }
                    else
                    {
                        return new Plant(PlantNaamParam.Value.ToString(), PlantSoortParam.Value.ToString(), LeverancierParam.Value.ToString(), KleurParam.Value.ToString(), (Decimal)KostPrijsParam.Value);
                    }


                }
            }
        }


        public List<Soort> GetSoorten()
        {
            var soorten = new List<Soort>();
            var manager = new TuinCentrumDbManager();

            using (var conTuin = manager.GetConnection())
            {
                using (var conSoorten = conTuin.CreateCommand())
                {
                    conSoorten.CommandType = CommandType.Text;
                    conSoorten.CommandText = "SELECT SoortNr, Soort from Soorten order by Soort";
                    conTuin.Open();

                    using (var SoortReader = conSoorten.ExecuteReader())
                    {
                        var soortNaamPos = SoortReader.GetOrdinal("soort");
                        var soortNrPos = SoortReader.GetOrdinal("soortnr");
                        while (SoortReader.Read())
                        {
                            soorten.Add(new Soort(SoortReader.GetString(soortNaamPos), SoortReader.GetInt32(soortNrPos)));
                        }
                    }//using Reader
                }//Using conSoorten
            }//Using conTuin
            return soorten;
        }

        public List<String> GetPlanten(int soortnr)
        {
            var planten = new List<String>();
            var manager = new TuinCentrumDbManager();

            using (var conTuin = manager.GetConnection())
            {
                using (var conPlanten = conTuin.CreateCommand())
                {
                    conPlanten.CommandType = CommandType.Text;
                    conPlanten.CommandText = "SELECT naam from planten where soortnr=@soortnr order by naam";
                    var SoortNrParam = conPlanten.CreateParameter();
                    SoortNrParam.ParameterName = "@soortnr";
                    SoortNrParam.Value = soortnr;
                    conPlanten.Parameters.Add(SoortNrParam);

                    conTuin.Open();

                    using (var PlantReader = conPlanten.ExecuteReader())
                    {
                        while (PlantReader.Read())
                        {
                            planten.Add(PlantReader["naam"].ToString());
                        }
                    }//Using Reader
                }//Using conPlanten
            }//Using conTuin
            return planten;
        }

        public Plant GetPlantInfo(string plantnaam)
        {
           
            var manager = new TuinCentrumDbManager();

            using(var conTuin = manager.GetConnection())
            {
                using(var conGetplantInfo = conTuin.CreateCommand())
                {
                    conGetplantInfo.CommandType = CommandType.Text;
                    conGetplantInfo.CommandText = "SELECT @PlantNummer = planten.PlantNr, @PlantNaam = planten.Naam, @PlantSoort = Soorten.Soort, @PlantPrijs = planten.VerkoopPrijs, @PlantLeverancier = Leveranciers.Naam, @PlantKleur = Planten.Kleur From Planten INNER JOIN Leveranciers on Planten.LevNr = Leveranciers.LevNr INNER JOIN Soorten on Planten.SoortNr = Soorten.SoortNr WHERE planten.Naam=@PlantNaam";

                    var PlantNaamParam = conGetplantInfo.CreateParameter();
                    PlantNaamParam.ParameterName = "@PlantNaam";
                    PlantNaamParam.Value = plantnaam;
                    conGetplantInfo.Parameters.Add(PlantNaamParam);

                    var PlantSoortParam = conGetplantInfo.CreateParameter();
                    PlantSoortParam.ParameterName = "@PlantSoort";
                    PlantSoortParam.DbType = DbType.String;
                    PlantSoortParam.Size = 100;
                    PlantSoortParam.Direction = ParameterDirection.Output;
                    conGetplantInfo.Parameters.Add(PlantSoortParam);

                    var PlantLeverancierParam = conGetplantInfo.CreateParameter();
                    PlantLeverancierParam.ParameterName = "@PlantLeverancier";
                    PlantLeverancierParam.DbType = DbType.String;
                    PlantLeverancierParam.Size = 100;
                    PlantLeverancierParam.Direction = ParameterDirection.Output;
                    conGetplantInfo.Parameters.Add(PlantLeverancierParam);

                    var PlantKleurParam = conGetplantInfo.CreateParameter();
                    PlantKleurParam.ParameterName = "@PlantKleur";
                    PlantKleurParam.DbType = DbType.String;
                    PlantKleurParam.Size = 100;
                    PlantKleurParam.Direction = ParameterDirection.Output;
                    conGetplantInfo.Parameters.Add(PlantKleurParam);

                    var PlantPrijsParam = conGetplantInfo.CreateParameter();
                    PlantPrijsParam.ParameterName = "@PlantPrijs";
                    PlantPrijsParam.DbType = DbType.Currency;
                    PlantPrijsParam.Direction = ParameterDirection.Output;
                    conGetplantInfo.Parameters.Add(PlantPrijsParam);

                    var PlantNummerParam = conGetplantInfo.CreateParameter();
                    PlantNummerParam.ParameterName = "@PlantNummer";
                    PlantNummerParam.DbType = DbType.Int32;
                    PlantNummerParam.Direction = ParameterDirection.Output;
                    conGetplantInfo.Parameters.Add(PlantNummerParam);

                    conTuin.Open();
                    
                    if (conGetplantInfo.ExecuteNonQuery() == 0)
                    {
                        throw new Exception("\nPlant niet terug gevonden in onze database");
                    }
                    else
                    {
                        return new Plant(PlantNaamParam.Value.ToString(), PlantSoortParam.Value.ToString(), PlantLeverancierParam.Value.ToString(), PlantKleurParam.Value.ToString(), (Decimal)PlantPrijsParam.Value, (int)PlantNummerParam.Value);
                        //return new RekeningInfo((Decimal)ParamSaldo.Value, (string)ParamKlantNaam.Value);
                     
                        
                    }


                }
            }

        }

        public Plant SavePlant(string Plantnaam, string Plantkleur, string Plantprijs)
        {
            var manager = new TuinCentrumDbManager();

            using (var conTuin = manager.GetConnection())
            {
                using (var conGetplantInfo = conTuin.CreateCommand())
                {
                    conGetplantInfo.CommandType = CommandType.Text;
                    //conGetplantInfo.CommandText = "SELECT @PlantNummer = planten.PlantNr, @PlantNaam = planten.Naam, @PlantSoort = Soorten.Soort, @PlantPrijs = planten.VerkoopPrijs, @PlantLeverancier = Leveranciers.Naam, @PlantKleur = Planten.Kleur From Planten INNER JOIN Leveranciers on Planten.LevNr = Leveranciers.LevNr INNER JOIN Soorten on Planten.SoortNr = Soorten.SoortNr WHERE planten.Naam=@PlantNaam";
                    conGetplantInfo.CommandText = "UPDATE Planten SET planten.Kleur = @PlantKleur, planten.VerkoopPrijs = @PlantPrijs WHERE planten.Naam = @PlantNaam";
                    var PlantNaamParam = conGetplantInfo.CreateParameter();
                    PlantNaamParam.ParameterName = "@PlantNaam";
                    PlantNaamParam.Value = Plantnaam;
                    conGetplantInfo.Parameters.Add(PlantNaamParam);

                    var PlantKleurParam = conGetplantInfo.CreateParameter();
                    PlantKleurParam.ParameterName = "@PlantKleur";
                    PlantKleurParam.Value = Plantkleur;
                    conGetplantInfo.Parameters.Add(PlantKleurParam);

                    var PlantPrijsParam = conGetplantInfo.CreateParameter();
                    PlantPrijsParam.ParameterName = "@PlantPrijs";
                    PlantPrijsParam.Value = Plantprijs;
                    conGetplantInfo.Parameters.Add(PlantPrijsParam);

                    conTuin.Open();

                    if (conGetplantInfo.ExecuteNonQuery() == 0)
                    {
                        throw new Exception("\nPlant niet terug gevonden in onze database");
                    }
                }//Using conGetPlantInfo
            }//Using conTuin

            return GetPlantInfo(Plantnaam);

        }
    }
}
