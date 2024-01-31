namespace TailwindMerge.Tests;

public class ValidatorTests
{
    [Fact]
    public void IsLengthTests()
    {
        Assert.True(Validators.IsLength("1"));
        Assert.True(Validators.IsLength("1023713"));
        Assert.True(Validators.IsLength("1.5"));
        Assert.True(Validators.IsLength("1231.503761"));
        Assert.True(Validators.IsLength("px"));
        Assert.True(Validators.IsLength("full"));
        Assert.True(Validators.IsLength("screen"));
        Assert.True(Validators.IsLength("1/2"));
        Assert.True(Validators.IsLength("123/345"));

        Assert.False(Validators.IsLength("[3.7%]"));
        Assert.False(Validators.IsLength("[481px]"));
        Assert.False(Validators.IsLength("[19.1rem]"));
        Assert.False(Validators.IsLength("[50vw]"));
        Assert.False(Validators.IsLength("[56vh]"));
        Assert.False(Validators.IsLength("[length:var(--arbitrary)]"));
        Assert.False(Validators.IsLength("1d5"));
        Assert.False(Validators.IsLength("[1]"));
        Assert.False(Validators.IsLength("[12px"));
        Assert.False(Validators.IsLength("12px]"));
        Assert.False(Validators.IsLength("one"));
    }

    [Fact]
    public void IsArbitraryLengthTests()
    {
        Assert.True(Validators.IsArbitraryLength("[3.7%]"));
        Assert.True(Validators.IsArbitraryLength("[481px]"));
        Assert.True(Validators.IsArbitraryLength("[19.1rem]"));
        Assert.True(Validators.IsArbitraryLength("[50vw]"));
        Assert.True(Validators.IsArbitraryLength("[56vh]"));
        Assert.True(Validators.IsArbitraryLength("[length:var(--arbitrary)]"));

        Assert.False(Validators.IsArbitraryLength("1"));
        Assert.False(Validators.IsArbitraryLength("3px"));
        Assert.False(Validators.IsArbitraryLength("1d5"));
        Assert.False(Validators.IsArbitraryLength("[1]"));
        Assert.False(Validators.IsArbitraryLength("[12px"));
        Assert.False(Validators.IsArbitraryLength("12px]"));
        Assert.False(Validators.IsArbitraryLength("one"));
    }

    [Fact]
    public void IsIntegerTests()
    {
        Assert.True(Validators.IsInteger("1"));
        Assert.True(Validators.IsInteger("123"));
        Assert.True(Validators.IsInteger("8312"));

        Assert.False(Validators.IsInteger("[8312]"));
        Assert.False(Validators.IsInteger("[2]"));
        Assert.False(Validators.IsInteger("[8312px]"));
        Assert.False(Validators.IsInteger("[8312%]"));
        Assert.False(Validators.IsInteger("[8312rem]"));
        Assert.False(Validators.IsInteger("8312.2"));
        Assert.False(Validators.IsInteger("1.2"));
        Assert.False(Validators.IsInteger("one"));
        Assert.False(Validators.IsInteger("1/2"));
        Assert.False(Validators.IsInteger("1%"));
        Assert.False(Validators.IsInteger("1px"));
    }

    [Fact]
    public void IsArbitraryValueTests()
    {
        Assert.True(Validators.IsArbitraryValue("[1]"));
        Assert.True(Validators.IsArbitraryValue("[bla]"));
        Assert.True(Validators.IsArbitraryValue("[not-an-arbitrary-value?]"));
        Assert.True(Validators.IsArbitraryValue("[auto,auto,minmax(0,1fr),calc(100vw-50%)]"));

        Assert.False(Validators.IsArbitraryValue("[]"));
        Assert.False(Validators.IsArbitraryValue("[1"));
        Assert.False(Validators.IsArbitraryValue("1]"));
        Assert.False(Validators.IsArbitraryValue("1"));
        Assert.False(Validators.IsArbitraryValue("one"));
        Assert.False(Validators.IsArbitraryValue("o[n]e"));
    }

    [Fact]
    public void IsAnyTests()
    {
        Assert.True(Validators.IsAny());
        // TypeScript specific @ts-expect-error tests are not applicable in C#
    }

