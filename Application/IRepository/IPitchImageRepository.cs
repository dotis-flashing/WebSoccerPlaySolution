using Application.IGenericRepository;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IPitchImageRepository : IGenericRepository<PitchImage>
    {
        Task<List<string>> GetAllImageByLandId(Guid LandId);
        Task<string> GetImageByLandId(Guid LandId);
    }
}
