namespace TextLinesComparing.Library;

public class SourceInfo
{
    private readonly string[] _Content;
    public string Name { get; }

    public SourceInfo(string source)
    {
        _Content = File.ReadAllLines(source);
        Name = source;
    }

    public LinesStorageMap GetArtifactsAsMapBasedStorage()
    {
        LinesStorageMap target_content = new()
        {
            Name = Name
        };

        foreach (string stringFromSource in _Content)
        {
            if (LinesPreprocessor.IsArtifact(stringFromSource))
            {
                string artifact_string = new LinesPreprocessor(stringFromSource)
                    .RetrievePreprocessedArtifact();
                target_content.PutContent(new LineInfo(artifact_string));
            }
        }

        return target_content;
    }

    public LinesStorageSet GetArtifactsAsSetBasedStorage()
    {
        LinesStorageSet target_content = new()
        {
            Name = Name
        };

        foreach (string stringFromSource in _Content)
        {
            if (LinesPreprocessor.IsArtifact(stringFromSource))
            {
                string artifact_string = new LinesPreprocessor(stringFromSource).RetrievePreprocessedArtifact();
                target_content.PutContent(new LineInfo(artifact_string));
            }
        }

        return target_content;
    }
}
