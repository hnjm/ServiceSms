using System.Text.RegularExpressions;
using static ServiceSms.Service.Service;

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
