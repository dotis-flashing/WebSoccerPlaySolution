﻿using Domain;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Security.Token.Imp
{
    public class TokensHandler : ITokensHandler
    {
        private readonly JWToken _JWToken;
        private readonly IMemoryCache _memoryCache;

        public TokensHandler(JWToken jWToken, IMemoryCache memoryCache)
        {
            _JWToken = jWToken;
            _memoryCache = memoryCache;
        }

        public Task<string> ClaimsFromToken(string token)
        {
            throw new NotImplementedException();
        }

        public AccessTokenn CreateAccessToken(Account account)
        {
            var refrehToken = GenerateRefreshToken();
            var cache = GetCacheKey(refrehToken.Token, account.UserName);
            _memoryCache.Set(cache, refrehToken, TimeSpan.FromDays(_JWToken.RefreshTokenExpiration));
            return AccessToken(account, refrehToken);
        }

        public void RevokeRefreshToken(string token, string userName)
        {
            var cachekey = GetCacheKey(token, userName);
            _memoryCache.Remove(cachekey);
        }

        public RefreshToken TakeRefreshToken(string refresh, string userName)
        {
            if (string.IsNullOrWhiteSpace(refresh) || string.IsNullOrWhiteSpace(userName))
                throw new Exception("Token or UserName Null");

            var cacheKey = GetCacheKey(refresh, userName);
            var refreshToken = _memoryCache.Get<RefreshToken>(cacheKey);

            if (refreshToken == null) throw new Exception("Data Refresh Token Null");
            _memoryCache.Remove(cacheKey);
            return refreshToken;
        }


        private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Guid.NewGuid().ToString(),
                Expiration = DateTime.UtcNow.AddDays(_JWToken.RefreshTokenExpiration)
            };

            return refreshToken;
        }

        private string GetCacheKey(string token, string userName)
        {
            return $"RefreshToken:{userName}:{token}";
        }

        private AccessTokenn AccessToken(Account account, RefreshToken refreshToken)
        {
            var accessTokenExpiration = DateTime.UtcNow.AddDays(_JWToken.AccessTokenExpiration);

            var secretKeyByte = Encoding.UTF8.GetBytes(_JWToken.JWTSecretKey);

            var securityToken = new JwtSecurityToken
            (
                _JWToken.Issuer,
                _JWToken.Audience,
                GetClaims(account),
                expires: accessTokenExpiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials
                    (new SymmetricSecurityKey(secretKeyByte), SecurityAlgorithms.HmacSha256)
            );
            var handle = new JwtSecurityTokenHandler();
            var accesstoken = handle.WriteToken(securityToken);
            return new AccessTokenn(accesstoken, accessTokenExpiration.Ticks, refreshToken);
        }

        private List<Claim> GetClaims(Account account)
        {
            var claims = new List<Claim>
        {
            new(ClaimTypes.Role, account.Role),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Sub, account.AccountId.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, account.UserName)
        };
            return claims;
        }
    }
}
