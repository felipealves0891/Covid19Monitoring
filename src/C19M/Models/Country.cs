using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19M.Models
{
    public class Country
    {
        public string Name { get; set; }

        public string Alpha2Code { get; set; }

        public string Alpha3Code { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public override string ToString()
        {
            return $"{Name};{Alpha2Code};{Alpha3Code};{Latitude};{Longitude}";
        }

    }
}
