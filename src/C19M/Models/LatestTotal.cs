using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19M.Models
{
    public class LatestTotal
    {
        public int Confirmed { get; set; }

        public int Recovered { get; set; }

        public int Critical { get; set; }

        public int Deaths { get; set; }

        public DateTime LastChange { get; set; }

        public DateTime LastUpdate { get; set; }

    }
}
