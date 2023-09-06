using TextLinesComparing.Library;

namespace TextLinesComparing.Testing;

public class StringsCommentsHandlerTest
{
    [Test]
    public void DeleteSingleStringComment_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(
            actual: StringsCommentsHandler.TrimSingleStringComment(
                artifactString: "This is a test artifact # with a comment"),
            expression: Is.EqualTo("This is a test artifact "));

            Assert.That(
                actual: StringsCommentsHandler.TrimSingleStringComment(
                    artifactString: "012345#6789"),
                expression: Is.EqualTo("012345"));

            Assert.That(
                actual: StringsCommentsHandler.TrimSingleStringComment(
                    artifactString: "# This is a comment string!"),
                expression: Is.EqualTo(""));
        });
    }

    [Test]
    public void DeleteAllCommentsFromString_TestCase_0()
    {
        const string artifact = "$/* comment */$";

        string actual_artifact = StringsCommentsHandler.TrimWrappedCommentsInsideString(artifact);
        string expected_artifact = "$$";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void DeleteAllCommentsFromString_TestCase_1()
    {
        const string artifact = "0 1 /* 1 */ 2 /* 2 */ 3 4 5 6 7 /* 7 */ 8 /* 8 */ 9";

        string actual_artifact = StringsCommentsHandler.TrimWrappedCommentsInsideString(artifact);
        string expected_artifact = "0 1  2  3 4 5 6 7  8  9";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void DeleteAllCommentsFromString_TestCase_2()
    {
        const string artifact = "0 1 /*step1*/ 2 /*step2*/ 3 /*step3*/ 4 5";

        string actual_artifact = StringsCommentsHandler.TrimWrappedCommentsInsideString(artifact);
        string expected_artifact = "0 1  2  3  4 5";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void DeleteAllCommentsFromString_TestCase_3()
    {
        const string artifact = "/* comment */   0 1 2 3 4 5";

        string actual_artifact = StringsCommentsHandler.TrimWrappedCommentsInsideString(artifact);
        string expected_artifact = "   0 1 2 3 4 5";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void DeleteAllCommentsFromString_TestCase_4()
    {
        const string artifact = "0 1 2 3 4 5   /* comment */\n";

        string actual_artifact = StringsCommentsHandler.TrimWrappedCommentsInsideString(artifact);
        string expected_artifact = "0 1 2 3 4 5   \n";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void DeleteAllCommentsFromString_TestCase_5()
    {
        const string artifact = "/* comment */0 1 2 /*   comment   */ 3 4 5/* comment */\n";

        string actual_artifact = StringsCommentsHandler.TrimWrappedCommentsInsideString(artifact);
        string expected_artifact = "0 1 2  3 4 5\n";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }
}
