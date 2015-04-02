namespace ExternalData
{
    public class DataSource
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public Authenticator Authentication { get; set; }
    }
}
