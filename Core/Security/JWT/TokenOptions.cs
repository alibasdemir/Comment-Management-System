﻿namespace Core.Security.JWT
{
    public class TokenOptions
    {
        public string SecurityKey { get; set; }
        public int TokenExpirationTime { get; set; }
        public int RefreshTokenTTL { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
