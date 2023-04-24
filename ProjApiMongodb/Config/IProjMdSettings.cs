namespace ProjApiMongodb.Config
{
    public interface IProjMdSettings
    {
        public string ClientCollectionName { get; set; }
        public string ConnectionString { get; set; }
         string  DatabaseName { get; set; }
    }
}
