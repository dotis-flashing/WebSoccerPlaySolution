using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Model.Response.ResponseFeedback
{
    public class ResponseFeedback
    {
        public Guid FeedbackId { get; set; }
        public int Rate { get; set; }
        public string Description { get; set; } = null!;
        public DateTime Date { get; set; }
        public string namePitch { get; set; }
        public string nameLand { get; set; }
        public string size { get; set; }
        public Guid LandId { get; set; }
        public Guid CustomerId { get; set; }
        public string nameCustomer { get; set; }
    }
}
