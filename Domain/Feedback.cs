﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Feedback
    {
        public Guid FeedbackId { get; set; }
        public int Rate { get; set; }
        public string Description { get; set; } = null!;
        public DateTime Date { get; set; }
        public Guid LandId { get; set; }
        public Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Land Land { get; set; } = null!;
    }
}
