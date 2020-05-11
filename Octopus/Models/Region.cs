﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Octopus.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string RegionName { get; set; }
        public int CarrierId { get; set; }
        public Carrier Carrier { get; set; }
    }
}
