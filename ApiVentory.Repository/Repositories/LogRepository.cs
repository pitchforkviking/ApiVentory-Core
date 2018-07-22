namespace ApiVentory.Repository
{
    using Common;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;
    using System.Threading.Tasks;
    public class LogRepository : ILogRepository
    {        
        private CloudStorageAccount _cloudStorageAccount;
        private CloudTableClient _cloudTableClient;  
        private CloudTable _cloudTable;
        public LogRepository()
        {
            _cloudStorageAccount = CloudStorageAccount.Parse(ConnectionStrings.StorageConnectionString);
            _cloudTableClient = _cloudStorageAccount.CreateCloudTableClient();
            _cloudTable = _cloudTableClient.GetTableReference(TableReferences.Log);
            _cloudTable.CreateIfNotExistsAsync();
        }

        public async Task Create(LogEntity logEntity)
        {            
            TableOperation insertOperation = TableOperation.Insert(logEntity);
            await _cloudTable.ExecuteAsync(insertOperation);
        }

        public void Read()
        {

        }

        public void Update()
        {

        }

        public void Delete()
        {
            
        }
    }
}