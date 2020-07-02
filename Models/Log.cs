using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Octopus.Models
{
    public class Log
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Type { get; set; }
        public string Team { get; set; }
        public string Description { get; set; }


    }
}
