namespace TextLinesComparing.Library;

public class SourcesExplorer
{
    private List<SourceInfo> _Sources;
    public SourcesExplorer(List<string> sources)
    {
        _Sources = new List<SourceInfo>();
        foreach (string source in sources)
        {
            _Sources.Add(new SourceInfo(source));
        }
    }

    public LinesResultView<LinesStorageMap> GetArtifactsFromSourcesAsMapBasedContent()
    {
        LinesRepository<LinesStorageMap> uncommented_content = ExtractUncommentedMapBasedContent();
        LinesStorageMap common_content = ExtractCommonContent(uncommented_content);
        LinesRepository<LinesStorageMap> unique_content = ExtractUniqueContent(uncommented_content, common_content);

        return new LinesResultView<LinesStorageMap>
        {
            ContentFromSources = uncommented_content,
            CommonContentStorage = common_content,
            UniqueContentRepository = unique_content
        };
    }

    public LinesResultView<LinesStorageSet> GetArtifactsFromSourcesAsSetBasedContent()
    {
        LinesRepository<LinesStorageSet> uncommented_content = ExtractUncommentedSetBasedContent();
        LinesStorageSet common_content = ExtractCommonContent(uncommented_content);
        LinesRepository<LinesStorageSet> unique_content = ExtractUniqueContent(uncommented_content, common_content);

        return new LinesResultView<LinesStorageSet>
        {
            ContentFromSources = uncommented_content,
            CommonContentStorage = common_content,
            UniqueContentRepository = unique_content
        };
    }


    private LinesRepository<LinesStorageMap> ExtractUncommentedMapBasedContent()
    {
        LinesRepository<LinesStorageMap> uncommented_content = new();

        foreach (SourceInfo source in _Sources)
        {
            uncommented_content.PutContent(source.GetArtifactsAsMapBasedStorage());
        }

        return uncommented_content;
    }

    private LinesRepository<LinesStorageSet> ExtractUncommentedSetBasedContent()
    {
        LinesRepository<LinesStorageSet> uncommented_content = new();

        foreach (SourceInfo source in _Sources)
        {
            uncommented_content.PutContent(source.GetArtifactsAsSetBasedStorage());
        }

        return uncommented_content;
    }

    private LinesStorageMap ExtractCommonContent(LinesRepository<LinesStorageMap> target_content_repos)
    {
        const byte storageInitializationIndex = 0;
        const byte extractionStartIndex = 1;

        List<LinesStorageMap> uncommented_content_repos = target_content_repos.Content;
        LinesStorageMap common_content = uncommented_content_repos.ElementAt(storageInitializationIndex);

        for (byte index = extractionStartIndex; index < uncommented_content_repos.Count; index++)
        {
            common_content = LinesMainProcessor.ExtractCommonContent(
                common_content, uncommented_content_repos.ElementAt(index));
        }

        return common_content;
    }

    private LinesStorageSet ExtractCommonContent(LinesRepository<LinesStorageSet> target_content_repos)
    {
        const byte storageInitializationIndex = 0;
        const byte extractionStartIndex = 1;

        List<LinesStorageSet> uncommented_content_repos = target_content_repos.Content;
        LinesStorageSet commonLinesSet = uncommented_content_repos.ElementAt(storageInitializationIndex);

        for (byte index = extractionStartIndex; index < uncommented_content_repos.Count; index++)
        {
            commonLinesSet = LinesMainProcessor.ExtractCommonContent(
                commonLinesSet, uncommented_content_repos.ElementAt(index));
        }

        return commonLinesSet;
    }

    private LinesRepository<LinesStorageMap> ExtractUniqueContent(LinesRepository<LinesStorageMap> target_content_repos, LinesStorageMap common_content)
    {
        LinesRepository<LinesStorageMap> uniqueLinesInAllFiles = new();

        foreach (LinesStorageMap content_map in target_content_repos.Content)
        {
            LinesStorageMap unique_content = LinesMainProcessor.ExtractUniqueContent(content_map, common_content);
            uniqueLinesInAllFiles.PutContent(unique_content);
        }

        return uniqueLinesInAllFiles;
    }

    private LinesRepository<LinesStorageSet> ExtractUniqueContent(LinesRepository<LinesStorageSet> target_content_repos, LinesStorageSet common_content)
    {
        LinesRepository<LinesStorageSet> uniqueLinesInAllFiles = new();

        foreach (LinesStorageSet content_set in target_content_repos.Content)
        {
            LinesStorageSet unique_content = LinesMainProcessor.ExtractUniqueContent(content_set, common_content);
            uniqueLinesInAllFiles.PutContent(unique_content);
        }

        return uniqueLinesInAllFiles;
    }
}
