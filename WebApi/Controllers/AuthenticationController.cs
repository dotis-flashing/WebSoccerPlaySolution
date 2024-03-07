﻿using Application.Common.Model.Request.RequestAccount;
using Application.Common.Model.Response.ResponseAccount;
using Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenService _authenService;

        public AuthenticationController(AuthenService authenService)
        {
            _authenService = authenService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseLogin>> Login(RequestLogin requestLogin)
        {
            var account = await _authenService.LoginAccessToken(requestLogin);
            return account == null
                ? BadRequest()
                : Ok(new
                {
                    Success = true,
                    Data = account
                });
        }


        [HttpPost]
        public async Task<ActionResult<ResponseLogin>> RefreshToken([FromForm] string refreshToken,
            [FromForm] string username)
        {
            var account = await _authenService.RefreshToken(refreshToken, username);
            return account == null
                ? BadRequest()
                : Ok(new
                {
                    Success = true,
                    Data = account
                });
        }

        [HttpPost]
        public IActionResult RevokeRefreshToken([FromForm] string refreshToken, [FromForm] string username)
        {
            _authenService.RevokeRefreshToken(refreshToken, username);
            return Ok();
        }
    }
}