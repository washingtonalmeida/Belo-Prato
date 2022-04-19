using BeloPrato.Core.DomainObjects;
using BeloPrato.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeloPrato.Delivery.Domain.Models
{
    public class Order : Entity, IAggregateRoot
    {
        public Guid RestaurantId { get; private set; }
        public Guid CustomerId { get; private set; }
        public string OrderNumber { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public DateTime RegistrationDate { get; private set; }

        public Order(Guid restaurantId, Guid customerId, string orderNumber)
        {
            RestaurantId = restaurantId;
            CustomerId = customerId;
            OrderNumber = orderNumber;

            Validate();
        }

        protected override void Validate()
        {
            Validations.EqualsThrowsException(RestaurantId, Guid.Empty, "'RestaurantId' cannot be empty.");
            Validations.EqualsThrowsException(CustomerId, Guid.Empty, "'CustomerId' cannot be empty.");
            Validations.EmptyThrowsException(OrderNumber, "'OrderNumber' cannot be empty.");
        }

        public void FinishOrder()
        {
            OrderStatus = OrderStatus.Finished;
        }
    }
}
