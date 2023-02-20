namespace ServiceSms.Service
{
    public class Service
    {

        public interface ISmsService
        {
            Task<string> SendSmsAsync(string to, string message);
        }
        public class GreekSmsService : ISmsService
        {
            public async Task<string> SendSmsAsync(string to, string message)
            {

                return "SMS sent to Greek vendor";
            }
        }

        public class CyprusSmsService : ISmsService
        {
            public async Task<string> SendSmsAsync(string to, string message)
            {
                return "SMS sent to Cyprus vendor";
            }
        }

        public class OtherSmsService : ISmsService
        {
            public async Task<string> SendSmsAsync(string to, string message)
            {
                return "SMS sent to Other vendor";
            }
        }


    }
}