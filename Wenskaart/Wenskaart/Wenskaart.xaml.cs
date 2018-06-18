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
using System.IO;
using System.ComponentModel;
using Microsoft.Win32;
using System.Reflection;

namespace Wenskaart
{
    /// <summary>
    /// Interaction logic for WenskaartWindow.xaml
    /// </summary>
    public partial class WenskaartWindow : Window
    {
        string RootDirectory = "pack://application:,,,/Wenskaart;component/";
        List<Bal> BallenOpCanvas = new List<Bal>();

        public WenskaartWindow()
        {
            InitializeComponent();
            ImageBrush imgBrushVuilnisbak = new ImageBrush();
            imgBrushVuilnisbak.ImageSource = new BitmapImage(new Uri(RootDirectory + "Images/vuilnisbak.png"));
            Vuilnisbak.Fill = imgBrushVuilnisbak;
            Controls.Visibility = Visibility.Collapsed;

            try
            {
                ComboBoxLetterType.Items.SortDescriptions.Add(new SortDescription("Source", ListSortDirection.Ascending));
                ComboBoxLetterType.SelectedItem = new FontFamily("Arial"); 
            }
            catch(Exception ex)
            {
                MessageBox.Show("Fout bij sorteren van de lettertypes: " + ex.Message, "Font error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

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

                    ComboboxKleur.Items.Add(kleur);

                    if(kleur.Naam == "Black")
                    {
                        ComboboxKleur.SelectedItem = kleur;
                    }
                    if(ComboboxKleur.SelectedItem == null)
                    {
                        ComboboxKleur.SelectedItem = "Black";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fout bij het toevoegen van kleuren aan ComboBox: " + ex.Message, "Error kleuren", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

       private void CloseWindow_Click(object sender, CancelEventArgs e)
        {
            if(MessageBox.Show("Programma afsluiten?", "Afsluiten", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void CommandNew_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            List<UIElement> BallenLijst = new List<UIElement>();
            BallenOpCanvas.Clear();
            Controls.Visibility = Visibility.Collapsed;
            ImageRect.Fill = null;
            canvas.Background = null;

            
                foreach (UIElement bal in canvas.Children)
                {
                    if(bal.GetType() == typeof(Ellipse))
                    {
                    BallenLijst.Add(bal);
                    }
                    
                }

                foreach(UIElement item in BallenLijst)
                {
                canvas.Children.Remove(item);
                }
            

            WensBoodschap.Text = "";
            MenuOpslaan.IsEnabled = false;
            MenuAfdruk.IsEnabled = false;
            StatusLabel.Content = "Nieuw";


        }

        private void CommandOpen_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            BallenOpCanvas.Clear();
            Controls.Visibility = Visibility.Visible;
            int Aantal = 0;
            try
            {
                
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.FileName = "";
                dlg.DefaultExt = ".txt";
                dlg.Filter = "Text Documents |*.txt";

                if(dlg.ShowDialog() == true)
                {
                    using(StreamReader bestand = new StreamReader(dlg.FileName))
                    {
                        //Lees de afbeelding in
                        string ImagePath = bestand.ReadLine();
                        ImageBrush imgBrush = new ImageBrush();
                        imgBrush.ImageSource = new BitmapImage(new Uri(ImagePath));
                        ImageRect.Fill = imgBrush;
                        ImageRect.Tag = ImagePath;
                        //Lees aantal ballen in
                        Aantal = Convert.ToInt32(bestand.ReadLine());


                        //Lees de gegevens van de ballen in
                        for(int i = 0; i < Aantal; i++)
                        {
                            string balKleur = bestand.ReadLine();
                            int xPos = Convert.ToInt32(bestand.ReadLine());
                            int yPos = Convert.ToInt32(bestand.ReadLine());

                            Ellipse bal = new Ellipse();
                            bal.Width = 40;
                            bal.Height = 40;
                            var converter = new System.Windows.Media.BrushConverter();
                            var brush = (Brush)converter.ConvertFromString(balKleur);  
                            bal.Fill = brush;
                            SolidColorBrush black = new SolidColorBrush(Colors.Black);
                            bal.Stroke = black;
                            bal.StrokeThickness = 3;
                            
                            Canvas.SetLeft(bal, xPos - 20);
                            Canvas.SetTop(bal, yPos - 20);
                            canvas.Children.Add(bal);

                            Bal balInLijst = new Bal(balKleur, Convert.ToInt32(xPos), Convert.ToInt32(yPos), "EmptyTag");
                            BallenOpCanvas.Add(balInLijst);


                        }
                        

                        //Lees de tekstboodschap in
                        WensBoodschap.Text = bestand.ReadLine();
                        //Lees de fontFamily in
                        ComboBoxLetterType.SelectedValue = new FontFamily(bestand.ReadLine());
                        //Lees de fontSize in
                        string Fontsize = bestand.ReadLine();
                        FontSizeLabel.Content = Fontsize;
                        WensBoodschap.FontSize = Convert.ToInt32(Fontsize);

                        MenuOpslaan.IsEnabled = true;
                        MenuAfdruk.IsEnabled = true;
                        StatusLabel.Content = dlg.FileName;
                    }
                     
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fout bij het openen van de wenskaart: " + ex.Message, "Openen error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CommandSave_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            int aantal = 0;
            try
            {
                //Path van de achtergrond
                string Documentpath = ImageRect.Tag.ToString();
                
                //Tel het aantal ballen op het canvas
                foreach(UIElement bal in canvas.Children)
                {
                    if (bal.GetType() == typeof(Ellipse))
                    {
                        aantal++;
                    }
                }

                string Wens = WensBoodschap.Text;
                string lettertype = WensBoodschap.FontFamily.ToString();
                string letterGrootte = WensBoodschap.FontSize.ToString(); 

                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = "Wenskaart";
                dlg.DefaultExt = ".txt";
                dlg.Filter = "Text Documents |*.txt";

                if(dlg.ShowDialog() == true)
                {
                    using(StreamWriter bestand = new StreamWriter(dlg.FileName))
                    {
                        //Schrijf document pathweg
                        bestand.WriteLine(Documentpath);
                        //Schrijf aantal ballen weg
                        bestand.WriteLine(aantal);

                        //schrijf de data van de ballen weg
                        foreach(Bal bal in BallenOpCanvas)
                        {
                            bestand.WriteLine(bal.Kleur);
                            bestand.WriteLine(bal.xPos);
                            bestand.WriteLine(bal.yPos);


                        }

                        //Schrijf de tekst weg
                        bestand.WriteLine(Wens);

                        //Schrijf het lettertype weg
                        bestand.WriteLine(lettertype);

                        //Schrijf de letterGrootte weg
                        bestand.WriteLine(letterGrootte);

                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Fout bij het opslaan van de wenskaart: " + ex.Message, "Opslaan error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CommandPrintPreview_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                afdrukvoorbeeld preview = new afdrukvoorbeeld();
                preview.Owner = this;
                preview.AfdrukDocument = StelAfdrukSamen();
                preview.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fout bij het generen van adrukvoorbeeld van de wenskaart: " + ex.Message, "afdruk error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void VerkleinFontSize_Click(object sender, RoutedEventArgs e)
        {
            int Fontint = Convert.ToInt32(FontSizeLabel.Content);
            Fontint--;
            if(Fontint < 10)
            {
                Fontint = 10;
            }
            else
            {
                FontSizeLabel.Content = Convert.ToString(Fontint);
                WensBoodschap.FontSize--;
            }
            
        }

        private void VergrootFontSize_Click(object sender, RoutedEventArgs e)
        {
            int Fontint = Convert.ToInt32(FontSizeLabel.Content);
            Fontint++;
            if(Fontint > 40)
            {
                Fontint = 40;

            }
            else
            {
                FontSizeLabel.Content = Convert.ToString(Fontint);
                WensBoodschap.FontSize++;
            }
            
        }

        private void CommandClose_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void KerstKaart_Click(object sender, RoutedEventArgs e)
        {
            BallenOpCanvas.Clear();
            List<UIElement> BallenLijst = new List<UIElement>();

            Controls.Visibility = Visibility.Visible;
            WensBoodschap.Text = "Prettige Feestdagen!";
            ImageBrush imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(RootDirectory + "Images/kerstkaart.jpg"));
            ImageRect.Fill = imgBrush;
            ImageRect.Tag = RootDirectory + "Images/kerstkaart.jpg";
            MenuOpslaan.IsEnabled = true;
            MenuAfdruk.IsEnabled = true;

            if (canvas.Children.Count > 2)
            {
                foreach (UIElement bal in canvas.Children)
                {
                    if(bal.GetType() == typeof(Ellipse))
                    {
                        BallenLijst.Add(bal);
                    }
                    
                }

                foreach(UIElement item in BallenLijst)
                {
                    canvas.Children.Remove(item);
                }
            }
        }

        private void GeboorteKaart_Click(object sender, RoutedEventArgs e)
        {
            BallenOpCanvas.Clear();
            List<UIElement> BallenLijst = new List<UIElement>();

            Controls.Visibility = Visibility.Visible;
            WensBoodschap.Text = "Proficiat met de geboorte van jullie zoon!";
            ImageBrush imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(RootDirectory + "Images/geboortekaart.jpg"));
            ImageRect.Tag = RootDirectory + "Images/geboortekaart.jpg";
            ImageRect.Fill = imgBrush;
            MenuOpslaan.IsEnabled = true;
            MenuAfdruk.IsEnabled = true;

            if (canvas.Children.Count > 2)
            {
                foreach (UIElement bal in canvas.Children)
                {
                    if (bal.GetType() == typeof(Ellipse))
                    {
                        BallenLijst.Add(bal);
                    }

                }

                foreach(UIElement item in BallenLijst)
                {
                    canvas.Children.Remove(item);
                }
            }
        }

        private Ellipse sleepBal = new Ellipse();
        private void DragBall_Event(object sender, MouseEventArgs e)
        {
            sleepBal = (Ellipse)sender;
            if (!canvas.Children.Contains(sleepBal))
            {
                if ((e.LeftButton == MouseButtonState.Pressed) && (sleepBal.Fill != null))
                {
                    DataObject sleepItem = new DataObject("deKleur", sleepBal.Fill);
                    DragDrop.DoDragDrop(sleepBal, sleepItem, DragDropEffects.Move);
                }
            }
            else
            {
                if ((e.LeftButton == MouseButtonState.Pressed) && (sleepBal.Fill != null))
                {
                    DataObject sleepItemData = new DataObject();
                    sleepItemData.SetData("deKleur", sleepBal.Fill);
                    sleepBal.Tag = "RemoveBalTag";
                    Point coordinaten = e.GetPosition(canvas);
                    sleepItemData.SetData("CoordinatenX", coordinaten.X);
                    sleepItemData.SetData("CoordinatenY", coordinaten.Y);
                    sleepItemData.SetData("Tag", sleepBal.Tag);
                    DragDrop.DoDragDrop(sleepBal, sleepItemData, DragDropEffects.Move);
                    
                }
            }
            
        }

        private void CanvasRemoveBall_Event(object sender, DragEventArgs e)
        {
            List<UIElement> BallenLijstRemove = new List<UIElement>();

            if (e.Data.GetDataPresent("deKleur") && e.Data.GetDataPresent("CoordinatenX") && e.Data.GetDataPresent("CoordinatenY") && e.Data.GetDataPresent("Tag"))
            {
                Brush gesleepteKleur = (Brush)e.Data.GetData("deKleur");
                Double X = (Double)e.Data.GetData("CoordinatenX");
                Double Y = (Double)e.Data.GetData("CoordinatenY");
                string tag = (string)e.Data.GetData("Tag").ToString();
                
                
                Bal bal = new Bal(Convert.ToString(gesleepteKleur), Convert.ToInt32(X), Convert.ToInt32(Y), "RemoveBalTag");
                
                foreach(UIElement removeBal in canvas.Children )
                {
                    //Point coordinaten = e.GetPosition(removeBal);
                    if (bal.xPos == X && bal.yPos == Y && removeBal.GetType() == typeof(Ellipse))
                    {
                        BallenLijstRemove.Add(removeBal);
                    }
                    
                }

                foreach(Ellipse removeBal in BallenLijstRemove)
                {
                    if(bal.Tag == removeBal.Tag)
                    {
                       canvas.Children.Remove(removeBal);
                    }
                   
                }

                BallenLijstRemove.Clear();
            }

            
            MessageBox.Show("test");

        }


        private void CanvasDrop_Event(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("deKleur"))
            {
                Brush gesleepteKleur = (Brush)e.Data.GetData("deKleur");
                Ellipse bal = new Ellipse();
                bal.Width = 40;
                bal.Height = 40;
                bal.Fill = gesleepteKleur;
                SolidColorBrush black = new SolidColorBrush(Colors.Black);
                bal.Stroke = black;
                bal.StrokeThickness = 3;
                Point coordinaten = e.GetPosition(canvas);
                Canvas.SetLeft(bal, coordinaten.X - 20);
                Canvas.SetTop(bal, coordinaten.Y - 20);

                //Add drag event to each bal
                bal.MouseMove += DragBall_Event; 

                canvas.Children.Add(bal);
               

                Bal balInLijst = new Bal(gesleepteKleur.ToString(), Convert.ToInt32(coordinaten.X), Convert.ToInt32(coordinaten.Y), "EmptyTag");
                BallenOpCanvas.Add(balInLijst);      
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
            catch (Exception ex)
            {
                MessageBox.Show("Afdrukvoorbeeld samenstellen mislukt: " + ex.Message);
            }

            return document;
        }

        private Image image()
        {
            //Create new Canvas en sla gebruikt canvas in app op in dit nieuwe canvas
            Canvas Wenskaart = new Canvas();
            Image deImage = new Image();
            try
            {
                Wenskaart = canvas;

                //Create new rectangle waarin de rendersize van de wenskaart meegegeven wordt
                Rect rect = new Rect(Wenskaart.RenderSize);

                //Create new bitmap en bind deze aan de gecreate rectangle
                RenderTargetBitmap rtb = new RenderTargetBitmap((int)rect.Right, 450, 96d, 96d, System.Windows.Media.PixelFormats.Default);
                //Render de bloem op de gecreerde bitmap
                rtb.Render(Wenskaart);

                //Encode de bitmap op een bitmapFrame 
                BitmapEncoder pngEncoder = new PngBitmapEncoder();
                pngEncoder.Frames.Add(BitmapFrame.Create(rtb));

                deImage.Source = rtb;
                deImage.Margin = new Thickness(100, 70, 96, 96);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Afbeelding toevoegen aan afdrukvoorbeeld mislukt: " + ex.Message,"Error afdrukvoorbeeld", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return deImage;
        }



    }
}
