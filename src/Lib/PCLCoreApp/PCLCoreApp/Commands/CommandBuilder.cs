using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreApp.Interfaces;
using PCLAppConfig.Common;

namespace CoreApp.Commands
{
    public static class CommandBuilder
    {        public static IDelegateCommand<TArgument, TResult> GetCommand<TArgument, TResult>(Func<TArgument, TResult> func,
            Func<object, bool> canExecute = null, Action<TResult> callback = null)
        {
            var command = Resolver.Instance.Resolve<IDelegateCommand<TArgument, TResult>>();
            command.SetCommand(func, canExecute, callback);
            return command;
        }
    }
}