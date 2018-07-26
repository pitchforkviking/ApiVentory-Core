namespace ApiVentory.Repository
{
    using Common;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;
    using System;
    using System.Threading.Tasks;
    public class RegisterRepository : IRegisterRepository
    {        
        private CloudStorageAccount _cloudStorageAccount;
        private CloudTableClient _cloudTableClient;  
        private CloudTable _registerTable; 
        private CloudTable _userTable;     
        private CloudTable _loginTable;
        public RegisterRepository()
        {
            _cloudStorageAccount = CloudStorageAccount.Parse(ConnectionStrings.StorageConnectionString);
            _cloudTableClient = _cloudStorageAccount.CreateCloudTableClient();
            _registerTable = _cloudTableClient.GetTableReference(TableReferences.Register);
            _registerTable.CreateIfNotExistsAsync();
            _userTable = _cloudTableClient.GetTableReference(TableReferences.User);
            _userTable.CreateIfNotExistsAsync();
            _loginTable = _cloudTableClient.GetTableReference(TableReferences.Login);
            _loginTable.CreateIfNotExistsAsync();
        }

        public async Task Create(RegisterModel registerModel)
        {
            try
            {
                string partitionKey = registerModel.Login.Substring(0,1).ToUpper();
                string rowKey = registerModel.Login;                
                
                RegisterEntity registerEntity = new RegisterEntity(partitionKey, rowKey);
                registerEntity.User = registerModel.User;
                registerEntity.Login = registerModel.Login;
                registerEntity.Password = registerModel.Password;

                LoginEntity loginEntity = new LoginEntity(partitionKey, rowKey);
                loginEntity.Login = registerModel.Login;
                loginEntity.Password = registerModel.Password;

                UserEntity userEntity = new UserEntity(partitionKey, rowKey);
                userEntity.User = registerModel.User;
                userEntity.Login = registerModel.Login; 

                registerEntity.Password = null;

                TableOperation insertRegisterEntityOp = TableOperation.InsertOrReplace(registerEntity);
                await _registerTable.ExecuteAsync(insertRegisterEntityOp);                

                TableOperation insertLoginEntityOp = TableOperation.InsertOrReplace(loginEntity);
                await _loginTable.ExecuteAsync(insertLoginEntityOp);                               

                TableOperation insertUserEntityOp = TableOperation.InsertOrReplace(userEntity);
                await _userTable.ExecuteAsync(insertUserEntityOp);
            }
            catch(Exception exception)
            {
                throw exception;
            }
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