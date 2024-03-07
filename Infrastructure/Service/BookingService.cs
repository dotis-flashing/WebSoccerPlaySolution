﻿using Application.Common.Model.Request.RequestBooking;
using Application.Common.Model.Response.ResponseBooking;
using Application.Common.Model.Response.ResponseLand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface BookingService
    {
        Task<List<ResponseBooking>> GetAllBooking();
        Task<bool> CancelBooking_v2(Guid BookingId);
        Task<bool> CancelBooking_v3(Guid BookingId);
        public Task<List<ResponseManageBooking>> GetByCustomerId(Guid customerId);
        public Task<List<ResponseAllLandBooking>> GetByOwner(Guid ownerId);
        public Task<ResponseBooking_v2> BookingPitch_v3(RequestBooking_v3 requestBooking);
        public Task<List<ResponseBooking_v2>> GetBookingByLandId(Guid id);
        public Task<bool> ChangeStatus(Guid id, string status);
        public Task<List<ResponseAllLandBooking_v2>> GetByOwner_v2(Guid ownerId);
        public Task<ResponeBooking_v3> GetByBookingId(Guid id);
        public Task<List<BookingSummary>> GetSummryInYear(int year, Guid ownerId);
        public Task<float> GetSummary(Guid ownerId);
        public Task<int> GetNumBooking(Guid ownerId);
        public Task<List<BookingSummary>> GetSummryInYearByLand(int year, Guid landId);
        public Task<float> GetSummaryByLand(Guid landId);
        public Task<int> GetNumBookingByLand(Guid landId);
    }
}
