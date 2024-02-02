using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;

namespace TailwindMerge.Tests;

public class ArbitraryVariantsTests
{
    private readonly TailwindMerge _TW;

    public ArbitraryVariantsTests()
    {
        _TW = new TailwindMerge();
    }

    [Fact]
    public void BasicArbitraryVariants()
    {
        Assert.Equal("[&>*]:line-through", _TW.Merge("[&>*]:underline [&>*]:line-through"));
        Assert.Equal("[&>*]:line-through [&_div]:line-through", _TW.Merge("[&>*]:underline [&>*]:line-through [&_div]:line-through"));
        Assert.Equal("supports-[display:grid]:grid", _TW.Merge("supports-[display:grid]:flex supports-[display:grid]:grid"));
    }

    [Fact]
    public void ArbitraryVariantsWithModifiers()
    {
        Assert.Equal("dark:lg:hover:[&>*]:line-through", _TW.Merge("dark:lg:hover:[&>*]:underline dark:lg:hover:[&>*]:line-through"));
        Assert.Equal("dark:hover:lg:[&>*]:line-through", _TW.Merge("dark:lg:hover:[&>*]:underline dark:hover:lg:[&>*]:line-through"));
        Assert.Equal("hover:[&>*]:underline [&>*]:hover:line-through", _TW.Merge("hover:[&>*]:underline [&>*]:hover:line-through"));
        Assert.Equal("dark:hover:[&>*]:underline dark:[&>*]:hover:line-through", _TW.Merge("hover:dark:[&>*]:underline dark:hover:[&>*]:underline dark:[&>*]:hover:line-through"));
    }

    [Fact]
    public void ArbitraryVariantsWithComplexSyntax()
    {
        Assert.Equal("[@media_screen{@media(hover:hover)}]:line-through", _TW.Merge("[@media_screen{@media(hover:hover)}]:underline [@media_screen{@media(hover:hover)}]:line-through"));
        Assert.Equal("hover:[@media_screen{@media(hover:hover)}]:line-through", _TW.Merge("hover:[@media_screen{@media(hover:hover)}]:underline hover:[@media_screen{@media(hover:hover)}]:line-through"));
    }

    [Fact]
    public void ArbitraryVariantsWithAttributeSelectors()
    {
        Assert.Equal("[&[data-open]]:line-through", _TW.Merge("[&[data-open]]:underline [&[data-open]]:line-through"));
    }

    [Fact]
    public void ArbitraryVariantsWithMultipleAttributeSelectors()
    {
        Assert.Equal("[&[data-foo][data-bar]:not([data-baz])]:line-through", _TW.Merge("[&[data-foo][data-bar]:not([data-baz])]:underline [&[data-foo][data-bar]:not([data-baz])]:line-through"));
    }

    [Fact]
    public void MultipleArbitraryVariants()
    {
        Assert.Equal("[&>*]:[&_div]:line-through", _TW.Merge("[&>*]:[&_div]:underline [&>*]:[&_div]:line-through"));
        Assert.Equal("[&>*]:[&_div]:underline [&_div]:[&>*]:line-through", _TW.Merge("[&>*]:[&_div]:underline [&_div]:[&>*]:line-through"));
        Assert.Equal("dark:hover:[&>*]:disabled:focus:[&_div]:line-through", _TW.Merge("hover:dark:[&>*]:focus:disabled:[&_div]:underline dark:hover:[&>*]:disabled:focus:[&_div]:line-through"));
        Assert.Equal("hover:dark:[&>*]:focus:[&_div]:disabled:underline dark:hover:[&>*]:disabled:focus:[&_div]:line-through", _TW.Merge("hover:dark:[&>*]:focus:[&_div]:disabled:underline dark:hover:[&>*]:disabled:focus:[&_div]:line-through"));
    }

    [Fact]
    public void ArbitraryVariantsWithArbitraryProperties()
    {
        Assert.Equal("[&>*]:[color:blue]", _TW.Merge("[&>*]:[color:red] [&>*]:[color:blue]"));
        Assert.Equal("[&[data-foo][data-bar]:not([data-baz])]:noa:nod:[color:blue]", _TW.Merge("[&[data-foo][data-bar]:not([data-baz])]:nod:noa:[color:red] [&[data-foo][data-bar]:not([data-baz])]:noa:nod:[color:blue]"));
    }
}

