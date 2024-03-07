using Application.Common.Model.Response.ResponseBooking;
using Application.IGenericRepository;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        Task<List<Booking>> GetAllBookingByCustomerId(Guid customerId);
        Task<List<Booking>> GetAllBooking();
        Task<Booking> GetBookingById(Guid bookingId);
        Task<bool> GetBookingByCustomerId(Guid id);
        Task<List<Booking>> GetBookingByLandId(Guid id);
        Task<List<BookingSummary>> GetBookingSummariesForYear(int year, Guid ownerId);
        Task<float> GetSummary(Guid ownerId);
        Task<int> GetNumBooking(Guid ownerId);
        Task<List<BookingSummary>> GetBookingSummariesForYearByLand(int year, Guid landId);
        Task<float> GetSummaryByLand(Guid landId);
        Task<int> GetNumBookingByLand(Guid landId);


    }
}
