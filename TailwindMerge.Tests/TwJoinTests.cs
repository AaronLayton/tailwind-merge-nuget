using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;
using System.ComponentModel.DataAnnotations;

namespace TailwindMerge.Tests;

public class TwJoinTests
{
    [Fact]
    public void Strings()
    {
        //Assert.Equal("", TwJoin(""));
        //Assert.Equal("foo", TwJoin("foo"));
        //Assert.Equal("foo", TwJoin(true && "foo"));
        //Assert.Equal("", TwJoin(false && "foo"));
    }

    [Fact]
    public void StringsVariadic()
    {
        //Assert.Equal("", TwJoin(""));
        //Assert.Equal("foo bar", TwJoin("foo", "bar"));
        //Assert.Equal("foo baz", TwJoin(true && "foo", false && "bar", "baz"));
        //Assert.Equal("bar baz", TwJoin(false && "foo", "bar", "baz", ""));
    }

    [Fact]
    public void Arrays()
    {
        //Assert.Equal("", TwJoin(new string[] { }));
        //Assert.Equal("foo", TwJoin(new string[] { "foo" }));
        //Assert.Equal("foo bar", TwJoin(new string[] { "foo", "bar" }));
        //Assert.Equal("foo baz", TwJoin(new string[] { "foo", 0 && "bar", 1 && "baz" }));
    }

    [Fact]
    public void ArraysNested()
    {
        //Assert.Equal("", TwJoin(new object[] { new object[] { new object[] { } } }));
        //Assert.Equal("foo", TwJoin(new object[] { new object[] { new object[] { "foo" } } }));
        //Assert.Equal("foo", TwJoin(new object[] { false, new object[] { new object[] { "foo" } } }));
        //Assert.Equal("foo bar baz", TwJoin(new object[] { "foo", new object[] { "bar", new object[] { "", new object[] { new object[] { "baz" } } } } }));
    }

    [Fact]
    public void ArraysVariadic()
    {
        //Assert.Equal("", TwJoin(new string[] { }, new string[] { }));
        //Assert.Equal("foo bar", TwJoin(new string[] { "foo" }, new string[] { "bar" }));
        //Assert.Equal("foo baz", TwJoin(new string[] { "foo" }, null, new string[] { "baz", "" }, false, "", new string[] { }));
    }
}