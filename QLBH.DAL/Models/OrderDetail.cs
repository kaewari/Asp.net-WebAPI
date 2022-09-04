﻿using System;
using System.Collections.Generic;

#nullable disable

namespace QLBH.DAL.Models
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public string Quantity { get; set; }
        public int ProductId { get; set; }
        public string UnitPrice { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
