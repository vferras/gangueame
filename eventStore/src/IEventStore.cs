using System.Threading.Tasks;

namespace Gangueame.Eventstore
{
    public interface IEventStore
    {
        Task AppendEvents<TAggregate>(string streamId, params object[] events);
    }
}