using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeatureController : ControllerBase
	{
		private readonly IFeatureService _featureService;
		private readonly IMapper _mapper;

		public FeatureController(IFeatureService featureService, IMapper mapper)
		{
			_featureService = featureService;
			_mapper = mapper;
		}

		// Tüm özellikleri listele
		[HttpGet]
		public IActionResult FeatureList()
		{
			var featureList = _featureService.TGetListAll();
			var result = _mapper.Map<List<ResultFeatureDto>>(featureList);
			return Ok(result);
		}

		// Belirli bir özelliği id'ye göre getir
		[HttpGet("{id}")]
		public IActionResult GetFeature(int id)
		{
			var feature = _featureService.TGetById(id);
			if (feature == null)
			{
				return NotFound("Öne Çıkan Bilgisi bulunamadı");
			}
			var result = _mapper.Map<ResultFeatureDto>(feature);
			return Ok(result);
		}

		// Yeni bir özellik oluştur
		[HttpPost]
		public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
		{
			var feature = _mapper.Map<Feature>(createFeatureDto);
			_featureService.TAdd(feature);
			return CreatedAtAction(nameof(GetFeature), new { id = feature.FeatureId }, "Özellik başarıyla eklendi");
		}

		// Var olan bir özelliği güncelle
		[HttpPut("{id}")]
		public IActionResult UpdateFeature(int id, UpdateFeatureDto updateFeatureDto)
		{
			var feature = _featureService.TGetById(id);
			if (feature == null)
			{
				return NotFound("Güncellenecek Öne Çıkan bulunamadı");
			}

			_mapper.Map(updateFeatureDto, feature);
			_featureService.TUpdate(feature);
			return Ok("Öne Çıkanlar başarıyla güncellendi");
		}

		// Bir özelliği sil
		[HttpDelete("{id}")]
		public IActionResult DeleteFeature(int id)
		{
			var feature = _featureService.TGetById(id);
			if (feature == null)
			{
				return NotFound("Öne Çıkanlar bulunamadı");
			}
			_featureService.TDelete(feature);
			return Ok("Öne Çıkanlar başarıyla silindi");
		}
	}
}
