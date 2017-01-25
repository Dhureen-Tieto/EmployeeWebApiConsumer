using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmployeeWebApiConsumer
{
    class SimpleCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        Action action;
        Func<bool> canExecute;
        public SimpleCommand(Action action, Func<bool> function)
        {
            this.action = action;
            this.canExecute = function;
        }

        public bool CanExecute(object parameter)
        {
            //throw new NotImplementedException();
            return canExecute();
        }

        public void Execute(object parameter)
        {
            //throw new NotImplementedException();
            action();
        }
    }
}
