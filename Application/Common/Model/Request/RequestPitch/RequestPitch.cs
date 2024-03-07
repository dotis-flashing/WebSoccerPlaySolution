using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Model.Request.RequestPitch
{
    public class RequestPitch
    {
        [Required] public string Name { get; set; } = null!;

        [Required] public int Size { get; set; }

        [Required] public Guid LandId { get; set; }

        [Required] public Guid OwnerId { get; set; }
    }
}
