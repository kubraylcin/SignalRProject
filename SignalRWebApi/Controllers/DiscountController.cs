﻿using AutoMapper;
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
			var value = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
			return Ok(value);
		}

		[HttpPost]
		public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
		{
			_discountService.TAdd(new Discount()
			{

				Amount = createDiscountDto.Amount,
				Description = createDiscountDto.Description,
				ImageUrl = createDiscountDto.ImageUrl,
				Title = createDiscountDto.Title,
				Status = false
			}); 

			return Ok("İndirim Bilgisi Eklendi");
		}

		[HttpDelete("{id}")]

		public IActionResult DeleteDiscount(int id)
		{
			var value = _discountService.TGetById(id);
			_discountService.TDelete(value);
			return Ok("İndirim bilgisi Silindi");
		}
		[HttpPut]
		public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
		{
			_discountService.TUpdate(new Discount()
			{
				
				Amount = updateDiscountDto.Amount,
				Description = updateDiscountDto.Description,
				ImageUrl = updateDiscountDto.ImageUrl,
				Title = updateDiscountDto.Title,
				DiscountId = updateDiscountDto.DiscountId,
				Status=false
			});

			return Ok("İndirim Bilgisi Güncellendi");
		}
		[HttpGet("{Id}")]
		public IActionResult GetDiscount(int Id)
		{
			var value = _discountService.TGetById(Id);

			return Ok(value);
		}

		[HttpGet("ChangeStatusToTrue/{id}")]
		public IActionResult ChangeStatusToTrue(int id)
		{
			_discountService.TChangeStatusToTrue(id);
			return Ok("Ürün İndirimi Aktif Hale Getirildi");
		}
		[HttpGet("ChangeStatusToFalse/{id}")]
		public IActionResult ChangeStatusToFalse(int id)
		{
			_discountService.TChangeStatusToFalse(id);
			return Ok("Ürün İndirimi Pasif Hale Getirildi");
		}
        [HttpGet("GetListByStatusTrue")]
        public IActionResult GetListByStatusTrue()
        {
            _discountService.TGetListByStatusTrue();
            return Ok(_discountService.TGetListByStatusTrue());
        }
    }
}
