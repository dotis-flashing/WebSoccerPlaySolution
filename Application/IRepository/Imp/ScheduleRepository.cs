using Application.Common.Enum;
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
    public class ScheduleRepository : GenericRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(FootBall_PitchContext context) : base(context)
        {
        }

        public async Task<List<Schedule>> GetScheduleByPitch(Guid PitchId)
        {
            var list = await _context.Schedules.Where(schedule =>
                schedule.PitchPitchId == PitchId && schedule.Status == ScheduleEnum.Waiting.ToString()).ToListAsync();
            return list;
        }

        public async Task<List<Schedule>> GetScheduleByBookingiD(Guid BookingId)
        {
            var list = await _context.Schedules.Where(schedule => schedule.BookingBookingId == BookingId).ToListAsync();
            return list;
        }
    }
}
