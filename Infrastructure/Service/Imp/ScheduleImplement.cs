using Application.Common.Enum;
using Application.IRepository;
using AutoMapper;
using Domain;
using Infrastructure.IUnitofwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Imp
{
    public class ScheduleImplement : ScheduleService
    {
        private readonly IMapper _mapper;
        private readonly IPriceRepository _priceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ScheduleImplement(IUnitOfWork unitOfWork, IMapper mapper, IPriceRepository priceRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _priceRepository = priceRepository;
        }

        public async Task<Schedule> CreateSchedule(DateTime starTime, DateTime endTime, Guid BookingId, Guid PitchId,
            Guid LandId, int Size, float price)
        {
            var schedule = new Schedule();
            schedule.BookingBookingId = BookingId;
            schedule.PitchPitchId = PitchId;
            schedule.EndTime = endTime;
            schedule.StarTime = starTime;
            schedule.Price = price;
            schedule.Date = DateTime.Now;
            schedule.Status = ScheduleEnum.Waiting.ToString();
            _unitOfWork.Schedule.Add(schedule);
            _unitOfWork.Save();
            return schedule;
        }
    }
}
