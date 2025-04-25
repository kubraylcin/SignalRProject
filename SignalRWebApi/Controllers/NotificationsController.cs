using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationsController : ControllerBase
	{
		private readonly INotificationService _notificationService;

		public NotificationsController(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}

		[HttpGet]
		public IActionResult NotificationList() 
		{
			return Ok(_notificationService.TGetListAll());
		}
		[HttpGet("NotificationCountByStatusFalse")]
		public IActionResult NotificationCountByStatusFalse()
		{
			return Ok(_notificationService.TNotificationCountByStatusFalse());
		}
		[HttpGet("GetAllNotificationByFalse")]
		public IActionResult GetAllNotificationByFalse()
		{
			return Ok(_notificationService.TGetAllNotificationByFalse());
		}
		[HttpPost]
		public IActionResult CreateNotification(CreateNotificationDto createNotificationDto) 
		{
			Notification notification = new Notification()
			{
				Description = createNotificationDto.Description,
				Icon = createNotificationDto.Icon,
				Status= false,
				Type= createNotificationDto.Type,
				Date= Convert.ToDateTime(DateTime.Now.ToShortDateString())
			};
			_notificationService.TAdd(notification);
			return Ok("Ekleeme işlemi başarı ile gerçekleşti");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteNotification(int id)
		{
			var notification = _notificationService.TGetById(id);
			_notificationService.TDelete(notification);
			return Ok("Bildirim alanı bilgisi silindi");
		}

		[HttpGet("{id}")]
		public IActionResult GetNotification(int id)
		{
			var notification = _notificationService.TGetById(id);
			return Ok(notification);
		}
		[HttpPut]
		public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
		{
			Notification notification = new Notification()
			{
				NotificationId = updateNotificationDto.NotificationId,
				Description = updateNotificationDto.Description,
				Icon = updateNotificationDto.Icon,
				Status = updateNotificationDto.Status,
				Type = updateNotificationDto.Type,
				Date = updateNotificationDto.Date
			};
			_notificationService.TUpdate(notification);
			return Ok("Güncelleme işlemi başarı ile gerçekleşti");
		}
	}
}
