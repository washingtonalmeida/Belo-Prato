using System;
using BeloPrato.Delivery.Application.Commands.Models;
using FluentValidation;

namespace BeloPrato.Delivery.Application.Commands.Validations
{
    public class SendDeliveryRequestToAvailableDeliverymenCommandValidation : AbstractValidator<SendDeliveryRequestToAvailableDeliverymenCommand>
    {
        public SendDeliveryRequestToAvailableDeliverymenCommandValidation()
        {
            RuleFor(x => x.RestaurantId)
                .NotEqual(Guid.Empty)
                .WithMessage("RestaurantId is invalid.");

            RuleFor(x => x.CustomerId)
                .NotEqual(Guid.Empty)
                .WithMessage("CustomerId is invalid.");

            RuleFor(x => x.OrderId)
                .NotEqual(Guid.Empty)
                .WithMessage("OrderId is invalid.");

            RuleFor(x => x.OrderNumber)
                .NotEmpty()
                .WithMessage("OrderNumber is invalid.");
        }
    }
}
