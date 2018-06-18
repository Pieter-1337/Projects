using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Collections.Specialized;
using System.Globalization;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DbManagers;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Markup;


namespace Videotheek
{
   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private CollectionViewSource filmViewSource;
        public ObservableCollection<Film>  FilmsOb = new ObservableCollection<Film>();
        public List<Film> OudeFilms = new List<Film>();
        public List<Film> NieuweFilms = new List<Film>();
        public List<Film> GewijzigdeFilms = new List<Film>();
        List<Film> teverwijderen = new List<Film>();
        List<Film> ToeTeVoegen = new List<Film>();
        static bool toevoegenBool = false;
        static bool verwijderenBool = false;

        public MainWindow()
        {
            InitializeComponent();
        }


        //Window LOADED//////////////////////////////////////////////////////////////////////
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                VulDeListBox();
                VulDeComboBox();
      
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       


        //OnCOLLECTIONCHANGED////////////////////////////////////////////////////////////////
        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.OldItems != null)
                {
                    foreach (Film oudeFilm in e.OldItems)
                    {
                        if (!OudeFilms.Contains(oudeFilm))
                        {
                            OudeFilms.Add(oudeFilm);
                        }
                    }
                }

                if(e.NewItems != null)
                {
                    foreach(Film newFilm in e.NewItems)
                    {
                        if (!NieuweFilms.Contains(newFilm))
                        {
                            NieuweFilms.Add(newFilm);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Fout bij het inladen van gegevens in CollectionChanged");
            }
        }


        



        //VULCOMBOBOX/////////////////////////////////////////////////////////////////////////////
        public void VulDeComboBox()
        {
            try
            {
                CollectionViewSource genreViewSource = ((CollectionViewSource)(this.FindResource("genreViewSource")));
                var manager = new GenreManager();
                var GenreOb = new ObservableCollection<Genre>();
                GenreOb = manager.GetAlleGenres();
                genreViewSource.Source = GenreOb;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //VULDELISTBOX///////////////////////////////////////////////////////////////////////
        public void VulDeListBox()
        {
            try
            {
                CollectionViewSource filmViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("filmViewSource")));
                var manager = new FilmsManager();

                FilmsOb = manager.GetAlleFilms();
                filmViewSource.Source = FilmsOb;
                FilmsOb.CollectionChanged += this.OnCollectionChanged;

            }
            catch (Exception ex)
            {

            }
        }


        //LISTBOX CHANGED ////////////////////////////////////////////////////
        public void FilmListBox_Changed(object sender ,SelectionChangedEventArgs e)
        {
            try
            {
            
                string GenreNr = "";
                foreach (Film film in filmListBox.Items)
                {
                    if (film.BandNr.ToString() == BandNrTextBox.Text.ToString())
                    {
                        GenreNr = Convert.ToString(film.Genre);
                    }
                }

                //string genreNaam = manager.getSelectedGenre(GenreNr);
                foreach (Genre genre in GenreComboBox.Items)
                {
                    if (genre.GenreNr == Convert.ToInt32(GenreNr))
                    {
                        GenreComboBox.SelectedItem = genre;
                    }
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show("Geeft een fout niet belangrijk mag genegeerd worden");
            }
        }


        //VERWIJDER FILM CLICK//////////////////////////////////////////////////////////////////
        public void VerwijderFilm_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonVerwijderen.Content.ToString() == "Verwijderen")
            {

                if (MessageBox.Show("Bent u zeker dat u deze Film: " + TitelTextbox.Text.ToString() + "\n wenst te verwijderen?", "verwijderen", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    //foreach (Film film in teverwijderen)
                    //{
                    //    if (film.Titel.ToString().Trim(' ').ToLower() == TitelTextbox.Text.ToString().Trim(' ').ToLower())
                    //    {
                    //        MessageBox.Show("Deze film werd reeds verwijderd!");
                    //        return;
                    //    }

                    //}

                    foreach (Film eenfilm in FilmsOb)
                    {
                        if (eenfilm.Titel.ToString().Trim(' ').ToLower() == TitelTextbox.Text.ToString().Trim(' ').ToLower())
                        {
                            teverwijderen.Add(eenfilm);
                        }
                    }

                    foreach (Film film in teverwijderen)
                    {
                        FilmsOb.Remove(film);
                        if (NieuweFilms.Contains(film))
                        {
                            NieuweFilms.Remove(film);
                        }

                    }

                }
            }
            else
            {
                try { 
                        ButtonToevoegen.Content = "Toevoegen";
                        ButtonVerwijderen.Content = "Verwijderen";

                        DislayForm.Visibility = Visibility.Visible;
                        ToevoegenForm.Visibility = Visibility.Collapsed;

                        ButtonOpslaan.IsEnabled = true;
                        ButtonVerhuur.IsEnabled = true;

                        filmListBox.IsEnabled = true;


                        //Set het Genre weer naar de geselecteerde film in de Listbox
                        string GenreNr = "";
                        foreach (Film film in filmListBox.Items)
                        {
                            if (film.BandNr.ToString() == BandNrTextBox.Text.ToString())
                            {
                                GenreNr = Convert.ToString(film.Genre);
                            }
                        }

                        //string genreNaam = manager.getSelectedGenre(GenreNr);
                        foreach (Genre genre in GenreComboBox.Items)
                        {
                            if (genre.GenreNr == Convert.ToInt32(GenreNr))
                            {
                                GenreComboBox.SelectedItem = genre;
                            }
                        }
                }
                catch (Exception ex)
                {

                }
            }
            
        }


        //TOEVEOGEN BUTTON///////////////////////////////////////////////////////////////////
        public void ToevoegenButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(ButtonToevoegen.Content.ToString() == "Toevoegen")
                {
                    ButtonToevoegen.Content = "Bevestigen";
                    ButtonVerwijderen.Content = "Annuleren";
                    DislayForm.Visibility = Visibility.Collapsed;
                    ToevoegenForm.Visibility = Visibility.Visible;

                   
                    ButtonOpslaan.IsEnabled = false;
                    ButtonVerhuur.IsEnabled = false;
                    filmListBox.IsEnabled = false;

                    GenreComboBox2.SelectedItem = GenreComboBox2.Items[0];

                }
                else
                {


                    if (Validation.GetHasError(TitelTextbox2) == true || Validation.GetHasError(InvoorraadTextBo2) == true || Validation.GetHasError(UitVoorraadTextBox) == true || Validation.GetHasError(PrijsTextBox2) == true || Validation.GetHasError(TotaalVerhuurdTextBox2) == true)
                    {
                        MessageBox.Show("Gelieve alle velden correct in te vullen", "Validatie", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return;
                    }

                    foreach(Film film in FilmsOb)
                    {
                        string film1 = film.Titel.Trim(' ').ToLower();
                        string film2 = TitelTextbox2.Text.Trim(' ').ToLower();
                        if(film1 == film2)
                        {
                            MessageBox.Show("Deze film zit reeds in de database");
                            
                            return;
                            
                        }      
                    }

                    
                    Film NieuweFilm = new Film();
                    NieuweFilm.Titel = TitelTextbox2.Text.ToString();
                    NieuweFilm.InVoorraad = Convert.ToInt32(InvoorraadTextBo2.Text.ToString());
                    NieuweFilm.uitVoorraad = Convert.ToInt32(UitVoorraadTextBox2.Text.ToString());
                    NieuweFilm.Genre = Convert.ToInt32(GenreComboBox2.SelectedValue.ToString());
                    NieuweFilm.Prijs = Convert.ToDecimal(PrijsTextBox2.Text.ToString());
                    NieuweFilm.TotaalVerhuurd = Convert.ToInt32(TotaalVerhuurdTextBox2.Text.ToString());

                    FilmsOb.Add(NieuweFilm);
                          
                    ButtonToevoegen.Content = "Toevoegen";
                    ButtonVerwijderen.Content = "Verwijderen";

                    DislayForm.Visibility = Visibility.Visible;
                    ToevoegenForm.Visibility = Visibility.Collapsed;

                    ButtonOpslaan.IsEnabled = true;
                    ButtonVerhuur.IsEnabled = true;
                   
                    filmListBox.IsEnabled = true;


                    //Set het Genre weer naar de geselecteerde film in de Listbox
                    string GenreNr = "";
                    foreach (Film film in filmListBox.Items)
                    {
                        if (film.BandNr.ToString() == BandNrTextBox.Text.ToString())
                        {
                            GenreNr = Convert.ToString(film.Genre);
                        }
                    }

                    //string genreNaam = manager.getSelectedGenre(GenreNr);
                    foreach (Genre genre in GenreComboBox.Items)
                    {
                        if (genre.GenreNr == Convert.ToInt32(GenreNr))
                        {
                            GenreComboBox.SelectedItem = genre;
                        }
                    }
                }   
            }
            catch(Exception ex)
            {
                MessageBox.Show("Fout bij het generen van AddMovieForm" + ex.Message);
            }
        }

        //Verhuur Film////////////////////////////////////////////////////////////
        public void VerhuurFilm_Click(object sender, RoutedEventArgs e)
        {
            try {
                foreach (Film eenFilm in FilmsOb)
                {
                    string GekozenFilmTitel = TitelTextbox.Text.ToString().Trim().ToLower();
                    string eenFilmTitel = eenFilm.Titel.ToString().Trim().ToLower();
                    if (GekozenFilmTitel == eenFilmTitel)
                    {
                        
                        if (eenFilm.InVoorraad > 0)
                        {
                            eenFilm.InVoorraad--;
                            eenFilm.uitVoorraad++;
                            eenFilm.TotaalVerhuurd++;
                            GewijzigdeFilms.Add(eenFilm);
                            if(filmListBox.SelectedIndex == filmListBox.Items.Count - 1)
                            {
                                filmListBox.SelectedIndex--;
                                filmListBox.SelectedIndex++;
                            }
                            else
                            {
                                filmListBox.SelectedIndex++;
                                filmListBox.SelectedIndex--;
                            }
                            break;
                        }
                        else
                        {
                            throw new Exception("Je kan deze film niet huren de voorraad is 0");
                        }
                    }
                   
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
       
        }


        //BUTTONSAVE///////////////////////////////////////////////////////////////
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bent u zeker dat u alles wenst weg te schrijven naar de database?", "Database", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {

                StringBuilder boodschap = new StringBuilder();
                List<Film> resultaatFilms = new List<Film>();
                var manager = new FilmsManager();


                foreach (Film eenfilm in FilmsOb)
                {
                    if (eenfilm.changed)
                    {

                        eenfilm.changed = false;
                    }
                }

                if (GewijzigdeFilms.Count() != 0)
                {

                    resultaatFilms = manager.SchrijfWijzigingen(GewijzigdeFilms);
                    if (resultaatFilms.Count > 0)
                    {
                        boodschap.Append("\n Niet gewijzigd: \n");
                        foreach (var film in resultaatFilms)
                        {
                            boodschap.Append("Titel: " + film.Titel + "\n");
                        }
                    }
                    else
                    {
                        boodschap.Append(GewijzigdeFilms.Count - resultaatFilms.Count + " films gewijzigd \n");
                    }
                }

                if (NieuweFilms.Count() != 0)
                {
                    resultaatFilms = manager.SchrijfToevoegingen(NieuweFilms);
                    if (resultaatFilms.Count > 0)
                    {
                        boodschap.Append("\n Niet toegevoegd: \n");
                        foreach (var film in resultaatFilms)
                        {
                            boodschap.Append("Titel: " + film.Titel + "\n");
                        }
                    }
                    else
                    {
                        boodschap.Append(NieuweFilms.Count - resultaatFilms.Count + " films toegevoegd \n");
                    }


                }

                if (OudeFilms.Count() != 0)
                {
                    resultaatFilms = manager.SchrijfVerwijderingen(OudeFilms);
                    if (resultaatFilms.Count > 0)
                    {

                        boodschap.Append("Niet verwijderd: \n");
                        foreach (var film in resultaatFilms)
                        {
                            boodschap.Append("Bandnr: " + film.BandNr + " Titel: " + film.Titel + "\n");
                        }
                    }
                    else
                    {
                        boodschap.Append(OudeFilms.Count - resultaatFilms.Count + " films verwijderd \n");
                    }
                }

                VulDeListBox();
                VulDeComboBox();

                boodschap.Append("\n Verwijderde film(s): ");
                foreach (Film film in teverwijderen)
                {
                    boodschap.Append("\n " + film.Titel.ToString());
                }
                boodschap.Append("\n Toegevoegde film(s): ");
                foreach (Film film in NieuweFilms)
                {
                    boodschap.Append("\n " + film.Titel.ToString());
                }
                boodschap.Append("\n Gewijzigde film(s): ");
                foreach (Film film in GewijzigdeFilms)
                {
                    boodschap.Append("\n " + film.Titel.ToString());
                }
                MessageBox.Show(boodschap.ToString(), "info", MessageBoxButton.OK);
                OudeFilms.Clear();
                NieuweFilms.Clear();
                GewijzigdeFilms.Clear();
                teverwijderen.Clear();
                ToeTeVoegen.Clear();
            }
          
        }
    }
}
