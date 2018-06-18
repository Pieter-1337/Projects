using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.ComponentModel;
using System.Windows;


namespace DbManagers
{
    public class FilmsManager
    {
        static List<Film> toetevoegen;
        
        public ObservableCollection<Film> GetAlleFilms()
        {
            
            ObservableCollection<Film> Films = new ObservableCollection<Film>();
            var DbManager = new VideotheekDbManager();

            try
            {
                using(var conVideotheek = DbManager.GetConnection())
                {
                    using(var conFilms = conVideotheek.CreateCommand())
                    {
                        conFilms.CommandType = CommandType.Text;
                        conFilms.CommandText = "SELECT * from Films";

                        conVideotheek.Open();

                        using (var FilmsReader = conFilms.ExecuteReader())
                        {
                            Int32 FilmBandNrPos = FilmsReader.GetOrdinal("BandNr");
                            Int32 TitelPos = FilmsReader.GetOrdinal("Titel");
                            Int32 GenreNrPos = FilmsReader.GetOrdinal("GenreNr");
                            Int32 InVoorraadPos = FilmsReader.GetOrdinal("InVoorraad");
                            Int32 UitVoorraadPos = FilmsReader.GetOrdinal("UitVoorraad");
                            Int32 PrijsPos = FilmsReader.GetOrdinal("Prijs");
                            Int32 TotaalVerhuurdPos = FilmsReader.GetOrdinal("TotaalVerhuurd");

                            while (FilmsReader.Read())
                            {
                                Films.Add(new Film(FilmsReader.GetInt32(FilmBandNrPos), FilmsReader.GetString(TitelPos), FilmsReader.GetInt32(GenreNrPos), FilmsReader.GetInt32(InVoorraadPos), FilmsReader.GetInt32(UitVoorraadPos), FilmsReader.GetDecimal(PrijsPos), FilmsReader.GetInt32(TotaalVerhuurdPos)));
                            }
                        }//Using Reader
                    }//Using ConFilms     
                }//Using ConVideotheek
                return Films;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public ObservableCollection<Film> GetAlleFilmsNaToevoegen(List<Film> toegevoegdeFilms)
        {
            ObservableCollection<Film> Films = new ObservableCollection<Film>();
            var DbManager = new VideotheekDbManager();
            
            if(toetevoegen == null)
            {
                toetevoegen = new List<Film>();
            }
            foreach(Film film in toegevoegdeFilms)
            {
                //Declared globally
                foreach(Film eenfilm in toetevoegen)
                {
                    string film1 = film.Titel.ToString().Trim(' ').ToLower();
                    string film2 = eenfilm.Titel.ToString().Trim(' ').ToLower();
                    if(film1 == film2)
                    {

                    }
                    else
                    {
                        toetevoegen.Add(film);
                    }
                }
              
            }

            try
            {
                using (var conVideotheek = DbManager.GetConnection())
                {
                    using (var conFilms = conVideotheek.CreateCommand())
                    {
                        conFilms.CommandType = CommandType.Text;
                        conFilms.CommandText = "SELECT * from Films";

                        conVideotheek.Open();

                        using (var FilmsReader = conFilms.ExecuteReader())
                        {
                            Int32 FilmBandNrPos = FilmsReader.GetOrdinal("BandNr");
                            Int32 TitelPos = FilmsReader.GetOrdinal("Titel");
                            Int32 GenreNrPos = FilmsReader.GetOrdinal("GenreNr");
                            Int32 InVoorraadPos = FilmsReader.GetOrdinal("InVoorraad");
                            Int32 UitVoorraadPos = FilmsReader.GetOrdinal("UitVoorraad");
                            Int32 PrijsPos = FilmsReader.GetOrdinal("Prijs");
                            Int32 TotaalVerhuurdPos = FilmsReader.GetOrdinal("TotaalVerhuurd");

                            while (FilmsReader.Read())
                            {
                                Film TeCheckenFilm = new Film(FilmsReader.GetInt32(FilmBandNrPos), FilmsReader.GetString(TitelPos), FilmsReader.GetInt32(GenreNrPos), FilmsReader.GetInt32(InVoorraadPos), FilmsReader.GetInt32(UitVoorraadPos), FilmsReader.GetDecimal(PrijsPos), FilmsReader.GetInt32(TotaalVerhuurdPos));

                                Films.Add(TeCheckenFilm);
                            }

                            foreach(Film film in toegevoegdeFilms)
                            {
                                
                                Films.Add(film);
                            }

                        }//Using Reader
                    }//Using ConFilms     
                }//Using ConVideotheek
                
                //MessageBox.Show(toetevoegen.Count.ToString()); //Result = 1
                return Films;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Get alle films na toevoegen" + ex.Message);
                return null;
            }
           
        }

        public ObservableCollection<Film> GetAlleFilmsNaVerwijderen(List<Film> verwijderdeFilms)
        {
            ObservableCollection<Film> Films = new ObservableCollection<Film>();
            var DbManager = new VideotheekDbManager();
            List<Film> teverwijderen = new List<Film>();
           
            if(toetevoegen == null)
            {
                toetevoegen = new List<Film>();
            }
          
            try
            {
                using (var conVideotheek = DbManager.GetConnection())
                {
                    using (var conFilms = conVideotheek.CreateCommand())
                    {
                        conFilms.CommandType = CommandType.Text;
                        conFilms.CommandText = "SELECT * from Films";

                        conVideotheek.Open();

                        using (var FilmsReader = conFilms.ExecuteReader())
                        {
                            Int32 FilmBandNrPos = FilmsReader.GetOrdinal("BandNr");
                            Int32 TitelPos = FilmsReader.GetOrdinal("Titel");
                            Int32 GenreNrPos = FilmsReader.GetOrdinal("GenreNr");
                            Int32 InVoorraadPos = FilmsReader.GetOrdinal("InVoorraad");
                            Int32 UitVoorraadPos = FilmsReader.GetOrdinal("UitVoorraad");
                            Int32 PrijsPos = FilmsReader.GetOrdinal("Prijs");
                            Int32 TotaalVerhuurdPos = FilmsReader.GetOrdinal("TotaalVerhuurd");

                            while (FilmsReader.Read())
                            {
                                Film TeCheckenFilm = new Film(FilmsReader.GetInt32(FilmBandNrPos), FilmsReader.GetString(TitelPos), FilmsReader.GetInt32(GenreNrPos), FilmsReader.GetInt32(InVoorraadPos), FilmsReader.GetInt32(UitVoorraadPos), FilmsReader.GetDecimal(PrijsPos), FilmsReader.GetInt32(TotaalVerhuurdPos));
                               
                                Films.Add(TeCheckenFilm);
                               
                                
                            }

                            if (toetevoegen.Count() > 0)
                            {
                                
                                foreach (Film film in toetevoegen)
                                {
                                    foreach(Film eenFilm in verwijderdeFilms)
                                    {
                                        string film1 = film.Titel.ToString().Trim().ToLower();
                                        string film2 = eenFilm.Titel.ToString().Trim().ToLower();
                                        if(film1 == film2)
                                        {
                                            
                                        }
                                        else
                                        {
                                            Films.Add(film);
                                        }
                                        
                                    }
                                    
                                }
                            }

                            foreach (Film eenFilm in verwijderdeFilms)
                            {
                                foreach(Film film in Films)
                                {
                                    if(film.Titel.ToString() == eenFilm.Titel.ToString())
                                    {
                                        teverwijderen.Add(film);
                                        toetevoegen.Remove(film);
                                        
                                    }
                                }
                            }
                            teverwijderen.Clear();
                            foreach (Film film in verwijderdeFilms)
                            {
                                foreach(Film eenFilm in Films)
                                {
                                    string film1 = film.Titel.ToString().Trim(' ').ToLower();
                                    string film2 = eenFilm.Titel.ToString().Trim(' ').ToLower();
                                    if(film1 == film2)
                                    {
                                        teverwijderen.Add(eenFilm);
                                    }
                                }
                                   
                            }

                            foreach(Film film in teverwijderen)
                            {
                                Films.Remove(film);
                            }
                            
                            teverwijderen.Clear();
                            
                            
                        }//Using Reader
                    }//Using ConFilms     
                }//Using ConVideotheek
                return Films;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public List<Film>SchrijfVerwijderingen(List<Film> films)
        {
            List<Film> nietVerwijderdeFilms = new List<Film>();
            var manager = new VideotheekDbManager();
            using(var conVideotheek = manager.GetConnection())
            {
                conVideotheek.Open();
                using (var conDeleteFilm = conVideotheek.CreateCommand())
                {
                    conDeleteFilm.CommandType = CommandType.Text;
                    conDeleteFilm.CommandText = "delete from Films where BandNr = @bandNr";

                    var BandNrParam = conDeleteFilm.CreateParameter();
                    BandNrParam.ParameterName = "@bandNr";
                    conDeleteFilm.Parameters.Add(BandNrParam);

                    foreach(Film eenFilm in films)
                    {
                        try
                        {
                            BandNrParam.Value = eenFilm.BandNr;
                            if(conDeleteFilm.ExecuteNonQuery() == 0)
                            {
                                if (BandNrParam.Value.ToString() != "0")
                                {
                                    nietVerwijderdeFilms.Add(eenFilm);
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            nietVerwijderdeFilms.Add(eenFilm);
                        }
                    }//foreach
                }//Using Con delete
            }//Using con Videotheek
            return nietVerwijderdeFilms;
        }

        public List<Film> SchrijfWijzigingen(List<Film> films)
        {
            List<Film> NietGewijzigdeFilms = new List<Film>();
            var manager = new VideotheekDbManager();

            using(var conVideoTheek = manager.GetConnection())
            {
                using(var conWijzigFilm = conVideoTheek.CreateCommand())
                {
                    conWijzigFilm.CommandType = CommandType.Text;
                    conWijzigFilm.CommandText = "UPDATE Films set InVoorraad=@InVoorraad, UitVoorraad=@UitVoorraad, TotaalVerhuurd=@TotaalVerhuurd where BandNr=@BandNr and Titel=@Titel";

                    var TitelParam = conWijzigFilm.CreateParameter();
                    TitelParam.ParameterName = "@Titel";
                    conWijzigFilm.Parameters.Add(TitelParam);

                    var BandNrParam = conWijzigFilm.CreateParameter();
                    BandNrParam.ParameterName = "@BandNr";
                    conWijzigFilm.Parameters.Add(BandNrParam);

                    var inVoorraadParam = conWijzigFilm.CreateParameter();
                    inVoorraadParam.ParameterName = "@InVoorraad";
                    conWijzigFilm.Parameters.Add(inVoorraadParam);

                    var uitVoorraadParam = conWijzigFilm.CreateParameter();
                    uitVoorraadParam.ParameterName = "@UitVoorraad";
                    conWijzigFilm.Parameters.Add(uitVoorraadParam);

                    var totaalVerhuurdParam = conWijzigFilm.CreateParameter();
                    totaalVerhuurdParam.ParameterName = "@TotaalVerhuurd";
                    conWijzigFilm.Parameters.Add(totaalVerhuurdParam);



                    conVideoTheek.Open();

                    foreach(Film eenfilm in films)
                    {
                        try
                        {
                            BandNrParam.Value = eenfilm.BandNr;
                            TitelParam.Value = eenfilm.Titel;
                            inVoorraadParam.Value = eenfilm.InVoorraad;
                            uitVoorraadParam.Value = eenfilm.uitVoorraad;
                            totaalVerhuurdParam.Value = eenfilm.TotaalVerhuurd;
                            if(conWijzigFilm.ExecuteNonQuery() == 0)
                            {
                                NietGewijzigdeFilms.Add(eenfilm);
                            }
                        }
                        catch(Exception ex)
                        {
                            NietGewijzigdeFilms.Add(eenfilm);
                            MessageBox.Show(ex.Message);
                        }
                    } //Foreach
                }//conWijzig
            }//ConVideoTheek
            return NietGewijzigdeFilms;
        }

        public List<Film> SchrijfToevoegingen(List<Film> films)
        {
            List<Film> nietToegevoegdeFilms = new List<Film>();
            var manager = new VideotheekDbManager();

            using(var conVideoTheek = manager.GetConnection())
            {
                using(var conAddFilm = conVideoTheek.CreateCommand())
                {
                    conAddFilm.CommandType = CommandType.Text;
                    conAddFilm.CommandText = "INSERT into Films (Titel, GenreNr, InVoorraad, UitVoorraad, Prijs, TotaalVerhuurd) values (@Titel, @GenreNr, @InVoorraad, @UitVoorraad, @Prijs, @TotaalVerhuurd)";

                    var TitelParam = conAddFilm.CreateParameter();
                    TitelParam.ParameterName = "@Titel";
                    conAddFilm.Parameters.Add(TitelParam);

                    var GenreNrParam = conAddFilm.CreateParameter();
                    GenreNrParam.ParameterName = "@GenreNr";
                    conAddFilm.Parameters.Add(GenreNrParam);

                    var InVoorraadParam = conAddFilm.CreateParameter();
                    InVoorraadParam.ParameterName = "@InVoorraad";
                    conAddFilm.Parameters.Add(InVoorraadParam);

                    var UitVoorraadParam = conAddFilm.CreateParameter();
                    UitVoorraadParam.ParameterName = "@UitVoorraad";
                    conAddFilm.Parameters.Add(UitVoorraadParam);

                    var PrijsParam = conAddFilm.CreateParameter();
                    PrijsParam.ParameterName = "@Prijs";
                    conAddFilm.Parameters.Add(PrijsParam);

                    var TotaalVerhuurdParam = conAddFilm.CreateParameter();
                    TotaalVerhuurdParam.ParameterName = "@TotaalVerhuurd";
                    conAddFilm.Parameters.Add(TotaalVerhuurdParam);

                    conVideoTheek.Open();

                    foreach(Film eenFilm in films)
                    {
                        try
                        {
                            TitelParam.Value = eenFilm.Titel;
                            GenreNrParam.Value = eenFilm.Genre;
                            InVoorraadParam.Value = eenFilm.InVoorraad;
                            UitVoorraadParam.Value = eenFilm.uitVoorraad;
                            PrijsParam.Value = eenFilm.Prijs;
                            TotaalVerhuurdParam.Value = eenFilm.TotaalVerhuurd;
                            if(conAddFilm.ExecuteNonQuery() == 0)
                            {
                                nietToegevoegdeFilms.Add(eenFilm);
                            }
                        }
                        catch(Exception ex)
                        {
                            nietToegevoegdeFilms.Add(eenFilm);
                            MessageBox.Show(ex.Message);
                        }
                    }//Foreach
                }//Using conAddFilm
            }//Using conVideoTheek
            return nietToegevoegdeFilms;
        }
            


    }
}
