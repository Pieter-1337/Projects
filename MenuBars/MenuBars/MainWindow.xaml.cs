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
using System.ComponentModel;
using Microsoft.Win32;
using System.IO;


namespace MenuBars
{
    /// <summary>
    /// Interaction logic for BarWindow.xaml
    /// </summary>
    public partial class BarWindow : Window
    {
        public static RoutedCommand mijnRouteCtrlB = new RoutedCommand();
        public static RoutedCommand mijnRouteCtrlI = new RoutedCommand();

        public BarWindow()
        {
            InitializeComponent();

            CommandBinding mijnCtrlB = new CommandBinding(mijnRouteCtrlB, ctrlBExecuted);
            this.CommandBindings.Add(mijnCtrlB);
            KeyGesture toetsCtrlB = new KeyGesture(Key.B, ModifierKeys.Control);
            KeyBinding mijnKeyCtrlB = new KeyBinding(mijnRouteCtrlB, toetsCtrlB);
            this.InputBindings.Add(mijnKeyCtrlB);

            CommandBinding mijnCtrlI = new CommandBinding(mijnRouteCtrlI, ctrlIExecuted);
            this.CommandBindings.Add(mijnCtrlI);
            KeyGesture toetsCtrlI = new KeyGesture(Key.I, ModifierKeys.Control);
            KeyBinding mijnKeyCtrlI = new KeyBinding(mijnRouteCtrlI, toetsCtrlI);
            this.InputBindings.Add(mijnKeyCtrlI);

            LettertypeComboBox.Items.SortDescriptions.Add(new SortDescription("Source", ListSortDirection.Ascending));
            LettertypeComboBox.SelectedItem = new FontFamily(TextBoxVoorbeeld.FontFamily.ToString());
        }

        private void Bold_On_Off()
        {
            if (TextBoxVoorbeeld.FontWeight == FontWeights.Normal)
            {
                TextBoxVoorbeeld.FontWeight = FontWeights.Bold;
                Bold.IsChecked = true;
                BoldButton.IsChecked = true;
                StatusBold.Content = "Bold";

            }
            else
            {
                TextBoxVoorbeeld.FontWeight = FontWeights.Normal;
                Bold.IsChecked = false;
                BoldButton.IsChecked = false;
                StatusBold.Content = "";
            }
        }

        private void Italic_On_Off()
        {
            if (TextBoxVoorbeeld.FontStyle == FontStyles.Normal)
            {
                TextBoxVoorbeeld.FontStyle = FontStyles.Italic;
                Italic.IsChecked = true;
                ItalicButton.IsChecked = true;
                StatusItalic.Content = "Italic";
                
            }
            else
            {
                TextBoxVoorbeeld.FontStyle = FontStyles.Normal;
                Italic.IsChecked = false;
                ItalicButton.IsChecked = false;
                StatusItalic.Content = "";
            }
        }

        private void ctrlBExecuted(object sender, RoutedEventArgs e)
        {
            Bold_On_Off();
        }

        private void ctrlIExecuted(object sender, RoutedEventArgs e)
        {
            Italic_On_Off();
        }

        private void Bold_Click(object sender, RoutedEventArgs e)
        {
            Bold_On_Off();
        }

        private void Italic_Click(object sender, RoutedEventArgs e)
        {
            Italic_On_Off();
        }

        private void Lettertype_On_Off(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.MenuItem hetLettertype = (System.Windows.Controls.MenuItem)sender;
            foreach(System.Windows.Controls.MenuItem lettertype in Fonts.Items)
            {
                lettertype.IsChecked = false;
            }
            hetLettertype.IsChecked = true;
            LettertypeComboBox.SelectedItem = new FontFamily(hetLettertype.Header.ToString());

        }

        private void LettertypeComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            foreach(System.Windows.Controls.MenuItem lettertype in Fonts.Items)
            {
                if(LettertypeComboBox.SelectedItem.ToString() == lettertype.Header.ToString())
                {
                    lettertype.IsChecked = true;
                }
                else
                {
                    lettertype.IsChecked = false;
                }
            }
        }

