using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using CoreApp.Interfaces;

namespace CoreApp.Commands
{
    public class DelegateCommand<TArgument, TResult> : IDelegateCommand<TArgument, TResult>, ICommand
    {
        protected Func<TArgument, TResult> _func;
        protected Func<object, bool> _canExecute;
        protected Action<TResult> _callback;
        public Task CommandTask { get; protected set; }

        #region Constants

        /// <summary>
        /// The defaul t_ error.
        /// </summary>
        protected const string DEFAULT_ERROR = "Error";

        #endregion

        #region Constructors and Destructors

        public DelegateCommand()
        {
        }

        public void SetCommand(Func<TArgument, TResult> func, Func<object, bool> canExecute = null, Action<TResult> callback = null, string spinnerText = null, bool showSpinner = true)
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            _func = func;
            _canExecute = canExecute;
            _callback = callback;
        }

        protected Task ExecuteAsync(object parameter)
        {
            var cts = new CancellationTokenSource();

            try
            {
                var task = Task.Run(async () =>
                {
                    // execute copmmand
                    var result = _func.Invoke((TArgument)parameter);

                    // cancel spinner
                    cts.Cancel();

                    return result;
                }, cts.Token);
                

                if (_callback != null)
                    task.ContinueWith(x => { _callback.Invoke(x.Result); });

                return task;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Public Methods and Operators

        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
            {
                return _canExecute(parameter);
            }

            return true;
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        public virtual void Execute(object parameter)
        {
            CommandTask = ExecuteAsync(parameter).ContinueWith(
                task =>
                {
                    if (task.Exception != null)
                    {
                        // spinner, alerts, log handler
                    }
                },
                TaskContinuationOptions.ExecuteSynchronously);
        }

        public event EventHandler CanExecuteChanged;

        #endregion
    }
}
