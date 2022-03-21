using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Models
{
    public class MovieStats
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int? Watches { get; set; }
        public double? AverageWatchDurationMs { get; set; }
        public string ReleaseYear { get; set; }
    }
}
