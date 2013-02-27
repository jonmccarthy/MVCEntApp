using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Text;

namespace PizzaStore.WebUI.Models
{
    public class EmailCustomer
    {
        public EmailCustomer()
        {
 
        }

        public void SendCustEmail(string fname, string emailaddress, int CustID)
        {
            using (var smtpClient = new SmtpClient())
            using (var mailMessage = BuildMailMessage(fname, emailaddress, CustID))
            {
                smtpClient.Send(mailMessage);
            }
        }

        private MailMessage BuildMailMessage(string fname, string emailaddress, int CustID)
        {
            StringBuilder body = new StringBuilder();
            body.AppendLine("Hi " + fname + ",");
            body.AppendLine("Thank you for signing up to Pizza.com");
            body.AppendLine("");
            body.AppendLine("We hope you enjoy using our on-line ordering service.");
            body.AppendLine("After you place your first order we will mail you order discount codes for future orders!");
            body.AppendLine("");
            body.AppendLine("If you need to update your details, please click on this link http://localhost:49209/customer/Display?id=" + CustID);
            body.AppendLine("");
            body.AppendLine("If there is anything we can help with, please don't hesitate to contact us!");
            body.AppendLine("");
            body.AppendLine("Thanks,");
            body.AppendLine("The Pizza Team!");
            return new MailMessage("jonathan.mccarthy.ire@gmail.com",   // From
                                   emailaddress,                      // To
                                   "Pizza Account Activated!",      // Subject
                                   body.ToString());            // Body
        }
    }
}