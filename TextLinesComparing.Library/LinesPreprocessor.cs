//-----------------------------------------------------------------------
// <copyright file="LinesPreprocessor.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TextLinesComparing.Library;

using System.Collections;
using System.Text;

/// <summary>
/// Represents possible preprocessing operations for an artifact line.
/// </summary>
public class LinesPreprocessor
{
    private readonly string targetLineToProcessing;

    /// <summary>
    /// Initializes a new instance of the <see cref="LinesPreprocessor"/> class.
    /// </summary>
    /// <param name="string_to_processing">Source artifact string.</param>
    public LinesPreprocessor(string string_to_processing)
    {
        this.targetLineToProcessing = string_to_processing;
    }

    /// <summary>
    /// Checks whether a character is not a comment symbol.
    /// </summary>
    /// <param name="character">A character to check.</param>
    /// <returns>Returns 'true' if a character is whitespace symbol else 'false'.</returns>
    public static bool IsNotCommentCharacter(char character)
    {
        const char comment_character = '#';

        if (character == comment_character)
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// Checks whether a character is a whitespace symbol.
    /// </summary>
    /// <param name="character">A character to check.</param>
    /// <returns>Returns 'true' if a character is whitespace symbol else 'false'.</returns>
    public static bool IsSpaceCharacter(char character)
    {
        return char.IsWhiteSpace(character);
    }

    /// <summary>
    ///  Trims all redundant (start/wrapped/end) whitespace characters from an artifact string.
    /// </summary>
    /// <param name="artifactString">Source artifact string.</param>
    /// <returns>Trimmed artifact string.</returns>
    public static string TrimRedundantWhitespaces(string artifactString)
    {
        ArrayList targetWhitespaceIndexes = new ();

        int currentIndex = 0;
        while (currentIndex < artifactString.Length)
        {
            if (IsSpaceCharacter(artifactString[currentIndex]))
            {
                int whitespacesBegIndex = currentIndex + 1;
                int whitespacesEndIndex = whitespacesBegIndex;

                while (whitespacesEndIndex < artifactString.Length)
                {
                    if (IsSpaceCharacter(artifactString[whitespacesEndIndex]))
                    {
                        targetWhitespaceIndexes.Add(whitespacesEndIndex);
                    }
                    else
                    {
                        break;
                    }

                    whitespacesEndIndex++;
                }

                currentIndex = whitespacesEndIndex;
            }

            currentIndex++;
        }

        StringBuilder artifactBuilder = new ();
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

    /// <summary>
    /// Trims all start whitespace characters from an artifact string.
    /// </summary>
    /// <param name="artifactString">Source artifact string.</param>
    /// <returns>Trimmed artifact string.</returns>
    public static string TrimStartWhitespaces(string artifactString)
    {
        return artifactString.TrimStart();
    }

    /// <summary>
    /// Trims all end whitespace characters from an artifact string.
    /// </summary>
    /// <param name="artifactString">Source artifact string.</param>
    /// <returns>Trimmed artifact string.</returns>
    public static string TrimEndWhitespaces(string artifactString)
    {
        return artifactString.TrimEnd();
    }

    /// <summary>
    /// Trims a inline comment from an artifact string.
    /// </summary>
    /// <param name="artifactString">Source artifact string.</param>
    /// <returns>Trimmed artifact string.</returns>
    public static string TrimSingleStringComment(string artifactString)
    {
        int trimmedSubstringLength = 0;

        CharEnumerator enumerator = artifactString.GetEnumerator();
        while (enumerator.MoveNext())
        {
            if (IsNotCommentCharacter(enumerator.Current))
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

    /// <summary>
    /// Trims all wrapped comments from an artifact string.
    /// </summary>
    /// <param name="artifactString">Source artifact string.</param>
    /// <returns>Trimmed artifact string.</returns>
    public static string TrimWrappedCommentsInsideString(string artifactString)
    {
        List<string> detectedComments = new ();

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
                                detectedComments.Add(artifactString[commentBegSlashIndex .. (commentEndSlashIndex + 1)]);
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

    /// <summary>
    /// Retrieves the artifact string.
    /// </summary>
    /// <returns>Preprocessed artifact string.</returns>
    public string RetrievePreprocessedArtifact()
    {
        string artifact = this.targetLineToProcessing;

        // WARNING:
        // This algorithm of preprocessing has the strict defined order.
        // If you swap its steps, your unit tests from LinesPreprocessorTest can fail !!!

        // 1. Preprocessing for C-style comments inside the string.
        artifact = TrimWrappedCommentsInsideString(artifact);

        // 2. Preprocessing for the single line Unix-style comment in the string.
        artifact = TrimSingleStringComment(artifact);

        // 3. Preprocessing for redunant whitespaces inside the string.
        artifact = TrimRedundantWhitespaces(artifact);

        // 4. Preprocessing for redunant whitespaces in the string's start.
        artifact = TrimStartWhitespaces(artifact);

        // 5. Preprocessing for redunant whitespaces in the string's end.
        artifact = TrimEndWhitespaces(artifact);

        return artifact;
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
