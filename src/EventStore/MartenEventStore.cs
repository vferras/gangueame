using System.Threading.Tasks;
using Marten;

namespace Gangueame.Eventstore
{
    public class MartenEventStore : IEventStore
    {
        private readonly IDocumentStore _store;

        public MartenEventStore(IDocumentStore store)
        {
            _store = store;
        }

        public Task AppendEvents<TAggregate>(string streamId, params object[] events)
        {
            using (var session = _store.OpenSession())
            {
                session.Events.Append(streamId, events);
                return session.SaveChangesAsync();
            }
        }
    }
}
