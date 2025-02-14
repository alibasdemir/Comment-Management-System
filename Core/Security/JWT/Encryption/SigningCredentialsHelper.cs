﻿using Microsoft.IdentityModel.Tokens;

namespace Core.Security.JWT.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey) =>
            new(securityKey, SecurityAlgorithms.HmacSha512Signature);
    }
}
