using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Model.Request.RequestBooking
{
    public class RequestBooking_v3
    {
        public Guid LandId { get; set; }
        public string Note { get; set; } = null!;
        public int Size { get; set; }
        public DateTime StarTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid CustomerId { get; set; }
        public float price { get; set; }
    }
}
