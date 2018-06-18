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


namespace SecretSanta
{
    /// <summary>
    /// Interaction logic for SecretSantaWindow.xaml
    /// </summary>
    public partial class SecretSantaWindow : Window
    {
        public List<string> Namen = new List<string>();
        public List<string> NamenMaakSecretSanta = new List<string>();
        public List<string> Gekocht = new List<string>();
        public List<string> Gekozen = new List<string>();
        public List<string> Koppels = new List<string>();
        public Random r = new Random();
        
        

        public SecretSantaWindow()
        {
            InitializeComponent();
            
        }

        private void AddName_Click(object sender, RoutedEventArgs e)
        {
            
            NamenLijstBox.Items.Clear();
            if (AddNameBox.Text != "")
            {

                if (Namen.Contains(AddNameBox.Text))
                {
                    foreach (string naam in Namen)
                    {
                        NamenLijstBox.Items.Add(naam);
                    }
                    MessageBox.Show("Het is niet mogelijk om dezelfde naam 2 maal in te voeren. Gelieve een andere naam te kiezen", "Dubbel name error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    Namen.Add(AddNameBox.Text);

                    foreach (string naam in Namen)
                    {
                        NamenLijstBox.Items.Add(naam);
                    }
                }    
            }
            else
            {
                foreach (string naam in Namen)
                {
                    NamenLijstBox.Items.Add(naam);
                    
                }
                MessageBox.Show("Gelieve een Naam in te geven", "Error Naam ingave", MessageBoxButton.OK, MessageBoxImage.Warning);
                
            }
            AddNameBox.Text = "";
            AddNameBox.Focus();
        }

        private void RemoveName_Click(object sender, RoutedEventArgs e)
        {
            if(NamenLijstBox.SelectedItem == null)
            {
                MessageBox.Show("Gelieve een naam te selecteren die je wenst te verwijderen!", "Remove name error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                Namen.Remove(NamenLijstBox.SelectedItem.ToString());
                NamenLijstBox.Items.RemoveAt(NamenLijstBox.SelectedIndex);
            }
            
            
        }

        private void MaakSecretSanta_Click(object sender, RoutedEventArgs e)
        {
            Restart:
            Gekocht.Clear();
            Gekozen.Clear();
            Koppels.Clear();
            NamenMaakSecretSanta.Clear();

            if (Namen.Count() == 1)
            {
                MessageBox.Show("Gelieve meer dan 1 naam in te vullen om een secret santa aan te maken", "Namen error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                    
                    GekozenKoppelsListBlock.Items.Clear();

                    foreach (string naam in Namen)
                    {
                        NamenMaakSecretSanta.Add(naam);
                    }

                    foreach (string naam in NamenMaakSecretSanta)
                    {

                        string Naam1 = "";
                        string Naam2 = "";
                        string Koppel = "";
                        int randomNaam = 0;
                        int loopStart = 0;

                        if (!Gekocht.Contains(naam))
                        {
                            Naam1 = naam;
                            Gekocht.Add(Naam1);

                            randomNaam = r.Next(NamenMaakSecretSanta.Count());
                            Naam2 = NamenMaakSecretSanta[randomNaam];

                            while (Naam2 == Naam1 || Gekozen.Contains(Naam2))
                            {
                                if (loopStart > 10)
                                {  
                                    goto Restart;
                                }
                                else
                                {
                                    randomNaam = 0;
                                    randomNaam = r.Next(NamenMaakSecretSanta.Count());
                                    Naam2 = NamenMaakSecretSanta[randomNaam];
                                }

                                loopStart++;
                            }
                            Gekozen.Add(Naam2);

                            Koppel = Naam1 + " koopt voor " + Naam2;
                            Koppels.Add(Koppel);
                        }
                        else
                        {
                            MessageBox.Show("Fout bij het random selecteren van koppels", "Randomizer error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    }

                    foreach (string koppel in Koppels)
                    {
                        GekozenKoppelsListBlock.Items.Add(koppel);
                    }
                
            }
        }
    }
}
