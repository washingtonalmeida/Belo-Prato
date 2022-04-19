using BeloPrato.Core.DomainObjects;
using BeloPrato.Delivery.Domain.Models;
using Xunit;

namespace BeloPrato.Delivery.Domain.Tests.Models
{
    public class DeliverymanTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Instantiate_Deliveryman_With_EmptyOrNull_Name_ThrowsException(string name)
        {
            var exception = Assert.Throws<DomainException>(() => new Deliveryman(name));

            Assert.Equal("'Name' cannot be empty.", exception.Message);
        }
    }
}
