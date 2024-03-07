using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Model.Request.RequestFeedback
{
    public class RequestFeedback
    {
        public int Rate { get; set; }
        public string Description { get; set; } = null!;
        public Guid LandId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
