using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Models
{
    class Paddle : INotifyPropertyChanged
    {
        private double x;
        private double y;
        private double height;
        private double width;
        private double speed;
        private bool moveleft;
        private bool notmoving;

        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
                onPropertyChanged("X");
            }
        }

        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
                onPropertyChanged("Y");
            }
        }

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

        public double Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
                onPropertyChanged("Speed");
            }
        }

        public bool MoveLeft
        {
            get
            {
                return moveleft;
            }
            set
            {
                moveleft = value;
                onPropertyChanged("MoveLeft");
            }
        }

        public bool NotMoving
        {
            get
            {
                return notmoving;
            }
            set
            {
                notmoving = value;
                onPropertyChanged("MoveRight");
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
