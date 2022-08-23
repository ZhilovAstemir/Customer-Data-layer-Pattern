namespace Customer.Datalayer.BusinessEntities
{
    public class Addresses
    {
        public int AddressID { get; set; }
        public int CustomerID { get; set; }
        public string AddressLine { get; set; } = string.Empty;
        public string AddressLine2 { get; set; }
        public string AddressType { get; set; } = "Unknown";
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string StateName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
