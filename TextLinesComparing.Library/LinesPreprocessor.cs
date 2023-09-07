namespace TextLinesComparing.Library;

public class LinesPreprocessor
{
    private readonly string _LineToProcessing;

    public LinesPreprocessor(string string_to_processing)
    {
        _LineToProcessing = string_to_processing;
    }

    public string RetrievePreprocessedArtifact()
    {
        string artifact = _LineToProcessing;

        // WARNING:
        // This algorithm of preprocessing has the strict defined order.
        // If you swap its steps, your unit tests from LinesPreprocessorTest can fail !!!

        // 1. Preprocessing for C-style comments inside the string.
        artifact = StringsCommentsHandler.TrimWrappedCommentsInsideString(artifact);
        // 2. Preprocessing for the single line Unix-style comment in the string.
        artifact = StringsCommentsHandler.TrimSingleStringComment(artifact);
        // 3. Preprocessing for redunant whitespaces inside the string.
        artifact = StringsWhitespacesHandler.TrimRedundantWhitespaces(artifact);
        // 4. Preprocessing for redunant whitespaces in the string's start.
        artifact = StringsWhitespacesHandler.TrimStartWhitespaces(artifact);
        // 5. Preprocessing for redunant whitespaces in the string's end.
        artifact = StringsWhitespacesHandler.TrimEndWhitespaces(artifact);

        return artifact;
    }
}
