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
using System.ComponentModel; //InotifyPropertyChanged

namespace CardDeck
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<Nummer> NummerLijst = new List<Nummer>();

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                CardSuitListBox.Items.Add(new Soort(Soort.NaamValue.Harten));
                CardSuitListBox.Items.Add(new Soort(Soort.NaamValue.Koeken));
                CardSuitListBox.Items.Add(new Soort(Soort.NaamValue.Pijken));
                CardSuitListBox.Items.Add(new Soort(Soort.NaamValue.Schoppen));

                foreach(string number in Nummer.NaamNumberArr)
                {
                    Nummer nummer = new Nummer(number.ToString());
                    CardNumberListBox.Items.Add(nummer);
                }

                CardSuitListBox.SelectedItem = CardSuitListBox.Items[0];
                CardNumberListBox.SelectedItem = CardNumberListBox.Items[0];

                
                foreach(Nummer item in CardNumberListBox.Items)
                {
                    NummerLijst.Add(item);
                }

                   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fout bij inladen Soort en nummers in MainWindow.Xaml.cs" + ex.Message, "Loading Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ChangedComboBox(object sender, SelectionChangedEventArgs e)
        {

            if (CardSuitListBox.SelectedItem == CardSuitListBox.Items[0] || CardSuitListBox.SelectedItem == CardSuitListBox.Items[1])
            {

                BorderCard.BorderBrush = Brushes.Red;
                NumberTextBox.Foreground = Brushes.Crimson;
            }
            else
            {
                BorderCard.BorderBrush = Brushes.Black;
                NumberTextBox.Foreground = Brushes.Black;
            }
        }
        
        public void ChangedNumberBox(object sender, SelectionChangedEventArgs e)
        {
            if (CardNumberListBox.SelectedItem == CardNumberListBox.Items[10] || CardNumberListBox.SelectedItem == CardNumberListBox.Items[11] || CardNumberListBox.SelectedItem == CardNumberListBox.Items[12])
            {
                
                foreach(Nummer nummer in NummerLijst)
                {
                    if(nummer == CardNumberListBox.SelectedItem)
                    {
                        CardImage3.Visibility = Visibility.Visible;
                        NumberTextBox.Visibility = Visibility.Collapsed;
                       
                        string source = nummer.Image.ToString();
                        CardImage3.Source = new BitmapImage(new Uri(source));
                    }
                }

            }
            else
            {
                NumberTextBox.Visibility = Visibility.Visible;
                CardImage3.Visibility = Visibility.Collapsed;
               
               
            }
                 
        }
    }
}
