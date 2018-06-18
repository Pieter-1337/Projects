using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
using System.Transactions;
using System.Collections.Generic;
using System.Windows;
using System.Collections.ObjectModel;

namespace DbManagers
{
    public class LeveranciersManager
    {
        public Int64 AddLeverancier(Leverancier eenLeverancier)
        {
            var dbManager = new TuinCentrumDbManager();

            using (var conTuinCentrum = dbManager.GetConnection())
            {
                using (var conAddLeverancier = conTuinCentrum.CreateCommand())
                {
                    try
                    {
                        //Stored procedure in DB 
                        conAddLeverancier.CommandType = CommandType.StoredProcedure;
                        conAddLeverancier.CommandText = "AddLeverancier";

                        DbParameter NaamParam = conAddLeverancier.CreateParameter();
                        NaamParam.ParameterName = "@Naam";
                        NaamParam.Value = eenLeverancier.Naam;
                        NaamParam.DbType = DbType.String;
                        conAddLeverancier.Parameters.Add(NaamParam);

                        DbParameter AdresParam = conAddLeverancier.CreateParameter();
                        AdresParam.ParameterName = "@Adres";
                        AdresParam.Value = eenLeverancier.Adres;
                        AdresParam.DbType = DbType.String;
                        conAddLeverancier.Parameters.Add(AdresParam);

                        DbParameter PostcodeParam = conAddLeverancier.CreateParameter();
                        PostcodeParam.ParameterName = "@Postcode";
                        PostcodeParam.Value = eenLeverancier.Postcode;
                        conAddLeverancier.Parameters.Add(PostcodeParam);

                        DbParameter PlaatsParam = conAddLeverancier.CreateParameter();
                        PlaatsParam.ParameterName = "@Plaats";
                        PlaatsParam.Value = eenLeverancier.Plaats;
                        PlaatsParam.DbType = DbType.String;
                        conAddLeverancier.Parameters.Add(PlaatsParam);

                        conTuinCentrum.Open();
                        Int64 KlantNr = Convert.ToInt64(conAddLeverancier.ExecuteScalar());
                        return KlantNr;



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error bij het toevoegen van Leverancier aan database " + ex.Message, "AddLeverancier Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 0;

                    }
                }
            }

        }

