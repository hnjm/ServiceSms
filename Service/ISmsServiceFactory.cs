using ServiceSms.Model;

namespace ServiceSms.Controllers
{
     public  interface ISmsServiceFactory
    {
        ISmsRepository GetSmsService(int vendor);
    }
    public class SmsServiceFactory : ISmsServiceFactory
    {
        Dictionary<TypeOfVendor, ISmsRepository> dictionary = new Dictionary<TypeOfVendor, ISmsRepository>() {
              {TypeOfVendor.GR,new SmsVendorGR()},
              {TypeOfVendor.CY,new SmsVendorCy()},
              {TypeOfVendor.Other,new SmsVendorOther()}
          };
        public ISmsRepository GetSmsService(int vendor)
        {
            //dictionary.TryGetValue((TypeOfVendor)vendor, out ISmsRepository service);
            return null;
        }
    }
}