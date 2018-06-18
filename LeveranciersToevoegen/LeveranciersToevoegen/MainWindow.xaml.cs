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
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Common;
using DbManagers;
using System.Text.RegularExpressions;


namespace LeveranciersToevoegen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EindejaarsKorting_Click(object sender, RoutedEventArgs e)
        {
            var manager = new PlantenManager();
            //manager.EindejaarsKortingPlanten();
            MessageLabel.Content = "Prijzen zijn geupdatet, aantal gewijzigde prijzen:" + manager.EindejaarsKortingPlanten().ToString();

        }

        private void AddLeverancier_Click(object sender, RoutedEventArgs e)
        {
            string Naam = NaamTxtBox.Text.ToString();
            string Adres = AdresTxtBox.Text.ToString();
            string Postcode = PostcodeTxtBox.Text.ToString();
            string Plaats = PlaatsTxtBox.Text.ToString();
            string ValidatieMessage = "";
            Regex PostcodeRegex = new Regex(@"^\d{4}$");

            if(Naam == "")
            {
                ValidatieMessage += "Gelieve een Naam in te vullen \n";
            }
            if(Adres == "")
            {
                ValidatieMessage += "Gelieve een Adres in te vullen \n";
            }
            if(!PostcodeRegex.IsMatch(Postcode))
            {
                ValidatieMessage += "Gelieve een geldige Postcode in te vullen \n";
            }
            if(Plaats == "")
            {
                ValidatieMessage += "Gelieve een Plaats in te vullen \n";
            }

            if(ValidatieMessage == "")
            {
                try
                {
                    var manager = new LeveranciersManager();
                    Leverancier eenLeverancier = new Leverancier(Naam, Adres, Postcode, Plaats);
                    MessageLabel.Content = "KlantNummer van nieuwe klant: " + manager.AddLeverancier(eenLeverancier);
                    //MessageBox.Show(" Nieuwe leverancier Toegevoegd", "Toevoegen Leverancier", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                     
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error bij Toevoegen van leverancier aan database" + ex.Message, "Db Connect error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                  
            }
            else
            {
                MessageBox.Show(ValidatieMessage, "Form", MessageBoxButton.OK);
            }
        }

        private void VerwisselPlantenVanLeverancier_Click(object sender, RoutedEventArgs e)
        {
            string LeveranciersNummer1 = LeveranciersNummerTeVervangen.Text.ToString();
            string LeveranciersNummer2 = LeveranciersNummer2TeVervangen.Text.ToString();

            bool resultParse = int.TryParse(LeveranciersNummer1, out int result) && int.TryParse(LeveranciersNummer2, out int result2);

            if (resultParse)
            {
                try
                {
                    var manager = new LeveranciersManager();
                    if(manager.VervangPlantenVanLeverancier(LeveranciersNummer1, LeveranciersNummer2))
                    {
                        MessageBox.Show($"Planten zijn verwisseld van Leveranciers Nummer: {LeveranciersNummer1} naar Leveranciers Nummer: {LeveranciersNummer2}");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Fout bij het overzetten van planten van de ene leverancier naar de andere: " + ex.Message, "DbError", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Gelieve 2 geldige Leveranciersnummers in te geven.", "LevNummer error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void GemiddeldeKostprijsSoort_Click(object sender, RoutedEventArgs e)
        {
            string Soort = GemiddeldeKostprijsTextBox.Text.ToString();
            try
            {
                var manager = new PlantenManager();
                GemiddeldeKostprijsLabel.Content = $"Gemiddelde kostprijs van de soort: {Soort} €" + manager.GemiddeldeKostprijsSoort(Soort);         
            }
            catch (Exception ex)
            {
                GemiddeldeKostprijsLabel.Content = ex.Message;
            }

        }

        private void ZoekPlantNr_Click(object sender, RoutedEventArgs e)
        {
            string PlantNr = ZoekPlantNrTextbox.Text.ToString();
            try
            {
                var manager = new PlantenManager();
                var info = manager.GetPlantInfoByPlantNr(PlantNr);
                NaamLabel.Content = info.PlantNaam.ToString();
                SoortLabel.Content = info.PlantSoort.ToString();
                LeverancierLabel.Content = info.Leverancier.ToString();
                KleurLabel.Content = info.Kleur.ToString();
                KostprijsLabel.Content = "€ " + info.Kostprijs.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var manager = new PlantenManager();
                SoortenBox.ItemsSource = manager.GetSoorten();
                SoortenBox.SelectedValuePath = "SoortNr";
                SoortenBox.DisplayMemberPath = "SoortNaam";
                SoortenBox.SelectedItem = SoortenBox.Items[0];

                PlantenLijst.Items.Clear();
                int soortNr = Convert.ToInt32(SoortenBox.SelectedValue);
                var allePlanten = manager.GetPlanten(soortNr);

                foreach (var plant in allePlanten)
                {
                    PlantenLijst.Items.Add(plant);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            System.Windows.Data.CollectionViewSource plantViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("plantViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // plantViewSource.Source = [generic data source]
        }

        private void ComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var manager = new PlantenManager();

                PlantenLijst.Items.Clear();
                int soortNr = Convert.ToInt32(SoortenBox.SelectedValue);
                var allePlanten = manager.GetPlanten(soortNr);

                foreach (var plant in allePlanten)
                {
                    PlantenLijst.Items.Add(plant);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SelectionPlant_Changed(object sender, SelectionChangedEventArgs e)
        {

            if(PlantenLijst.Items.Count != 0)
            {
                try
                {
                    var manager = new PlantenManager();
                    string plantNaam = PlantenLijst.SelectedValue.ToString();
                    Plant plant = manager.GetPlantInfo(plantNaam);

                    PlantNummerTextBox.Text = plant.PlantNummer.ToString();
                    LeverancierTextBox.Text = plant.Leverancier.ToString();
                    KleurTextBox.Text = plant.Kleur.ToString();
                    PrijsTextbox.Text = plant.Kostprijs.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
         
        }


      

        private void TextBox_OnChanged(object sender, TextChangedEventArgs e)
        {

            try
            {
                if (KleurTextBox.Text.ToString() == string.Empty)
                {

                    KleurErrorTextBlock.Text = "Veld moet ingevuld zijn";
                    KleurErrorTextBlock.Foreground = Brushes.Red;

                }
                else
                {
                    KleurErrorTextBlock.Text = "";
                    

                }

                if (string.IsNullOrEmpty(PrijsTextbox.Text))
                {
                    PrijsErrorTextBlock.Text = "Veld moet ingevuld zijn";
                    PrijsErrorTextBlock.Foreground = Brushes.Red;
                }
                else
                {

                    Double number;
                    bool result = Double.TryParse(PrijsTextbox.Text.ToString(), out number);
                    if (result)
                    {
                        if (number <= 0.00)
                        {
                            PrijsErrorTextBlock.Text = "Prijs moet groter dan 0 zijn";
                            PrijsErrorTextBlock.Foreground = Brushes.Red;
                        }
                        else
                        {
                            PrijsErrorTextBlock.Text = "";
                            
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error bij het valideren van de gegevens! " + ex.Message, "Validatie error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SavePlant_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (KleurErrorTextBlock.Text == "" && PrijsErrorTextBlock.Text == "")
                {
                    string kleur = KleurTextBox.Text;
                    string prijs = PrijsTextbox.Text;
                    string naam = PlantenLijst.SelectedItem.ToString();

                    var manager = new PlantenManager();
                    Plant plant = manager.SavePlant(naam, kleur, prijs);

                    PlantNummerTextBox.Text = plant.PlantNummer.ToString();
                    LeverancierTextBox.Text = plant.Leverancier.ToString();
                    KleurTextBox.Text = plant.Kleur.ToString();
                    PrijsTextbox.Text = plant.Kostprijs.ToString();

                    MessageBox.Show("Wijzigingen opgeslaan", "Wijzigingen", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Gelieve eerst alle velden correct in te vullen");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fout bij het opslaan van de gegevens naar de database" + ex.Message, "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
