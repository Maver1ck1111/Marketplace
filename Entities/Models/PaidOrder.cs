﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class PaidOrder
    {
        public Guid ProductId {  get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public DateTime DateTime { get; set; }
    }
}
