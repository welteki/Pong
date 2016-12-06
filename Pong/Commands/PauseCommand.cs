using Pong.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pong.Commands
{
    internal class PauseCommand : ICommand
    {
        private Singleplayer ViewModel;

        public PauseCommand(Singleplayer ViewModel)
        {
            this.ViewModel = ViewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested += value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;

        }

        public void Execute(object parameter)
        {
            ViewModel.PauseGame();
        }
    }
}
