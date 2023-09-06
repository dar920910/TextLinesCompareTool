using TextLinesComparing.Library;

namespace TextLinesComparing.Testing;

public class LinesRepositoryTest
{
    [Test]
    public void PutContent_TestCase()
    {
        // STEP 1: ARRANGE

        SortedSet<string> test_set = new();

        const string unique_source_name_0 = "unique_source_name_0";
        const string unique_source_name_1 = "unique_source_name_1";
        const string unique_source_name_2 = "unique_source_name_2";

        LinesStorageSet unique_info_0 = new(test_set, unique_source_name_0);
        LinesStorageSet unique_info_1 = new(test_set, unique_source_name_1);
        LinesStorageSet unique_info_2 = new(test_set, unique_source_name_2);

        // STEP 2: ACT

        LinesRepository<LinesStorageSet> repos = new();

        repos.PutContent(unique_info_0);
        List<LinesStorageSet> actual_content_0 = repos.Content;

        repos.PutContent(unique_info_1);
        List<LinesStorageSet> actual_content_1 = repos.Content;

        repos.PutContent(unique_info_2);
        List<LinesStorageSet> actual_content_2 = repos.Content;

        // STEP 3: ASSERT

        Assert.Multiple(() =>
        {
            Assert.That(actual: actual_content_0.ElementAt(0).Name,
                expression: Is.EqualTo(unique_source_name_0));

            Assert.That(actual: actual_content_1.ElementAt(0).Name,
                expression: Is.EqualTo(unique_source_name_0));
            Assert.That(actual: actual_content_1.ElementAt(1).Name,
                expression: Is.EqualTo(unique_source_name_1));

            Assert.That(actual: actual_content_2.ElementAt(0).Name,
                expression: Is.EqualTo(unique_source_name_0));
            Assert.That(actual: actual_content_2.ElementAt(1).Name,
                expression: Is.EqualTo(unique_source_name_1));
            Assert.That(actual: actual_content_2.ElementAt(2).Name,
                expression: Is.EqualTo(unique_source_name_2));
        });
    }

    [Test]
    public void GetContent_TestCase()
    {
        // STEP 1: ARRANGE

        const string test_name = "test_source";

        string[] array_1 = { "A", "B", "C", "D", "E", "F" };
        string[] array_2 = { "A", "B", "C", "D", "E" };
        string[] array_3 = { "A", "B", "C", "D" };
        string[] array_4 = { "A", "B", "C", };
        string[] array_5 = { "A", "B" };
        string[] array_6 = { "A" };

        LinesStorageSet unique_info_1 = new(array_1, test_name);
        LinesStorageSet unique_info_2 = new(array_2, test_name);
        LinesStorageSet unique_info_3 = new(array_3, test_name);
        LinesStorageSet unique_info_4 = new(array_4, test_name);
        LinesStorageSet unique_info_5 = new(array_5, test_name);
        LinesStorageSet unique_info_6 = new(array_6, test_name);

        // STEP 2: ACT

        List<LinesStorageSet> expected_content = new()
        {
            unique_info_1,
            unique_info_2,
            unique_info_3,
            unique_info_4,
            unique_info_5,
            unique_info_6
        };
        
        List<LinesStorageSet> actual_content;
        LinesRepository<LinesStorageSet> repos = new();
        repos.PutContent(unique_info_1);
        repos.PutContent(unique_info_2);
        repos.PutContent(unique_info_3);
        repos.PutContent(unique_info_4);
        repos.PutContent(unique_info_5);
        repos.PutContent(unique_info_6);
        actual_content = repos.Content;

        // STEP 3: ASSERT

        Assert.Multiple(() =>
        {
            Assert.That(
                actual: actual_content.ElementAt(0).Content,
                expression: Is.EqualTo(expected_content.ElementAt(0).Content));
            Assert.That(
                actual: actual_content.ElementAt(1).Content,
                expression: Is.EqualTo(expected_content.ElementAt(1).Content));
            Assert.That(
                actual: actual_content.ElementAt(2).Content,
                expression: Is.EqualTo(expected_content.ElementAt(2).Content));
            Assert.That(
                actual: actual_content.ElementAt(3).Content,
                expression: Is.EqualTo(expected_content.ElementAt(3).Content));
            Assert.That(
                actual: actual_content.ElementAt(4).Content,
                expression: Is.EqualTo(expected_content.ElementAt(4).Content));
            Assert.That(
                actual: actual_content.ElementAt(5).Content,
                expression: Is.EqualTo(expected_content.ElementAt(5).Content));
        });
    }
}
