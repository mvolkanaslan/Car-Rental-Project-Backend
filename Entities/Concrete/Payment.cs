﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Payment
    {
        public string CardNumber { get; set; }
        public string HolderName { get; set; }
        public string MounthOfExp { get; set; }
        public string YearOfExp { get; set; }
        public string CVV { get; set; }
        public int Amount { get; set; }
    }
}
