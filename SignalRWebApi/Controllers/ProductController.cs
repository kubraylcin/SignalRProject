using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
	
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;

		public object Description { get; private set; }

		public ProductController(IProductService productService, IMapper mapper)
		{
			_productService = productService;
			_mapper = mapper;
		}

		// Tüm ürünleri listele (GET)
		[HttpGet]
		public IActionResult ProductList()
		{
			var productList = _productService.TGetListAll();
			var result = _mapper.Map<List<ResultProductDto>>(productList);
			return Ok(result);
		}
		[HttpGet("ProductCount")]
		public IActionResult ProductCount() 
		{ 
			return Ok(_productService.TProductCount());
		}
		[HttpGet("ProducCountByHamburger")]
		public IActionResult ProducCountByHamburger()
		{
			return Ok(_productService.TProducCountByNameHamburger());
		}
		[HttpGet("ProducCountByDrink")]
		public IActionResult ProducCountByDrink()
		{
			return Ok(_productService.TProducCountByNameDrink());
		}
		[HttpGet("ProductPriceAvg")]
		public IActionResult ProductPriceAvg()
		{
			return Ok(_productService.TProductPriceAvg());
		}
		[HttpGet("ProductNamePriceMax")]
		public IActionResult ProductPriceMax()
		{
			return Ok(_productService.TProductNamePriceMax());
		}
		[HttpGet("ProductNamePriceMin")]
		public IActionResult ProductPriceMin()
		{
			return Ok(_productService.TProductNamePriceMin());
		}

		[HttpGet("ProductPriceByHamburger()")]
		public IActionResult ProductPriceByHamburger()
		{
			return Ok(_productService.TProductPriceByHamburger());
		}

		[HttpGet("ProductListWithCategory")]
		public IActionResult ProductListWithCategroy()
		{
			var context = new SignalRContext();
			var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory
			{
				Description = y.Description,
				ImageUrl = y.ImageUrl,
				Price = y.Price,
				ProductId = y.ProductId,
				ProductName = y.ProductName,
				ProductStatus = y.ProductStatus,
				CategoryName = y.Category.CategoryName,
			});
			return Ok(values.ToList());
		}

		// Yeni bir ürün oluştur (POST)
		[HttpPost]
		public IActionResult CreateProduct(CreateProductDto createProductDto)
		{
			var product = _mapper.Map<Product>(createProductDto);
			_productService.TAdd(product);
			return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, "Ürün başarıyla eklendi");
		}

		// Var olan bir ürünü güncelle (PUT)
		[HttpPut("{id}")]
		public IActionResult UpdateProduct(int id, UpdateProductDto updateProductDto)
		{
			_productService.TUpdate(new Product()
			{
				Description = updateProductDto.Description,
				ImageUrl = updateProductDto.ImageUrl,
				Price = updateProductDto.Price,
				ProductId = updateProductDto.ProductId,
				ProductName = updateProductDto.ProductName,
				ProductStatus = updateProductDto.ProductStatus,
				CategoryId= updateProductDto.CategoryId,

			});
			return Ok("ürün  bilgisi güncellendi ");
		}

		// Bir ürünü sil (DELETE)
		[HttpDelete("{id}")]
		public IActionResult DeleteProduct(int id)
		{
			var product = _productService.TGetById(id);
			if (product == null)
			{
				return NotFound("Ürün bulunamadı");
			}
			_productService.TDelete(product);
			return Ok("Ürün başarıyla silindi");
		}

		// Belirli bir ürünü id'ye göre getir (GET)
		[HttpGet("{id}")]
		public IActionResult GetProduct(int id)
		{
			var product = _productService.TGetById(id);
			if (product == null)
			{
				return NotFound("Ürün bulunamadı");
			}
			var result = _mapper.Map<ResultProductDto>(product);
			return Ok(result);
		}
	}
}