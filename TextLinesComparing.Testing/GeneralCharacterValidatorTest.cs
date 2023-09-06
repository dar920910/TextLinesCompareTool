using TextLinesComparing.Library;

namespace TextLinesComparing.Testing;

public class GeneralCharacterValidatorTest
{
    [Test]
    public void IsCommentCharacter()
    {
        const char comment_character = '#';
        const char test_character = comment_character;

        Assert.That(GeneralCharacterValidator.IsNotCommentCharacter(test_character), Is.EqualTo(test_character != comment_character));
    }

    [Test]
    public void IsNotCommentCharacter_TestCase()
    {
        char comment_character = '#';
        char test_character = default;
        Assert.That(GeneralCharacterValidator.IsNotCommentCharacter(test_character), Is.EqualTo(test_character != comment_character));

        comment_character = '#';
        test_character = 'Z';
        Assert.That(GeneralCharacterValidator.IsNotCommentCharacter(test_character), Is.EqualTo(test_character != comment_character));

        comment_character = '#';
        test_character = 'b';
        Assert.That(GeneralCharacterValidator.IsNotCommentCharacter(test_character), Is.EqualTo(test_character != comment_character));

        comment_character = '#';
        test_character = 'y';
        Assert.That(GeneralCharacterValidator.IsNotCommentCharacter(test_character), Is.EqualTo(test_character != comment_character));

        comment_character = '#';
        test_character = '1';
        Assert.That(GeneralCharacterValidator.IsNotCommentCharacter(test_character), Is.EqualTo(test_character != comment_character));

        comment_character = '#';
        test_character = '9';
        Assert.That(GeneralCharacterValidator.IsNotCommentCharacter(test_character), Is.EqualTo(test_character != comment_character));

        comment_character = '#';
        test_character = '@';
        Assert.That(GeneralCharacterValidator.IsNotCommentCharacter(test_character), Is.EqualTo(test_character != comment_character));

        comment_character = '#';
        test_character = '&';
        Assert.That(GeneralCharacterValidator.IsNotCommentCharacter(test_character), Is.EqualTo(test_character != comment_character));
    }

    [Test]
    public void IsSpaceCharacter_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(GeneralCharacterValidator.IsSpaceCharacter(' '), Is.True); // ASCII: 0x20
            Assert.That(GeneralCharacterValidator.IsSpaceCharacter('\f'), Is.True); // ASCII: 0x0C
            Assert.That(GeneralCharacterValidator.IsSpaceCharacter('\n'), Is.True); // ASCII: 0x0A
            Assert.That(GeneralCharacterValidator.IsSpaceCharacter('\r'), Is.True); // ASCII: 0x0D
            Assert.That(GeneralCharacterValidator.IsSpaceCharacter('\t'), Is.True); // ASCII: 0x09
            Assert.That(GeneralCharacterValidator.IsSpaceCharacter('\v'), Is.True); // ASCII: 0x0B
            Assert.That(GeneralCharacterValidator.IsSpaceCharacter('A'), Is.False);
            Assert.That(GeneralCharacterValidator.IsSpaceCharacter('Z'), Is.False);
            Assert.That(GeneralCharacterValidator.IsSpaceCharacter('b'), Is.False);
            Assert.That(GeneralCharacterValidator.IsSpaceCharacter('y'), Is.False);
            Assert.That(GeneralCharacterValidator.IsSpaceCharacter('0'), Is.False);
            Assert.That(GeneralCharacterValidator.IsSpaceCharacter('9'), Is.False);
            Assert.That(GeneralCharacterValidator.IsSpaceCharacter('#'), Is.False);
            Assert.That(GeneralCharacterValidator.IsSpaceCharacter('/'), Is.False);
            Assert.That(GeneralCharacterValidator.IsSpaceCharacter('\\'), Is.False);
        });
    }
}
