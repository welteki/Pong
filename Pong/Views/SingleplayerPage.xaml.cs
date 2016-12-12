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
        private BitmapImage play;
        private BitmapImage pause;

        public SingleplayerPage()
        {
            InitializeComponent();
            singleplayer = new Singleplayer();
            DataContext = singleplayer;

            play.BeginInit();
            play.UriSource = new System.Uri("../Resources/Images/Play.png");
            play.EndInit();

            pause.BeginInit();
            pause.UriSource = new System.Uri("../Resources/Images/Pause.png");
            pause.EndInit();
        }

        private void btnPlayPause_Checked(object sender, RoutedEventArgs e)
        {
            singleplayer.PauseCommand.Execute(null);
            imgPlayPause.Source = play;
        }

        private void btnPlayPause_Unchecked(object sender, RoutedEventArgs e)
        {
            singleplayer.PlayCommand.Execute(null);
            imgPlayPause.Source = pause;
        }

        private void Page_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
                singleplayer.StopMovingCommand.Execute(null);
            if (e.Key == Key.Right)
                singleplayer.StopMovingCommand.Execute(null);
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }
    }
}
