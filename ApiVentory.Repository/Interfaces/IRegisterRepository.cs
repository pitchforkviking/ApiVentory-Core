namespace ApiVentory.Repository
{
    using System.Threading.Tasks;
    using Common;
    public interface IRegisterRepository
    {
        Task Create(RegisterModel registerModel);

        void Read();

       void Update();

        void Delete();
    }
}