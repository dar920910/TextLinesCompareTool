//-----------------------------------------------------------------------
// <copyright file="LinesStorageSetTest.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TextLinesComparing.Testing;

using TextLinesComparing.Library;

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
        LinesStorageSet set = new (new string[] { "A", "B", "C" });

        set.PutContent(new LineInfo("D"));
        set.PutContent(new LineInfo("E"));
        set.PutContent(new LineInfo("F"));

        Assert.That(set.Content, Is.EqualTo(
            new string[] { "A", "B", "C", "D", "E", "F" }));
    }
}
