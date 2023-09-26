using TextLinesComparing.Library;

namespace TextLinesComparing.Testing;

public class LinesPreprocessorTest
{
    [Test]
    public void RetrieveArtifactFromLineWithStartSpaces_TestCase_1()
    {
        LinesPreprocessor preprocessor = new("     /AAA/BBB/CCC/");
        Assert.That(preprocessor.RetrievePreprocessedArtifact(), Is.EqualTo("/AAA/BBB/CCC/"));
    }

    [Test]
    public void RetrieveArtifactFromLineWithStartSpaces_TestCase_2()
    {
        LinesPreprocessor preprocessor = new("         /DDD/EEE/");
        Assert.That(preprocessor.RetrievePreprocessedArtifact(), Is.EqualTo("/DDD/EEE/"));
    }

    [Test]
    public void RetrieveArtifactFromLineWithStartSpaces_TestCase_3()
    {
        LinesPreprocessor preprocessor = new("             /FFF/");
        Assert.That(preprocessor.RetrievePreprocessedArtifact(), Is.EqualTo("/FFF/"));
    }


    [Test]
    public void RetrieveArtifactFromLineWithEndSpaces_TestCase_1()
    {
        LinesPreprocessor preprocessor = new("/AAA/BBB/CCC/     ");
        Assert.That(preprocessor.RetrievePreprocessedArtifact(), Is.EqualTo("/AAA/BBB/CCC/"));
    }

    [Test]
    public void RetrieveArtifactFromLineWithEndSpaces_TestCase_2()
    {
        LinesPreprocessor preprocessor = new("/DDD/EEE/         ");
        Assert.That(preprocessor.RetrievePreprocessedArtifact(), Is.EqualTo("/DDD/EEE/"));
    }

    [Test]
    public void RetrieveArtifactFromLineWithEndSpaces_TestCase_3()
    {
        LinesPreprocessor preprocessor = new("/FFF/             ");
        Assert.That(preprocessor.RetrievePreprocessedArtifact(), Is.EqualTo("/FFF/"));
    }


    [Test]
    public void RetrieveArtifactFromLineWrappedBySpaces_TestCase_1()
    {
        LinesPreprocessor preprocessor = new("  /AAA/BBB/CCC/   ");
        Assert.That(preprocessor.RetrievePreprocessedArtifact(), Is.EqualTo("/AAA/BBB/CCC/"));
    }

    [Test]
    public void RetrieveArtifactFromLineWrappedBySpaces_TestCase_2()
    {
        LinesPreprocessor preprocessor = new("    /DDD/EEE/     ");
        Assert.That(preprocessor.RetrievePreprocessedArtifact(), Is.EqualTo("/DDD/EEE/"));
    }

    [Test]
    public void RetrieveArtifactFromLineWrappedBySpaces_TestCase_3()
    {
        LinesPreprocessor preprocessor = new("      /FFF/       ");
        Assert.That(preprocessor.RetrievePreprocessedArtifact(), Is.EqualTo("/FFF/"));
    }


    [Test]
    public void RetrieveArtifactFromLineWithComment_TestCase_1()
    {
        LinesPreprocessor preprocessor = new("/aa/bb/cc# Unix style");
        Assert.That(preprocessor.RetrievePreprocessedArtifact(), Is.EqualTo("/aa/bb/cc"));
    }

    [Test]
    public void RetrieveArtifactFromLineWithComment_TestCase_2()
    {
        LinesPreprocessor preprocessor = new("\\aa\\bb\\cc# Windows style");
        Assert.That(preprocessor.RetrievePreprocessedArtifact(), Is.EqualTo("\\aa\\bb\\cc"));
    }


    [Test]
    public void RetrieveArtifactFromLineWithSpacesAndComment_TestCase_1()
    {
        LinesPreprocessor preprocessor = new("    /aa/bb/cc    # Unix style     ");
        Assert.That(preprocessor.RetrievePreprocessedArtifact(), Is.EqualTo("/aa/bb/cc"));
    }

