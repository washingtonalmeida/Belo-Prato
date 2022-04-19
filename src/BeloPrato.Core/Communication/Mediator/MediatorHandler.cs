using BeloPrato.Core.Messages;
using BeloPrato.Core.Messages.CommonMessages.Notifications;
using System.Threading.Tasks;
using MediatR;

namespace BeloPrato.Core.Communication.Mediator
{
    public class MediatrHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatrHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishEvent<T>(T eventToPublish) where T : Event
        {
            await _mediator.Publish(eventToPublish);
        }

        public async Task<bool> SendCommand<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }

        public async Task PublishNotification<T>(T notification) where T : DomainNotification
        {
            await _mediator.Publish(notification);
        }
    }
}
