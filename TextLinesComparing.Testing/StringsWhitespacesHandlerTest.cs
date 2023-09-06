using TextLinesComparing.Library;

namespace TextLinesComparing.Testing;

public class StringsWhitespacesHandlerTest
{
    [Test]
    public void PostProcessingForSpaces_TestCase_1()
    {
        string artifact = "A  B   C    D     E          F";

        string actual_artifact = StringsWhitespacesHandler.TrimRedundantWhitespaces(artifact);
        const string expected_artifact = "A B C D E F";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void PostProcessingForSpaces_TestCase_2()
    {
        string artifact = "G     H     I     J     K     L";

        string actual_artifact = StringsWhitespacesHandler.TrimRedundantWhitespaces(artifact);
        const string expected_artifact = "G H I J K L";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void PostProcessingForSpaces_TestCase_3()
    {
        string artifact = "0   1 2    3     4 5     6    7 8   9";

        string actual_artifact = StringsWhitespacesHandler.TrimRedundantWhitespaces(artifact);
        const string expected_artifact = "0 1 2 3 4 5 6 7 8 9";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void PostProcessingForSpaces_TestCase_4()
    {
        string artifact = "0 1 2  3      4  5     6  7 8 9";

        string actual_artifact = StringsWhitespacesHandler.TrimRedundantWhitespaces(artifact);
        const string expected_artifact = "0 1 2 3 4 5 6 7 8 9";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void PostProcessingForSpaces_TestCase_5()
    {
        string artifact = "/  home /  user   / projects /   SendCodeLinesExplorer  /";

        string actual_artifact = StringsWhitespacesHandler.TrimRedundantWhitespaces(artifact);
        const string expected_artifact = "/ home / user / projects / SendCodeLinesExplorer /";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void TrimStartWhitespaces_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(
            actual: StringsWhitespacesHandler.TrimStartWhitespaces("     0123456789"),
            expression: Is.EqualTo("0123456789"));

            Assert.That(
                actual: StringsWhitespacesHandler.TrimStartWhitespaces("     0123456789     "),
            expression: Is.EqualTo("0123456789     "));

            Assert.That(
                actual: StringsWhitespacesHandler.TrimStartWhitespaces("   qwerty   0123456789   qwerty   "),
                expression: Is.EqualTo("qwerty   0123456789   qwerty   "));
        });
    }

    [Test]
    public void TrimEndWhitespaces_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(
            actual: StringsWhitespacesHandler.TrimEndWhitespaces("0123456789     "),
            expression: Is.EqualTo("0123456789"));

            Assert.That(
                actual: StringsWhitespacesHandler.TrimEndWhitespaces("     0123456789     "),
            expression: Is.EqualTo("     0123456789"));

            Assert.That(
                actual: StringsWhitespacesHandler.TrimEndWhitespaces("   qwerty   0123456789   qwerty   "),
                expression: Is.EqualTo("   qwerty   0123456789   qwerty"));
        });
    }
}
