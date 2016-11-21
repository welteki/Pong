using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Models
{
    class ScoreBoard : INotifyPropertyChanged
    {
        private int score;

        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
                onPropertyChanged("Score");
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
