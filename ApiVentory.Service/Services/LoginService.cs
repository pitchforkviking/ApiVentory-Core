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

        public void Create()
        {
            throw new System.NotImplementedException();
        }

        public void Delete()
        {
            throw new System.NotImplementedException();
        }

        public void Read()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}