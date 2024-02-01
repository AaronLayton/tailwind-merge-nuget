﻿using Xunit;
using TailwindMerge.Tests;
using TailwindMerge;

namespace TailwindMerge.Tests;

public class ArbitraryPropertiesTests
{
    [Fact]
    public void HandlesArbitraryPropertyConflictsCorrectly()
    {
        Assert.Equal("[paint-order:normal]", TW.Merge("[paint-order:markers] [paint-order:normal]"));
        Assert.Equal("[paint-order:normal] [--my-var:4px]", TW.Merge("[paint-order:markers] [--my-var:2rem] [paint-order:normal] [--my-var:4px]"));
    }

    [Fact]
    public void HandlesArbitraryPropertyConflictsWithModifiersCorrectly()
    {
        Assert.Equal("[paint-order:markers] hover:[paint-order:normal]", TW.Merge("[paint-order:markers] hover:[paint-order:normal]"));
        Assert.Equal("hover:[paint-order:normal]", TW.Merge("hover:[paint-order:markers] hover:[paint-order:normal]"));
        Assert.Equal("focus:hover:[paint-order:normal]", TW.Merge("hover:focus:[paint-order:markers] focus:hover:[paint-order:normal]"));
        Assert.Equal("[paint-order:normal] [--my-var:2rem] lg:[--my-var:4px]", TW.Merge("[paint-order:markers] [paint-order:normal] [--my-var:2rem] lg:[--my-var:4px]"));
    }

    [Fact]
    public void HandlesComplexArbitraryPropertyConflictsCorrectly()
    {
        Assert.Equal("[-unknown-prop:url(https://hi.com)]", TW.Merge("[-unknown-prop:::123:::] [-unknown-prop:url(https://hi.com)]"));
    }

    [Fact]
    public void HandlesImportantModifierCorrectly()
    {
        Assert.Equal("![some:prop] [some:other]", TW.Merge("![some:prop] [some:other]"));
        Assert.Equal("[some:one] ![some:another]", TW.Merge("![some:prop] [some:other] [some:one] ![some:another]"));
    }
}
