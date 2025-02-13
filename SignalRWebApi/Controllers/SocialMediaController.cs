using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SocialMediaController : ControllerBase
	{
		private readonly ISocialMediaService _socialMediaService;
		private readonly IMapper _mapper;

		public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
		{
			_socialMediaService = socialMediaService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult SocialMediaList()
		{
			var socialMediaList = _socialMediaService.TGetListAll();
			var result = _mapper.Map<List<ResultSocialMediaDto>>(socialMediaList);
			return Ok(result);
		}

		[HttpPost]
		public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
		{
			var socialMedia = _mapper.Map<SocialMedia>(createSocialMediaDto);
			_socialMediaService.TAdd(socialMedia);
			return CreatedAtAction(nameof(GetSocialMedia), new { id = socialMedia.SocialMediaId }, "Sosyal medya bilgisi başarıyla eklendi");
		}

		[HttpPut("{id}")]
		public IActionResult UpdateSocialMedia(int id, UpdateSocialMediaDto updateSocialMediaDto)
		{
			var socialMedia = _socialMediaService.TGetById(id);
			if (socialMedia == null)
			{
				return NotFound("Güncellenecek sosyal medya bilgisi bulunamadı");
			}

			_mapper.Map(updateSocialMediaDto, socialMedia);
			_socialMediaService.TUpdate(socialMedia);
			return Ok("Sosyal medya bilgisi başarıyla güncellendi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteSocialMedia(int id)
		{
			var socialMedia = _socialMediaService.TGetById(id);
			if (socialMedia == null)
			{
				return NotFound("Sosyal medya bilgisi bulunamadı");
			}
			_socialMediaService.TDelete(socialMedia);
			return Ok("Sosyal medya bilgisi başarıyla silindi");
		}

		[HttpGet("{id}")]
		public IActionResult GetSocialMedia(int id)
		{
			var socialMedia = _socialMediaService.TGetById(id);
			if (socialMedia == null)
			{
				return NotFound("Sosyal medya bilgisi bulunamadı");
			}
			var result = _mapper.Map<ResultSocialMediaDto>(socialMedia);
			return Ok(result);
		}
	}
}
