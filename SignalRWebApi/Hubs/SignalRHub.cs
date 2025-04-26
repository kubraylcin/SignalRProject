using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRWebApi.Hubs
{
    //hub sunucu görevi görecek dağıtım işlemi hubs sınıfı hnagisiyse onun üzeirnden yapıcaz
    public class SignalRHub:Hub
    {

		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;
		private readonly IOrderService _orderService;
		private readonly IMoneyCaseService _moneyCaseService;
		private readonly ITableNumberService _tableNumberService;
		private readonly IReservationService _reservationService;
		private readonly INotificationService _notificationService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, ITableNumberService tableNumberService, IReservationService reservationService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _tableNumberService = tableNumberService;
            _reservationService = reservationService;
			_notificationService = notificationService;
        }

        public async Task SendStatistic() // client tarafında gelince bu methot  ınvoke ile  çağrılacak 
        {
            var value = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", value); //bu method içindeki ReceiveCategoryCount kullan 

			var value2 = _productService.TProductCount();
			await Clients.All.SendAsync("ReceiveProductCount", value2);

			var value3 = _categoryService.TActiveCategoryCount();
			await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3);

			var value4 = _categoryService.TPassiveCategoryCount();
			await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);

			var values5 = _productService.TProducCountByNameHamburger();
			await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", values5);

			var values6 = _productService.TProducCountByNameDrink();
			await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", values6);

			var values7 = _productService.TProductPriceAvg();
			await Clients.All.SendAsync("ReceiveProductPriceAvg", values7.ToString("0.00") + "₺");

			var values8 = _productService.TProductNamePriceMax();
			await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", values8);

			var values9 = _productService.TProductNamePriceMin();
			await Clients.All.SendAsync("ReceiveProductNameByMinPrice", values9);

			var values10 = _productService.TProductPriceByHamburger();
			await Clients.All.SendAsync("ReceiveProductAvgPriceByHamburger", values10.ToString("0.00" + "₺"));

			var values11 = _orderService.TTotalOrderCount();
			await Clients.All.SendAsync("ReceiveTotalOrderCount", values11);

			var values12 = _orderService.TActiveOrderCount();
			await Clients.All.SendAsync("ReceiveActiveOrderCount", values12);

			var values13 = _orderService.TLastOrderPrice();
			await Clients.All.SendAsync("ReceiveLastOrderPrice", values13.ToString("0.00" + "₺"));

			var values14 = _moneyCaseService.TTotalMoneyCaseAmount();
			await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", values14.ToString("0.00" + "₺"));



			var values16 = _tableNumberService.TTableNumberCount();
			await Clients.All.SendAsync("ReceiveTotalTableNumberCount", values16);
		}
		public async Task SendProgress()
		{
			var value = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value.ToString("0.00")+ "₺");

            var value2 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", value2);

            var value3 = _tableNumberService.TTableNumberCount();
            await Clients.All.SendAsync("ReceiveTableNumberCount", value3);
        }
		public async Task GetReservaitonList()
		{
			var values= _reservationService.TGetListAll();
			await Clients.All.SendAsync("ReceiveReservationList", values);
		}

		public async Task SendNotification()
		{
			var value = _notificationService.TNotificationCountByStatusFalse();
			await Clients.All.SendAsync("ReceiveNotificationCountByFalse", value);

			var natificationListByFalse= _notificationService.TGetAllNotificationByFalse();
			await Clients.All.SendAsync("ReceiveNotificationListByFalse", natificationListByFalse);
		}

		public async Task GetTableNumberStatus()
		{
			var value = _tableNumberService.TGetListAll();
			await Clients.All.SendAsync("ReceiveTableNumberStatus",value);
		}


	}
}
