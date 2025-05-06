using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfProductDal : GenericRepository<Product>, IProductDal
	{
		public EfProductDal(SignalRContext context) : base(context)
		{
		}

		public List<Product> GetLast9Products()
		{
			var context= new SignalRContext();
			var values= context.Products.Take(9).ToList();
			return values;
		}

		public List<Product> GetProductsWithCategroies()
		{
			var context= new SignalRContext();
			var values = context.Products.Include(x=>x.Category).ToList();
			return values;
		}

		public int ProducCountByNameDrink()
		{
			using var context= new SignalRContext();
			return context.Products.Where(x => x.CategoryId == (context.Categories.Where(y => y.CategoryName=="İçecek").Select(z=>z.CategoryId).FirstOrDefault())).Count();
		}

		public int ProducCountByNameHamburger()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.CategoryId == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryId).FirstOrDefault())).Count();
		}

		public int ProductCount()
		{
			using var context= new SignalRContext();
			return context.Products.Count();
		}

		public string ProductNamePriceMax()
		{
			using var context = new SignalRContext();
			return context.Products
				.OrderByDescending(x => x.Price)
				.Select(x => x.ProductName)
				.FirstOrDefault() ?? "Ürün bulunamadı";
		}

		public string ProductNamePriceMin()
		{
			using var context = new SignalRContext();
			return context.Products
				.OrderBy(x => x.Price)
				.Select(x => x.ProductName)
				.FirstOrDefault() ?? "Ürün bulunamadı";
		}

		public decimal ProductPriceAvg()
		{
			using var context= new SignalRContext();
			return context.Products.Average(x=>x.Price);
		}

		public decimal ProductPriceByHamburger()
		{
			using var context= new SignalRContext();
			return context.Products.Where(x=>x.CategoryId==(context.Categories.Where(y=>y.CategoryName=="Hamburger").Select(z=>z.CategoryId).FirstOrDefault())).Average(w=>w.Price);
		}

        public decimal TotalPriceByDrinkCategory()
        {
			using var context = new SignalRContext();
			int id= context.Categories.Where(x=>x.CategoryName=="İçecek").Select(y=>y.CategoryId).FirstOrDefault();
			return context.Products.Where(x => x.CategoryId == id).Sum(x=>x.Price);
        }
    }
}
