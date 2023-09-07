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
}
