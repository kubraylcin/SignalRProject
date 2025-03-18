using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalRWebApi.Models;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly  IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        [HttpGet]
        public IActionResult GetBasketsByTableNumber(int id) 
        { 
            var  values = _basketService.TGetBasketsByTableNumber(id);
            return Ok(values);
        }
        [HttpGet("BasketListByTableNumberWithProductName")]
        public IActionResult BasketListByTableNumberWithProductName (int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Include(x => x.Product).Where(y => y.TableNumberId == id).Select(z => new ResultBasketListWithProducts
            {
                BasketId = z.BasketId,
                Count = z.Count,
                TableNumberId = z.TableNumberId,
                Price = z.Price,
                ProductId = z.ProductId,
                ProductName = z.Product.ProductName,
                TotalPrice = z.TotalPrice,
            }).ToList();
            return Ok(values);
        }
    }
}
