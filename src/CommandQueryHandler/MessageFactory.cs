using AutoMapper;
namespace CommandQueryHandler
{
    public static class MessageFactory
    {
        public static T ToMessage<T>(object model)
        {
            return Mapper.Map<T>(model);
        }
    }
}