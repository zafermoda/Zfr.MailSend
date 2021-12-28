using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Zfr.MailSend.Abstract
{
    public interface IEmailSend
    {
        void SendEmailConfirmationCodeWithGmail(string subject, string body, List<MailAddress> mailList);
    }
}
