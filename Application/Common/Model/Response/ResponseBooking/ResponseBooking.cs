using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Model.Response.ResponseBooking
{
    public class ResponseBooking
    {
        public Guid BookingId { get; set; }
        public float TotalPrice { get; set; }
        public Guid LandId { get; set; }
        public string? Location { get; set; }
        public DateTime DateBooking { get; set; }
        public string Note { get; set; } = null!;
        public Guid CustomerId { get; set; }
        public List<ResponseSchedule.ResponseSchedule> Schedules { get; set; } = null!;
    }
}
