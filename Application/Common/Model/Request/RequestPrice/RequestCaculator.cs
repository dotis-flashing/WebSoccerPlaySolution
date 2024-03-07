using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Model.Request.RequestPrice
{
    public class RequestCaculator
    {
        [Required] public Guid LandId { get; set; }

        [Required] public int Size { get; set; }

        [Required] public DateTime StarTime { get; set; }

        [Required] public DateTime EndTime { get; set; }
    }
}