    [Test]
    public void RetrieveArtifactFromLineWithSpacesAndComment_TestCase_2()
    {
        LinesPreprocessor preprocessor = new("  \\aa\\bb\\cc   # Windows style  ");
        Assert.That(preprocessor.RetrievePreprocessedArtifact(), Is.EqualTo("\\aa\\bb\\cc"));
    }


    [Test]
    public void RetrieveArtifactFromLineWithCommentInsideText_TestCase_1()
    {
        LinesPreprocessor preprocessor = new("/aa/bb/ # Unix style like /cc/dd/");
        Assert.That(preprocessor.RetrievePreprocessedArtifact(), Is.EqualTo("/aa/bb/"));
    }

    [Test]
    public void RetrieveArtifactFromLineWithCommentInsideText_TestCase_2()
    {
        LinesPreprocessor preprocessor = new("\\aa\\bb\\ # Windows style like \\cc\\dd\\");
        Assert.That(preprocessor.RetrievePreprocessedArtifact(), Is.EqualTo("\\aa\\bb\\"));
    }

    [Test]
    public void RetrieveArtifact_SmokeTestCase_1()
    {
        const string test_string = "     ./a/b/c/example.txt   #todo: replace the file to ./a/b  ";
        string actual_result = new LinesPreprocessor(test_string).RetrievePreprocessedArtifact();

        Assert.That(actual_result, Is.EqualTo("./a/b/c/example.txt"));
    }

    [Test]
    public void RetrieveArtifact_SmokeTestCase_2()
    {
        const string test_string = "  EXAMPLE:/* comment_1 */     test_path:     /* comment_2 */./a/b/c/example.txt   #  todo   ";
        string actual_result = new LinesPreprocessor(test_string).RetrievePreprocessedArtifact();

        Assert.That(actual_result, Is.EqualTo("EXAMPLE: test_path: ./a/b/c/example.txt"));
    }

    [Test]
    public void RetrieveArtifact_SmokeTestCase_3()
    {
        const string test_string = "/* Types of paths: */    dir1\\dir2\\dir3    /* it's a path for Windows */    dir1/dir2/dir3      /* it's a path for Unix */    \n";
        string actual_result = new LinesPreprocessor(test_string).RetrievePreprocessedArtifact();

        Assert.That(actual_result, Is.EqualTo("dir1\\dir2\\dir3 dir1/dir2/dir3"));
    }

    [Test]
    public void RetrieveArtifact_SmokeTestCase_4()
    {
        const string test_string = "    /* Comment: '#' is Unix-style comment */ dir1/dir2/dir3 /* for Unix */ # dir1\\dir2\\dir3 (for Windows)\n";
        string actual_result = new LinesPreprocessor(test_string).RetrievePreprocessedArtifact();

        Assert.That(actual_result, Is.EqualTo("dir1/dir2/dir3"));
    }

    [Test]
    public void DeleteSingleStringComment_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(
            actual: LinesPreprocessor.TrimSingleStringComment(
                artifactString: "This is a test artifact # with a comment"),
            expression: Is.EqualTo("This is a test artifact "));

            Assert.That(
                actual: LinesPreprocessor.TrimSingleStringComment(
                    artifactString: "012345#6789"),
                expression: Is.EqualTo("012345"));

