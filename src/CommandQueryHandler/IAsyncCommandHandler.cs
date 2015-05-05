using System.Threading.Tasks;

namespace CommandQueryHandler
{
    public interface IAsyncCommandHandler<T>
    {
        Task<CommandResponse> Execute(T message);
    }
}