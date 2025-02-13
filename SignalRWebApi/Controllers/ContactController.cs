using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private readonly IContactService _contactService;
		private readonly IMapper _mapper;

		public ContactController(IContactService contactService, IMapper mapper)
		{
			_contactService = contactService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult ContactList()
		{
			var contactList=_contactService.TGetListAll();
			var result= _mapper.Map<List<ResultContactDto>>(contactList);
			return Ok(result);
		}
		[HttpPost]
		public IActionResult CreateContact(CreateContactDto createContactDto)
		{
			var contact= _mapper.Map<Contact>(createContactDto);
			_contactService.TAdd(contact);
			return Ok("İletişim bilgisi eklendi");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteContact(int id)
		{
			var contact = _contactService.TGetById(id);
			if (contact == null)
			{
				return NotFound("İletişim bilgisi bulunamadı");
			}
			_contactService.TDelete(contact);
			return Ok("İletişim bilgisi silindi.");
		}
		[HttpPut]
		public IActionResult UpdateContact(UpdateContactDto updateContactDto)
		{
			var contact = _contactService.TGetById(updateContactDto.ContactId);
            if (contact==null)
            {
				return NotFound("Güncellenecek iletişim bilgisi bulunamadı");
            }
			_mapper.Map(updateContactDto , contact);
			_contactService.TUpdate(contact);
			return Ok("İletişim bilgisi güncellendi ");
        }
		[HttpGet("{id}")]
		public IActionResult GetContact(int id)
		{
			var contact = _contactService.TGetById(id);
			if (contact == null)
			{
				return NotFound("İletişim Bilgisi bulunamadı");
			}
			var result = _mapper.Map<ResultContactDto>(contact);
			return Ok(result);
		}
	}
}
