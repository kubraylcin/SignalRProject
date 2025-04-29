using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SliderController : ControllerBase
	{
		private readonly ISliderService _sliderService;
		private readonly IMapper _mapper;

		public SliderController(ISliderService sliderService, IMapper mapper)
		{
            _sliderService = sliderService;
			_mapper = mapper;
		}

		// Tüm özellikleri listele
		[HttpGet]
		public IActionResult SliderList()
		{
			var sliderList = _sliderService.TGetListAll();
			var result = _mapper.Map<List<ResultSliderDto>>(sliderList);
			return Ok(result);
		}

		// Belirli bir özelliği id'ye göre getir
		[HttpGet("{id}")]
		public IActionResult GetSlider(int id)
		{
			var slider = _sliderService.TGetById(id);
			if (slider == null)
			{
				return NotFound("Öne Çıkan Bilgisi bulunamadı");
			}
			var result = _mapper.Map<ResultSliderDto>(slider);
			return Ok(result);
		}

		// Yeni bir özellik oluştur
		[HttpPost]
		public IActionResult CreateSlider(CreateSliderDto createSliderDto)
		{
			var slider = _mapper.Map<Slider>(createSliderDto);
            _sliderService.TAdd(slider);
			return CreatedAtAction(nameof(GetSlider), new { id = slider.SliderId }, "Özellik başarıyla eklendi");
		}

		// Var olan bir özelliği güncelle
		[HttpPut("{id}")]
		public IActionResult UpdateSlider(int id, UpdateSliderDto updateSliderDto)
		{
			var slider = _sliderService.TGetById(id);
			if (slider == null)
			{
				return NotFound("Güncellenecek Öne Çıkan bulunamadı");
			}

			_mapper.Map(updateSliderDto, slider);
            _sliderService.TUpdate(slider);
			return Ok("Öne Çıkanlar başarıyla güncellendi");
		}

		// Bir özelliği sil
		[HttpDelete("{id}")]
		public IActionResult DeleteSlider(int id)
		{
			var slider = _sliderService.TGetById(id);
			if (slider == null)
			{
				return NotFound("Öne Çıkanlar bulunamadı");
			}
			_sliderService.TDelete(slider);
			return Ok("Öne Çıkanlar başarıyla silindi");
		}
	}
}
