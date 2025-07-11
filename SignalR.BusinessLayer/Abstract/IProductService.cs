﻿using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
	public interface IProductService: IGenericService<Product>
	{
		
		List<Product> TGetProductsWithCategroies();
		public int TProductCount();
		public int TProducCountByNameHamburger();
		public int TProducCountByNameDrink();
		public decimal TProductPriceAvg();
		public string TProductNamePriceMax();
		public string TProductNamePriceMin();
		public decimal TProductPriceByHamburger();
		public decimal TTotalPriceByDrinkCategory();
		List<Product> TGetLast9Products();

	}
}