        private void SaveExecuted(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = "Document";
                dlg.DefaultExt = ".txt";
                dlg.Filter = "Text document |*.txt*";

                if(dlg.ShowDialog() == true)
                {
                    using (StreamWriter bestand = new StreamWriter(dlg.FileName))
                    {
                        bestand.WriteLine(LettertypeComboBox.SelectedValue);
                        bestand.WriteLine(TextBoxVoorbeeld.FontWeight.ToString());
                        bestand.WriteLine(TextBoxVoorbeeld.FontStyle.ToString());
                        bestand.WriteLine(TextBoxVoorbeeld.Text);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Opslaan Mislukt : " + ex.Message, "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.FileName = "Document";
                dlg.DefaultExt = ".txt";
                dlg.Filter = "Text Document |*.txt*";

                if(dlg.ShowDialog() == true)
                {
                    using(StreamReader bestand = new StreamReader(dlg.FileName))
                    {
                        LettertypeComboBox.SelectedValue = new FontFamily(bestand.ReadLine());

                        TypeConverter convertBold = TypeDescriptor.GetConverter(typeof(FontWeight));
                        TextBoxVoorbeeld.FontWeight = (FontWeight)convertBold.ConvertFromString(bestand.ReadLine());
                        if(TextBoxVoorbeeld.FontWeight.ToString() == "Normal")
                        {
                            Bold.IsChecked = false;
                            BoldButton.IsChecked = false;
                            StatusBold.Content = "";
                        }
                        else
                        {
                            Bold.IsChecked = true;
                            BoldButton.IsChecked = true;
                            StatusBold.Content = "Bold";
                        }

                        TypeConverter convertStyle = TypeDescriptor.GetConverter(typeof(FontStyle));
                        TextBoxVoorbeeld.FontStyle = (FontStyle)convertStyle.ConvertFromString(bestand.ReadLine());
                        if (TextBoxVoorbeeld.FontStyle.ToString() == "Normal")
                        {
                            Italic.IsChecked = false;
                            ItalicButton.IsChecked = false;
                            StatusItalic.Content = "";
                        }
                        else
                        {
                            Italic.IsChecked = true;
                            ItalicButton.IsChecked = true;
                            StatusItalic.Content = "Italic";
                        }

                        TextBoxVoorbeeld.Text = bestand.ReadLine();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Openen bestand mislukt" + ex.Message, "Error openen bestand", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Fixed document voor printing met vars
        private double A4Breedte = 21 / 2.54 * 96;
        private double A4Hoogte = 29.7 / 2.54 * 96;
        private double vertPositie;

        private FixedDocument StelAfdrukSamen()
        {
            FixedDocument document = new FixedDocument();
            document.DocumentPaginator.PageSize = new System.Windows.Size(A4Breedte, A4Hoogte);

            PageContent inhoud = new PageContent();
            document.Pages.Add(inhoud);
            
            FixedPage page = new FixedPage();
            inhoud.Child = page;

            page.Width = A4Breedte;
            page.Height = A4Hoogte;
            vertPositie = 96;

            page.Children.Add(Regel("Gebruikte lettertype: " + TextBoxVoorbeeld.FontFamily.ToString()));
            page.Children.Add(Regel("Gewicht van het lettertype: " + TextBoxVoorbeeld.FontWeight.ToString()));
            page.Children.Add(Regel("Stijl van het lettertype: " + TextBoxVoorbeeld.FontStyle.ToString()));
            page.Children.Add(Regel(" "));
            page.Children.Add(Regel("inhoud van de tekstbox: "));

            for (int i = 0; i < TextBoxVoorbeeld.LineCount; i++)
            {
                page.Children.Add(Regel(TextBoxVoorbeeld.GetLineText(i)));
            }
            return document;
        }

        private TextBlock Regel(string tekst)
        {
            TextBlock deRegel = new TextBlock();
            deRegel.Text = tekst;
            deRegel.FontSize = TextBoxVoorbeeld.FontSize;
            deRegel.FontFamily = TextBoxVoorbeeld.FontFamily;
            deRegel.FontWeight = TextBoxVoorbeeld.FontWeight;
            deRegel.FontStyle = TextBoxVoorbeeld.FontStyle;
            deRegel.Margin = new Thickness(96, vertPositie, 96, 96);
            vertPositie += 30;
            return deRegel;
        }

        private void PrintExecuted(object sender, RoutedEventArgs e)
        {
            PrintDialog afdrukken = new PrintDialog();
            if(afdrukken.ShowDialog() == true)
            {
                afdrukken.PrintDocument(StelAfdrukSamen().DocumentPaginator, "tekstbox");
            }
        }

        private void PreviewExecuted(object sender, RoutedEventArgs e)
        {
            Afdrukvoorbeeld preview = new Afdrukvoorbeeld();
            preview.Owner = this;
            preview.AfdrukDocument = StelAfdrukSamen();
            preview.ShowDialog();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Programma afsluiten?","Afsluiten", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
                
        }

        private void CloseExecuted(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
    }
}
