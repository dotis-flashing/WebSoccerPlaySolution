using Application.IGenericRepository;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class PriceRepository : GenericRepository<Price>, IPriceRepository
    {
        public PriceRepository(FootBall_PitchContext context) : base(context)
        {
        }

        public async Task<Price?> GetBySizeAndLand(Guid LandId, int Size, DateTime startTime)
        {
            var time = startTime.Hour;
            var price = _context.Set<Price>().FirstOrDefault(p =>
                p.Size == Size && p.LandLandId == LandId && time >= p.StarTime && time <= p.EndTime);
            return price;
        }

        public async Task<List<Price>> GetPriceByLandId(Guid LandId)
        {
            var price = await _context.Set<Price>().Where(p => p.LandLandId == LandId).ToListAsync();
            return price;
        }

        public async Task<Price?> InActive(Guid landId, int startTime, int endTime, int size)
        {
            var price = await _context.Prices.FirstOrDefaultAsync(p => p.Size == size && p.LandLandId == landId && p.EndTime == endTime && p.StarTime == startTime);
            return price;
        }
    }
}
