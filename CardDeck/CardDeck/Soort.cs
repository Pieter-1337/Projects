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
using System.Drawing;



namespace CardDeck
{
    

    public class Soort
    {
       public enum NaamValue { Pijken, Schoppen, Koeken, Harten };

       private NaamValue _Naam;
       private string ImageValue;
       private Brush BorderBrushValue;
        
        public Soort(NaamValue naam)
        {
            this._Naam = naam;
            this.Image = Image;
        }

        public string Image
        {
            get
            {
                if (this.Naam == NaamValue.Harten)
                {
                    ImageValue = "pack://application:,,,/CardDeck;component/Images/HartenAlleen.png";
                }
                else if (this.Naam == NaamValue.Koeken)
                {
                    ImageValue = "pack://application:,,,/CardDeck;component/Images/RuitenAlleen.png";
                }
                else if (this.Naam == NaamValue.Pijken)
                {
                    ImageValue = "pack://application:,,,/CardDeck;component/Images/PijkenAlleen.png";
                }
                else if (this.Naam == NaamValue.Schoppen)
                {
                    ImageValue = "pack://application:,,,/CardDeck;component/Images/SchoppenAlleen.png";
                }

                return ImageValue;
            }
            set { }
        }

        public NaamValue Naam
        {
            get
            {
                return _Naam;
            }
            set
            {
                _Naam = value;
            }
        }

        public Brush BorderBrush
        {
            get
            {
                return BorderBrushValue;
            }
            set
            {
                if(this.Naam == NaamValue.Pijken || this.Naam == NaamValue.Schoppen)
                {
                    BorderBrushValue = Brushes.Red;
                }
                else
                {
                    BorderBrushValue = Brushes.Black;
                }
            }
        }
    }
}