        public Boolean VervangPlantenVanLeverancier(string LevNr1, string LevNr2)
        {
            try
            {
                var dbManager = new TuinCentrumDbManager();
                var opties = new TransactionOptions();
                opties.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;

                using (var TraWisselPlanten = new TransactionScope(TransactionScopeOption.Required, opties))
                {
                    using (var conTuinCentrum = dbManager.GetConnection())
                    {

                        using (var conAddPlanten = conTuinCentrum.CreateCommand())
                        {
                            conAddPlanten.CommandType = CommandType.StoredProcedure;
                            conAddPlanten.CommandText = "AddPlanten";

                            var ParamLevNr1 = conAddPlanten.CreateParameter();
                            ParamLevNr1.ParameterName = "@LeveranciersNummer1";
                            ParamLevNr1.Value = LevNr1;
                            conAddPlanten.Parameters.Add(ParamLevNr1);

                            var ParamLevNr2 = conAddPlanten.CreateParameter();
                            ParamLevNr2.ParameterName = "@LeveranciersNummer2";
                            ParamLevNr2.Value = LevNr2;
                            conAddPlanten.Parameters.Add(ParamLevNr2);

                            conTuinCentrum.Open();
                            if (conAddPlanten.ExecuteNonQuery() == 0)
                            {
                                //Bij Transactionscope vindt de rollback automatisch plaats bij DbTranscaction class moet je dit manueel adden
                                throw new Exception($"LeveranciersNummer 2: {LevNr2}  werd niet terug gevonden in de database.");
                            }

                        }

                        //Indien we met de leverancier vanwaar de planten werderen verwijderd nog iets willen uitvoeren kunne we onderstaande code gebruiken.
                        //using (var conVerwijderPlanten = conTuinCentrum.CreateCommand())
                        //{
                        //    conVerwijderPlanten.CommandType = CommandType.StoredProcedure;
                        //    conVerwijderPlanten.CommandText = "VerwijderPlanten";

                        //    var ParamLevNr1 = conVerwijderPlanten.CreateParameter();
                        //    ParamLevNr1.ParameterName = "@LeveranciersNummer1";
                        //    ParamLevNr1.Value = LevNr1;
                        //    conVerwijderPlanten.Parameters.Add(ParamLevNr1);

                        //    conTuinCentrum.Open();
                        //    if (conVerwijderPlanten.ExecuteNonQuery() == 0)
                        //    {
                        //        //Bij Transactionscope vindt de rollback automatisch plaats bij DbTranscaction class moet je dit manueel adden
                        //        throw new Exception($"LeveranciersNummer 1: {LevNr1} werd niet terug gevonden in de database.");
                        //    }     
                        //}

                        TraWisselPlanten.Complete();
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message);

            }
        }


        //LAATSTE OEFENING START HIER (BUITEN DE VARS declared bovenaan uiteraard!

        public ObservableCollection<Leverancier> GetLeveranciersOpPostcode(string postcode)
        {
            ObservableCollection<Leverancier> Leveranciers = new ObservableCollection<Leverancier>();
            var Dbmanager = new TuinCentrumDbManager();
            try
            {
                using (var conTuincentrum = Dbmanager.GetConnection())
                {
                    using (var conLeveranciers = conTuincentrum.CreateCommand())
                    {
                        if (postcode != "Alles")
                        {
                            conLeveranciers.CommandType = CommandType.Text;
                            //Insert Query
                            conLeveranciers.CommandText = "SELECT * from Leveranciers Where PostNr = @zoals order by LevNr";

                            var ZoalsParam = conLeveranciers.CreateParameter();
                            ZoalsParam.ParameterName = "@zoals";
                            ZoalsParam.Value = postcode;
                            conLeveranciers.Parameters.Add(ZoalsParam);
                        }
                        else
                        {
                            conLeveranciers.CommandText = "Select * From Leveranciers";
                        }
                        conTuincentrum.Open();

                        using (var LeveranciersReader = conLeveranciers.ExecuteReader())
                        {

                            Int32 LevNrPos = LeveranciersReader.GetOrdinal("LevNr");
                            Int32 NaamPos = LeveranciersReader.GetOrdinal("Naam");
                            Int32 AdresPos = LeveranciersReader.GetOrdinal("Adres");
                            Int32 PostcodePos = LeveranciersReader.GetOrdinal("PostNr");
                            Int32 WoonplaatsPos = LeveranciersReader.GetOrdinal("Woonplaats");

                            while (LeveranciersReader.Read())
                            {
                                Leveranciers.Add(new Leverancier(LeveranciersReader.GetInt32(LevNrPos), LeveranciersReader.GetString(NaamPos), LeveranciersReader.GetString(AdresPos), LeveranciersReader.GetString(PostcodePos), LeveranciersReader.GetString(WoonplaatsPos)));
                            }//Do while
                        }//Using Reader
                    }//Using conLeveranciers
                }//Using conTuincentrum
                return Leveranciers;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public List<Leverancier> SchrijfVerwijderingen(List<Leverancier> leveranciers)
        {
            List<Leverancier> nietVerwijderdeLeveranciers = new List<Leverancier>();
            var manager = new TuinCentrumDbManager();

            using(var conTuinCentrum = manager.GetConnection())
            {
                conTuinCentrum.Open();
                using(var conDeleteLeverancier = conTuinCentrum.CreateCommand())
                {
                    conDeleteLeverancier.CommandType = CommandType.Text;
                    conDeleteLeverancier.CommandText = "DELETE from Leveranciers where LevNr = @LevNummer";

                    var LeveranciersNummerParam = conDeleteLeverancier.CreateParameter();
                    LeveranciersNummerParam.ParameterName = "@LevNummer";
                    conDeleteLeverancier.Parameters.Add(LeveranciersNummerParam);
                    
                    foreach(Leverancier eenLeverancier in leveranciers)
                    {
                        try
                        {
                            LeveranciersNummerParam.Value = eenLeverancier.LevNr;
                            if(conDeleteLeverancier.ExecuteNonQuery() == 0)
                            {
                                nietVerwijderdeLeveranciers.Add(eenLeverancier);
                            }
                        }
                        catch(Exception ex)
                        {
                            nietVerwijderdeLeveranciers.Add(eenLeverancier);
                        }
                    }//Foreach
                }//Using conDelete
            }//Using conTuin
            return nietVerwijderdeLeveranciers;
        }

        public List<Leverancier> SchrijfToevoegingen(List<Leverancier> leveranciers)
        {
            List<Leverancier> nietToegevoegdeLeveranciers = new List<Leverancier>();
            var manager = new TuinCentrumDbManager();

            using(var conTuinCentrum = manager.GetConnection())
            {
                try
                {
                    using (var conToevoegingen = conTuinCentrum.CreateCommand())
                    {
                        conToevoegingen.CommandType = CommandType.Text;
                        conToevoegingen.CommandText = "INSERT INTO Leveranciers (Naam, Adres, PostNr, Woonplaats) values (@Naam, @Adres, @PostNr, @Woonplaats)";

                        var NaamParam = conToevoegingen.CreateParameter();
                        NaamParam.ParameterName = "@Naam";
                        conToevoegingen.Parameters.Add(NaamParam);

                        var AdresParam = conToevoegingen.CreateParameter();
                        AdresParam.ParameterName = "@Adres";
                        conToevoegingen.Parameters.Add(AdresParam);

                        var PostNrParam = conToevoegingen.CreateParameter();
                        PostNrParam.ParameterName = "@PostNr";
                        conToevoegingen.Parameters.Add(PostNrParam);

                        var WoonplaatsParam = conToevoegingen.CreateParameter();
                        WoonplaatsParam.ParameterName = "@Woonplaats";
                        conToevoegingen.Parameters.Add(WoonplaatsParam);

                        conTuinCentrum.Open();

                        foreach (var eenLeverancier in leveranciers)
                        {
                            try
                            {
                                NaamParam.Value = eenLeverancier.Naam;
                                AdresParam.Value = eenLeverancier.Adres;
                                PostNrParam.Value = eenLeverancier.Postcode;
                                WoonplaatsParam.Value = eenLeverancier.Plaats;

                                if (conToevoegingen.ExecuteNonQuery() == 0)
                                {
                                    nietToegevoegdeLeveranciers.Add(eenLeverancier);
                                }
                            }
                            catch (Exception ex)
                            {
                                nietToegevoegdeLeveranciers.Add(eenLeverancier);
                            }

                        }//Foreach
                    }//Using conToevoegingen
                }
                catch (Exception ex)
                {
                        MessageBox.Show("Fout bij het uitvoeren van Query toevoegen van leveranciers " + ex.Message, "Toevoegen error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }//Using conTuincentrum
            return nietToegevoegdeLeveranciers;
        }

        public List<Leverancier> SchrijfWijzigingen(List<Leverancier> leveranciers)
        {
            List<Leverancier> NietGewijzigdeLeveranciers = new List<Leverancier>();
            var manager = new TuinCentrumDbManager();

            using(var conTuinCentrum = manager.GetConnection())
            {
                using(var conWijzig = conTuinCentrum.CreateCommand())
                {
                    conWijzig.CommandType = CommandType.Text;
                    conWijzig.CommandText = "Update leveranciers Set Naam = @LevNaam, Adres = @LevAdres, PostNr = @LevPostNr, Woonplaats = @LevWoonplaats Where LevNr = @LevNummer";

                    var NaamParam = conWijzig.CreateParameter();
                    NaamParam.ParameterName = "@LevNaam";
                    conWijzig.Parameters.Add(NaamParam);

                    var AdresParam = conWijzig.CreateParameter();
                    AdresParam.ParameterName = "@LevAdres";
                    conWijzig.Parameters.Add(AdresParam);

                    var PostNrParam = conWijzig.CreateParameter();
                    PostNrParam.ParameterName = "@LevPostNr";
                    conWijzig.Parameters.Add(PostNrParam);

                    var WoonPlaatsParam = conWijzig.CreateParameter();
                    WoonPlaatsParam.ParameterName = "@LevWoonplaats";
                    conWijzig.Parameters.Add(WoonPlaatsParam);

                    var LevNrParam = conWijzig.CreateParameter();
                    LevNrParam.ParameterName = "@LevNummer";
                    conWijzig.Parameters.Add(LevNrParam);

                    conTuinCentrum.Open();

                    foreach(var eenLeverancier in leveranciers)
                    {
                        try
                        {
                            NaamParam.Value = eenLeverancier.Naam;
                            AdresParam.Value = eenLeverancier.Adres;
                            PostNrParam.Value = eenLeverancier.Postcode;
                            WoonPlaatsParam.Value = eenLeverancier.Plaats;
                            LevNrParam.Value = eenLeverancier.LevNr;

                            if(conWijzig.ExecuteNonQuery() == 0)
                            {
                                NietGewijzigdeLeveranciers.Add(eenLeverancier);
                            }
                        }
                        catch(Exception ex)
                        {
                            NietGewijzigdeLeveranciers.Add(eenLeverancier);
                            MessageBox.Show("Error wijzigen leverancier" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                        }
                    }//Foreach
                }//Using conWijzig
            }//Using ConTuinCentrum
            return NietGewijzigdeLeveranciers;
        }
    }
}

