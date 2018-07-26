namespace ApiVentory.Common
{
    using Microsoft.WindowsAzure.Storage.Table;
    public class RegisterEntity : TableEntity
    {
        public RegisterEntity()
        {
        }

        public RegisterEntity(string partitionKey, string rowKey) 
        {
            PartitionKey = partitionKey;
            RowKey = rowKey;
        }

        public string User { get; set; }

        public string Group { get; set; }         

        public string Login { get; set; }

        public string Password { get; set; }
    }
}