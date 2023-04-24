namespace ProjApiMongodb.Config
{
    public class ProjMdSettings : IProjMdSettings
    {
        public string ClientCollectionName { get; set; }
        public string ConnectionString { get ; set ; }
        public string DatabaseName { get; set ; }
    }
}
