namespace ApiVentory.Api
{
    using Service;
    using Microsoft.AspNetCore.Mvc;
    using ApiVentory.Common;
    using System.Threading.Tasks;
    using System;

    [Route("[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private ILoginService _loginService;
        private ILogService _logService;
        public LoginController()
        {
            _loginService = new LoginService();
            _logService = new LogService();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] LoginModel loginModel)
        {
            try
            {
                bool success = await _loginService.Read(loginModel);
                if(success)
                {
                    //To-Do: Log, Token, Session
                    return Ok();
                }

                return BadRequest();
            }
            catch(Exception exception)
            {
                //Refactor
                LogEntity logEntity = new LogEntity
                {
                    PartitionKey = loginModel.Login,
                    User = loginModel.Login,
                    Event = "POST -> Login",
                    Details = exception.Message ?? exception.InnerException.Message
                };

                //await _logService.Create(logEntity);

                return BadRequest();
            }
        }
    }
}