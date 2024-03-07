using Application.IGenericRepository;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IFeedBackRepository : IGenericRepository<Feedback>
    {
        Task<List<Feedback>> GetByFeedBackLandId(Guid landId);
    }
}
