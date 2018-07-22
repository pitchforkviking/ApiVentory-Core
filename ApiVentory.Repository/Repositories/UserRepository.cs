namespace ApiVentory.Repository
{
    using Common;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;
    using System.Threading.Tasks;
    public class UserRepository : IUserRepository
    {        
        private CloudStorageAccount _cloudStorageAccount;
        private CloudTableClient _cloudTableClient;  
        private CloudTable _cloudTable;
        public UserRepository()
        {
            _cloudStorageAccount = CloudStorageAccount.Parse(ConnectionStrings.StorageConnectionString);
            _cloudTableClient = _cloudStorageAccount.CreateCloudTableClient();
            _cloudTable = _cloudTableClient.GetTableReference(TableReferences.User);
            _cloudTable.CreateIfNotExistsAsync();
        }

        public async Task Create(UserEntity userEntity)
        {
            userEntity.PartitionKey = userEntity.Login.Substring(0,1).ToUpper();
            userEntity.RowKey = userEntity.Login;

            TableOperation insertOperation = TableOperation.InsertOrReplace(userEntity);
            await _cloudTable.ExecuteAsync(insertOperation);
        }

        public async Task<UserEntity> Read(string login)
        {            
            string partitionKey = login.Substring(0,1).ToUpper();
            string rowKey = login;

            TableOperation retrieveOperation = TableOperation.Retrieve<UserEntity>(partitionKey, rowKey);
            TableResult retrievedResult = await _cloudTable.ExecuteAsync(retrieveOperation);

            return retrievedResult == null ? null : (UserEntity)retrievedResult.Result;
        }

        public void Update()
        {

        }

        public void Delete()
        {
            
        }
    }
}