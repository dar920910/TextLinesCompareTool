using TextLinesComparing.Library;

namespace TextLinesComparing.Testing;


public class LinesMainProcessorTest
{
    [Test]
    public void ExtractCommonLinesFromMapBasedSources_TestCase_1()
    {
        LinesStorageMap map_1 = new();
        map_1.PutContent(new LineInfo("sss/ggg"));
        map_1.PutContent(new LineInfo("/test1/"));
        map_1.PutContent(new LineInfo("/test2/"));
        map_1.PutContent(new LineInfo("/rrr/ttt"));
        map_1.PutContent(new LineInfo("/aaa/eee/"));
        map_1.PutContent(new LineInfo("/test/"));

        LinesStorageMap map_2 = new();
        map_2.PutContent(new LineInfo("/test2/"));
        map_2.PutContent(new LineInfo("vvvv/pppp"));
        map_2.PutContent(new LineInfo("/aaa/eee/"));
        map_2.PutContent(new LineInfo("sss/ggg"));
        map_2.PutContent(new LineInfo("/test/"));
        map_2.PutContent(new LineInfo("dddd/wwww"));
        map_2.PutContent(new LineInfo("/test1/"));

        LinesStorageMap expected_common_map = new();
        expected_common_map.PutContent(new LineInfo("/aaa/eee/"));
        expected_common_map.PutContent(new LineInfo("/test/"));
        expected_common_map.PutContent(new LineInfo("/test1/"));
        expected_common_map.PutContent(new LineInfo("/test2/"));
        expected_common_map.PutContent(new LineInfo("sss/ggg"));

        LinesStorageMap actual_common_map = LinesMainProcessor.ExtractCommonContent(map_1, map_2);

        Assert.That(actual_common_map.Content, Is.EqualTo(expected_common_map.Content));
    }

    [Test]
    public void ExtractCommonLinesFromMapBasedSources_TestCase_2()
    {
        LinesStorageMap map_1 = new();
        map_1.PutContent(new LineInfo("/test2/"));
        map_1.PutContent(new LineInfo("vvvv/pppp"));
        map_1.PutContent(new LineInfo("/aaa/eee/"));
        map_1.PutContent(new LineInfo("sss/ggg"));
        map_1.PutContent(new LineInfo("/test/"));
        map_1.PutContent(new LineInfo("dddd/wwww"));
        map_1.PutContent(new LineInfo("/test1/"));

        LinesStorageMap map_2 = new();
        map_2.PutContent(new LineInfo("sss/ggg"));
        map_2.PutContent(new LineInfo("/test2/"));
        map_2.PutContent(new LineInfo("vvvv/pppp"));
        map_2.PutContent(new LineInfo("/test1/"));
        map_2.PutContent(new LineInfo("/test/"));

        LinesStorageMap expected_common_map = new();
        expected_common_map.PutContent(new LineInfo("/test/"));
        expected_common_map.PutContent(new LineInfo("/test1/"));
        expected_common_map.PutContent(new LineInfo("/test2/"));
        expected_common_map.PutContent(new LineInfo("sss/ggg"));
        expected_common_map.PutContent(new LineInfo("vvvv/pppp"));

        LinesStorageMap actual_common_map = LinesMainProcessor.ExtractCommonContent(map_1, map_2);

        Assert.That(actual_common_map.Content, Is.EqualTo(expected_common_map.Content));
    }

    [Test]
    public void ExtractCommonLinesFromMapBasedSources_TestCase_3()
    {
        LinesStorageMap map_1 = new();
        map_1.PutContent(new LineInfo("sss/ggg"));
        map_1.PutContent(new LineInfo("/test2/"));
        map_1.PutContent(new LineInfo("vvvv/pppp"));
        map_1.PutContent(new LineInfo("/test1/"));
        map_1.PutContent(new LineInfo("/test/"));

        LinesStorageMap map_2 = new();
        map_2.PutContent(new LineInfo("/test/"));
        map_2.PutContent(new LineInfo("/test1/"));
        map_2.PutContent(new LineInfo("/test2/"));
        map_2.PutContent(new LineInfo("ddd/eee"));

        LinesStorageMap expected_common_map = new();
        expected_common_map.PutContent(new LineInfo("/test/"));
        expected_common_map.PutContent(new LineInfo("/test1/"));
        expected_common_map.PutContent(new LineInfo("/test2/"));

        LinesStorageMap actual_common_map = LinesMainProcessor.ExtractCommonContent(map_1, map_2);

        Assert.That(actual_common_map.Content, Is.EqualTo(expected_common_map.Content));
    }


