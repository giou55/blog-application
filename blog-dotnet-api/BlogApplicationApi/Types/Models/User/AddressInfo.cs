namespace Types.Models.User
{
    public class AddressInfo
    {
        public string? Street { get; set; }
        public string? Suite { get; set; }
        public string? City { get; set; }
        public string? Zipcode { get; set; }
        public GeoInfo? Geo { get; set; }
    }
}