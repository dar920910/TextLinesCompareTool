//-----------------------------------------------------------------------
// <copyright file="LineInfoTest.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TextLinesComparing.Testing;

using TextLinesComparing.Library;

public class LineInfoTest
{
    private const string LowerTestString = "/aaa/bbb/ccc/ddd/eee/";
    private const string UpperTestString = "\\AAA\\BBB\\CCC\\DDD\\EEE\\";

    private string exampleTestString;

    [SetUp]
    public void Setup()
    {
        this.exampleTestString = default;
    }

    [Test]
    public void GetLinePairInfo_TestCase_1()
    {
        this.exampleTestString = LowerTestString;

        Assert.That(
            actual: new LineInfo(this.exampleTestString).Content,
            expression: Is.EqualTo(
                new KeyValuePair<int, string>(
                    key: this.exampleTestString.GetHashCode(), value: this.exampleTestString)));
    }

    [Test]
    public void GetLinePairInfo_TestCase_2()
    {
        this.exampleTestString = UpperTestString;

        Assert.That(
            actual: new LineInfo(this.exampleTestString).Content,
            expression: Is.EqualTo(
                new KeyValuePair<int, string>(
                    key: this.exampleTestString.GetHashCode(), value: this.exampleTestString)));
    }

    [Test]
    public void GetKeyOfPair_TestCase_1()
    {
        this.exampleTestString = LowerTestString;

        Assert.That(
            actual: new LineInfo(this.exampleTestString).Content.Key,
            expression: Is.EqualTo(this.exampleTestString.GetHashCode()));
    }

    [Test]
    public void GetKeyOfPair_TestCase_2()
    {
        this.exampleTestString = UpperTestString;

        Assert.That(
            actual: new LineInfo(this.exampleTestString).Content.Key,
            expression: Is.EqualTo(this.exampleTestString.GetHashCode()));
    }

    [Test]
    public void GetValueOfPair_TestCase_1()
    {
        this.exampleTestString = LowerTestString;

        Assert.That(
            actual: new LineInfo(this.exampleTestString).Content.Value,
            expression: Is.EqualTo(this.exampleTestString));
    }

    [Test]
    public void GetValueOfPair_TestCase_2()
    {
        this.exampleTestString = UpperTestString;

        Assert.That(
            actual: new LineInfo(this.exampleTestString).Content.Value,
            expression: Is.EqualTo(this.exampleTestString));
    }

    [Test]
    public void CalculateHashForString()
    {
        const string test_string = "A-B-C-D-E-F-G-H";

        int expected_hash = test_string.GetHashCode();
        int actual_hash = LineInfo.GenerateLineHash(test_string);

        Assert.That(actual_hash, Is.EqualTo(expected_hash));
    }

    [Test]
    public void CompareHashForEqualStrings()
    {
        const string test_string_1 = "A-B-C-D-E-F-G-H";
        const string test_string_2 = "A-B-C-D-E-F-G-H";

        int hash_1 = LineInfo.GenerateLineHash(test_string_1);
        int hash_2 = LineInfo.GenerateLineHash(test_string_2);

        Assert.That(actual: hash_1, expression: Is.EqualTo(hash_2));
    }

    [Test]
    public void CompareHashForNotEqualStrings()
    {
        const string test_string_1 = "A-B-C-D-E-F-G-H";
        const string test_string_2 = "a-b-c-d-e-f-g-h";

        int hash_1 = LineInfo.GenerateLineHash(test_string_1);
        int hash_2 = LineInfo.GenerateLineHash(test_string_2);

        Assert.That(actual: hash_1, expression: Is.Not.EqualTo(hash_2));
    }

    [Test]
    public void CompareHashForCustomEqualStrings()
    {
        Assert.Multiple(() =>
        {
            Assert.That(
                actual: LineInfo.GenerateLineHash("0123456789"),
                expression: Is.EqualTo("0123456789".GetHashCode()));

            Assert.That(
                actual: LineInfo.GenerateLineHash("1234567890"),
                expression: Is.EqualTo("1234567890".GetHashCode()));

            Assert.That(
                actual: LineInfo.GenerateLineHash("2345678901"),
                expression: Is.EqualTo("2345678901".GetHashCode()));

            Assert.That(
                actual: LineInfo.GenerateLineHash("3456789012"),
                expression: Is.EqualTo("3456789012".GetHashCode()));

            Assert.That(
                actual: LineInfo.GenerateLineHash("4567890123"),
                expression: Is.EqualTo("4567890123".GetHashCode()));

            Assert.That(
                actual: LineInfo.GenerateLineHash("5678901234"),
                expression: Is.EqualTo("5678901234".GetHashCode()));

            Assert.That(
                actual: LineInfo.GenerateLineHash("6789012345"),
                expression: Is.EqualTo("6789012345".GetHashCode()));

            Assert.That(
                actual: LineInfo.GenerateLineHash("7890123456"),
                expression: Is.EqualTo("7890123456".GetHashCode()));

            Assert.That(
                actual: LineInfo.GenerateLineHash("8901234567"),
                expression: Is.EqualTo("8901234567".GetHashCode()));

            Assert.That(
                actual: LineInfo.GenerateLineHash("9012345678"),
                expression: Is.EqualTo("9012345678".GetHashCode()));
        });
    }

    [Test]
    public void CompareHashForCustomNotEqualStrings()
    {
        Assert.Multiple(() =>
        {
            Assert.That(
                actual: LineInfo.GenerateLineHash("012345678"),
                expression: Is.Not.EqualTo("123456789".GetHashCode()));

            Assert.That(
                actual: LineInfo.GenerateLineHash("123456789"),
                expression: Is.Not.EqualTo("234567890".GetHashCode()));
            Assert.That(
                actual: LineInfo.GenerateLineHash("234567890"),
                expression: Is.Not.EqualTo("345678901".GetHashCode()));
            Assert.That(
                actual: LineInfo.GenerateLineHash("345678901"),
                expression: Is.Not.EqualTo("456789012".GetHashCode()));
            Assert.That(
                actual: LineInfo.GenerateLineHash("456789012"),
                expression: Is.Not.EqualTo("567890123".GetHashCode()));
            Assert.That(
                actual: LineInfo.GenerateLineHash("567890123"),
                expression: Is.Not.EqualTo("678901234".GetHashCode()));
            Assert.That(
                actual: LineInfo.GenerateLineHash("678901234"),
                expression: Is.Not.EqualTo("789012345".GetHashCode()));
            Assert.That(
                actual: LineInfo.GenerateLineHash("789012345"),
                expression: Is.Not.EqualTo("890123456".GetHashCode()));
            Assert.That(
                actual: LineInfo.GenerateLineHash("890123456"),
                expression: Is.Not.EqualTo("901234567".GetHashCode()));
            Assert.That(
                actual: LineInfo.GenerateLineHash("901234567"),
                expression: Is.Not.EqualTo("012345678".GetHashCode()));
        });
    }
}
