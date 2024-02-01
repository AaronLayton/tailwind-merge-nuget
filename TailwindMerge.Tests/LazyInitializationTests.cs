using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;

namespace TailwindMerge.Tests;

public class LazyInitializationTests
{
    [Fact]
    public void LazyInitialization()
    {
        //var initMock = new Mock<Config>();
        //initMock.Setup(x => x.GetDefaultConfig()).Returns(new Config());
        //var twMerge = new TailwindMerge(initMock.Object);

        //Assert.Equal(0, initMock.Invocations.Count);

        //twMerge.Merge();

        //Assert.Equal(1, initMock.Invocations.Count);

        //twMerge.Merge();
        //twMerge.Merge("");
        //twMerge.Merge("px-2 p-3 p-4");

        //Assert.Equal(1, initMock.Invocations.Count);
    }
}
