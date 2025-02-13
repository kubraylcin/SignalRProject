using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DiscountController : ControllerBase
	{
		private readonly IDiscountService _discountService;
		private readonly IMapper _mapper;

		public DiscountController(IDiscountService discountService, IMapper mapper)
		{
			_discountService = discountService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult DiscountList()
		{
			var discountList = _discountService.TGetListAll();
			var result = _mapper.Map<List<ResultDiscountDto>>(discountList);
			return Ok(result);
		}
		[HttpPost]
		public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
		{
			var discount = _mapper.Map<Discount>(createDiscountDto);
			_discountService.TAdd(discount);
			return Ok("İndirimler eklendi");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteDiscount(int id)
		{
			var discount = _discountService.TGetById(id);
			if (discount == null)
			{
				return NotFound("İndirim bulunamadı");
			}
			_discountService.TDelete(discount);
			return Ok("İndirim silindi");
		}

		[HttpPut("{id}")]
		public IActionResult UpdateDiscount(int id, UpdateDiscountDto updateDiscountDto)
		{
			var discount = _discountService.TGetById(id);
			if (discount == null)
			{
				return NotFound("Güncellenecek indirim bulunamadı");
			}

			_mapper.Map(updateDiscountDto, discount);
			_discountService.TUpdate(discount);
			return Ok("İndirim güncellendi");
		}

		[HttpGet("{id}")]
		public IActionResult GetDiscount(int id)
		{
			var discount = _discountService.TGetById(id);
			if (discount == null)
			{
				return NotFound("İndirim bulunamadı");
			}
			var result = _mapper.Map<ResultDiscountDto>(discount);
			return Ok(result);
		}
	}
}
