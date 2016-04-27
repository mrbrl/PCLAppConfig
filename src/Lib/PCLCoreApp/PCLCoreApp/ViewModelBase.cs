using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XLabs.Forms.Mvvm;

namespace CoreApp
{
    ///     Base class for all view models
    ///     - Implements INotifyPropertyChanged for WinRT
    ///     - Implements some basic validation logic
    ///     - Implements some IsBusy logic
    /// </summary>
   
    public abstract class ViewModelBase : ViewModel, INotifyPropertyChanged
    {
        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// You know what that doest, don't you?
        /// </summary>
        /// <param name="propertyExpression">
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var body = propertyExpression.Body as MemberExpression;
            if (body != null)
            {
                OnPropertyChanged(body.Member.Name);
            }
        }

        /// <summary>
        /// The on property changed.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler ev = PropertyChanged;
            if (ev != null)
            {
                try
                {
                    ev(this, new PropertyChangedEventArgs(name));
                }
                catch (InvalidOperationException ioex)
                {
                    // we are running tests, we don't know about specific xamarin env
                    if (!ioex.Message.Contains("Init()"))
                        throw;
                }
            }
        }
    }
}
