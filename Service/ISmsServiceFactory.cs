using ServiceSms.Model;

namespace ServiceSms.Controllers
{
     public  interface ISmsServiceFactory
    {
         ISmsRepository GetSmsService(int vendor);
    }
    public class SmsServiceFactory : ISmsServiceFactory
    {
    
        public  ISmsRepository  GetSmsService(int vendor)
        {
            //dictionary.TryGetValue((TypeOfVendor)vendor, out ISmsRepository service);
            return null;
        }
    }
}