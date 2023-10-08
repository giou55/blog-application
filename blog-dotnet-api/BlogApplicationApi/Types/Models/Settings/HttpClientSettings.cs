namespace Types.Models.Settings
{
    public class HttpClientSettings
    {
        public string Name { get; set; } = "default-client";
        public uint Timeout { get; set; } = 120;
    }
}
