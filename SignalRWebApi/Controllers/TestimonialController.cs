using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialController : ControllerBase
	{
		private readonly ITestimonialService _testimonialService;
		private readonly IMapper _mapper;

		public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
		{
			_testimonialService = testimonialService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult TestimonialList()
		{
			var testimonialList = _testimonialService.TGetListAll();
			var result = _mapper.Map<List<ResultTestimonialDto>>(testimonialList);
			return Ok(result);
		}

		[HttpPost]
		public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
		{
			var testimonial = _mapper.Map<Testimonial>(createTestimonialDto);
			_testimonialService.TAdd(testimonial);
			return CreatedAtAction(nameof(GetTestimonial), new { id = testimonial.TestimonialId }, "Testimonial başarıyla eklendi");
		}

		[HttpPut("{id}")]
		public IActionResult UpdateTestimonial(int id, UpdateTestimonialDto updateTestimonialDto)
		{
			var testimonial = _testimonialService.TGetById(id);
			if (testimonial == null)
			{
				return NotFound("Güncellenecek testimonial bulunamadı");
			}

			_mapper.Map(updateTestimonialDto, testimonial);
			_testimonialService.TUpdate(testimonial);
			return Ok("Testimonial başarıyla güncellendi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteTestimonial(int id)
		{
			var testimonial = _testimonialService.TGetById(id);
			if (testimonial == null)
			{
				return NotFound("Testimonial bulunamadı");
			}
			_testimonialService.TDelete(testimonial);
			return Ok("Testimonial başarıyla silindi");
		}

		[HttpGet("{id}")]
		public IActionResult GetTestimonial(int id)
		{
			var testimonial = _testimonialService.TGetById(id);
			if (testimonial == null)
			{
				return NotFound("Testimonial bulunamadı");
			}
			var result = _mapper.Map<ResultTestimonialDto>(testimonial);
			return Ok(result);
		}
	}
}
