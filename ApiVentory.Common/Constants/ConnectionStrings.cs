namespace ApiVentory.Common
{
    using System.Configuration;
    public static class ConnectionStrings
    {
        public static string StorageConnectionString = ConfigurationManager.AppSettings["StorageConnectionString"];        
    }
}