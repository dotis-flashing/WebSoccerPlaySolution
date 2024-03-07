using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Security.Token
{
    public interface ITokensHandler
    {
        AccessTokenn CreateAccessToken(Account account);
        RefreshToken TakeRefreshToken(string refresh, string userName);
        void RevokeRefreshToken(string token, string userName);
        Task<string> ClaimsFromToken(string token);
    }
}
