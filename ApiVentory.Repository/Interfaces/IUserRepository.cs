namespace ApiVentory.Repository
{
    using System.Threading.Tasks;
    using Common;
    using Microsoft.WindowsAzure.Storage.Table;
    public interface IUserRepository
    {
        Task Create(UserModel userModel);

        Task<UserModel> Read(string login);

       void Update();

        void Delete();
    }
}