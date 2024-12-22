using Soenneker.ServiceBus.Sender.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.ServiceBus.Sender.Tests;

[Collection("Collection")]
public class ServiceBusSenderUtilTests : FixturedUnitTest
{
    private readonly IServiceBusSenderUtil _util;

    public ServiceBusSenderUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IServiceBusSenderUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
