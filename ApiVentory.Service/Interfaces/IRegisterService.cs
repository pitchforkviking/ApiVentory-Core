namespace ApiVentory.Service
{
    using System.Threading.Tasks;
    using ApiVentory.Common;
    public interface IRegisterService
    {
        Task Create(RegisterModel registerModel);

        void Read();

       void Update();

        void Delete();
    }
}