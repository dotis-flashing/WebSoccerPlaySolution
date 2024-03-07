using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Security.Token
{
    public class AccessTokenn
    {
        public AccessTokenn(string token, long expirationTicks, RefreshToken refreshToken)
        {
            Token = token;
            ExpirationTicks = expirationTicks;
            RefreshToken = refreshToken;
        }

        public string Token { get; set; }
        public long ExpirationTicks { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
