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
    public class FeedBackRepository : GenericRepository<Feedback>, IFeedBackRepository
    {
        public FeedBackRepository(FootBall_PitchContext context) : base(context)
        {
        }

        public async Task<List<Feedback>> GetByFeedBackLandId(Guid landId)
        {
            var feedBacks = await _context.Feedbacks.Include(c => c.Customer).Where(feedback => feedback.LandId == landId).ToListAsync();
            return feedBacks;
        }
    }
}
