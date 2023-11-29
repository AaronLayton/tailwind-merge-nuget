namespace TailwindMerge.Tests;
using TailwindMerge; // Replace with the namespace of your class library

public class TWTests
{
    [Fact]
    public void Merge_SingleClass_ReturnsSameClass()
    {
        var result = TW.Merge("text-red-500");
        Assert.Equal("text-red-500", result);
    }

    [Fact]
    public void Merge_DuplicateClasses_ReturnsSingleClass()
    {
        var result = TW.Merge("text-red-500", "text-red-500");
        Assert.Equal("text-red-500", result);
    }

    [Fact]
    public void Merge_MultipleDifferentClasses_ReturnsAllClasses()
    {
        var result = TW.Merge("p-4", "m-2");
        Assert.Equal("p-4 m-2", result);
    }

    [Fact]
    public void Merge_ConflictingClasses_ReturnsLastInstance()
    {
        var result = TW.Merge("text-red-500", "text-blue-600");
        Assert.Equal("text-blue-600", result);
    }

    [Fact]
    public void Merge_MixedClasses_KeepsNonConflictingAndLastInstanceOfConflicting()
    {
        var result = TW.Merge("p-4", "text-red-500", "m-2", "text-blue-600");
        Assert.Equal("p-4 text-blue-600 m-2", result);
    }

    [Fact]
    public void Merge_ClassesWithNoHyphen_AreTreatedIndividually()
    {
        var result = TW.Merge("block", "inline");
        Assert.Equal("block inline", result);
    }

    [Fact]
    public void Merge_ClassesWithAndWithoutHyphen_GroupsAreHandledCorrectly()
    {
        var result = TW.Merge("block", "p-4", "inline", "p-2");
        Assert.Equal("block p-2 inline", result);
    }

    [Fact]
    public void Merge_EmptyStrings_Ignored()
    {
        var result = TW.Merge("", "p-4", "", "m-2");
        Assert.Equal("p-4 m-2", result);
    }

    [Fact]
    public void Merge_NullInputs_ReturnsEmptyString()
    {
        var result = TW.Merge(null, null);
        Assert.Equal("", result);
    }

    [Fact]
    public void Merge_WhitespaceInputs_Ignored()
    {
        var result = TW.Merge("  ", "p-4", "   ", "m-2");
        Assert.Equal("p-4 m-2", result);
    }

    [Fact]
    public void Merge_MultipleClassesWithSamePrefix_ReturnsLastOfClassEachPrefix()
    {
        var result = TW.Merge("bg-red-500", "p-4", "bg-blue-600", "p-2");
        Assert.Equal("bg-blue-600 p-2", result);
    }

    [Theory]
    [InlineData(true, "bg-blue-600", "bg-blue-600")]
    [InlineData(false, "bg-blue-600", "bg-red-500")]
    public void Merge_ConditionalClass_IncludesClassBasedOnCondition(bool condition, string conditionalClass, string expected)
    {
        var result = TW.Merge("bg-red-500", condition ? conditionalClass : null);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(true, "bg-blue-600", "bg-blue-600")]
    [InlineData(false, "bg-blue-600", "bg-red-500")]
    public void Merge_ConditionalClassWithEmptyString_IncludesClassBasedOnCondition(bool condition, string conditionalClass, string expected)
    {
        var result = TW.Merge("bg-red-500", condition ? conditionalClass : "");
        Assert.Equal(expected, result);
    }
}