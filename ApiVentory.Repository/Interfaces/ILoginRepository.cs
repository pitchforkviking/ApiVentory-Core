namespace ApiVentory.Repository
{
    using System.Threading.Tasks;
    using Common;
    public interface ILoginRepository
    {
        Task Create(LoginModel loginModel);

        Task<bool> Read(LoginModel loginModel);

       void Update();

        void Delete();
    }
}