using System.Text.RegularExpressions;

namespace ServiceSms.Service
{
    public class Service
    {

        public interface ISmsService
        {
            Task<bool> SendSmsAsync(string to, string message);
        }
        public class GreekSmsService : ISmsService
        {
            public async Task<bool> SendSmsAsync(string to, string message)
            {
                if(message.Length > 480 && Regex.IsMatch(message,"^[Α - Ωα - ω0 - 9] +$"))
                return true;
                return false;

            }
        }

        public class CyprusSmsService : ISmsService
        {
            public async Task<bool> SendSmsAsync(string to, string message)
            {
                if (message.Length > 480)
                    return true;
                return false;
            }
        }

        public class OtherSmsService : ISmsService
        {
            public async Task<bool> SendSmsAsync(string to, string message)
            {
                if (message.Length > 480)
                    return true;

                return false;
            }
        }


    }
}