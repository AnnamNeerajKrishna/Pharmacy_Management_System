using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pharmacy_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        // : api/<EmailController>
        [HttpGet("Sending Email")]
        public IActionResult EmailSending(string name,string emailID)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("annam neeraj", "vtu14698@veltech.edu.in")); 
            message.To.Add(new MailboxAddress(name, emailID));
            message.Subject = "test mail from the asp.net core";
            message.Body = new TextPart("plain")
            {
                Text = "Hello you received this mail from vtu14698"
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("vtu14698@veltech.edu.in","14698@veltech");
                client.Send(message);
                client.Disconnect(true);
            }

            return Ok("Email sent Successfully");
        }


    }
}
