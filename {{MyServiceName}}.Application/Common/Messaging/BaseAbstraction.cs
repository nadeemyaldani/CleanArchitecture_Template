using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __MyServiceName__.Application.Common.Messaging;

public abstract class BaseCommand : ICommand<Unit> { }
public abstract class BaseQuery<TResponse> : IQuery<TResponse> { }