    [Test]
    public void ExtractCommonLinesFromSetBasedSources_TestCase_1()
    {
        LinesStorageSet source_1 = new(new string[] { "sss/ggg", "/test1/", "/test2/", "/rrr/ttt", "/aaa/eee/", "/test/" });
        LinesStorageSet source_2 = new(new string[] { "/test2/", "vvvv/pppp", "/aaa/eee/", "sss/ggg", "/test/", "dddd/wwww", "/test1/" });

        LinesStorageSet common_storage = LinesMainProcessor.ExtractCommonContent(source_1, source_2);

        Assert.That(common_storage.Content, Is.EqualTo(new SortedSet<string>() {"/aaa/eee/", "/test/", "/test1/", "/test2/", "sss/ggg"}));
    }

    [Test]
    public void ExtractCommonLinesFromSetBasedSources_TestCase_2()
    {
        LinesStorageSet source_2 = new(new string[] { "/test2/", "vvvv/pppp", "/aaa/eee/", "sss/ggg", "/test/", "dddd/wwww", "/test1/" });
        LinesStorageSet source_3 = new(new string[] { "sss/ggg", "/test2/", "vvvv/pppp", "/test1/", "/test/" });

        LinesStorageSet common_storage = LinesMainProcessor.ExtractCommonContent(source_2, source_3);

        Assert.That(common_storage.Content, Is.EqualTo(new SortedSet<string>() {"/test/", "/test1/", "/test2/", "sss/ggg", "vvvv/pppp"}));
    }

    [Test]
    public void ExtractCommonLinesFromSetBasedSources_TestCase_3()
    {
        LinesStorageSet source_3 = new(new string[] { "sss/ggg", "/test2/", "vvvv/pppp", "/test1/", "/test/" });
        LinesStorageSet source_4 = new(new string[] { "/test/", "/test1/", "/test2/", "ddd/eee" });

        LinesStorageSet common_storage = LinesMainProcessor.ExtractCommonContent(source_3, source_4);

        Assert.That(common_storage.Content, Is.EqualTo(new SortedSet<string>() {"/test/", "/test1/", "/test2/"}));
    }


    [Test]
    public void ExtractUniqueLinesFromSource_TestCase_1()
    {
        LinesStorageSet compared_storage = new(new string[] { "/test/", "/test1/", "/test2/" });

        LinesStorageSet target_storage = new(new string[] { "sss/ggg", "/test1/", "/test2/", "/rrr/ttt", "/aaa/eee/", "/test/" });
        LinesStorageSet diff_storage = LinesMainProcessor.ExtractUniqueContent(target_storage, compared_storage);

        Assert.That(diff_storage.Content, Is.EqualTo(new SortedSet<string>() { "/aaa/eee/", "/rrr/ttt", "sss/ggg" }));
    }

    [Test]
    public void ExtractUniqueLinesFromSource_TestCase_2()
    {
        LinesStorageSet compared_storage = new(new string[] { "/test/", "/test1/", "/test2/" });

        LinesStorageSet target_storage = new(new string[] { "/test2/", "vvvv/pppp", "/aaa/eee/", "sss/ggg", "/test/", "dddd/wwww", "/test1/" });
        LinesStorageSet diff_storage = LinesMainProcessor.ExtractUniqueContent(target_storage, compared_storage);

        Assert.That(diff_storage.Content, Is.EqualTo(new SortedSet<string>() { "/aaa/eee/", "dddd/wwww", "sss/ggg", "vvvv/pppp" }));
    }

    [Test]
    public void ExtractUniqueLinesFromSource_TestCase_3()
    {
        LinesStorageSet compared_storage = new(new string[] { "/test/", "/test1/", "/test2/" });

        LinesStorageSet target_storage = new(new string[] { "sss/ggg", "/test2/", "vvvv/pppp", "/test1/", "/test/" });
        LinesStorageSet diff_storage = LinesMainProcessor.ExtractUniqueContent(target_storage, compared_storage);

        Assert.That(diff_storage.Content, Is.EqualTo(new SortedSet<string>() { "sss/ggg", "vvvv/pppp" }));
    }

    [Test]
    public void ExtractUniqueLinesFromSource_TestCase_4()
    {
        LinesStorageSet compared_storage = new(new string[] { "/test/", "/test1/", "/test2/" });

        LinesStorageSet target_storage = new(new string[] { "/test/", "/test1/", "/test2/", "ddd/eee" });
        LinesStorageSet diff_storage = LinesMainProcessor.ExtractUniqueContent(target_storage, compared_storage);

        Assert.That(diff_storage.Content, Is.EqualTo(new SortedSet<string>() { "ddd/eee" }));
    }
}
