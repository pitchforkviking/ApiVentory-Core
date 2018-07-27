namespace ApiVentory.Service
{
    using System.Threading.Tasks;
    using Common;
    using Repository;
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public Task Create(UserModel userModel)
        {
            return _userRepository.Create(userModel);
        }

        public async Task<UserModel> Read(string login)
        {
            return await _userRepository.Read(login);
        }

        public void Update()
        {

        }

        public void Delete()
        {
            
        }
    }
}