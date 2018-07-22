namespace ApiVentory.Service
{
    using Repository;
    public class RegisterService : IRegisterService
    {
        private IRegisterRepository _registerRepository;
        public RegisterService()
        {
            _registerRepository = new RegisterRepository();
        }
    }
}