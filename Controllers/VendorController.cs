using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceSms.Model;
using ServiceSms.Service;

namespace ServiceSms.Controllers;

[Route("api/sms")]
[ApiController]
public class VendorController : ControllerBase
{

    private readonly ISmsServiceFactory _smsServiceFactory;
    private readonly ISmsRepository _smsRepository;
    enum TypeOfVendor
    {
        GR = 1,
        CY = 2,
        Other = 3

    };
    Dictionary<TypeOfVendor, ISmsRepository> dictionary = new Dictionary<TypeOfVendor, ISmsRepository>() {
              {TypeOfVendor.GR,new SmsVendorGR()},
              {TypeOfVendor.CY,new SmsVendorCy()},
              {TypeOfVendor.Other,new SmsVendorOther()}
          };
   

    [HttpPost]
    public async Task<IActionResult> SendSmsAsync([FromBody] SmsRequest request)
    {
        //var smsService = _smsServiceFactory.GetSmsService(request.Vendor);

        //if (smsService == null)
        //{
        //    return BadRequest("Invalid vendor");
        //}
        dictionary.TryGetValue((TypeOfVendor)request.Vendor, out ISmsRepository service);

        //var internalRequest = MapRequest(request);
        // var result = await smsService.SendSmsAsync(internalRequest.To, internalRequest.Message);

        //var sms = new Sms
        //{
        //    To = internalRequest.To,
        //    Message = internalRequest.Message,
        //    Timestamp = DateTime.UtcNow
        //};
        //var result = _smsRepository.AddSms(sms);
        //await _smsRepository.SendSmsAsync(sms);

        return Ok(true);
    }

    //[HttpGet]
    //public async Task<IActionResult> GetSmsListAsync()
    //{
    //    var smsList = await _smsRepository.GetSmsListAsync();
    //    return Ok(smsList);
    //}

 


    public class InternalSmsRequest
    {
        public string To { get; set; }
        public string Message { get; set; }

    }
}