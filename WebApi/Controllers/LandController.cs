﻿using Application.Common.Model.Request.RequestLand;
using Application.Common.Model.Response.ResponseLand;
using Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LandController : ControllerBase
    {
        private readonly LandService _landService;

        public LandController(LandService landService)
        {
            _landService = landService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseLand_2>> CreateLand(RequestLand requestLand)
        {
            var create = await _landService.CreateLand(requestLand);
            return Ok(create);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseLand_2>> UpdateLand(RequestUpdateLand requestLand)
        {
            var update = await _landService.UpdateLand(requestLand);
            return Ok(update);
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseLand>>> GetAllLand()
        {
            var lands = await _landService.GetAllLands();
            return Ok(lands);
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseLand>>> GetTop6Land()
        {
            var lands = await _landService.Top6Land();
            return Ok(lands);
        }

        [HttpGet]
        public async Task<ActionResult<ResponseLand>> GetLandById(Guid landId)
        {
            var land = await _landService.LandDetail(landId);
            return Ok(land);
        }

        [HttpGet]
        public async Task<ActionResult<ResponseLand>> GetLandByOwner(Guid OwnerId)
        {
            var land = await _landService.LandByOwnerId(OwnerId);
            return Ok(land);
        }

        [HttpGet]
        public async Task<ActionResult<ResponseLand>> GetLandByOwnerAndNameLand(Guid OwnerId, string nameLand)
        {
            var land = await _landService.LandByOwnerIdAndNameLand(OwnerId, nameLand);
            return Ok(land);
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseLand>>> SearchLand(string location, string landName)
        {
            try
            {
                var lands = await _landService.SearchLand(location, landName);
                return Ok(lands);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet]
        public async Task<ActionResult<List<ResponseLand>>> SearchLandByLocation(string location)
        {
            try
            {
                var lands = await _landService.SearchLandByLocation(location);
                return Ok(lands);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet]
        public async Task<ActionResult<List<ResponseLand>>> SearchLandByName(string landName)
        {
            try
            {
                var lands = await _landService.SearchLandByName(landName);
                return Ok(lands);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseLand>>> Filter([FromQuery] RequestFilter requestFilter)
        {
            var lands = await _landService.FilterLand(requestFilter);
            return Ok(lands);
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseLand>>> GetTop3IncomeLandOfOwner(Guid id)
        {
            var lands = await _landService.Top3LandSummary(id);
            return Ok(lands);
        }
    }
}
