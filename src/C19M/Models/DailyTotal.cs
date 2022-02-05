using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19M.Models
{
    public class DailyTotal
    {
        public int Active { get; set; }

        public int Confirmed { get; set; }

        public int Critical { get; set; }

        public DateTime Date { get; set; }

        public int Deaths { get; set; }

        public int Recovered { get; set; }
    }
}
