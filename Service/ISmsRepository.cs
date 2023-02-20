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
                {To = to,
                    Enno=1,
                    Timestamp = DateTime.UtcNow() 
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
            List<string> substrings = new List<string>();
            List<Sms> smsList = new List<Sms>();
            int count =  1;
            for (int i = 0; i < message.Length; i += length)
            {
                int remainingLength = message.Length - i;
                int currentLength = remainingLength < length ? remainingLength : length;
                substrings.Add(message.Substring(i, currentLength));
                var newSms = new Sms()
                {
                    To = to,
                    Enno = (short)count++,
                    Timestamp = DateTime.UtcNow()
                };
                 smsList.Add(newSms);
            }
            return smsList;
        }
    }

    public class SmsVendorOther : ISmsRepository
    {
        public async Task<List<Sms>> ConvertSmsAsync(string to, string message)
        {

            return null;
        }
    }


}
