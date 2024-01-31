namespace TailwindMerge.Tests;

public class ColoursTests
{
    [Fact]
    public void Merge_KeepsLastBackgroundColor_WhenThereIsConflict()
    {
        var result = TW.Merge("bg-grey-5", "bg-hotpink");
        Assert.Equal("bg-hotpink", result);
    }

    [Fact]
    public void Merge_KeepsLastHoverBackgroundColor_WhenThereIsConflict()
    {
        var result = TW.Merge("hover:bg-grey-5", "hover:bg-hotpink");
        Assert.Equal("hover:bg-hotpink", result);
    }
}