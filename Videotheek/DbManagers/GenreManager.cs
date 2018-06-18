using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;

namespace DbManagers
{
    public class GenreManager
    {

        public ObservableCollection<Genre> GetAlleGenres()
        {
            ObservableCollection<Genre> Genres = new ObservableCollection<Genre>();
            var DbManager = new VideotheekDbManager();
            try
            {
                using(var conVideoTheek = DbManager.GetConnection())
                {
                    using(var conGenres = conVideoTheek.CreateCommand())
                    {
                        conGenres.CommandType = CommandType.Text;
                        conGenres.CommandText = "Select * From Genres";

                        conVideoTheek.Open();

                        using(var GenreReader = conGenres.ExecuteReader())
                        {
                            Int32 GenreNrPos = GenreReader.GetOrdinal("GenreNr");
                            Int32 GenreNaamPos = GenreReader.GetOrdinal("Genre");

                            while (GenreReader.Read())
                            {
                                Genres.Add(new Genre(GenreReader.GetInt32(GenreNrPos), GenreReader.GetString(GenreNaamPos)));
                            }
                        }//GenreReader
                    }//Using ConGenres
                }//Using ConVideotheek
                return Genres;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        
    }
}
