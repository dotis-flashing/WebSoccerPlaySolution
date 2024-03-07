using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PitchImage
    {
        public Guid ImageId { get; set; }
        public string Name { get; set; } = null!;
        public Guid LandId { get; set; }
        public virtual Land Land { get; set; } = null!;
    }
}
