using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace ParkingBon
{
    /// <summary>
    /// Interaction logic for ParkingBonWindow.xaml
    /// </summary>
    public partial class ParkingBonWindow : Window
    {
        public ParkingBonWindow()
        {
            
            InitializeComponent();
            Nieuw();   
        }


        private void Nieuw()
        {
            DatumBon.SelectedDate = DateTime.Now;
            AankomstLabelTijd.Content = DateTime.Now.ToLongTimeString();
            TeBetalenLabel.Content = "0 €";
            VertrekLabelTijd.Content = AankomstLabelTijd.Content;
            BonStatus.Content = "Nieuwe Bon";
            SaveEnAfdruk(false);

        }

        private void SaveEnAfdruk(Boolean actief)
        {
            Afdrukvoorbeeld.IsEnabled = actief;
            SaveBon.IsEnabled = actief;
            AfdrukkenBonMenuButton.IsEnabled = actief;
            SaveBonMenuButton.IsEnabled = actief;

        }

        private void NieuwExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Nieuw();
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.FileName = "Document";
                dlg.DefaultExt = ".bon";
                dlg.Filter = "Bon Document |*.bon*";

                if(dlg.ShowDialog() == true)
                {
                    using (StreamReader bestand = new StreamReader(dlg.FileName))
                    {
                        
                        DatumBon.SelectedDate = Convert.ToDateTime(bestand.ReadLine());
                        AankomstLabelTijd.Content = bestand.ReadLine();
                        TeBetalenLabel.Content = bestand.ReadLine();
                        VertrekLabelTijd.Content = bestand.ReadLine();
                    }

                    BonStatus.Content = DatumBon.SelectedDate + "om" + AankomstLabelTijd.Content + dlg.DefaultExt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Openen mislukt: " + ex.Message, "Openen error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                DateTime tijd = (DateTime)DatumBon.SelectedDate;
                dlg.FileName =  tijd.Day.ToString() + "-" + tijd.Month.ToString() + "-" + tijd.Year.ToString() + "om" + AankomstLabelTijd.Content.ToString().Replace(":", "-");
                dlg.DefaultExt = ".bon";
                dlg.Filter = "Bon Document |*.bon*";

                if(dlg.ShowDialog() == true)
                {
                    using (StreamWriter bestand = new StreamWriter(dlg.FileName))
                    {
                        bestand.WriteLine(DatumBon.SelectedDate.ToString());
                        bestand.WriteLine(AankomstLabelTijd.Content);
                        bestand.WriteLine(TeBetalenLabel.Content);
                        bestand.WriteLine(VertrekLabelTijd.Content);
                    }

                    BonStatus.Content = dlg.FileName;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Opslaan mislukt: " + ex.Message, "Opslaan error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Fixed document for printing met vars
        private double BonBreedte = 640;
        private double BonHoogte = 320;
        private double vertPositie = 96;
       
        
        

        private FixedDocument StelAfdrukSamen()
        {
            FixedDocument document = new FixedDocument();
            document.DocumentPaginator.PageSize = new Size(BonBreedte, BonHoogte);

            PageContent inhoud = new PageContent();
            document.Pages.Add(inhoud);

            FixedPage page = new FixedPage();
            inhoud.Child = page;

            page.Width = BonBreedte;
            page.Height = BonHoogte;

            

            page.Children.Add(Afbeelding(logoImage));
            page.Children.Add(Regel("datum: " + DatumBon.Text));
            page.Children.Add(Regel("starttijd: " + AankomstLabelTijd.Content));
            page.Children.Add(Regel("eindtijd: " + VertrekLabelTijd.Content));
            page.Children.Add(Regel("bedrag betaald: " + TeBetalenLabel.Content));

            return document;
        }

        private TextBlock Regel(string tekst)
        {
            TextBlock deRegel = new TextBlock();
            deRegel.Text = tekst;
            deRegel.FontSize = 18;
            deRegel.Margin = new Thickness(300, vertPositie, 96, 96);
            vertPositie += 30;
            return deRegel;
            
        }

        private Image Afbeelding(Image img)
        {
            Image deAfbeelding = new Image();
            deAfbeelding.Source = img.Source;
            deAfbeelding.Margin = new Thickness(96);
            return deAfbeelding;
        }

        private void PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Afdrukvoorbeeld preview = new Afdrukvoorbeeld();
            preview.Owner = this;
            preview.AfdrukDocument = StelAfdrukSamen();
            preview.ShowDialog();
        }

     
        private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Programma afsluiten ?", "Afsluiten", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.No)
                e.Cancel = true;
        }

        private void minder_Click(object sender, RoutedEventArgs e)
        {
            int bedrag = Convert.ToInt32(TeBetalenLabel.Content.ToString().Replace(" €", ""));
            if (bedrag > 0)
                bedrag -= 1;
            TeBetalenLabel.Content = bedrag.ToString() + " €";
            VertrekLabelTijd.Content = Convert.ToDateTime(AankomstLabelTijd.Content).AddHours(0.5 * bedrag).ToLongTimeString();

            if(bedrag == 0)
            {
                SaveEnAfdruk(false);
            }
            else
            {
                SaveEnAfdruk(true);
            }
            
        }

        private void meer_Click(object sender, RoutedEventArgs e)
        {
            int bedrag = Convert.ToInt32(TeBetalenLabel.Content.ToString().Replace(" €", ""));
            DateTime vertrekuur = Convert.ToDateTime(AankomstLabelTijd.Content).AddHours(0.5 * bedrag);
            if (vertrekuur.Hour < 22)
                bedrag += 1;
            TeBetalenLabel.Content = bedrag.ToString() + " €";
            VertrekLabelTijd.Content = Convert.ToDateTime(AankomstLabelTijd.Content).AddHours(0.5 * bedrag).ToLongTimeString();

            if (bedrag == 0)
            {
                SaveEnAfdruk(false);
            }
            else
            {
                SaveEnAfdruk(true);
            }
        }
    }
}

