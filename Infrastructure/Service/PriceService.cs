using Application.Common.Model.Request.RequestPrice;
using Application.Common.Model.Response.ResponseSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface PriceService
    {
        Task<ResponsePrice> CreatePrice(RequestPrice requestPrice);

        Task<List<ResponsePrice>> GetPriceByLand(Guid LandId);

        Task<Boolean> RemovePrice(Guid id);

        Task<float> Calculator(RequestCaculator requestCaculator);
    }
}
