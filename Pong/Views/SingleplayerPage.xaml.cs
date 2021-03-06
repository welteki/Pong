﻿using Pong.ViewModels;
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

            play = new BitmapImage();
            play.BeginInit();
            play.UriSource = new Uri("../Resources/Images/Play.png", UriKind.Relative);
            play.EndInit();

            pause = new BitmapImage();
            pause.BeginInit();
            pause.UriSource = new Uri("../Resources/Images/Pause.png", UriKind.Relative);
            pause.EndInit();
        }

        #region Graphical Interaction

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

        #endregion

        #region KeyBoard Interaction

        private void Page_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    singleplayer.StopMovingCommand.Execute(null);
                    break;
                case Key.Right:
                    singleplayer.StopMovingCommand.Execute(null);
                    break;
                case Key.Enter:
                    btnPlayPause.RaiseEvent(new RoutedEventArgs(MenuItem.ClickEvent));
                    break;
            }
        }

        #endregion

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }
    }
}
