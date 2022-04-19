using BeloPrato.Core.DomainObjects;

namespace BeloPrato.Delivery.Domain.Models
{
    public class DeliveryAddress : ValueObject
    {
        public string PublicArea { get; private set; }
        public string Neighborhood { get; private set; }
        public string Number { get; private set; }
        public string ZipCode { get; private set; }
        public string Complement { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }

        public DeliveryAddress(string publicArea, string neighborhood, string number, string zipCode, string complement, string city, string state, string country)
        {
            PublicArea = publicArea;
            Neighborhood = neighborhood;
            Number = number;
            ZipCode = zipCode;
            Complement = complement;
            City = city;
            State = state;
            Country = country;

            Validate();
        }

        private void Validate()
        {
            Validations.EmptyThrowsException(PublicArea, "'PublicArea' cannot be empty.");
            Validations.EmptyThrowsException(Neighborhood, "'Neighborhood' cannot be empty.");
            Validations.EmptyThrowsException(Number, "'Number' cannot be empty.");
            Validations.EmptyThrowsException(ZipCode, "'ZipCode' cannot be empty.");
            Validations.EmptyThrowsException(Complement, "'Complement' cannot be empty.");
            Validations.EmptyThrowsException(City, "'City' cannot be empty.");
            Validations.EmptyThrowsException(State, "'State' cannot be empty.");
            Validations.EmptyThrowsException(Country, "'Country' cannot be empty.");
        }
    }
}
