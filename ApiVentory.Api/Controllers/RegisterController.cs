namespace ApiVentory.Api
{
    using Service;
    using Microsoft.AspNetCore.Mvc;

    [Route("[controller]")]
    [ApiController]
    public class RegisterController : Controller
    {
        private IRegisterService _registerService;
        public RegisterController()
        {
            _registerService = new RegisterService();
        }
    }
}