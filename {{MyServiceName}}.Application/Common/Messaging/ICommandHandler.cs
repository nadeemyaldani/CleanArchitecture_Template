using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __MyServiceName__.Application.Common.Messaging
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
      where TCommand : ICommand
    {
    }

    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
    }
    public abstract class CommandHandler<TRequest, TResponse> : ICommandHandler<TRequest, TResponse>
        where TRequest : ICommand<TResponse>
    {
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }

}
