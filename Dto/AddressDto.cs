

namespace VoteApp.Dto
{
    public class AddressDto
    {
        public string Id { get; set; }
        public int Plot { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int UserId { get; set; }

    public class CreateAddressRequestModel
    {
            public int Plot { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
        }

    public class UpdateAddressRequestModel
    {
            public int Plot { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
        }
}
