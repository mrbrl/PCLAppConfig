using System;
using PCLCoreApp.Interfaces;
using PCLResolver;
using PCLResolver.Resolvers;

namespace PCLCoreApp.Commands
{
    public static class CommandBuilder
    {        public static IDelegateCommand<TArgument, TResult> GetCommand<TArgument, TResult>(Func<TArgument, TResult> func,
            Func<object, bool> canExecute = null, Action<TResult> callback = null)
        {
            var command = Resolver<AutofacResolver>.Instance.Resolve<IDelegateCommand<TArgument, TResult>>();
            command.SetCommand(func, canExecute, callback);
            return command;
        }
    }
}