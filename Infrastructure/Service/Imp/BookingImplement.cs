﻿using Application.Common.Enum;
using Application.Common.Model.Request.Mail;
using Application.Common.Model.Request.RequestBooking;
using Application.Common.Model.Response.ResponseBooking;
using Application.Common.Model.Response.ResponseLand;
using Application.Common.Model.Response.ResponseSchedule;
using AutoMapper;
using Domain;
using Infrastructure.IUnitofwork;
using Infrastructure.Security.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Imp
{
    public class BookingImplement : BookingService
    {
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;
        private readonly ScheduleService _scheduleService;
        private readonly IUnitOfWork _unitOfWork;

        public BookingImplement(IUnitOfWork unitOfWork, IMapper mapper, ScheduleService scheduleService,
            IMailService mailService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _scheduleService = scheduleService;
            _mailService = mailService;
        }

        public async Task<List<ResponseBooking>> GetAllBooking()
        {
            var bookingEntities =
                await _unitOfWork.Booking.GetAllBooking(); // Assuming a method like GetAllAsync() exists in your repository
            var responseBookings = _mapper.Map<List<ResponseBooking>>(bookingEntities);
            var i = 0;
            foreach (var booking in responseBookings)
            {
                booking.Schedules = _mapper.Map<List<ResponseSchedule>>(bookingEntities[i].Schedules);
                i++;
            }

            return responseBookings;
        }

        public async Task<List<ResponseManageBooking>> GetByCustomerId(Guid customerId)
        {
            var bookingEntities = await _unitOfWork.Booking.GetAllBookingByCustomerId(customerId);
            var responseBookings = _mapper.Map<List<ResponseManageBooking>>(bookingEntities);
            int count = 0;
            foreach (var Booking in bookingEntities)
            {
                var firstSchedule = Booking.Schedules.FirstOrDefault(s => s.BookingBookingId == Booking.BookingId);
                if (firstSchedule != null && firstSchedule.PitchPitch != null)
                {
                    responseBookings[count].EndTime = firstSchedule.EndTime;
                    responseBookings[count].StartTime = firstSchedule.StarTime;
                    responseBookings[count].size = firstSchedule.PitchPitch.Size;
                }

                count++;
            }

            return responseBookings;
        }

        public async Task<List<ResponseAllLandBooking>> GetByOwner(Guid ownerId)
        {
            var lands = await _unitOfWork.Land.GetLandByOwnerId(ownerId);
            var response = _mapper.Map<List<ResponseAllLandBooking>>(lands);
            int i = 0;
            foreach (var land in response)
            {
                land.List = await GetBookingByLandId(lands[i].LandId);
                i++;
            }

            return response;
        }

        public async Task<bool> CancelBooking_v2(Guid BookingId)
        {
            var booking = await _unitOfWork.Booking.GetBookingById(BookingId);
            booking.Status = BookingStatus.Cancel.ToString();
            foreach (var s in booking.Schedules)
            {
                s.Status = BookingStatus.Cancel.ToString();
                var sendMail = new Mail
                {
                    To = _unitOfWork.Customer.GetById(booking.CustomerId).Email,
                    Subject = "Your football pitch booking schedule is Cancel.",
                    Body = "Your football pitch booking time starts from " + s.StarTime + " to" + s.EndTime + "is Cancel"
                };
                await _mailService.SendEmail(sendMail);
            }

            _unitOfWork.Save();
            return true;
        }

        public async Task<bool> CancelBooking_v3(Guid BookingId)
        {
            var booking = await _unitOfWork.Booking.GetBookingById(BookingId);
            booking.Status = BookingStatus.Cancel.ToString();
            foreach (var s in booking.Schedules)
            {
                s.Status = BookingStatus.Cancel.ToString();
                var sendMail = new Mail
                {
                    To = _unitOfWork.Customer.GetById(booking.CustomerId).Email,
                    Subject = "Lịch đặt sân bông bị Hủy.",
                    Body = "Sân bóng bạn đặt lúc " + s.StarTime + " đến" + s.EndTime +
                           "đã bị hủy do sự cố của Sân bóng./n Chúng tôi chân thành xin lỗi quý khách"
                };
                await _mailService.SendEmail(sendMail);
            }

            _unitOfWork.Save();
            return true;
        }

        public async Task<ResponseBooking_v2> BookingPitch_v3(RequestBooking_v3 requestBooking)
        {

            //Check Schedule
            var pitchs = await _unitOfWork.Pitch.GetPitchToBooking
                (requestBooking.LandId, requestBooking.StarTime, requestBooking.EndTime, requestBooking.Size);

            var booking = _mapper.Map<Booking>(requestBooking);
            _unitOfWork.Booking.Add(booking);
            _unitOfWork.Save();

            var scheduling = await _scheduleService.CreateSchedule(requestBooking.StarTime, requestBooking.EndTime,
                booking.BookingId, pitchs.PitchId, requestBooking.LandId, pitchs.Size, requestBooking.price);

            //Total Price 
            booking.TotalPrice = requestBooking.price;
            _unitOfWork.Save();

            var getBooking = _mapper.Map<ResponseBooking_v2>(booking);
            getBooking.StartTime = requestBooking.StarTime;
            getBooking.EndTime = requestBooking.EndTime;

            //Send Mail
            var sendMail = new Mail
            {
                To = _unitOfWork.Customer.GetById(requestBooking.CustomerId).Email,
                Subject = "Your football pitch booking schedule.",
                Body = "Your football pitch booking time starts from " + scheduling.StarTime + " to" + scheduling.EndTime
            };
            await _mailService.SendEmail(sendMail);

            return getBooking;
        }

        public async Task<List<ResponseBooking_v2>> GetBookingByLandId(Guid id)
        {
            var bookings = await _unitOfWork.Booking.GetBookingByLandId(id);
            var getBooking = _mapper.Map<List<ResponseBooking_v2>>(bookings);
            int i = 0;
            foreach (var b in bookings)
            {
                getBooking[i].StartTime = b.Schedules.FirstOrDefault().StarTime;
                getBooking[i].EndTime = b.Schedules.FirstOrDefault().EndTime;
                getBooking[i].pitchName = _unitOfWork.Pitch.GetById(b.Schedules.FirstOrDefault().PitchPitchId).Name;
                i++;
            }

            return getBooking;
        }


        public async Task<bool> ChangeStatus(Guid id, string status)
        {
            string a = "";
            if (status.ToUpper().Equals(BookingStatus.Cancel.ToString().ToUpper()))
            {
                a = BookingStatus.Cancel.ToString();
            }

            if (status.ToUpper().Equals(BookingStatus.Done.ToString().ToUpper()))
            {
                a = BookingStatus.Done.ToString();
            }

            var booking = await _unitOfWork.Booking.GetBookingById(id);
            booking.Status = a;
            foreach (var s in booking.Schedules)
            {
                s.Status = a;
            }

            _unitOfWork.Save();
            return true;
        }

        public async Task<List<ResponseAllLandBooking_v2>> GetByOwner_v2(Guid ownerId)
        {
            var lands = await _unitOfWork.Land.GetLandByOwnerId(ownerId);
            List<ResponseAllLandBooking_v2> list = new List<ResponseAllLandBooking_v2>();
            foreach (var l in lands)
            {
                var bookings = await _unitOfWork.Booking.GetBookingByLandId(l.LandId);
                var getBooking = _mapper.Map<List<ResponseAllLandBooking_v2>>(bookings);
                int i = 0;
                foreach (var b in bookings)
                {
                    getBooking[i].StartTime = b.Schedules.FirstOrDefault().StarTime;
                    getBooking[i].EndTime = b.Schedules.FirstOrDefault().EndTime;
                    getBooking[i].pitchName = _unitOfWork.Pitch.GetById(b.Schedules.FirstOrDefault().PitchPitchId).Name;
                    i++;
                }

                list = list.Concat(getBooking).ToList();
            }

            return list;
        }

        public async Task<ResponeBooking_v3> GetByBookingId(Guid id)
        {
            var booking = await _unitOfWork.Booking.GetBookingById(id);
            var pitch = _unitOfWork.Pitch.GetById(booking.Schedules.FirstOrDefault()!.PitchPitchId);
            var response = _mapper.Map<ResponeBooking_v3>(booking);
            response.PitchId = pitch.PitchId;
            response.PitchName = pitch.Name;
            response.Size = pitch.Size;
            return _mapper.Map<ResponeBooking_v3>(booking);
        }

        public async Task<List<BookingSummary>> GetSummryInYear(int year, Guid ownerId)
        {
            var summary = await _unitOfWork.Booking.GetBookingSummariesForYear(year, ownerId);
            return summary;
        }

        public async Task<float> GetSummary(Guid ownerId)
        {
            return await _unitOfWork.Booking.GetSummary(ownerId);
        }

        public async Task<int> GetNumBooking(Guid ownerId)
        {
            return await _unitOfWork.Booking.GetNumBooking(ownerId);
        }

        public async Task<List<BookingSummary>> GetSummryInYearByLand(int year, Guid landId)
        {
            var summary = await _unitOfWork.Booking.GetBookingSummariesForYearByLand(year, landId);
            return summary;
        }

        public async Task<float> GetSummaryByLand(Guid landId)
        {
            return await _unitOfWork.Booking.GetSummaryByLand(landId);
        }


        public async Task<int> GetNumBookingByLand(Guid landId)
        {
            return await _unitOfWork.Booking.GetNumBookingByLand(landId);
        }
    }
}
