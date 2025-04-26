using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TableNumberDto;
using SignalR.EntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TableNumberController : ControllerBase
	{
		private readonly ITableNumberService _tableNumberService;
		

		public TableNumberController(ITableNumberService tableNumberService)
		{
			_tableNumberService = tableNumberService;
			
		}

		[HttpGet("TableNumberCount")]
		public IActionResult TableNumberCount() 
		{
			return Ok(_tableNumberService.TTableNumberCount());
		}
		[HttpGet]
		public IActionResult TableNumberList()
		{
			var values = _tableNumberService.TGetListAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateTableNumber(CreateTableNumberDto createTableNumberDto)
		{
			TableNumber tableNumber = new TableNumber()
			{
				
				TableName = createTableNumberDto.TableName,
				Status = false
			
			};
			_tableNumberService.TAdd(tableNumber);
			return Ok("Masa Eklendi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteTableNumber(int id)
		{
			var value = _tableNumberService.TGetById(id);
			_tableNumberService.TDelete(value);
			return Ok("Masa silindi");
		}

		[HttpPut]
		public IActionResult UpdateTableNumber(UpdateTableNumberDto updateTableNumberDto)
		{
			TableNumber TableNumber = new TableNumber()
			{
				
				TableName = updateTableNumberDto.TableName,
				Status = false,
				TableNumberId=updateTableNumberDto.TableNumberId
			};

			_tableNumberService.TUpdate(TableNumber);
			return Ok("Masa bilgisi Güncellendi");
		}
		[HttpGet("{id}")]
		public IActionResult GetTableNumber(int id)
		{
			var value = _tableNumberService.TGetById(id);
			return Ok(value);
		}
	}
}
