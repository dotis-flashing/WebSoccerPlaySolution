using Application.IGenericRepository;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IPriceRepository : IGenericRepository<Price>
    {
        Task<Price?> GetBySizeAndLand(Guid LandId, int Size, DateTime startTime);

        Task<List<Price>> GetPriceByLandId(Guid LandId);
        Task<Price?> InActive(Guid landId, int startTime, int endTime, int size);
    }
}
