using Microsoft.Extensions.Configuration;
using System;
using System.Net.Mail;
using System.IO;


namespace Crm.Comercial.Utility.Email
{
    public class Email
    {
        private readonly IConfiguration _configuration;

        public Email()
        {
            _configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .AddJsonFile("appsettings.Development.json", optional: true)
           .Build(); 
        }
    
        public void EnviarEmail(String msg, String emailDestino)
        {
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            string email = _configuration.GetSection("EndPoint").GetSection("Email").Value;
            string senha = _configuration.GetSection("EndPoint").GetSection("Senha").Value; 

            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(email, senha);
            client.EnableSsl = true;
            client.Credentials = credentials;
            client.TargetName = "smtp-mail.outlook.com";
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(email, string.Empty, System.Text.Encoding.UTF8);
                mail.To.Add(new MailAddress(emailDestino));
                mail.Subject = "Validação de Usuário";
                mail.Body = msg;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;


                client.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
