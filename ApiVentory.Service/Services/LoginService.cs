namespace ApiVentory.Service
{
    using System.Threading.Tasks;
    using ApiVentory.Common;
    using Repository;
    public class LoginService : ILoginService
    {
        private ILoginRepository _loginRepository;
        public LoginService()
        {
            _loginRepository = new LoginRepository();
        }

        public async Task Create(LoginModel loginModel)
        {
            await _loginRepository.Create(loginModel);
        }

        public void Delete()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Read(LoginModel loginModel)
        {
            return await _loginRepository.Read(loginModel);
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}