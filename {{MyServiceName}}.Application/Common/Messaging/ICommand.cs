using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __MyServiceName__.Application.Common.Messaging;

public interface ICommand : IAnyRequest { }
public interface ICommand<out TResponse> : IAnyRequest<TResponse> { }

