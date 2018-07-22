namespace ApiVentory.Api
{
    using Service;
    using Microsoft.AspNetCore.Mvc;

    [Route("[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private ILoginService _loginService;
        public LoginController()
        {
            _loginService = new LoginService();
        }
    }
}