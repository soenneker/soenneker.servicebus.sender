using Soenneker.ServiceBus.Sender.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.ServiceBus.Sender.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class ServiceBusSenderUtilTests : HostedUnitTest
{
    private readonly IServiceBusSenderUtil _util;

    public ServiceBusSenderUtilTests(Host host) : base(host)
    {
        _util = Resolve<IServiceBusSenderUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
