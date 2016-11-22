using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Models
{
    class PlayField : INotifyPropertyChanged
    {
        private double height;
        private double width;

        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
                onPropertyChanged("Height");
            }
        }

        public double Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
                onPropertyChanged("Width");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        virtual protected void onPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
