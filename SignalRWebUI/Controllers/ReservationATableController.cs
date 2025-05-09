using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SignalRWebUI.Dtos.ReservationDtos;
using System.Net.Http;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class ReservationATableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7087/api/Contact");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var item = JArray.Parse(responseBody);
            string value = item[0]["location"]?.ToString();
            ViewBag.location = value;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
        {
            using var client2 = new HttpClient();
            var response = await client2.GetAsync("https://localhost:7087/api/Contact");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var item = JArray.Parse(responseBody);
            string value = item[0]["location"]?.ToString();
            ViewBag.location = value;

            if (!ModelState.IsValid)
            {
                return View(createReservationDto);
            }

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createReservationDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7087/api/Reservation", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            else
            {
                var errorContent = await responseMessage.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, errorContent);
                return View(createReservationDto);
            }
        }
    }
}
