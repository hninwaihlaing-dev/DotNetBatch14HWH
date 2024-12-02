﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.ContosoPizza.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Quantity {  get; set; }  
        public int OrderId {  get; set; }   
        public int ProductId { get; set; }
        public Order Order { get; set; } = null;
        public Product Product { get; set; } = null;
    }
}
