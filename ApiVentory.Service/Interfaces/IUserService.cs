namespace ApiVentory.Service
{
    using System.Threading.Tasks;
    using Common;
    public interface IUserService
    {
        Task Create(UserModel userModel);

        Task<UserModel> Read(string login);

       void Update();

        void Delete();
    }
}