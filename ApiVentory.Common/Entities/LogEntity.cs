namespace ApiVentory.Common
{
    using Microsoft.WindowsAzure.Storage.Table;
    public class LogEntity : TableEntity
    {
        public LogEntity()
        {
        }

        public LogEntity(string partitionKey, string rowKey) 
        {
            PartitionKey = partitionKey;
            RowKey = rowKey;
        }

        public int Id { get; set; }

        public string User { get; set; }

        public string Event { get; set; }

        public string Details { get; set; }
    }
}