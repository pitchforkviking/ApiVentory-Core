namespace ApiVentory.Repository
{
    using Common;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;
    using System.Threading.Tasks;
    public class RegisterRepository : IRegisterRepository
    {        
        private CloudStorageAccount _cloudStorageAccount;      
        public RegisterRepository()
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