using Pong.ViewModels;
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
using System.Windows.Threading;

namespace Pong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Singleplayer singleplayer;

        public MainWindow()
        {
            InitializeComponent();
            singleplayer= new Singleplayer();
            DataContext = singleplayer;
        }

        private void Window_KeyUp(object sneder, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
                singleplayer.Paddle.NotMoving = true;
            if (e.Key == Key.Right)
                singleplayer.Paddle.NotMoving = true;
        }
    }
}
