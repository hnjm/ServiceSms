using System.Text.RegularExpressions;

namespace ServiceSms.Controllers
{
    internal interface ISmsRepository
    {
        Task<bool> SendSmsAsync(string to, string message);

    }
    public class SmsVendorGR : ISmsRepository
    {
        public async Task<bool> SendSmsAsync(string to, string message)
        {
            if (Regex.Match(message, @"^[α-ωΑ-Ω]*").Success)
            {
                
            return true;
            }
            return false;
        }
    }

    public class SmsVendorCy : ISmsRepository
    {
        public async Task<bool> SendSmsAsync(string to, string message)
        {
            int length = 160;
            List<string> substrings = new List<string>();

            for (int i = 0; i < message.Length; i += length)
            {
                int remainingLength = message.Length - i;
                int currentLength = remainingLength < length ? remainingLength : length;
                substrings.Add(message.Substring(i, currentLength));
            }
            return false;
        }
    }

    public class SmsVendorOther : ISmsRepository
    {
        public async Task<bool> SendSmsAsync(string to, string message)
        {
            return false;
        }
    }


}
