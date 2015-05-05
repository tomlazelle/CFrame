using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Should;

namespace CommandQueryHandler.Tests
{
    [TestFixture]
    public class CommandTestFixture
    {
        [Test]
        public async void can_create_a_new_command()
        {
            var cmd = new TrueTestCommand();

            var response = await cmd.Execute("test");

            response.Success.ShouldBeTrue();
        }
    }

    public class TrueTestCommand:AsyncCommandHandler<string>
    {
        public override async Task<CommandResponse> Execute(string message)
        {         
            

            return await Task.FromResult(new CommandResponse
            {
                Success = !string.IsNullOrEmpty(message)
            });
        }
        
    }
}