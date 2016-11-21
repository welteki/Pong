using Pong.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pong.Commands
{
    class MoveRightCommand : ICommand
    {
        private Singleplayer ViewModel;

        public MoveRightCommand(Singleplayer ViewModel)
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
            return ViewModel.CanMoveRight;
        }

        public void Execute(object parameter)
        {
            ViewModel.MovePaddleRight();
        }
    }
}
