using BeloPrato.Core.Messages;
using BeloPrato.Delivery.Application.Commands.Validations;
using System;

namespace BeloPrato.Delivery.Application.Commands.Models
{
    public class SendDeliveryRequestToAvailableDeliverymenCommand : Command
    {
        public Guid RestaurantId { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid OrderId { get; private set; }
        public string OrderNumber { get; private set; }

        public SendDeliveryRequestToAvailableDeliverymenCommand(Guid restaurantId, Guid customerId, Guid orderId, 
                                                                string orderNumber)
        {
            AggregateId = orderId;
            RestaurantId = restaurantId;
            CustomerId = customerId;
            OrderId = orderId;
            OrderNumber = orderNumber;
        }

        public override bool IsValid()
        {
            ValidationResult = new SendDeliveryRequestToAvailableDeliverymenCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
