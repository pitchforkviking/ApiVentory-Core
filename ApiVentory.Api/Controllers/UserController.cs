namespace ApiVentory.Api
{
    using Common;
    using Service;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserService _userService;    
        private ILogService _logService;     
        public UserController()
        {
            _userService = new UserService();
            _logService = new LogService();
        }          

        [HttpGet()]
        public async Task<ActionResult> Get([FromQuery(Name = "login")]string login)
        {
            try
            {
                UserModel userModel = await _userService.Read(login);
                
                return Ok(value: userModel);
            }
            catch(Exception exception)
            {
                //Refactor
                LogEntity logEntity = new LogEntity
                {
                    PartitionKey = login,
                    User = login,
                    Event = "Get -> User",
                    Details = exception.Message ?? exception.InnerException.Message
                };

                //await _logService.Create(logEntity);

                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(UserModel userModel)
        {
            try
            {
                await _userService.Create(userModel);

                return Ok();
            }
            catch(Exception exception)
            {
                //Refactor
                LogEntity logEntity = new LogEntity
                {
                    PartitionKey = userModel.Login,
                    User = userModel.Login,
                    Event = "POST -> User",
                    Details = exception.Message ?? exception.InnerException.Message
                };

                //await _logService.Create(logEntity);

                return BadRequest();
            }
        }
        
        [HttpDelete("{login}")]
        public void Delete(int login)
        {
        }
    }
}