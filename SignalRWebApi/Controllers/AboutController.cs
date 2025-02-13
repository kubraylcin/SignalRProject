using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AboutController : ControllerBase
	{
		private readonly IAboutService _aboutService;
		private readonly IMapper _mapper;

		public AboutController(IAboutService aboutService, IMapper mapper)
		{
			_aboutService = aboutService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult AboutList()
		{
			var aboutList = _aboutService.TGetListAll();
			var result = _mapper.Map<List<ResultAboutDto>>(aboutList);
			return Ok(result);
		}

		[HttpPost]
		public IActionResult CreateAbout(CreateAboutDto createAboutDto)
		{
			var about = _mapper.Map<About>(createAboutDto);
			_aboutService.TAdd(about);
			return CreatedAtAction(nameof(GetAbout), new { id = about.AboutId }, "Hakkımda bilgisi eklendi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteAbout(int id)
		{
			var about = _aboutService.TGetById(id);
			if (about == null)
			{
				return NotFound("Hakkımda bilgisi bulunamadı");
			}
			_aboutService.TDelete(about);
			return Ok("Hakkımda bilgisi silindi");
		}

		[HttpPut]
		public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
		{
			var about = _aboutService.TGetById(updateAboutDto.AboutId);
			if (about == null)
			{
				return NotFound("Güncellenecek hakkımda bilgisi bulunamadı");
			}

			_mapper.Map(updateAboutDto, about);
			_aboutService.TUpdate(about);
			return Ok("Hakkımda bilgisi güncellendi");
		}

		[HttpGet("{id}")]
		public IActionResult GetAbout(int id)
		{
			var about = _aboutService.TGetById(id);
			if (about == null)
			{
				return NotFound("Hakkımda bilgisi bulunamadı");
			}
			var result = _mapper.Map<ResultAboutDto>(about);
			return Ok(result);
		}
	}
}
