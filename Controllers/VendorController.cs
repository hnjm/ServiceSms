using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceSms.Model;
using ServiceSms.Database;

namespace ServiceSms.Controllers;

[Route("api/sms")]
[ApiController]
public class VendorController : ControllerBase
{

    private readonly ISmsServiceFactory _smsServiceFactory;
    private readonly ISmsRepository _smsRepository;
    private readonly IRepository _dbRepository;

    public VendorController(ISmsServiceFactory smsServiceFactory, ISmsRepository smsRepository)
    {
        _smsServiceFactory=smsServiceFactory;
        _smsRepository  = smsRepository;
    }


    [HttpPost]
    public async Task<IActionResult> SendSmsAsync([FromBody] SmsRequest request)
    {
       var smsService = _smsServiceFactory.GetSmsService(request.Vendor);
       var takis= smsService.ConvertSmsAsync(request.To,request.Message);
        if (smsService == null || request.Message.Length > 480)
        {
            return BadRequest("Invalid message");
        }
        _dbRepository.Add(takis);




        return Ok(true);
    }

    //[HttpGet]
    //public async Task<IActionResult> GetSmsListAsync()
    //{
    //    var smsList = await _smsRepository.GetSmsListAsync();
    //    return Ok(smsList);
    //}




   
}