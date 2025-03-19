using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
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

        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context = new SignalRContext();
            _basketService.TAdd(new Basket()
            {
                ProductId= createBasketDto.ProductId,
                Count = 1,
                TableNumberId = 3,
                Price = context.Products.Where(x => x.ProductId == createBasketDto.ProductId).Select(y => y.Price).FirstOrDefault(),
                TotalPrice= 0
            });
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var basket = _basketService.TGetById(id);
            if (basket == null)
            {
                return NotFound("Böyle bir ürün bulunamadı");
            }
            _basketService.TDelete(basket);
            return Ok("Sepetteki seçilen ürün silindi");

        }
    }
}
