namespace ApiVentory.Service
{
    using System.Threading.Tasks;
    using ApiVentory.Common;

    public interface ILoginService
    {
        Task Create(LoginModel loginModel);

        Task<bool> Read(LoginModel loginModel);

       void Update();

        void Delete();
    }
}