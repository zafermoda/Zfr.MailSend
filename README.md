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

to Startup.cs

  We add it inside the ConfigureServices method:
  
    services.AddScoped<IEmailSend, EmailSend>();
