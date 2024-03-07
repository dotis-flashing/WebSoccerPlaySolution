using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Model.Request.RequestFile
{
    public class RequestFile
    {
        public Guid LandId { get; set; }
        public IFormFile? ImageLogo { get; set; }
    }
}
