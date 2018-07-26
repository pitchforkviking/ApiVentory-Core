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
        private CloudTable _userTable;
        public UserRepository()
        {
            _cloudStorageAccount = CloudStorageAccount.Parse(ConnectionStrings.StorageConnectionString);
            _cloudTableClient = _cloudStorageAccount.CreateCloudTableClient();
            _userTable = _cloudTableClient.GetTableReference(TableReferences.User);
            _userTable.CreateIfNotExistsAsync();
        }

        public async Task Create(UserEntity userEntity)
        {
            userEntity.PartitionKey = userEntity.Login.Substring(0,1).ToUpper();
            userEntity.RowKey = userEntity.Login;

            TableOperation insertUserEntityOp = TableOperation.InsertOrReplace(userEntity);
            await _userTable.ExecuteAsync(insertUserEntityOp);
        }

        public async Task<UserEntity> Read(string login)
        {            
            string partitionKey = login.Substring(0,1).ToUpper();
            string rowKey = login;

            TableOperation retrieveUserEntityOp = TableOperation.Retrieve<UserEntity>(partitionKey, rowKey);
            TableResult retrievedUserEntity = await _userTable.ExecuteAsync(retrieveUserEntityOp);

            return retrievedUserEntity == null ? null : (UserEntity)retrievedUserEntity.Result;
        }

        public void Update()
        {

        }

        public void Delete()
        {
            
        }
    }
}