using System;
using Newtonsoft.Json;

namespace ApiVentory.Common
{    
    public class UserModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public string User { get; set; }

        public string Login { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}