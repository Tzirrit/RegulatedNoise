namespace ExternalData
{
    public interface IDataSource
    {
        string Name { get; set; }
        string Url { get; set; }
        Header AuthenticationHeader { get; set; }
    }
}
