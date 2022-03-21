using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Models
{
    public class Stats
    {
        public int MovieId { get; set; }
        public int? Watches { get; set; }
        public double? AverageWatchDurationMs { get; set; }
    }
}
