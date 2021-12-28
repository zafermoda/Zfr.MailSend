using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Zfr.MailSend.Abstract;

namespace Zfr.MailSend.Concrete
{
    public class EmailSend : IEmailSend
    {
        public IConfiguration _configuration { get; }

        public EmailSend(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmailConfirmationCodeWithGmail(string subject, string body, List<MailAddress> toMailList)
        {
            try
            {
                var mailHost = _configuration.GetSection("Email")["MailHost"];
                var mailPort = Convert.ToInt32(_configuration.GetSection("Eposta")["MailPort"]);
                var mailUser = _configuration.GetSection("Email")["MailUser"];
                var mailPass = _configuration.GetSection("Email")["MailPass"];

                #region add to appsettings.json file
                /* add this code to appsettings.json 
                "Email": {
                    "MailHost": "smtp.gmail.com",
                    "MailPort": "587",
                    "MailUser": "youremailaddress@gmail.com",
                    "MailPass": "*********"
                }
                */
                #endregion

                var message = new MailMessage();
                message.From = new MailAddress(mailUser);

                toMailList.ForEach(x =>
                {
                    message.To.Add(new MailAddress(x.Address, x.DisplayName));
                });

                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;

                using var smtp = new SmtpClient(
                    mailHost,
                    mailPort);
                smtp.EnableSsl = true;
                smtp.Credentials =
                    new NetworkCredential(
                        mailUser,
                        mailPass);

                smtp.Send(message);
            }
            catch (Exception)
            {

            }
        }
    }
}
