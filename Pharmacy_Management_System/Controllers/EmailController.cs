using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using Pharmacy_Management_System.Model;
using System.Collections.Generic;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pharmacy_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        // : api/<EmailController>
        [HttpPost ("SendingEmail")]
        public IActionResult EmailSending(List<Orders> data_table)
        {
            double totalamount = 0;
            string textBody = "<p> Hello Doctor, </p> <p>Thank you for ordering from Pharmacy Management system.</p> <p>We’re happy to let you know that we’ve received your order.</p> <p>Once your order is approved by admin, we will send you an email " +
                "with a tracking number and link so you can see the movement of your order.</p>";
            textBody += " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + "><tr bgcolor='#4da6ff'><td><b>Drug Name</b></td> <td> <b> Drug Quantity</b> </td> <td> <b> Unit Price</b> </td> <td> <b>Total Amount</b> </td></tr>";
            for (int loopCount = 0; loopCount < data_table.Count; loopCount++)
            {
                textBody += "<tr><td>" + data_table[loopCount].DrugsName + "</td><td> " + data_table[loopCount].DrugQuantity + "</td><td> " + data_table[loopCount].DrugPrice + "</td><td> " + Convert.ToInt32(data_table[loopCount].TotalAmount) + "</td> </tr>";
                totalamount += data_table[loopCount].TotalAmount;
            }
            textBody += "</table> <br>";
            textBody += "<strong>Order Date :</strong>";
            textBody += data_table[0].PickupDate.ToShortDateString();
            textBody += "<br><strong>Total Order Amount :</strong>";
            textBody += totalamount;
            textBody += "<br><i>If you have any questions, contact us here on <b>vtu14218@veltech.edu.in</b>! " +
                "We are here to help you! </i>";
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("annam neeraj", "vtu14698@veltech.edu.in")); 
            message.To.Add(new MailboxAddress("Doctor", data_table[0].DoctorId));
            message.Subject = "Order Placed";
            message.Body = new TextPart("html")
            {
                Text = textBody
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
