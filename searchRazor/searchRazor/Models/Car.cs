﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchRazor.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
    }
}
