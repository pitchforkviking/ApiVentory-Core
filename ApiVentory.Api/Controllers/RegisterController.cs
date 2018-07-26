namespace ApiVentory.Api
{
    using Service;
    using Microsoft.AspNetCore.Mvc;
    using Common;
    using System;
    using System.Threading.Tasks;

    [Route("[controller]")]
    [ApiController]
    public class RegisterController : Controller
    {
        private IRegisterService _registerService;
        private ILogService _logService;    
        public RegisterController()
        {
            _registerService = new RegisterService();
            _logService = new LogService();
        }

         [HttpPost]
        public async Task<ActionResult> Post([FromBody]RegisterModel registerModel)
        {
            try
            {
                await _registerService.Create(registerModel);

                return Ok();
            }
            catch(Exception exception)
            {
                //Refactor
                LogEntity logEntity = new LogEntity
                {
                    PartitionKey = registerModel.Login,
                    User = registerModel.Login,
                    Event = "POST -> Register",
                    Details = exception.Message ?? exception.InnerException.Message
                };

                await _logService.Create(logEntity);

                return BadRequest();
            }
            
        }
    }
}