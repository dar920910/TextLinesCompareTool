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
        int artifactBegIndex = 0;
        int artifactEndIndex = artifactString.Length - 1;

        int commentBegIndex = artifactBegIndex;
        int commentEndIndex = artifactBegIndex;

        while (commentBegIndex != artifactEndIndex)
        {
            if (IsCommentSlash(artifactString.ElementAt(commentBegIndex)))
            {
                if (IsCommentAsterisk(artifactString.ElementAt(commentBegIndex + 1)))
                {
                    commentEndIndex = commentBegIndex;

                    while (commentEndIndex != artifactEndIndex)
                    {
                        char currentCharacter = artifactString.ElementAt(commentEndIndex);

                        if (IsCommentAsterisk(currentCharacter))
                        {
                            if (IsCommentSlash(artifactString.ElementAt(currentCharacter + 1)))
                            {
                                commentEndIndex++;
                                break;
                            }
                        }

                        commentEndIndex++;
                    }

                    CutCommentInsideString(artifactString, commentBegIndex, commentEndIndex + 1);
                }
            }

            commentBegIndex++;
        }

        return artifactString;
    }


    private static void CutCommentInsideString(string artifactString, int commentBegIndex, int commentEndIndex)
    {
        int commentLength = commentEndIndex - commentBegIndex;
        string commentSubstring = artifactString.Substring(commentBegIndex, commentLength);
        artifactString.Replace(commentSubstring, string.Empty);
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
