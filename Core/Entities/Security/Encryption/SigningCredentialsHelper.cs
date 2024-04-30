using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Security.Encryption;

public class SigningCredentialsHelper
{
    public static SigningCredentials CreatesigningCredentials (SecurityKey securityKey)
    {
        return new SigningCredentials (securityKey, SecurityAlgorithms.HmacSha512Signature);
    }
}
