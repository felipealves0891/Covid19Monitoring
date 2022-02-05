using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19M.Models
{
    public class DailyResult
    {
        public string Province { get; set; }

        public int confirmed { get; set; }

        public int recovered { get; set; }

        public int deaths { get; set; }

        public int active { get; set; }
    }
}
