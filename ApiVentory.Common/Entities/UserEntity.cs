namespace ApiVentory.Common
{
    using Microsoft.WindowsAzure.Storage.Table;
    using Newtonsoft.Json;

    public class UserEntity : TableEntity
    {
        public UserEntity()
        {
        }

        public UserEntity(string partitionKey, string rowKey) 
        {
            PartitionKey = partitionKey;
            RowKey = rowKey;
        }

        [JsonIgnore]
        public int Id { get; set; }

        public string User { get; set; }

        public string Group { get; set; }         

        public string Login { get; set; }

        public string Password { get; set; }

        public bool Verified { get; set; }
    }
}