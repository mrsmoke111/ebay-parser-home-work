﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eBayParser.Classes
{
    public class EBayItem
    {
        public string title { get; set; }
        public string link { get; set; }
        public int quantity { get; set; }
        public Decimal price { get; set; }
    }
}