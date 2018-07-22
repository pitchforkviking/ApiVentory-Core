namespace ApiVentory.Repository
{
    using System.Threading.Tasks;
    using Common;
    using Microsoft.WindowsAzure.Storage.Table;
    public interface ILogRepository
    {
        Task Create(LogEntity logEntity);

        void Read();

       void Update();

        void Delete();
    }
}