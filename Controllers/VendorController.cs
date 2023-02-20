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

    Dictionary<TypeOfVendor, ISmsRepository> dictionary = new Dictionary<TypeOfVendor, ISmsRepository>() {
              {TypeOfVendor.GR,new SmsVendorGR()},
              {TypeOfVendor.CY,new SmsVendorCy()},
              {TypeOfVendor.Other,new SmsVendorOther()}
          };


    [HttpPost]
    public async Task<IActionResult> SendSmsAsync([FromBody] SmsRequest request)
    {
        var smsService = _smsServiceFactory.GetSmsService(request.Vendor);

        if (smsService == null || request.Message.Length > 480)
        {
            return BadRequest("Invalid message");
        }
        dictionary.TryGetValue((TypeOfVendor)request.Vendor, out ISmsRepository service);

       

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