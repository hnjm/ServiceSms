using ServiceSms.Model;
using System.Text.RegularExpressions;

namespace ServiceSms.Controllers
{
    public interface ISmsRepository
    {
        Task<List<Sms>> ConvertSmsAsync(string to, string message);

    }
    public class SmsVendorGR : ISmsRepository
    {
        public async Task<List<Sms>> ConvertSmsAsync(string to, string message)
        {
            if (Regex.Match(message, @"^[α-ωΑ-Ω]*").Success)
            {
                List<Sms> smsList = new List<Sms>();
                var newSms= new Sms()
                {
                    Id = to,
                    NumOfLine=1,
                    RecTime = DateTime.UtcNow,
                    MessageBody = message,
                };
                smsList.Add(newSms);
                
                return smsList;
            }
            return null;
        }
    }

    public class SmsVendorCy : ISmsRepository
    {
        public async Task<List<Sms>> ConvertSmsAsync(string to, string message)
        {
            int length = 160;
            List<Sms> smsList = new List<Sms>();
            short count =  1;
            for (int i = 0; i < message.Length; i += length)
            {
                int remainingLength = message.Length - i;
                int currentLength = remainingLength < length ? remainingLength : length;
                var newSms = new Sms()
                {
                    Id = to,
                    NumOfLine = count++,
                    RecTime = DateTime.UtcNow,
                    MessageBody= message.Substring(i, currentLength)

                };
                 smsList.Add(newSms);
            }
            return smsList;
        }
    }

    public class SmsVendorRest : ISmsRepository
    {
        public async Task<List<Sms>> ConvertSmsAsync(string to, string message)
        {
            List<Sms> smsList = new List<Sms>();
            var newSms = new Sms()
            {
                Id = to,
                NumOfLine = 1,
                RecTime = DateTime.UtcNow,
                MessageBody = message
            };
            smsList.Add(newSms);

            return smsList;
            ;
        }
    }


}
