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
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.Win32;
using System.Globalization;
using System.ComponentModel;

namespace FormValidation
{
    /// <summary>
    /// Interaction logic for FormWindow.xaml
    /// </summary>
    public partial class FormWindow : Window
    {
        Regex Naam = new Regex("^[a-zA-Z-\\s]+$");
        Regex Email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        public DateTime Date;


        public FormWindow()
        {
            InitializeComponent();
        }

        private void NewExecuted_Click(object sender, ExecutedRoutedEventArgs e)
        {
            NameBox.Text = "";
            EmailBox.Text = "";
            BirtDatePicker.Text = "";
            AdressBox.Text = "";
            CityBox.Text = "";
        }

        private void SaveExecuted_Click(object sender, ExecutedRoutedEventArgs e)
        {

            if (ValidationData())
            {
                try
                {
                    SaveFileDialog dlg = new SaveFileDialog();
                    dlg.FileName = "User: " + NameBox.Text;
                    dlg.DefaultExt = ".txt";
                    dlg.Filter = "Text documents |*.txt*";

                    if (dlg.ShowDialog() == true)
                    {
                        using (StreamWriter bestand = new StreamWriter(dlg.FileName))
                        {
                            bestand.WriteLine(NameBox.Text);
                            bestand.WriteLine(EmailBox.Text);
                            bestand.WriteLine(BirtDatePicker.SelectedDate.ToString());
                            bestand.WriteLine(AdressBox.Text);
                            bestand.WriteLine(CityBox.Text);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fout bij opslaan bestand" + ex.Message, "Save Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
                    
        }

        private void OpenExecuted_Click(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.FileName = "";
                dlg.DefaultExt = ".txt";
                dlg.Filter = "Text Document|*.txt*";

                if(dlg.ShowDialog() == true)
                {
                    using(StreamReader bestand = new StreamReader(dlg.FileName))
                    {
                        NameBox.Text = bestand.ReadLine();
                        EmailBox.Text = bestand.ReadLine();
                        DateTime Datetime = DateTime.Parse(bestand.ReadLine());
                        BirtDatePicker.SelectedDate = Datetime;
                        AdressBox.Text = bestand.ReadLine();
                        CityBox.Text = bestand.ReadLine();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Fout bij openen bestand" + ex.Message, "Open error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public Boolean ValidationData()
        {
            Boolean Validate = false;

            string FoutieveInfo = "";
            try
            {

                if (!Naam.IsMatch(NameBox.Text))
                {
                    FoutieveInfo += "Gelieve enkel letters of een - te gebruiken bij ingave naam\n";
                    Validate = true;
                }

                if (!Email.IsMatch(EmailBox.Text))
                {
                    FoutieveInfo += "Gelieve een correct email adres in te voeren\n";
                    Validate = true;
                }


                if (!CheckDate(BirtDatePicker.Text))
                {

                    FoutieveInfo += "Gelieve een geldige (18+ vereist) geboortedatum in te geven\n";
                    Validate = true;
                }

                if (AdressBox.Text == string.Empty)
                {
                    FoutieveInfo += "Gelieve een adres in te vullen\n";
                    Validate = true;
                }

                if (CityBox.Text == string.Empty)
                {
                    FoutieveInfo += "Gelieve een stad/gemeente in te vullen\n";
                    Validate = true;
                }

                if (Validate)
                {
                    MessageBox.Show(FoutieveInfo, "Form validation", MessageBoxButton.OK);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ValidationDate(), Gelieve dit te melden aan de beheerder van de applicatie" + ex.Message, "ValidationDate() Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
                 
        }

        private Boolean CheckDate(string Birthdate)
        {
            try
            {
                bool isValid = DateTime.TryParseExact(Birthdate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out Date);
                if (isValid)
                {
                    if (DateTime.Now >= Date.Date)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error CheckDate() gelieve dit te melden aan beheerder van de applicatie" + ex.Message, "Error CheckDate()", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }        
        }

        private void Closing_Click(object sender, CancelEventArgs e)
        {
            if(MessageBox.Show("Bent u zeker dat u het programma wenst af te sluiten?", "Afsluiten", MessageBoxButton.YesNo,MessageBoxImage.Question,MessageBoxResult.Yes) == MessageBoxResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
