using System.Threading;
using System.Threading.Tasks;
using MediatR;
using YtDeveloppement.EventSourcing.Orders.Domain.Abstractions;
using YtDeveloppement.EventSourcing.Orders.Domain.Events;

namespace Orders.Application.Behaviours
{
    public class EventSourcingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEventRepository _eventStore;

        public EventSourcingBehaviour(IEventRepository eventStore)
        {
            _eventStore = eventStore;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var response = await next();
            await _eventStore.RecordAsync(request as EventBase); // Persisting the event
            return response;
        }
    }
}
