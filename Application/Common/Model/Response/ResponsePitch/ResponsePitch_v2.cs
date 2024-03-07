using Application.Common.Model.Response.ResponseSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Model.Response.ResponsePitch
{
    public class ResponsePitchV2
    {
        public Guid PitchId { get; set; }
        public string Name { get; set; } = null!;
        public string Size { get; set; } = null!;
        public Guid LandId { get; set; }
        public DateTime Date { get; set; }

        public float PriceMin { get; set; }
        public float PriceMax { get; set; }
        public List<ResponseSchedule_v2>? Schedules { get; set; }
    }
}
