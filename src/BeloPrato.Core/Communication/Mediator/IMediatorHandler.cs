using BeloPrato.Core.Messages;
using BeloPrato.Core.Messages.CommonMessages.Notifications;
using System.Threading.Tasks;

namespace BeloPrato.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T eventToPublish) where T : Event;
        Task<bool> SendCommand<T>(T command) where T : Command;
        Task PublishNotification<T>(T notification) where T : DomainNotification;
    }
}
