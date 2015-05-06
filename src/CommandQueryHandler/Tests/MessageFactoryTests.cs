using AutoMapper;
using NUnit.Framework;
using Should;
using StructureMap;

namespace CommandQueryHandler.Tests
{
    [TestFixture]
    public class MessageFactoryTests
    {
        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            var container = new Container(x =>
            {
                x.ForConcreteType<TestData>();
                x.ForConcreteType<TestMessage>();
            });


            Mapper.Initialize(x =>
            {
                x.ConstructServicesUsing(container.GetInstance);

                Mapper.CreateMap<TestModel, TestMessage>()
                    .ConstructUsing((model) => new TestMessage(model.AggregateId));
            });
        }

        [Test]
        public void can_create_a_message()
        {
            //scenario get data for screen
            //present data
            //allow submit of screen
            //populate model from screen
            //model should be valid


            var projection = new TestData().GetProjection();

            var model = new TestModel
            {
                AggregateId = projection.AggregateId,
                Id = projection.Id,
                Name = projection.Name
            };

            var message = MessageForge.Create<TestMessage>(model);

            message.ShouldNotBeNull();
            message.Name.ShouldNotBeNull();
            message.Id.ShouldEqual(1);
            message.AggregateId.ShouldBeGreaterThan(0);
        }
    }

    public class TestData
    {
        public int Get()
        {
            return 1;
        }

        public TestQueryProjection GetProjection()
        {
            return new TestQueryProjection
            {
                Id = 1,
                Name = "zippy",
                AggregateId = 1
            };
        }
    }

    public interface IQueryProjection
    {
        int AggregateId { get; set; }
    }

    public class TestQueryProjection : IQueryProjection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AggregateId { get; set; }
    }

    public class TestMessage : DbCommandMessage
    {
        public TestMessage(int aggregateId):base(aggregateId)
        {
        }

        public int Id { get;  set; }
        public string Name { get;  set; }
    }

    public class TestModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int AggregateId { get; set; }
    }
}