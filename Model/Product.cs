﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineOrderPlacementSystem.Model
{
    public class Product
    {
        public string Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
    }
}
