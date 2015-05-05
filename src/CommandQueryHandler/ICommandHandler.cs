namespace CommandQueryHandler
{
    public interface ICommandHandler<T>
    {
        CommandResponse Execute(T message);
    }
}