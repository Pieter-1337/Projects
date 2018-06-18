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



    public class Nummer 
    {
        public static List<string> NaamNumberArr = new List<string> { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        private string NaamValue;
        private string ImageValue;
        
        public Nummer(string naam)
        {
            this.Naam = naam;
            this.Image = Image;
                     
        }

        public string Naam
        {
            get
            {
                return NaamValue;
            }
            set
            {
             
               if (!NaamNumberArr.Contains(value))
               {
                    MessageBox.Show("Error Loading Number of card in Class Nummer", "Nummber Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    NaamValue = value;
                    
                   
                }
                
            }
        }

       


        public string Image
        {
            get
            {
                if (this.Naam == "K")
                {
                    ImageValue = "pack://application:,,,/CardDeck;component/Images/King.jpg";
                }
                else if (this.Naam == "Q")
                {
                    ImageValue = "pack://application:,,,/CardDeck;component/Images/Queen.jpg";
                }
                else if (this.Naam == "J")
                {
                    ImageValue = "pack://application:,,,/CardDeck;component/Images/Joker.jpg";
                }
                else
                {
                    ImageValue = null;
                }

                return ImageValue;
            }
            set { }
        }
    }
}
