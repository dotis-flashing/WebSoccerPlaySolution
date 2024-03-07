﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Model.Request.RequestLand
{
    public class RequestLand
    {
        [Required] public string NameLand { get; set; }

        [Required] public string Title { get; set; }

        [Required] public string Policy { get; set; }

        [Required] public string Location { get; set; }

        [Required] public string Description { get; set; }

        [Required] public Guid OwnerId { get; set; }
    }
}
