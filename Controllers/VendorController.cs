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

    public VendorController(ISmsServiceFactory smsServiceFactory, ISmsRepository smsRepository, IRepository rep)
    {
        _smsServiceFactory=smsServiceFactory;
        _smsRepository  = smsRepository;
        _dbRepository = rep;    
    }


    [HttpPost]
    public async Task<IActionResult> SendSmsAsync([FromBody] SmsRequest request)
    {
        //please send me back a feed back
       var smsService = _smsServiceFactory.GetSmsService(request.Vendor);//not if ocp
        if (smsService == null || request.Message.Length > 480)
        {
            return BadRequest("Invalid message");
        }
       var ListOfSms= smsService.ConvertSms(request.To,request.Message);
        _dbRepository.Add(ListOfSms);//dapper
        return Ok(true);
    }

    //[HttpGet]
    //public async Task<IActionResult> GetSmsListAsync()
    //{
    //    var smsList = await _smsRepository.GetSmsListAsync();
    //    return Ok(smsList);
    //}




   
}