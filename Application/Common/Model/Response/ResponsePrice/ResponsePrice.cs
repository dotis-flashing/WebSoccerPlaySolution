using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Model.Response.ResponseSchedule
{
    public class ResponsePrice
    {
        public Guid PriceId { get; set; }
        public int StarTime { get; set; }
        public int EndTime { get; set; }
        public DateTime Date { get; set; }
        public float Price1 { get; set; }
        public int Size { get; set; }
        public Guid LandLandId { get; set; }
    }
}
