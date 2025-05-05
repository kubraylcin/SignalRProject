using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.Dtos.MailDtos;


namespace SignalRWebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Restoran Projesi","kubrayalcin.272@gmail.com" );
            mimeMessage.From.Add(mailboxAddressFrom); //mail kimden gidiyor 

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", createMailDto.ReceiveMail);
            mimeMessage.To.Add(mailboxAddressTo); //mail kime gidiyor 

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = createMailDto.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody(); //mail içeriğini ekle

            mimeMessage.Subject = createMailDto.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com",587,false);
            client.Authenticate("kubrayalcin.272@gmail.com", "rtir gbpg ioer gsbc");

            client.Send(mimeMessage);
            client.Disconnect(true);

            return RedirectToAction("Index", "Category");
        }
    }
}
