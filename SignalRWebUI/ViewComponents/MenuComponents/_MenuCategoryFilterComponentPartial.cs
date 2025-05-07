using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;
using System.Net.Http;

namespace SignalRWebUI.ViewComponents.MenuComponents
{
    public class _MenuCategoryFilterComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _MenuCategoryFilterComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7087/api/Category");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);//JSON verisini bir C# nesnesine çevirmek için resultCategoryDto sınıfını oluşturduk
                return View(values);//deserialize = json bir datayı çözerken kullanılan yöntem
            }
            return View();
        }
    }
}
