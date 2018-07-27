namespace ApiVentory.Repository
{
    using Common;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Net;
    using Microsoft.Azure.Documents;
    using Microsoft.Azure.Documents.Client;
    using Newtonsoft.Json;
    using System;

    public class UserRepository : IUserRepository
    {        
        // private CloudStorageAccount _cloudStorageAccount;
        // private CloudTableClient _cloudTableClient;  
        // private CloudTable _userTable;

        private const string EndpointUri = "https://alphaventory.documents.azure.com:443/";
        private const string PrimaryKey = "iLJmsue2nvLdhzG1iQ8X8ujGLWUfkSURKEWFzHUiCiAYTfTbWpm9eEGmV5uYBgWluF6jl2WoPxTS9KNYscCsow==";
        private DocumentClient client;

        public UserRepository()
        {
            // _cloudStorageAccount = CloudStorageAccount.Parse(ConnectionStrings.StorageConnectionString);
            // _cloudTableClient = _cloudStorageAccount.CreateCloudTableClient();
            // _userTable = _cloudTableClient.GetTableReference(TableReferences.User);
            // _userTable.CreateIfNotExistsAsync();

            client = new DocumentClient(new Uri(EndpointUri), PrimaryKey);
            client.CreateDatabaseIfNotExistsAsync(new Database { Id = "AlphaVentory" });
        }

        public async Task Create(UserModel userModel)
        {
            // userEntity.PartitionKey = userEntity.Login.Substring(0,1).ToUpper();
            // userEntity.RowKey = userEntity.Login;

            // TableOperation insertUserEntityOp = TableOperation.InsertOrReplace(userEntity);
            // await _userTable.ExecuteAsync(insertUserEntityOp);

            try
            {
                userModel.Id = userModel.Login;

                await this.client.ReadDocumentAsync(UriFactory.CreateDocumentUri("AlphaVentory", "User", userModel.Id));                
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await this.client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri("AlphaVentory", "User"), userModel);                    
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<UserModel> Read(string login)
        {            
            // string partitionKey = login.Substring(0,1).ToUpper();
            // string rowKey = login;

            // TableOperation retrieveUserEntityOp = TableOperation.Retrieve<UserEntity>(partitionKey, rowKey);
            // TableResult retrievedUserEntity = await _userTable.ExecuteAsync(retrieveUserEntityOp);

            // return retrievedUserEntity == null ? null : (UserEntity)retrievedUserEntity.Result;

            // Set some common query options
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = 1 };
            
            var userModel = this.client.CreateDocumentQuery<UserModel>(
                    UriFactory.CreateDocumentCollectionUri("AlphaVentory", "User"), queryOptions)
                    .Where(f => f.Login == login);

            return userModel.ToList().FirstOrDefault();
        }

        public void Update()
        {

        }

        public void Delete()
        {
            
        }
    }
}