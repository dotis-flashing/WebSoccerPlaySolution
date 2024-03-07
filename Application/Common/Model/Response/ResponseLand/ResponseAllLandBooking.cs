using Application.Common.Model.Response.ResponseBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Model.Response.ResponseLand
{
    public class ResponseAllLandBooking
    {
        public Guid LandId { get; set; }
        public string Location { get; set; } = null!;
        public string Name { get; set; } = null!;

        public List<ResponseBooking_v2>? List { get; set; }
    }
}
