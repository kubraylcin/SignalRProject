using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
	
	public interface IProductDal : IGenericDal<Product>
	{
		//entity özel methotlar 
		//ürünleri category adlarıyla beraber getirmek için
		List<Product> GetProductsWithCategroies();
		public int ProductCount();
		public int ProducCountByNameHamburger();
		public int ProducCountByNameDrink();
		public decimal ProductPriceAvg();
		public string ProductNamePriceMax();
		public string ProductNamePriceMin();
		public decimal ProductPriceByHamburger();

		decimal TotalPriceByDrinkCategory();

	}
}
