using TextLinesComparing.Library;

namespace TextLinesComparing.Testing;

public class LineInfoTest
{
    private string _ExampleString;

    private const string LOWER_TEST_STRING = "/aaa/bbb/ccc/ddd/eee/";
    private const string UPPER_TEST_STRING = "\\AAA\\BBB\\CCC\\DDD\\EEE\\";

    [SetUp]
    public void Setup()
    {
        _ExampleString = default;
    }

    [Test]
    public void GetLinePairInfo_TestCase_1()
    {
        _ExampleString = LOWER_TEST_STRING;

        Assert.That(actual: new LineInfo(_ExampleString).Content,
            expression: Is.EqualTo(
                new KeyValuePair<int, string>(
                    key: _ExampleString.GetHashCode(), value: _ExampleString)));
    }

    [Test]
    public void GetLinePairInfo_TestCase_2()
    {
        _ExampleString = UPPER_TEST_STRING;

        Assert.That(actual: new LineInfo(_ExampleString).Content,
            expression: Is.EqualTo(
                new KeyValuePair<int, string>(
                    key: _ExampleString.GetHashCode(), value: _ExampleString)));
    }


    [Test]
    public void GetKeyOfPair_TestCase_1()
    {
        _ExampleString = LOWER_TEST_STRING;

        Assert.That(
            actual: new LineInfo(_ExampleString).Content.Key,
            expression: Is.EqualTo(_ExampleString.GetHashCode()));
    }

    [Test]
    public void GetKeyOfPair_TestCase_2()
    {
        _ExampleString = UPPER_TEST_STRING;

        Assert.That(
            actual: new LineInfo(_ExampleString).Content.Key,
            expression: Is.EqualTo(_ExampleString.GetHashCode()));
    }


    [Test]
    public void GetValueOfPair_TestCase_1()
    {
        _ExampleString = LOWER_TEST_STRING;

        Assert.That(
            actual: new LineInfo(_ExampleString).Content.Value,
            expression: Is.EqualTo(_ExampleString));
    }

    [Test]
    public void GetValueOfPair_TestCase_2()
    {
        _ExampleString = UPPER_TEST_STRING;

        Assert.That(
            actual: new LineInfo(_ExampleString).Content.Value,
            expression: Is.EqualTo(_ExampleString));
    }
}
