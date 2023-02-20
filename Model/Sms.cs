namespace ServiceSms.Model
{
    public class Sms
    {
        public int Id { get; set; }
        public string To { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }
    public class SmsRequest
    {
        public string To { get; set; }
        public string Message { get; set; }
        public int Vendor { get; set; }
    }
}
