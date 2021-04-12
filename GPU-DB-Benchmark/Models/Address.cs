namespace GPU_DB_Benchmark.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public string BuildingNumber { get; set; }
        public string SecondaryAddress { get; set; }
        public string CountryCode { get; set; }
        public string Country { get; set; }
    }
}