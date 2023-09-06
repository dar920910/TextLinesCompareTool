using System.Collections;
using System.Text;

namespace TextLinesComparing.Library;

public static class StringsWhitespacesHandler
{
    public static string TrimRedundantWhitespaces(string artifactString)
    {
        //List<string> whitespacesSubstrings = new();
        ArrayList targetWhitespaceIndexes = new();

        int currentIndex = 0;
        while (currentIndex < artifactString.Length)
        {
            if (GeneralCharacterValidator.IsSpaceCharacter(artifactString[currentIndex]))
            {
                int whitespacesBegIndex = currentIndex + 1;
                int whitespacesEndIndex = whitespacesBegIndex;

                while (whitespacesEndIndex < artifactString.Length)
                {
                    if (GeneralCharacterValidator.IsSpaceCharacter(artifactString[whitespacesEndIndex]))
                    {
                        targetWhitespaceIndexes.Add(whitespacesEndIndex);
                    }
                    else
                    {
                        break;
                    }

                    whitespacesEndIndex++;
                }

                //string whitespaces = artifactString[whitespacesBegIndex..whitespacesEndIndex];
                //whitespacesSubstrings.Add(whitespaces);
                currentIndex = whitespacesEndIndex;
            }

            currentIndex++;
        }

        StringBuilder artifactBuilder = new();
        for (int index = 0; index < artifactString.Length; index++)
        {
            if (targetWhitespaceIndexes.Contains(index))
            {
                continue;
            }
            artifactBuilder.Append(artifactString[index]);
        }

        return artifactBuilder.ToString();
    }

    public static string TrimStartWhitespaces(string artifactString)
    {
        return artifactString.TrimStart();
    }

    public static string TrimEndWhitespaces(string artifactString)
    {
        return artifactString.TrimEnd();
    }
}
