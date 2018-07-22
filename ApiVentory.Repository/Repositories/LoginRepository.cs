namespace ApiVentory.Repository
{
    using Common;
    using Microsoft.WindowsAzure.Storage;
    public class LoginRepository : ILoginRepository
    {
        private CloudStorageAccount _cloudStorageAccount;     
        public LoginRepository() 
        {
            _cloudStorageAccount = CloudStorageAccount.Parse(ConnectionStrings.StorageConnectionString);
        }

        public void Create()
        {

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