using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Model.Request.RequestBooking
{
    public class RequestBookingV2
    {
        public Guid LandId { get; set; }
        public string Note { get; set; } = null!;

        public int TotalPitch { get; set; }
        public List<int> Size { get; set; }
        public List<DateTime> StarTime { get; set; }
        public List<DateTime> EndTime { get; set; }
        public Guid CustomerId { get; set; }
    }
}
