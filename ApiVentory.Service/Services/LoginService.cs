namespace ApiVentory.Service
{
    using Repository;
    public class LoginService : ILoginService
    {
        private ILoginRepository _loginRepository;
        public LoginService()
        {
            _loginRepository = new LoginRepository();
        }
    }
}