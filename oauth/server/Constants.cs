namespace server
{
    public static class Constants
    {
        public const string Issuer = Audiance;
        public const string Audiance = "https://localhost:44383";
        //public const string Audiance = "https://localhost:5002";
        public const string Secret = "not_too_short_secret_otherwise_it_might_error";
    }
}