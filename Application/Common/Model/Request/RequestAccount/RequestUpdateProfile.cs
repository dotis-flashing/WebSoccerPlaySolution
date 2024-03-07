﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Model.Request.RequestAccount
{
    public class RequestUpdateProfile
    {
        public Guid CustomerId { get; set; }

        public string? FullName { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }
    }
}
