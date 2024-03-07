using Application.Common.Model.Request.RequestAccount;
using Application.Common.Model.Response.ResponseAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface AuthenService
    {
        Task<ResponseLogin> LoginAccessToken(RequestLogin requestLogin);
        Task<ResponseLogin> RefreshToken(string refreshToken, string username);
        void RevokeRefreshToken(string refreshToken, string username);
    }
}
