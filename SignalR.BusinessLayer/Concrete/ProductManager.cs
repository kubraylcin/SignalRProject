﻿using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{

	public class ProductManager : IProductService
	{
		private readonly IProductDal _productDal;


		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;
		}
		public void TAdd(Product entity)
		{
			_productDal.Add(entity);
		}

		public void TDelete(Product entity)
		{
			_productDal.Delete(entity);
		}

		public Product TGetById(int id)
		{
			return _productDal.GetById(id);
		}

		public List<Product> TGetLast9Products()
		{
			return _productDal.GetLast9Products();
		}

		public List<Product> TGetListAll()
		{
			return _productDal.GetListAll();
		}

		public List<Product> TGetProductsWithCategroies()
		{
			return _productDal.GetProductsWithCategroies();
		}

		public int TProducCountByNameDrink()
		{
			return _productDal.ProducCountByNameDrink();
		}

		public int TProducCountByNameHamburger()
		{
			return _productDal.ProducCountByNameHamburger();
		}

		public int TProductCount()
		{
			return _productDal.ProductCount();
		}

		public string TProductNamePriceMax()
		{
			return _productDal.ProductNamePriceMax();
		}

		public string TProductNamePriceMin()
		{
			return _productDal.ProductNamePriceMin();
		}

		public decimal TProductPriceAvg()
		{
			return _productDal.ProductPriceAvg();
		}

		public decimal TProductPriceByHamburger()
		{
			return _productDal.ProductPriceByHamburger();
		}

        public decimal TTotalPriceByDrinkCategory()
        {
            return _productDal.TotalPriceByDrinkCategory();
        }

        public void TUpdate(Product entity)
		{
			 _productDal.Update(entity);
		}
	}
}
