namespace WebServer.Server.HTTP
{
    using Common;

    public class HttpHeader
    {
        public const string ContentType = "Content-Type";
        public const string Host = "Host";
        public const string Location = "Location";

        public HttpHeader(string key, string value)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CoreValidator.ThrowIfNullOrEmpty(value, nameof(value));
            this.Key = key;
            this.Value = value;
        }

        public string Key { get; }

        public string Value { get; }

        public override string ToString()
        {
            return this.Key + ": " + this.Value;
        }
    }
}