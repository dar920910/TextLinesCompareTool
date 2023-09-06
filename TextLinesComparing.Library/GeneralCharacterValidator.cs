namespace TextLinesComparing.Library;

public static class GeneralCharacterValidator
{
    public static bool IsNotCommentCharacter(char character)
    {
        const char comment_character = '#';

        if (character == comment_character)
        {
            return false;
        }

        return true;
    }

    public static bool IsSpaceCharacter(char character)
    {
        return char.IsWhiteSpace(character);
    }
}
