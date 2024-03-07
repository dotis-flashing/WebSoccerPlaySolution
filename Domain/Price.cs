﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Price
    {
        public Price()
        {
            Pitches = new HashSet<Pitch>();
        }

        public Guid PriceId { get; set; }
        public int StarTime { get; set; }
        public int EndTime { get; set; }
        public DateTime Date { get; set; }
        public float Price1 { get; set; }
        public int Size { get; set; }
        public Guid LandLandId { get; set; }

        public virtual Land LandLand { get; set; } = null!;
        public virtual ICollection<Pitch> Pitches { get; set; }
    }
}
