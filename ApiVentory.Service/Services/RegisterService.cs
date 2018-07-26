namespace ApiVentory.Service
{
    using System;
    using System.Threading.Tasks;
    using ApiVentory.Common;
    using Repository;
    public class RegisterService : IRegisterService
    {
        private IRegisterRepository _registerRepository;
        public RegisterService()
        {
            _registerRepository = new RegisterRepository();
        }

        public async Task Create(RegisterModel registerModel)
        {
            try
            {
                await _registerRepository.Create(registerModel);
            }
            catch(Exception exception)
            {
                throw exception;
            }
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