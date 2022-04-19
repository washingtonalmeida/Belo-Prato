using BeloPrato.Core.DomainObjects;
using BeloPrato.Delivery.Domain.Models;
using Xunit;

namespace BeloPrato.Delivery.Domain.Tests.Models
{
    public class DeliveryAddressTests
    {
        private const string PUBLIC_AREA = "Avenida Paulista";
        private const string NEIGHBORHOOD = "Cerqueira César";
        private const string NUMBER = "1002";
        private const string ZIPCODE = "04854-194";
        private const string COMPLEMENT = "Ap. 22";
        private const string CITY = "São Paulo";
        private const string STATE = "SP";
        private const string COUNTRY = "Brasil";

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Instantiate_DeliveryAddress_With_EmptyOrNull_PublicArea_ThrowsException(string publicArea)
        {
            var exception = Assert.Throws<DomainException>(() => new DeliveryAddress(publicArea, NEIGHBORHOOD, NUMBER, ZIPCODE, COMPLEMENT, CITY, STATE, COUNTRY));

            Assert.Equal("'PublicArea' cannot be empty.", exception.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Instantiate_DeliveryAddress_With_EmptyOrNull_Neighborhood_ThrowsException(string neighborhood)
        {
            var exception = Assert.Throws<DomainException>(() => new DeliveryAddress(PUBLIC_AREA, neighborhood, NUMBER, ZIPCODE, COMPLEMENT, CITY, STATE, COUNTRY));

            Assert.Equal("'Neighborhood' cannot be empty.", exception.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Instantiate_DeliveryAddress_With_EmptyOrNull_Number_ThrowsException(string number)
        {
            var exception = Assert.Throws<DomainException>(() => new DeliveryAddress(PUBLIC_AREA, NEIGHBORHOOD, number, ZIPCODE, COMPLEMENT, CITY, STATE, COUNTRY));

            Assert.Equal("'Number' cannot be empty.", exception.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Instantiate_DeliveryAddress_With_EmptyOrNull_Zipcode_ThrowsException(string zipcode)
        {
            var exception = Assert.Throws<DomainException>(() => new DeliveryAddress(PUBLIC_AREA, NEIGHBORHOOD, NUMBER, zipcode, COMPLEMENT, CITY, STATE, COUNTRY));

            Assert.Equal("'ZipCode' cannot be empty.", exception.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Instantiate_DeliveryAddress_With_EmptyOrNull_Complement_ThrowsException(string complement)
        {
            var exception = Assert.Throws<DomainException>(() => new DeliveryAddress(PUBLIC_AREA, NEIGHBORHOOD, NUMBER, ZIPCODE, complement, CITY, STATE, COUNTRY));

            Assert.Equal("'Complement' cannot be empty.", exception.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Instantiate_DeliveryAddress_With_EmptyOrNull_City_ThrowsException(string city)
        {
            var exception = Assert.Throws<DomainException>(() => new DeliveryAddress(PUBLIC_AREA, NEIGHBORHOOD, NUMBER, ZIPCODE, COMPLEMENT, city, STATE, COUNTRY));

            Assert.Equal("'City' cannot be empty.", exception.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Instantiate_DeliveryAddress_With_EmptyOrNull_State_ThrowsException(string state)
        {
            var exception = Assert.Throws<DomainException>(() => new DeliveryAddress(PUBLIC_AREA, NEIGHBORHOOD, NUMBER, ZIPCODE, COMPLEMENT, CITY, state, COUNTRY));

            Assert.Equal("'State' cannot be empty.", exception.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Instantiate_DeliveryAddress_With_EmptyOrNull_Country_ThrowsException(string country)
        {
            var exception = Assert.Throws<DomainException>(() => new DeliveryAddress(PUBLIC_AREA, NEIGHBORHOOD, NUMBER, ZIPCODE, COMPLEMENT, CITY, STATE, country));

            Assert.Equal("'Country' cannot be empty.", exception.Message);
        }
    }
}
