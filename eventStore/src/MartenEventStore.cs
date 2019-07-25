using System.Threading.Tasks;
using Marten;

namespace Gangueame.Eventstore
{
    public class MartenEventStore : IEventStore
    {
        private readonly DocumentStore _store;

        public MartenEventStore()
        {
            _store = DocumentStore.For(_ =>
            {
                _.Connection("host=localhost;database=gangueame;password=;username=");
            });
        }

        public Task AppendEvents<TAggregate>(string streamId, params object[] events)
        {
            Task task;

            using (var session = _store.OpenSession())
            {
                session.Events.Append(streamId, events);
                task = session.SaveChangesAsync();
            }

            return task;
        }
    }
}
