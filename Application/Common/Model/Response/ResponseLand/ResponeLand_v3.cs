﻿using Application.Common.Model.Response.ResponseSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Model.Response.ResponseLand
{
    public class ResponseLand_v3
    {
        public Guid LandId { get; set; }
        public string NameLand { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Distance { get; set; } = null!;
        public decimal AverageRate { get; set; } = 0;
        public float MinPrice { get; set; }
        public float MaxPrice { get; set; }
        public int TotalPitch { get; set; }
        public string Description { get; set; } = null!;
        public string Status { get; set; } = null!;
        public Guid OwnerId { get; set; }
        public DateTime Date { get; set; }
        public string image { get; set; } = null;
        public List<string> PitchImages { get; set; } = null;
        public List<ResponsePrice> Price { get; set; } = null;
    }
}
