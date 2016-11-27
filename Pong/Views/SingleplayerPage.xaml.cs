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

namespace Pong.Views
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class SingleplayerPage : Page
    {
        private Singleplayer singleplayer;

        public SingleplayerPage()
        {
            InitializeComponent();
            singleplayer = new Singleplayer();
            DataContext = singleplayer;
        }

        private void Page_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
                singleplayer.Paddle.NotMoving = true;
            if (e.Key == Key.Right)
                singleplayer.Paddle.NotMoving = true;
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }
    }
}
