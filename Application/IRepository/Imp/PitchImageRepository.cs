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
    public class PitchImageRepository : GenericRepository<PitchImage>, IPitchImageRepository
    {
        public PitchImageRepository(FootBall_PitchContext context) : base(context)
        {
        }

        public async Task<List<string>> GetAllImageByLandId(Guid LandId)
        {
            var list = _context.Set<PitchImage>().Where(image => image.LandId == LandId).Select(image => image.Name)
                .ToList();
            if (list == null) return null;
            return list;
        }

        public async Task<string> GetImageByLandId(Guid LandId)
        {
            var list = _context.Set<PitchImage>().Where(land => land.LandId == LandId)
                .OrderByDescending(item => item.LandId).FirstOrDefault();
            if (list == null) return null;
            return list.Name;
        }
    }
}
