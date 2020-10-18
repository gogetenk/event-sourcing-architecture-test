using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using YtDeveloppement.EventSourcing.Orders.Domain.Abstractions;
using YtDeveloppement.EventSourcing.Orders.Domain.Events;

namespace Orders.Application.Behaviours
{
    public class EventSourcingBehaviour<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        private readonly IEventStore _eventStore;

        public EventSourcingBehaviour(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public async Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            await _eventStore.RecordAsync(request as EventBase);
        }
    }
}
