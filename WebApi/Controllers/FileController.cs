﻿using Application.Common.Model.Request.RequestFile;
using Application.Common.Model.Response.ResponseFile;
using Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly FileService _fileService;

        public FileController(FileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseFile>>
            Add([FromForm] RequestFile requestFile) 
        {
            var responseFile = await _fileService.UploadFile(requestFile);
            return responseFile == null
                ? BadRequest()
                : Ok(new
                {
                    Success = true,
                    Data = responseFile
                });
        }

        [HttpGet]
        public async Task<IActionResult> GetNameFile(string name)
        {
            var result = await _fileService.Get(name);
            var fileType = "";
            if (fileType.Contains("png")) fileType = "png";
            return File(result, $"image/{fileType}");
        }
    }
}
