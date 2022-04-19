using BeloPrato.Core.DomainObjects;
using BeloPrato.Delivery.Domain.Models;
using Xunit;

namespace BeloPrato.Delivery.Domain.Tests.Models
{
    public class CustomerTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Instantiate_Customer_With_EmptyOrNull_Name_ThrowsException(string name)
        {
            var exception = Assert.Throws<DomainException>(() => new Customer(name, "11 95815-6133"));

            Assert.Equal("'Name' cannot be empty.", exception.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("958148655")]
        [InlineData("00 958148655")]
        public void Instantiate_Customer_With_Invalid_PhoneNumber_ThrowsException(string phoneNumber)
        {
            var exception = Assert.Throws<DomainException>(() => new Customer("Antony Rubens", phoneNumber));

            Assert.Equal("'PhoneNumber' is invalid.", exception.Message);
        }
    }
}
