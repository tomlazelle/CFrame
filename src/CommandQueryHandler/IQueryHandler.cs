namespace CommandQueryHandler
{
    public interface IQueryHandler<T>
    {
        object Execute(T message);
    }
}