    [Fact]
    public void IsTshirtSizeTests()
    {
        Assert.True(Validators.IsTshirtSize("xs"));
        Assert.True(Validators.IsTshirtSize("sm"));
        Assert.True(Validators.IsTshirtSize("md"));
        Assert.True(Validators.IsTshirtSize("lg"));
        Assert.True(Validators.IsTshirtSize("xl"));
        Assert.True(Validators.IsTshirtSize("2xl"));
        Assert.True(Validators.IsTshirtSize("2.5xl"));
        Assert.True(Validators.IsTshirtSize("10xl"));
        Assert.True(Validators.IsTshirtSize("2xs"));
        Assert.True(Validators.IsTshirtSize("2lg"));

        Assert.False(Validators.IsTshirtSize(""));
        Assert.False(Validators.IsTshirtSize("hello"));
        Assert.False(Validators.IsTshirtSize("1"));
        Assert.False(Validators.IsTshirtSize("xl3"));
        Assert.False(Validators.IsTshirtSize("2xl3"));
        Assert.False(Validators.IsTshirtSize("-xl"));
        Assert.False(Validators.IsTshirtSize("[sm]"));
    }

    [Fact]
    public void IsArbitrarySizeTests()
    {
        Assert.True(Validators.IsArbitrarySize("[size:2px]"));
        Assert.True(Validators.IsArbitrarySize("[size:bla]"));
        Assert.True(Validators.IsArbitrarySize("[length:bla]"));
        Assert.True(Validators.IsArbitrarySize("[percentage:bla]"));

        Assert.False(Validators.IsArbitrarySize("[2px]"));
        Assert.False(Validators.IsArbitrarySize("[bla]"));
        Assert.False(Validators.IsArbitrarySize("size:2px"));
    }

    [Fact]
    public void IsArbitraryPositionTests()
    {
        Assert.True(Validators.IsArbitraryPosition("[position:2px]"));
        Assert.True(Validators.IsArbitraryPosition("[position:bla]"));

        Assert.False(Validators.IsArbitraryPosition("[2px]"));
        Assert.False(Validators.IsArbitraryPosition("[bla]"));
        Assert.False(Validators.IsArbitraryPosition("position:2px"));
    }

    [Fact]
    public void IsArbitraryImageTests()
    {
        Assert.True(Validators.IsArbitraryImage("[url:var(--my-url)]"));
        Assert.True(Validators.IsArbitraryImage("[url(something)]"));
        Assert.True(Validators.IsArbitraryImage("[url:bla]"));
        Assert.True(Validators.IsArbitraryImage("[image:bla]"));
        Assert.True(Validators.IsArbitraryImage("[linear-gradient(something)]"));
        Assert.True(Validators.IsArbitraryImage("[repeating-conic-gradient(something)]"));

        Assert.False(Validators.IsArbitraryImage("[var(--my-url)]"));
        Assert.False(Validators.IsArbitraryImage("[bla]"));
        Assert.False(Validators.IsArbitraryImage("url:2px"));
        Assert.False(Validators.IsArbitraryImage("url(2px)"));
    }

    [Fact]
    public void IsArbitraryNumberTests()
    {
        Assert.True(Validators.IsArbitraryNumber("[number:black]"));
        Assert.True(Validators.IsArbitraryNumber("[number:bla]"));
        Assert.True(Validators.IsArbitraryNumber("[number:230]"));
        Assert.True(Validators.IsArbitraryNumber("[450]"));

        Assert.False(Validators.IsArbitraryNumber("[2px]"));
        Assert.False(Validators.IsArbitraryNumber("[bla]"));
        Assert.False(Validators.IsArbitraryNumber("[black]"));
        Assert.False(Validators.IsArbitraryNumber("black"));
        Assert.False(Validators.IsArbitraryNumber("450"));
    }

    [Fact]
    public void IsArbitraryShadowTests()
    {
        Assert.True(Validators.IsArbitraryShadow("[0_35px_60px_-15px_rgba(0,0,0,0.3)]"));
        Assert.True(Validators.IsArbitraryShadow("[0_0_#00f]"));
        Assert.True(Validators.IsArbitraryShadow("[.5rem_0_rgba(5,5,5,5)]"));
        Assert.True(Validators.IsArbitraryShadow("[-.5rem_0_#123456]"));
        Assert.True(Validators.IsArbitraryShadow("[0.5rem_-0_#123456]"));
        Assert.True(Validators.IsArbitraryShadow("[0.5rem_-0.005vh_#123456]"));
        Assert.True(Validators.IsArbitraryShadow("[0.5rem_-0.005vh]"));

        Assert.False(Validators.IsArbitraryShadow("[rgba(5,5,5,5)]"));
        Assert.False(Validators.IsArbitraryShadow("[#00f]"));
        Assert.False(Validators.IsArbitraryShadow("[something-else]"));
    }

    [Fact]
    public void IsPercentTests()
    {
        Assert.True(Validators.IsPercent("1%"));
        Assert.True(Validators.IsPercent("100.001%"));
        Assert.True(Validators.IsPercent(".01%"));
        Assert.True(Validators.IsPercent("0%"));

        Assert.False(Validators.IsPercent("0"));
        Assert.False(Validators.IsPercent("one%"));
    }
}