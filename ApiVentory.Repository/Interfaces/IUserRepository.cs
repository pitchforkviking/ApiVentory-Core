namespace ApiVentory.Repository
{
    using System.Threading.Tasks;
    using Common;
    using Microsoft.WindowsAzure.Storage.Table;
    public interface IUserRepository
    {
        Task Create(UserEntity userEntity);

        Task<UserEntity> Read(string login);

       void Update();

        void Delete();
    }
}