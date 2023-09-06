using TextLinesComparing.Library;

namespace TextLinesComparing.Testing;

public class LinesStorageSetTest
{
    [Test]
    public void GetContent_TestCase()
    {
        string[] sequence = { "A", "B", "C" };

        Assert.That(
            actual: new LinesStorageSet(sequence).Content,
            expression: Is.EqualTo(sequence));
    }

    [Test]
    public void PutContent_TestCase()
    {
        LinesStorageSet set = new(new string[] { "A", "B", "C" });

        set.PutContent("D");
        set.PutContent("E");
        set.PutContent("F");

        Assert.That(set.Content, Is.EqualTo(
            new string[] { "A", "B", "C", "D", "E", "F" }));
    }
}
