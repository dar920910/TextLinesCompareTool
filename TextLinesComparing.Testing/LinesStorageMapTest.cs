//-----------------------------------------------------------------------
// <copyright file="LinesStorageMapTest.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TextLinesComparing.Testing;

using TextLinesComparing.Library;

public class LinesStorageMapTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void PutContent_TestCase_1()
    {
        const string example = "1111111111";
        LineInfo info = new (example);

        Assert.That(
            actual: new LinesStorageMap(info).Content,
            expression: Is.EqualTo(
                new Dictionary<int, string>()
                {
                    { info.Content.Key, info.Content.Value },
                }));
    }

    [Test]
    public void PutContent_TestCase_2()
    {
        const string example_1 = "1111111111";
        const string example_2 = "2222222222";

        LineInfo info_1 = new (example_1);
        LineInfo info_2 = new (example_2);

        LinesStorageMap map = new ();
        map.PutContent(info_1);
        map.PutContent(info_2);

        Assert.That(
            actual: map.Content,
            expression: Is.EqualTo(
                new Dictionary<int, string>()
                {
                    { info_1.Content.Key, info_1.Content.Value },
                    { info_2.Content.Key, info_2.Content.Value },
                }));
    }

    [Test]
    public void PutContent_TestCase_3()
    {
        const string example_1 = "1111111111";
        const string example_2 = "2222222222";
        const string example_3 = "3333333333";

        LineInfo info_1 = new (example_1);
        LineInfo info_2 = new (example_2);
        LineInfo info_3 = new (example_3);

        LinesStorageMap map = new ();
        map.PutContent(info_1);
        map.PutContent(info_2);
        map.PutContent(info_3);

        Assert.That(
            actual: map.Content,
            expression: Is.EqualTo(
                new Dictionary<int, string>()
                {
                    { info_1.Content.Key, info_1.Content.Value },
                    { info_2.Content.Key, info_2.Content.Value },
                    { info_3.Content.Key, info_3.Content.Value },
                }));
    }
}
