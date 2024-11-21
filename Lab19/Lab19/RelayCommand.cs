using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab19
{

    public class RelayCommand : ICommand
    {

        private readonly Action<object> __execute;
        
        private readonly Func<object, bool> __can_execute;

        public RelayCommand(Action<object> execute, Func<object, bool> can_execute = null)
        {
            if(execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            this.__execute = execute;
            this.__can_execute = can_execute;
        }

        event EventHandler ICommand.CanExecuteChanged
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

        bool ICommand.CanExecute(object parameter)
        {
            return (this.__can_execute == null) ? true : this.__can_execute(parameter);
        }

        void ICommand.Execute(object parameter)
        {
            this.__execute(parameter);
        }
    }
}
