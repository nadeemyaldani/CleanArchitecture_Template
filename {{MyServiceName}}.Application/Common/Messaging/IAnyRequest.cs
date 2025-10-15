using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __MyServiceName__.Application.Common.Messaging;

public interface IAnyRequest : IRequest { }
public interface IAnyRequest<out TResponse> : IRequest<TResponse> { }

