﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogusDemo
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Item { get; set; }
        public double UnitPrice { get; set; }

        public int Quantity { get; set; }
    }
}
