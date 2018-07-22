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
    }
}