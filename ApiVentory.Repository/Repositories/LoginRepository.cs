namespace ApiVentory.Repository
{
    using Common;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;
    using System.Threading.Tasks;
    public class LoginRepository : ILoginRepository
    {
        private CloudStorageAccount _cloudStorageAccount;
        private CloudTableClient _cloudTableClient;  
        private CloudTable _loginTable;
        public LoginRepository() 
        {
            _cloudStorageAccount = CloudStorageAccount.Parse(ConnectionStrings.StorageConnectionString);
            _cloudTableClient = _cloudStorageAccount.CreateCloudTableClient();
            _loginTable = _cloudTableClient.GetTableReference(TableReferences.Login);
            _loginTable.CreateIfNotExistsAsync();
        }

        public async Task Create(LoginModel loginModel)
        {
            string partitionKey = loginModel.Login.Substring(0,1).ToUpper();
            string rowKey = loginModel.Login;

            LoginEntity loginEntity = new LoginEntity(partitionKey, rowKey);

            TableOperation insertLoginEntityOp = TableOperation.InsertOrReplace(loginEntity);
            await _loginTable.ExecuteAsync(insertLoginEntityOp);
        }

        public async Task<bool> Read(LoginModel loginModel)
        {
            string partitionKey = loginModel.Login.Substring(0,1).ToUpper();
            string rowKey = loginModel.Login;
            string password = loginModel.Password;

            TableOperation retrieveLoginEntityOp = TableOperation.Retrieve<LoginEntity>(partitionKey, rowKey);
            TableResult retrievedLoginEntity = await _loginTable.ExecuteAsync(retrieveLoginEntityOp);

            if(retrievedLoginEntity != null)
            {
                var loginEntity = (LoginEntity)retrievedLoginEntity.Result;
                if(loginEntity.Password == password)
                {
                    return true;
                }
            }

            return false;
        }

        public void Update()
        {

        }

        public void Delete()
        {
            
        }
    }
}