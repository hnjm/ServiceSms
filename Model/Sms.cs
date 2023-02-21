namespace ServiceSms.Model
{
    public class Sms
    {
        //ID ,    SendTo ,	Vendor , NumOfLine , MessageBody ,	RecTime

        public string Id { get; set; }

        public string SendTo { get; set; }
        public string MessageBody { get; set; }

        public short Vendor { get; set; }
        public short NumOfLine { get; set; }
        public DateTime RecTime { get; set; }
    }
    public class SmsRequest
    {
        public string To { get; set; }
        public string Message { get; set; }
        public int Vendor { get; set; }
    }
    enum TypeOfVendor
    {
        GR = 1,
        CY = 2,
        Other = 3

    };
}
