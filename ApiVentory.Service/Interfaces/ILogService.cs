namespace ApiVentory.Service
{
    using System.Threading.Tasks;
    using Common;
    public interface ILogService
    {
        Task Create(LogEntity logEntity);

        void Read();

       void Update();

        void Delete();
    }
}