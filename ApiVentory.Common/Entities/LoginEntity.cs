namespace ApiVentory.Common
{
    using Microsoft.WindowsAzure.Storage.Table;
    public class LoginEntity : TableEntity
    {
        public LoginEntity()
        {
        }

        public LoginEntity(string partitionKey, string rowKey) 
        {
            PartitionKey = partitionKey;
            RowKey = rowKey;
        }
    }
}