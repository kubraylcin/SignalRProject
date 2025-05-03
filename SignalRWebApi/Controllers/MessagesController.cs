using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessagesController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var messageList = _messageService.TGetListAll();
            var result = _mapper.Map<List<ResultMessageDto>>(messageList);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            var message = _mapper.Map<Message>(createMessageDto);
            _messageService.TAdd(message);
            return CreatedAtAction(nameof(GetMessage), new { id = message.MessageId }, "Mesaj bilgisi eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var message = _messageService.TGetById(id);
            if (message == null)
            {
                return NotFound("Mesaj bilgisi bulunamadı");
            }
            _messageService.TDelete(message);
            return Ok("Mesaj bilgisi silindi");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var message = _messageService.TGetById(updateMessageDto.MessageId);
            if (message == null)
            {
                return NotFound("Güncellenecek mesaj bilgisi bulunamadı");
            }

            _mapper.Map(updateMessageDto, message);
            _messageService.TUpdate(message);
            return Ok("Mesaj bilgisi güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var message = _messageService.TGetById(id);
            if (message == null)
            {
                return NotFound("Mesaj bilgisi bulunamadı");
            }
            var result = _mapper.Map<ResultMessageDto>(message);
            return Ok(result);
        }
    }
}
