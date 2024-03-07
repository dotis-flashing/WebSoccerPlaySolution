using Application.IGenericRepository;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IScheduleRepository : IGenericRepository<Schedule>
    {
        Task<List<Schedule>> GetScheduleByPitch(Guid PitchId);

        Task<List<Schedule>> GetScheduleByBookingiD(Guid BookingId);
    }
}
