using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Model.Response.ResponseSchedule
{
    public class ResponseSchedule
    {
        public Guid ScheduleId { get; set; }
        public DateTime StarTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Date { get; set; }

        public float Price { get; set; }
        public string Status { get; set; } = null!;
        public Guid PitchPitchId { get; set; }
    }
}
