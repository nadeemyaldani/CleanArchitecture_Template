using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __MyServiceName__.Application.Common.Messaging;

public interface IQuery : IAnyRequest { }
public interface IQuery<out TResponse> : IAnyRequest<TResponse> { }
