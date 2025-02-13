using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;


namespace SignalRWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;

		public CategoryController(ICategoryService categoryService, IMapper mapper)
		{
			_categoryService = categoryService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult CategoryList()
		{
			var categories = _categoryService.TGetListAll();
			var result = _mapper.Map<List<ResultCategoryDto>>(categories);
			return Ok(result);
		}

		[HttpPost]
		public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
		{
			var category = _mapper.Map<Category>(createCategoryDto);
			category.Status = true; // Varsayılan olarak aktif eklenmesini sağladım.
			_categoryService.TAdd(category);
			return Ok("Kategori eklendi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteCategory(int id)
		{
			var category = _categoryService.TGetById(id);
			if (category == null)
			{
				return NotFound("Kategori bulunamadı");
			}
			_categoryService.TDelete(category);
			return Ok("Kategori silindi");
		}

		[HttpGet("{id}")]
		public IActionResult GetCategory(int id)
		{
			var category = _categoryService.TGetById(id);
			if (category == null)
			{
				return NotFound("Kategori bulunamadı");
			}
			var result = _mapper.Map<ResultCategoryDto>(category);
			return Ok(result);
		}

		[HttpPut]
		public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
		{
			var category = _categoryService.TGetById(updateCategoryDto.CategoryId);
			if (category == null)
			{
				return NotFound("Kategori bulunamadı");
			}

			_mapper.Map(updateCategoryDto, category);
			_categoryService.TUpdate(category);
			return Ok("Kategori güncellendi");
		}
	}
}
