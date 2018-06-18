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
using System.Reflection;
using System.IO;
using Microsoft.Win32;
using Bloemsamenstelling;

namespace BloemSamenstelling
{
    /// <summary>
    /// Interaction logic for BloemWindow.xaml
    /// </summary>
    public partial class BloemWindow : Window
    {
         public BloemWindow()
        {
            InitializeComponent();

            try
            {
                foreach (PropertyInfo info in typeof(Colors).GetProperties())
                {
                    BrushConverter bc = new BrushConverter();
                    SolidColorBrush deKleur = (SolidColorBrush)bc.ConvertFromString(info.Name);
                    Kleur kleur = new Kleur();
                    kleur.Borstel = deKleur;
                    kleur.Naam = info.Name.ToString();
                    kleur.Hex = deKleur.ToString();
                    kleur.Rood = deKleur.Color.R;
                    kleur.Groen = deKleur.Color.G;
                    kleur.Blauw = deKleur.Color.B;

                    cirkelKaderKleuren.Items.Add(kleur);
                    cirkelsKleuren.Items.Add(kleur);
                    rechthoekenKleuren.Items.Add(kleur);
                    rechthoekKaderKleuren.Items.Add(kleur);

                    if (kleur.Naam == "Black")
                    {
                        cirkelKaderKleuren.SelectedItem = kleur;
                        cirkelsKleuren.SelectedItem = kleur;
                        rechthoekenKleuren.SelectedItem = kleur;
                        rechthoekKaderKleuren.SelectedItem = kleur;
                    }

                    if (cirkelKaderKleuren.SelectedItem == null)
                    {
                        cirkelKaderKleuren.SelectedItem = "Black";
                    }

                }
            }catch(Exception ex)
            {
                MessageBox.Show("Fout bij toevoegen van kleuren : " + ex.Message);
            }
           
        }

        public void SaveExecuted(object sender, RoutedEventArgs e)
        {
           
            try
            {
                    //Create new Canvas en sla gebruikt canvas in app op in dit nieuwe canvas
                    Canvas Bloem = new Canvas();
                    Bloem = FlowerCanvas;

                    //Create new rectangle waarin de rendersize van de bloem meegegeven wordt
                    Rect rect = new Rect(Bloem.RenderSize);
                    
                    //Create new bitmap en bind deze aan de gecreate rectangle
                    RenderTargetBitmap rtb = new RenderTargetBitmap((int)rect.Right, 325, 96d, 96d, System.Windows.Media.PixelFormats.Default);
                    //Render de bloem op de gecreerde bitmap
                    rtb.Render(Bloem);

                    //Encode de bitmap op een bitmapFrame 
                    BitmapEncoder pngEncoder = new PngBitmapEncoder();
                    pngEncoder.Frames.Add(BitmapFrame.Create(rtb));
                

                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = "Bloem";
                dlg.DefaultExt = ".png";
                dlg.Filter = "PNG IMAGES |*.png*";

                if(dlg.ShowDialog() == true)
                {
                    using (var stream = dlg.OpenFile())
                    {
                        //Save naar gewenste locatie
                        pngEncoder.Save(stream);
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Converteren/Opslaan image mislukt : " + ex.Message);
            }
        }

        private double A4breedte = 21 / 2.54 * 96;
        private double A4hoogte = 29.7 / 2.54 * 96;
        private double vertPositie;

        public FixedDocument StelAfdrukSamen()
        {
            FixedDocument document = new FixedDocument();
            try
            {   
                document.DocumentPaginator.PageSize = new System.Windows.Size(A4breedte, A4hoogte);

                PageContent inhoud = new PageContent();
                document.Pages.Add(inhoud);

                FixedPage page = new FixedPage();
                inhoud.Child = page;

                page.Width = A4breedte;
                page.Height = A4hoogte;
                vertPositie = 96;

                page.Children.Add(image());      
            }
            catch(Exception ex)
            {
                MessageBox.Show("Afdrukvoorbeeld samenstellen mislukt: " + ex.Message);
            }

            return document;
        }

        private void PrintExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            afdrukvoorbeeld preview = new afdrukvoorbeeld();
            preview.Owner = this;
            preview.AfdrukDocument = StelAfdrukSamen();
            preview.ShowDialog();
        }

        private Image image()
        {
            //Create new Canvas en sla gebruikt canvas in app op in dit nieuwe canvas
            Canvas Bloem = new Canvas();
            Image deImage = new Image();
            try
            {
                Bloem = FlowerCanvas;

                //Create new rectangle waarin de rendersize van de bloem meegegeven wordt
                Rect rect = new Rect(Bloem.RenderSize);

                //Create new bitmap en bind deze aan de gecreate rectangle
                RenderTargetBitmap rtb = new RenderTargetBitmap((int)rect.Right, 325, 96d, 96d, System.Windows.Media.PixelFormats.Default);
                //Render de bloem op de gecreerde bitmap
                rtb.Render(Bloem);

                //Encode de bitmap op een bitmapFrame 
                BitmapEncoder pngEncoder = new PngBitmapEncoder();
                pngEncoder.Frames.Add(BitmapFrame.Create(rtb));

                deImage.Source = rtb;
                deImage.Margin = new Thickness(100, 50, 96, 96);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Afbeelding toevoegen aan afdrukvoorbeeld mislukt: " + ex.Message);
            }

            return deImage;
        }
    }  
}
