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

        // Get all testimonials
        [HttpGet]
        public IActionResult TestimonialList()
        {
            var value = _testimonialService.TGetListAll();
            var dtoList = _mapper.Map<List<ResultTestimonialDto>>(value);
            return Ok(dtoList);
        }

        // Create new testimonial
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var testimonial = _mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.TAdd(testimonial);
            return Ok("Müşteri Yorum Bilgisi Eklendi");
        }

        // Delete testimonial
        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            if (value == null)
            {
                return NotFound("Müşteri Yorum Bulunamadı");
            }
            _testimonialService.TDelete(value);
            return Ok("Müşteri Yorum Silindi");
        }

        // Get a single testimonial by ID
        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            if (value == null)
            {
                return NotFound("Müşteri Yorum Bulunamadı");
            }
            var dto = _mapper.Map<ResultTestimonialDto>(value);
            return Ok(dto);
        }

        // Update testimonial
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var testimonial = _mapper.Map<Testimonial>(updateTestimonialDto);
            _testimonialService.TUpdate(testimonial);
            return Ok("Müşteri Yorum Bilgisi Güncellendi");
        }
    }
}
