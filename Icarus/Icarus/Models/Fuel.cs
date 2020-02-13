using System;
using System.Collections.Generic;
using System.Text;

namespace Icarus.Models
{
    public class Fuel
    {
        public Fuel (string name, double percentageUse)
        {
            Name = name;
            PercentUse = percentageUse.ToString();
        }

        public string Name { get; set; }
        public string PercentUse { get; set; }
    }
}
