namespace ApiVentory.Service
{
    using System.Threading.Tasks;
    using Common;
    public interface IUserService
    {
        Task Create(UserEntity userEntity);

        Task<UserEntity> Read(string login);

       void Update();

        void Delete();
    }
}