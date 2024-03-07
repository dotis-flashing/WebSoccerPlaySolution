using Application.Common.Model.Request.RequestPitch;
using Application.Common.Model.Response.ResponsePitch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface PitchService
    {
        Task<ResponsePitchV2> CreatePitch(RequestPitch requestPitch);
        Task<List<ResponsePitchV2>> GetScheduleListByDate(Guid landId, string date, int size);
        Task<ResponsePitchV2> GetScheduleList(Guid landId, string date, int size, string name);
        Task<List<ICollection<ResponsePitch>>> GetAllPitchOfOwner(Guid ownerId);
        Task<List<ResponsePitch>> GetAllPitchByNameLandAndOwnerId(Guid ownerId, Guid landId);
        Task<int[]> GetNumPitch(Guid ownerId);
        Task<int[]> GetNumPitchByLand(Guid ownerId);
        Task<ResponsePitch> ChangePitchStatus(Guid pitchId, string status);

    }
}