            Assert.That(
                actual: LinesPreprocessor.TrimSingleStringComment(
                    artifactString: "# This is a comment string!"),
                expression: Is.EqualTo(""));
        });
    }

    [Test]
    public void DeleteAllCommentsFromString_TestCase_0()
    {
        const string artifact = "$/* comment */$";

        string actual_artifact = LinesPreprocessor.TrimWrappedCommentsInsideString(artifact);
        string expected_artifact = "$$";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void DeleteAllCommentsFromString_TestCase_1()
    {
        const string artifact = "0 1 /* 1 */ 2 /* 2 */ 3 4 5 6 7 /* 7 */ 8 /* 8 */ 9";

        string actual_artifact = LinesPreprocessor.TrimWrappedCommentsInsideString(artifact);
        string expected_artifact = "0 1  2  3 4 5 6 7  8  9";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void DeleteAllCommentsFromString_TestCase_2()
    {
        const string artifact = "0 1 /*step1*/ 2 /*step2*/ 3 /*step3*/ 4 5";

        string actual_artifact = LinesPreprocessor.TrimWrappedCommentsInsideString(artifact);
        string expected_artifact = "0 1  2  3  4 5";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void DeleteAllCommentsFromString_TestCase_3()
    {
        const string artifact = "/* comment */   0 1 2 3 4 5";

        string actual_artifact = LinesPreprocessor.TrimWrappedCommentsInsideString(artifact);
        string expected_artifact = "   0 1 2 3 4 5";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void DeleteAllCommentsFromString_TestCase_4()
    {
        const string artifact = "0 1 2 3 4 5   /* comment */\n";

        string actual_artifact = LinesPreprocessor.TrimWrappedCommentsInsideString(artifact);
        string expected_artifact = "0 1 2 3 4 5   \n";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void DeleteAllCommentsFromString_TestCase_5()
    {
        const string artifact = "/* comment */0 1 2 /*   comment   */ 3 4 5/* comment */\n";

        string actual_artifact = LinesPreprocessor.TrimWrappedCommentsInsideString(artifact);
        string expected_artifact = "0 1 2  3 4 5\n";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void PostProcessingForSpaces_TestCase_1()
    {
        string artifact = "A  B   C    D     E          F";

        string actual_artifact = LinesPreprocessor.TrimRedundantWhitespaces(artifact);
        const string expected_artifact = "A B C D E F";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void PostProcessingForSpaces_TestCase_2()
    {
        string artifact = "G     H     I     J     K     L";

        string actual_artifact = LinesPreprocessor.TrimRedundantWhitespaces(artifact);
        const string expected_artifact = "G H I J K L";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void PostProcessingForSpaces_TestCase_3()
    {
        string artifact = "0   1 2    3     4 5     6    7 8   9";

        string actual_artifact = LinesPreprocessor.TrimRedundantWhitespaces(artifact);
        const string expected_artifact = "0 1 2 3 4 5 6 7 8 9";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void PostProcessingForSpaces_TestCase_4()
    {
        string artifact = "0 1 2  3      4  5     6  7 8 9";

        string actual_artifact = LinesPreprocessor.TrimRedundantWhitespaces(artifact);
        const string expected_artifact = "0 1 2 3 4 5 6 7 8 9";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void PostProcessingForSpaces_TestCase_5()
    {
        string artifact = "/  home /  user   / projects /   SendCodeLinesExplorer  /";

        string actual_artifact = LinesPreprocessor.TrimRedundantWhitespaces(artifact);
        const string expected_artifact = "/ home / user / projects / SendCodeLinesExplorer /";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void TrimStartWhitespaces_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(
            actual: LinesPreprocessor.TrimStartWhitespaces("     0123456789"),
            expression: Is.EqualTo("0123456789"));

            Assert.That(
                actual: LinesPreprocessor.TrimStartWhitespaces("     0123456789     "),
                expression: Is.EqualTo("0123456789     "));

            Assert.That(
                actual: LinesPreprocessor.TrimStartWhitespaces("   qwerty   0123456789   qwerty   "),
                expression: Is.EqualTo("qwerty   0123456789   qwerty   "));
        });
    }

    [Test]
    public void TrimEndWhitespaces_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(
            actual: LinesPreprocessor.TrimEndWhitespaces("0123456789     "),
            expression: Is.EqualTo("0123456789"));

            Assert.That(
                actual: LinesPreprocessor.TrimEndWhitespaces("     0123456789     "),
                expression: Is.EqualTo("     0123456789"));

            Assert.That(
                actual: LinesPreprocessor.TrimEndWhitespaces("   qwerty   0123456789   qwerty   "),
                expression: Is.EqualTo("   qwerty   0123456789   qwerty"));
        });
    }
}
