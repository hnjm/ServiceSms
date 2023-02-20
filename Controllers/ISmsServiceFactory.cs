namespace ServiceSms.Controllers
{
    internal interface ISmsServiceFactory
    {
        object GetSmsService(int vendor);
    }
}