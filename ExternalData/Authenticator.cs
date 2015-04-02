namespace ExternalData
{
    public enum AuthenticatorTypes
    {
        None,   // No authentication required
        Token,  // Auth-token must be provided via header
        Login   // Login with creadentials (coming soon)
    }

    public class Authenticator
    {
        public AuthenticatorTypes Type { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
