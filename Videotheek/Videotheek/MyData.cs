using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videotheek
{
    public class MyData : INotifyPropertyChanged
    {
        private string myDataProperty;

        public MyData() { }

        public MyData(String dataproperty)
        {
            myDataProperty = "";
        }

        public String MyDataProperty
        {
            get { return myDataProperty; }
            set
            {
                myDataProperty = value;
                OnPropertyChanged("MyDataProperty");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
