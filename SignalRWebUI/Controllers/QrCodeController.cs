﻿using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace SignalRWebUI.Controllers
{
	public class QrCodeController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(string value)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				QRCodeGenerator qrGenerator = new QRCodeGenerator();
				QRCodeData qrCodeData = qrGenerator.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
				QRCode qrCode = new QRCode(qrCodeData);

				using (Bitmap qrCodeImage = qrCode.GetGraphic(10))
				{
					qrCodeImage.Save(memoryStream, ImageFormat.Png);
					ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
				}
			}
			return View();
		}
	}
}
