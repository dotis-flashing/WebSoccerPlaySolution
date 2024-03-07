using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Model.Response.ResponseBooking
{
    public class ResponseManageBooking
    {
        public Guid BookingId { get; set; }

        public string Name { get; set; }
        public float TotalPrice { get; set; }
        public Guid LandId { get; set; }
        public string? Location { get; set; }
        public DateTime DateBooking { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Note { get; set; }
        public int size { get; set; }
        public string Status { get; set; }
    }
}
