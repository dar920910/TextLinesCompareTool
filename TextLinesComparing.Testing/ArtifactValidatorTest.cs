using TextLinesComparing.Library;

namespace TextLinesComparing.Testing;

public class ArtifactValidatorTest
{
    [Test]
    public void IsArtifact_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(ArtifactValidator.IsArtifact("/a/b/c/d/"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("   b/c   "), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("/a/ # /d/"), Is.True);
        });
    }

    [Test]
    public void IsNotArtifact_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(ArtifactValidator.IsArtifact(""), Is.False);
            Assert.That(ArtifactValidator.IsArtifact(string.Empty), Is.False);
            Assert.That(ArtifactValidator.IsArtifact("         "), Is.False);
        });
    }

    [Test]
    public void IsArtifactWhenLineContainsOnlyLetters_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(ArtifactValidator.IsArtifact("ABCDEFGHIJKLMNOPQRSTUVWXYZ"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("abcdefghijklmnopqrstuvwxyz"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("ABCDEFGHIJKLMnopqrstuvwxyz"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("abcdefghijklmNOPQRSTUVWXYZ"), Is.True);
        });
    }

    [Test]
    public void IsArtifactWhenLineContainsOnlyDigits_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(ArtifactValidator.IsArtifact("0123456789"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("9876543210"), Is.True);
        });
    }

    [Test]
    public void IsArtifactWhenLineContainsOnlyPunctuationSigns_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(ArtifactValidator.IsArtifact("....."), Is.True);
            Assert.That(ArtifactValidator.IsArtifact(",,,,,,"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("!!!!!"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("?????"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact(":::::"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact(";;;;;"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("((((("), Is.True);
            Assert.That(ArtifactValidator.IsArtifact(")))))"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("-----"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("'''''"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("\"\"\"\"\""), Is.True);
        });
    }

    [Test]
    public void IsArtifactWhenLineContainsOnlyArithmeticSigns_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(ArtifactValidator.IsArtifact("+++++"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("-----"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("*****"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("/////"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("======"), Is.True);
        });
    }

    [Test]
    public void IsArtifactWhenLineContainsOnlySpecialSymbols_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(ArtifactValidator.IsArtifact("~~~~~"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("`````"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("@@@@@"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("$$$$$"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("%%%%%"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("&&&&&"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("_____"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("^^^^^"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("<<<<<"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact(">>>>>"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("[[[[["), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("]]]]]"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("|||||"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("\\\\\\\\\\"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("{{{{{"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("}}}}}"), Is.True);
        });
    }

    [Test]
    public void IsArtifactWhenLineContainsOnlyPathLikeUnixStyle_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(ArtifactValidator.IsArtifact("/AAA/"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("/BBB/CCC/"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("/CCC/DDD/EEE/"), Is.True);
        });
    }

    [Test]
    public void IsArtifactWhenLineContainsOnlyPathLikeWindowsStyle_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(ArtifactValidator.IsArtifact("\\AAA\\"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("\\BBB\\CCC\\"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("\\CCC\\DDD\\EEE\\"), Is.True);
        });
    }

    [Test]
    public void IsArtifactWhenLineContainsSpacesBeforeText_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(ArtifactValidator.IsArtifact("          \\AAA\\BBB\\CCC\\"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("     /ddd/eee/fff/"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact(" /g\\h/i\\j"), Is.True);
        });
    }

    [Test]
    public void IsArtifactWhenLineContainsCommentsAfterText_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(ArtifactValidator.IsArtifact("\\AAA\\BBB\\CCC\\ # Windows style"), Is.True);
            Assert.That(ArtifactValidator.IsArtifact("/ddd/eee/fff/     # Unix style   "), Is.True);
        });
    }

    [Test]
    public void IsNotArtifactWhenLineContainsOnlyComments_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(ArtifactValidator.IsArtifact("##########"), Is.False);
            Assert.That(ArtifactValidator.IsArtifact("#####"), Is.False);
            Assert.That(ArtifactValidator.IsArtifact("#"), Is.False);
        });
    }

    [Test]
    public void IsNotArtifactWhenLineContainsCommentsBeforeText_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(ArtifactValidator.IsArtifact("#/AAA/BBB/CCC/"), Is.False);
            Assert.That(ArtifactValidator.IsArtifact("#    /DDD/EEE/"), Is.False);
        });
    }

    [Test]
    public void IsNotArtifactWhenLineContainsSpacesBeforeComment_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(ArtifactValidator.IsArtifact(" #/AAA/BBB/CCC/"), Is.False);
            Assert.That(ArtifactValidator.IsArtifact("  #/DDD/EEE/"), Is.False);
            Assert.That(ArtifactValidator.IsArtifact("   #/FFF/GGG/"), Is.False);
        });
    }
}
