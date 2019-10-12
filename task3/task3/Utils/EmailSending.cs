using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace task3.Utils
{
    public class EmailSending
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents,String filename,String path)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("524670545@qq.com", "FIT5032 Example Email User");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var bytes = File.ReadAllBytes(path);
            var transfer = Convert.ToBase64String(bytes);
            msg.AddAttachment(filename, transfer);
            var response = client.SendEmailAsync(msg);
        }

        internal void Send(string toEmail, string subject, string contents)
        {
            throw new NotImplementedException();
        }
    }
}