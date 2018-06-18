using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DbManagers;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace LeveranciersOverview
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private CollectionViewSource leverancierViewSource;
        public ObservableCollection<Leverancier> LeverancierOb = new ObservableCollection<Leverancier>();
        public List<Leverancier> OudeLeveranciers = new List<Leverancier>();
        public List<Leverancier> NieuweLeveranciers = new List<Leverancier>();
        public List<Leverancier> GewijzigdeLeveranciers = new List<Leverancier>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                VulDeGrid();

                //Add de Postcodes dynamisch zodat ze de Collection view source volgen
                var Postcodes = (from l in LeverancierOb orderby l.Postcode select l.Postcode.ToString()).Distinct().ToList();
                Postcodes.Insert(0, "Alles");
                postcodeComboBox.ItemsSource = Postcodes;
                postcodeComboBox.SelectedIndex = 0;
                // Load data by setting the CollectionViewSource.Source property:
                // leverancierViewSource.Source = [generic data source]
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void VulDeGrid()
        {
            try
            {

                leverancierViewSource = ((CollectionViewSource)(this.FindResource("leverancierViewSource")));
                var manager = new LeveranciersManager();
                LeverancierOb = new ObservableCollection<Leverancier>();
                if (postcodeComboBox.Items.Count > 0)
                {
                    LeverancierOb = manager.GetLeveranciersOpPostcode(postcodeComboBox.SelectedItem.ToString());
                }
                else
                {
                    LeverancierOb = manager.GetLeveranciersOpPostcode("Alles");
                }
                leverancierViewSource.Source = LeverancierOb;

                //Telkens de Observable collection LeverancierdOb veranderd zal the functie OnCollectionChanged updaten
                LeverancierOb.CollectionChanged += this.OnCollectionChanged;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


  
        public void PostcodeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VulDeGrid();
        }


        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //Wanneer een item verwijderd wordt uit de viewsource (Datagrid) wordt deze toegevoegd aan OldItems en nadien in een List Oude... geAdd
            if(e.OldItems != null)
            {
                foreach(Leverancier oudeLeverancier in e.OldItems)
                {
                    OudeLeveranciers.Add(oudeLeverancier);
                }
            }

            //Wanneer een item toegevoegd wordt aan de viewsource (Datagrid) wordt deze toegevoegd aan NewItems en nadien in een List Nieuwe... geAdd
            if (e.NewItems != null)
            {
                foreach(Leverancier nieuweLeverancier in e.NewItems)
                {
                    NieuweLeveranciers.Add(nieuweLeverancier);
                }
            }

            
        }

        public void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            List<Leverancier> resultaatLeveranciers = new List<Leverancier>();
            var manager = new LeveranciersManager();
            StringBuilder boodschap = new StringBuilder();

            if (OudeLeveranciers.Count() != 0)
            {
                resultaatLeveranciers = manager.SchrijfVerwijderingen(OudeLeveranciers);
                if(resultaatLeveranciers.Count > 0)
                {
                    
                    boodschap.Append("Niet verwijderd: \n");
                    foreach(var leverancier in resultaatLeveranciers)
                    {
                        boodschap.Append("Leverancier: " + leverancier.Naam + " LevNr: " + leverancier.LevNr + "\n");
                    }
                    //MessageBox.Show(boodschap.ToString());
                }
                else
                {
                    boodschap.Append(OudeLeveranciers.Count - resultaatLeveranciers.Count + " leverancier(s) verwijderd \n");
                }
            }

            if(NieuweLeveranciers.Count() != 0)
            {
                resultaatLeveranciers = manager.SchrijfToevoegingen(NieuweLeveranciers);
                if(resultaatLeveranciers.Count > 0)
                {
                    boodschap.Append("\n");
                    boodschap.Append("Niet toegevoegd: \n");
                    foreach(var leverancier in resultaatLeveranciers)
                    {
                        boodschap.Append("Leverancier: " + leverancier.Naam + " LevNr: " + leverancier.LevNr + "\n");
                    }
                }
                else
                {
                    boodschap.Append(NieuweLeveranciers.Count - resultaatLeveranciers.Count + " leverancier(s) toegevoegd \n");
                }
            }

           foreach(Leverancier eenLeverancier in LeverancierOb)
           {
                if((eenLeverancier.Changed == true) && (eenLeverancier.LevNr != 0))
                {
                    GewijzigdeLeveranciers.Add(eenLeverancier);
                    eenLeverancier.Changed = false;
                }
           }
            resultaatLeveranciers.Clear();
            if(GewijzigdeLeveranciers.Count() != 0)
            {
                resultaatLeveranciers = manager.SchrijfWijzigingen(GewijzigdeLeveranciers);
                if(resultaatLeveranciers.Count > 0)
                {
                    boodschap.Append("\n");
                    boodschap.Append("Niet gewijzigd: \n");
                    foreach(var leverancier in resultaatLeveranciers)
                    {
                        boodschap.Append("Leverancier: " + leverancier.Naam + " LevNr: " + leverancier.LevNr + "\n");
                    }
                }
                else
                {
                    boodschap.Append(GewijzigdeLeveranciers.Count - resultaatLeveranciers.Count + " leverancier(s) aangepast \n");
                }
            }


            
            VulDeGrid();
            OudeLeveranciers.Clear();
            NieuweLeveranciers.Clear();
            GewijzigdeLeveranciers.Clear();

            MessageBox.Show(boodschap.ToString(), "info", MessageBoxButton.OK);
        }
    }
}
