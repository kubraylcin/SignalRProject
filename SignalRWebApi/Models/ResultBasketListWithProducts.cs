using SignalR.EntityLayer.Entities;

namespace SignalRWebApi.Models
{
    public class ResultBasketListWithProducts
    {
        public int BasketId { get; set; }
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public int TableNumberId { get; set; }
        public string ProductName { get; set; }
    }
}
