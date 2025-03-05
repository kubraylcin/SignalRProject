using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
	public class ProgressBars : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
