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