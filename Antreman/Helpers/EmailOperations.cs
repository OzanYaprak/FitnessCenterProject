using System.Text;

namespace Antreman.Helpers
{
    public class EmailOperations
    {
        public static void SendActivationMail(string toEmail)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(toEmail);
            mail.From = new System.Net.Mail.MailAddress("getirucuz@hotmail.com");
            mail.Subject = "dermaapi.com Kullanıcı Aktivasyon";
            mail.SubjectEncoding= System.Text.Encoding.UTF8;


            string linkk = "https://localhost:7213/Hesap/Aktivasyon?kkk=" + Criyptoo.Encrypted(toEmail);


            var HtmlBody = new StringBuilder();
            HtmlBody.AppendFormat("Hoşgeldiniz, {0}\n", "Sevgili Kullanıcımız");
            HtmlBody.AppendLine(@"Hesabınızı Aktif Etmek İçin Lütfen Aşağıdaki Bağlantıya Tıklayınız.");
            HtmlBody.AppendLine("<a href=\"" + linkk + "\">Aktivasyon</a>");
            mail.Body = HtmlBody.ToString();
            mail.BodyEncoding= System.Text.Encoding.UTF8;
            mail.IsBodyHtml= true;
            mail.Priority= System.Net.Mail.MailPriority.Normal;

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Host = "smtp.office365.com";
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("getirucuz@hotmail.com", "ucuzgetir123");
            client.EnableSsl = false;

            try 
            {
                client.Send(mail);
            }
            catch(Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2!= null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
            }
        }
    }
}
