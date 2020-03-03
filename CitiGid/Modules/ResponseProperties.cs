using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiGid.Modules
{
    public class Properties
    {
        public int TotalTime { get; set; }
        public int TotalDistance { get; set; }
        public string GetPoints { get; set; }
        public string Result { get; set; }
    }

    public class Geometry
    {
        public string Type { get; set; }
        public string Coordinates { get; set; }
    }

    public class Feature
    {
        public string Type { get; set; }
        public Geometry Geometry { get; set; }
        public Properties Properties { get; set; }
        public string ZoneIntersections { get; set; }
        public string PointsOrder { get; set; }
        public string PointsStartIndexes { get; set; }
    }

    public class CityGidResponse
    {
        public string Type { get; set; }
        public Feature[] Features { get; set; }
        public string ErrorMessage { get; set; }
    }
}
