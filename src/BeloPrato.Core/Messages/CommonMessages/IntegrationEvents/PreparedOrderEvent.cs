using System;

namespace BeloPrato.Core.Messages.CommonMessages.IntegrationEvents
{
    public class PreparedOrderEvent : IntegrationEvent
    {
        public Guid RestaurantId { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid OrderId { get; private set; }
        public string OrderNumber { get; private set; }

        public PreparedOrderEvent(Guid restaurantId, Guid customerId, Guid orderId, string orderNumber)
        {
            AggregateId = orderId;
            RestaurantId = restaurantId;
            CustomerId = customerId;
            OrderId = orderId;
            OrderNumber = orderNumber;
        }
    }
}
