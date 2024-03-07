using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Model.Request.RequestLand
{
    public class RequestUpdateLand
    {
        public Guid LandId { get; set; }
        public string NameLand { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Policy { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Distance { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
