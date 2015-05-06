namespace CommandQueryHandler
{
    public abstract class QueryHandler<T> : IQueryHandler<T>
    {
        public abstract object Execute(T message);
    }
}