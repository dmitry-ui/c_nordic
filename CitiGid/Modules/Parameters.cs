using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiGid.Modules
{
    public class Parameters
    {
        public string type { get; set; }
        public string allowYards { get; set; }
        public string allowSideWays { get; set; }
        public string allowGroundRoads { get; set; }
        public string allowPaidRoads { get; set; }
        public string useLimitsUpd { get; set; }
        public string useForecast { get; set; }
        public string useJams { get; set; }
    }
}
