using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

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
	}
}
