# Zfr.MailSend
Sending email from gmail email address

# Add this code to appsettings.json

    "Email": {
    
      "MailHost": "smtp.gmail.com",

      "MailPort": "587",

      "MailUser": "youremailaddress@gmail.com",

      "MailPass": "*********"
    
    }

# Dependency injection

To Startup.cs

  We add it inside the ConfigureServices method:
  
    services.AddScoped<IEmailSend, EmailSend>();
    
To controller

    private readonly IEmailSend _emailSend;
    
    public HomeController(IEmailSend emailSend)
    {            
        _emailSend = emailSend;
    }

# Use

    _emailSend.SendEmailConfirmationCodeWithGmail(string subject, string body, List<MailAddress> toMailList);
    
    or
    
    _emailSend.SendEmailConfirmationCodeWithGmail(MailModel model);
