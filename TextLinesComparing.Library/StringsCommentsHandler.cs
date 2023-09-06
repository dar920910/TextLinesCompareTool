using System.Text;

namespace TextLinesComparing.Library;

public static class StringsCommentsHandler
{
    public static string TrimSingleStringComment(string artifactString)
    {
        int trimmedSubstringLength = 0;

        CharEnumerator enumerator = artifactString.GetEnumerator();
        while (enumerator.MoveNext())
        {
            if (GeneralCharacterValidator.IsNotCommentCharacter(enumerator.Current))
            {
                trimmedSubstringLength++;
            }
            else
            {
                break;
            }
        }

        return artifactString[..trimmedSubstringLength];
    }


    public static string TrimWrappedCommentsInsideString(string artifactString)
    {
        List<string> detectedComments = new();

        int artifactBegIndex = 0;
        int artifactEndIndex = artifactString.Length - 1;

        int currentIndex = artifactBegIndex;
        while (currentIndex != artifactEndIndex)
        {
            int commentBegSlashIndex = currentIndex;
            if (IsCommentSlash(artifactString.ElementAt(commentBegSlashIndex)))
            {
                int commentBegAsteriskIndex = currentIndex + 1;
                if (IsCommentAsterisk(artifactString.ElementAt(commentBegAsteriskIndex)))
                {
                    int currentCommentIndex = currentIndex;
                    while (currentCommentIndex != artifactEndIndex)
                    {
                        int commentEndAsteriskIndex = currentCommentIndex;
                        if (IsCommentAsterisk(artifactString.ElementAt(commentEndAsteriskIndex)))
                        {
                            int commentEndSlashIndex = currentCommentIndex + 1;
                            if (IsCommentSlash(artifactString.ElementAt(commentEndSlashIndex)))
                            {
                                detectedComments.Add(artifactString[commentBegSlashIndex..(commentEndSlashIndex + 1)]);
                                currentIndex = commentEndSlashIndex;
                                break;
                            }
                        }

                        currentCommentIndex++;
                    }
                }
            }

            currentIndex++;
        }

        foreach (string comment in detectedComments)
        {
            artifactString = artifactString.Replace(comment, string.Empty);
        }

        return artifactString;
    }

    private static bool IsCommentSlash(char artifactCharacter)
    {
        const char comment_slash = '/';
        return artifactCharacter == comment_slash;
    }

    private static bool IsCommentAsterisk(char artifactCharacter)
    {
        const char comment_asterisk = '*';
        return artifactCharacter == comment_asterisk;
    }
}
