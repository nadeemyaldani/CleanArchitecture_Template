using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __MyServiceName__.Application;

public abstract class Query;
public class BaseCommand;

public interface IAnyRequest : IRequest<object> { }

public interface IQuery : IAnyRequest { }

public interface ICommand : IAnyRequest { }

public interface ITaskUpdateCommand : ICommand { }

public interface IGeneralTaskUpdateCommand : ITaskUpdateCommand { }

public interface ILevelTaskUpdateCommand : ITaskUpdateCommand { }

public abstract class CommandHandler<TRequest> : IRequestHandler<TRequest, object> where TRequest : IRequest<object>
{
    public abstract Task<object> Handle(TRequest request, CancellationToken cancellationToken);
}

