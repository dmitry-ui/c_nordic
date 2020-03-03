using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiGid.Modules
{
    public class DBString
    {
        public int Id { get; set; }
        public string HostName { get; set; }
        public string Pid { get; set; }
        public DateTime Date { get; set; }
        public string Thread { get; set; }
        public string Logger { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public CitiGigRequest citiGigRequest { get; set; }
        public string Exception { get; set; }
    }

    public class DBStringResponse
    {
        public int Id { get; set; }
        public string HostName { get; set; }
        public string Pid { get; set; }
        public DateTime Date { get; set; }
        public string Thread { get; set; }
        public string Logger { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public CityGidResponse CityGidResponse { get; set; }
        public string Exception { get; set; }
    }
}
