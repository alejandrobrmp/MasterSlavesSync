using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MasterSlavesSync.ViewModel
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        private Predicate<object> canExecute;
        private Action action;

        public RelayCommand(Action action, Predicate<object> canExecute)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter = null)
        {
            return canExecute(parameter);
        }

        public void Execute(object parameter = null)
        {
            action();
        }
    }
}
