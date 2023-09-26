namespace TextLinesComparing.Library;

public static class ArtifactValidator
{
    public static bool IsArtifact(string targetString)
    {
        if (IsLine(targetString))
        {
            if (StartsWithPermissibleCharacter(targetString))
            {
                return true;
            }
        }

        return false;
    }

    private static bool IsLine(string targetString)
    {
        if (string.IsNullOrEmpty(targetString))
        {
            return false;
        }

        return true;
    }

    private static bool StartsWithPermissibleCharacter(string targetString)
    {
        foreach (char character in targetString)
        {
            if (LinesPreprocessor.IsSpaceCharacter(character))
            {
                continue;
            }
            else if (LinesPreprocessor.IsNotCommentCharacter(character))
            {
                return true;
            }
            else
            {
                break;
            }
        }

        return false;
    }
};
