namespace CommandQueryHandler
{
    public interface ICommandMessage
    {
        int AggregateId { get; }
    }

    public abstract class DbCommandMessage:ICommandMessage
    {
        public int AggregateId { get; private set; }

        public DbCommandMessage(int aggregateId)
        {
            AggregateId = aggregateId;
        }


    }
}