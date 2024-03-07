using Application.Common.Model.Request.RequestLand;
using Application.Common.Model.Response.ResponseLand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface LandService
    {
        Task<ResponseLand_2> CreateLand(RequestLand requestLand);
        Task<ResponseLand_2> UpdateLand(RequestUpdateLand requestUpdateLand);
        Task<List<ResponseLand>> GetAllLands();
        Task<ResponseLand_v3> LandDetail(Guid landId);
        Task<List<ResponseLand>> LandByOwnerId(Guid ownerId);
        Task<List<ResponseLand>> LandByOwnerIdAndNameLand(Guid ownerId, string nameLand);
        Task<List<ResponseLand>> Top6Land();
        Task<List<ResponseLand>> SearchLand(string location, string landName);
        Task<List<ResponseLand>> SearchLandByLocation(string landName);
        Task<List<ResponseLand>> SearchLandByName(string landName);
        Task<List<ResponseLand>> FilterLand(RequestFilter requestFilter);
        Task<List<ResponseLand>> Top3LandSummary(Guid ownerId);
    }
}
