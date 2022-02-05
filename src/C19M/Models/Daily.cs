using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19M.Models
{
    public class Daily
    {
        public string Country { get; set; }

        public IEnumerable<DailyResult> Provinces { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public DateTime Date { get; set; }
    }
}
