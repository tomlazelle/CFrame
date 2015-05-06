using AutoMapper;
namespace CommandQueryHandler
{
    public static class MessageForge
    {
        public static T Create<T>(object model)
        {
            return Mapper.Map<T>(model);
        }
    }
}