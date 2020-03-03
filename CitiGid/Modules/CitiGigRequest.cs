using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiGid.Modules
{
    public class CitiGigRequest
    {
        public string accessKey { get; set; }
        public string getPoints { get; set; }
        public Parameters parameters { get; set; }
        public Points[] routes { get; set; }
    }
}
