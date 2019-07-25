using Marten;

namespace gangueame.eventstore
{
    public class EventStore
    {
        private readonly DocumentStore _store;

        public EventStore()
        {
            _store = DocumentStore.For("host=localhost;database=marten_test;password=mypassword;username=someuser");
        }


    }
}
