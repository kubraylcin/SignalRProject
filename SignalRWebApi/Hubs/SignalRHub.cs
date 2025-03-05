﻿using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRWebApi.Hubs
{
    //hub sunucu görevi görecek dağıtım işlemi hubs sınıfı hnagisiyse onun üzeirnden yapıcaz
    public class SignalRHub:Hub
    {

		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;

		public SignalRHub(ICategoryService categoryService, IProductService productService)
		{
			_categoryService = categoryService;
			_productService = productService;
		}

		public async Task SendCategoryCount() // client tarafında gelince bu methot  ınvoke ile  çağrılacak 
        {
            var value = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", value); //bu method içindeki ReceiveCategoryCount kullan 
        }

		public async Task SendProductCount()
		{
			var value2= _productService.TProductCount();
			await Clients.All.SendAsync("ReceiveProductCount", value2);
		}
		public async Task  ActivePassiveCategoryCount()
		{
			var value3= _categoryService.TActiveCategoryCount();
			var value4= _categoryService.TPassiveCategoryCount();
			await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3);
			await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);
		}
    }
}
