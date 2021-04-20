using Aga.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aga.Domain.Implements
{
    public interface IJWTTokenService
    {
        string CreateToken(User user);
    }
}
