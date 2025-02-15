using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class CategoryController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public CategoryController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client= _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7087/api/Category");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData= await responseMessage.Content.ReadAsStringAsync();
				var values= JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);//JSON verisini bir C# nesnesine çevirmek için resultCategoryDto sınıfını oluşturduk
				return View(values);//deserialize = json bir datayı çözerken kullanılan yöntem
			}
			return View();
		}
		[HttpGet]
		public IActionResult CreateCategory()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto) 
		{
			createCategoryDto.Status = true;
			var client = _httpClientFactory.CreateClient();
			var jsonData=JsonConvert.SerializeObject(createCategoryDto);
			StringContent stringContent = new StringContent(jsonData,Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7087/api/Category",stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteCategory(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7087/api/Category/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateCategory(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7087/api/Category/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var category = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
				return View(category);
			}

			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateCategory( UpdateCategoryDto updateCategoryDto)
		{
			// API'ye güncellenmiş veriyi gönder
			updateCategoryDto.Status = true; // Varsayılan bir durum
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PutAsync($"https://localhost:7087/api/Category/", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index"); // Güncelleme başarılı ise listeye geri dön
			}

			return View(); // Hata olursa formu tekrar göster
		}
	}
}

