using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Model.Response.ResponseSchedule
{
    public class ResponseSchedule_v2
    {
        public TimeSpan StarTime { get; set; }
        public DateTime Date { get; set; }

        public TimeSpan EndTime { get; set; }
    }
}
