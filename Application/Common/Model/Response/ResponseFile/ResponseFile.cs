using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Model.Response.ResponseFile
{
    public class ResponseFile
    {
        public Guid PitchImageId { get; set; }
        public Guid PitchId { get; set; }
        public string Name { get; set; } = null!;
        public string Size { get; set; } = null!;
        public string Status { get; set; } = null!;
        public Guid LandId { get; set; }
        public Guid OwnerId { get; set; }
    }
}
