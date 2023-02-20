using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceSms.Model;

namespace ServiceSms.Controllers;

[Route("api/sms")]
[ApiController]
public class VendorController : ControllerBase
{

    private readonly ISmsServiceFactory _smsServiceFactory;
    private readonly ISmsRepository _smsRepository;

    public VendorController(ISmsServiceFactory smsServiceFactory, ISmsRepository smsRepository)
    {
        _smsServiceFactory=smsServiceFactory;
        _smsRepository  = smsRepository;
    }


    [HttpPost]
    public async Task<IActionResult> SendSmsAsync([FromBody] SmsRequest request)
    {
        var smsService = _smsServiceFactory.GetSmsService(request.Vendor);

        if (smsService == null || request.Message.Length > 480)
        {
            return BadRequest("Invalid message");
        }      

       

        return Ok(true);
    }

    //[HttpGet]
    //public async Task<IActionResult> GetSmsListAsync()
    //{
    //    var smsList = await _smsRepository.GetSmsListAsync();
    //    return Ok(smsList);
    //}




   
}