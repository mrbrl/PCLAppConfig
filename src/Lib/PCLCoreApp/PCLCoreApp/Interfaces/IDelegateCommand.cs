using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoreApp.Interfaces
{
    public interface IDelegateCommand<TArgument, TResult> : ICommand
    {
        event EventHandler CanExecuteChanged;

        bool CanExecute(object parameter);

        void SetCommand(Func<TArgument, TResult> func, Func<object, bool> canExecute = null,
            Action<TResult> callback = null, string spinnerText = null, bool showSpinner = true);
    }
}
