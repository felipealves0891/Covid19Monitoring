using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19M.Models
{
    public class Latest
    {
        public string Country { get; set; }

        public string Code { get; set; }

        public int Confirmed { get; set; }

        public int Recovered { get; set; }

        public int Critical { get; set; }

        public int Deaths { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public DateTime LastChange { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}
