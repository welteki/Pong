using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Pong.Models
{
    class Ball : INotifyPropertyChanged
    {
        private double x;
        private double y;
        private double angle;
        private double speed;
        private double size;
        private bool moving_up;
        
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

        public double Angle
        {
            get
            {
                return angle;
            }
            set
            {
                angle = value;
                onPropertyChanged("Angle");
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

        public double Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
                onPropertyChanged("Size");
            }
        }

        public bool MovingUp
        {
            get
            {
                return moving_up;
            }
            set
            {
                moving_up = value;
                onPropertyChanged("X");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void onPropertyChanged(string propName)               //Zoek betekenis protected en virtual op
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
