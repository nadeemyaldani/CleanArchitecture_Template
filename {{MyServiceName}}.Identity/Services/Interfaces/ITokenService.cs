using __MyServiceName__.Identity.Domain.Entities;
using __MyServiceName__.Identity.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __MyServiceName__.Identity.Services.Interfaces;
public interface ITokenService
{
    AuthResult GenerateToken(ApplicationUser user, IList<string> roles);

}
