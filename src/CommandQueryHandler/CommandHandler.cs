namespace CommandQueryHandler
{
    public abstract class CommandHandler<T> : ICommandHandler<T>
    {
        public abstract CommandResponse Execute(T message);    
    }
}