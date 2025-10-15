using __MyServiceName__.Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __MyServiceName__.Identity.Services.Interfaces;
public interface ITokenService
{
    string GenerateToken(ApplicationUser user, IList<string> roles);
}
