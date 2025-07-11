﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
	public class Category
	{
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
        public bool Status { get; set; }
		public List<Product> Products { get; set; } /* Bir Category birden fazla Ürün içerebilir */
	}
}
