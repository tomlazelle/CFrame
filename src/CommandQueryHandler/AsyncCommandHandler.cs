using System.Threading.Tasks;

namespace CommandQueryHandler
{
    public abstract class AsyncCommandHandler<T> : IAsyncCommandHandler<T>
    {
        public abstract Task<CommandResponse> Execute(T message);
    
    }
}