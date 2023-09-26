//-----------------------------------------------------------------------
// <copyright file="SourcesExplorer.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TextLinesComparing.Library;

/// <summary>
/// Represents a device to search for artifact strings in source text files.
/// </summary>
public class SourcesExplorer
{
    private readonly List<SourceInfo> customSources;

    /// <summary>
    /// Initializes a new instance of the <see cref="SourcesExplorer"/> class.
    /// </summary>
    /// <param name="sources">The list of source text files.</param>
    public SourcesExplorer(List<string> sources)
    {
        this.customSources = new List<SourceInfo>();

        foreach (string source in sources)
        {
            this.customSources.Add(new SourceInfo(source));
        }
    }

    /// <summary>
    /// Gets artifacts from sources by using the 'LinesStorageMap' storage container.
    /// </summary>
    /// <returns>Result view of found artifacts.</returns>
    public LinesResultView<LinesStorageMap> GetArtifactsFromSourcesAsMapBasedContent()
    {
        LinesRepository<LinesStorageMap> uncommented_content = this.ExtractUncommentedMapBasedContent();
        LinesStorageMap common_content = this.ExtractCommonContent(uncommented_content);
        LinesRepository<LinesStorageMap> unique_content = this.ExtractUniqueContent(uncommented_content, common_content);

        return new LinesResultView<LinesStorageMap>
        {
            ContentFromSources = uncommented_content,
            CommonContentStorage = common_content,
            UniqueContentRepository = unique_content,
        };
    }

    /// <summary>
    /// Gets artifacts from sources by using the 'LinesStorageSet' storage container.
    /// </summary>
    /// <returns>Result view of found artifacts.</returns>
    public LinesResultView<LinesStorageSet> GetArtifactsFromSourcesAsSetBasedContent()
    {
        LinesRepository<LinesStorageSet> uncommented_content = this.ExtractUncommentedSetBasedContent();
        LinesStorageSet common_content = this.ExtractCommonContent(uncommented_content);
        LinesRepository<LinesStorageSet> unique_content = this.ExtractUniqueContent(uncommented_content, common_content);

        return new LinesResultView<LinesStorageSet>
        {
            ContentFromSources = uncommented_content,
            CommonContentStorage = common_content,
            UniqueContentRepository = unique_content,
        };
    }

    private static LinesStorageMap GetArtifactsAsMapBasedStorage(SourceInfo sourceInfo)
    {
        LinesStorageMap target_content = new ()
        {
            Name = sourceInfo.Name,
        };

        foreach (string stringFromSource in sourceInfo.Content)
        {
            if (LinesArtifactAnalyzer.IsArtifact(stringFromSource))
            {
                string artifact_string = LinesArtifactAnalyzer.RetrievePreprocessedArtifact(stringFromSource);
                target_content.PutContent(new LineInfo(artifact_string));
            }
        }

        return target_content;
    }

    private static LinesStorageSet GetArtifactsAsSetBasedStorage(SourceInfo sourceInfo)
    {
        LinesStorageSet target_content = new ()
        {
            Name = sourceInfo.Name,
        };

        foreach (string stringFromSource in sourceInfo.Content)
        {
            if (LinesArtifactAnalyzer.IsArtifact(stringFromSource))
            {
                string artifact_string = LinesArtifactAnalyzer.RetrievePreprocessedArtifact(stringFromSource);
                target_content.PutContent(new LineInfo(artifact_string));
            }
        }

        return target_content;
    }

    private LinesRepository<LinesStorageMap> ExtractUncommentedMapBasedContent()
    {
        LinesRepository<LinesStorageMap> uncommented_content = new ();

        foreach (SourceInfo source in this.customSources)
        {
            uncommented_content.PutContent(GetArtifactsAsMapBasedStorage(source));
        }

        return uncommented_content;
    }

    private LinesRepository<LinesStorageSet> ExtractUncommentedSetBasedContent()
    {
        LinesRepository<LinesStorageSet> uncommented_content = new ();

        foreach (SourceInfo source in this.customSources)
        {
            uncommented_content.PutContent(GetArtifactsAsSetBasedStorage(source));
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
            common_content = LinesArtifactAnalyzer.ExtractCommonContent(
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
            commonLinesSet = LinesArtifactAnalyzer.ExtractCommonContent(
                commonLinesSet, uncommented_content_repos.ElementAt(index));
        }

        return commonLinesSet;
    }

    private LinesRepository<LinesStorageMap> ExtractUniqueContent(LinesRepository<LinesStorageMap> target_content_repos, LinesStorageMap common_content)
    {
        LinesRepository<LinesStorageMap> uniqueLinesInAllFiles = new ();

        foreach (LinesStorageMap content_map in target_content_repos.Content)
        {
            LinesStorageMap unique_content = LinesArtifactAnalyzer.ExtractUniqueContent(content_map, common_content);
            uniqueLinesInAllFiles.PutContent(unique_content);
        }

        return uniqueLinesInAllFiles;
    }

    private LinesRepository<LinesStorageSet> ExtractUniqueContent(LinesRepository<LinesStorageSet> target_content_repos, LinesStorageSet common_content)
    {
        LinesRepository<LinesStorageSet> uniqueLinesInAllFiles = new ();

        foreach (LinesStorageSet content_set in target_content_repos.Content)
        {
            LinesStorageSet unique_content = LinesArtifactAnalyzer.ExtractUniqueContent(content_set, common_content);
            uniqueLinesInAllFiles.PutContent(unique_content);
        }

        return uniqueLinesInAllFiles;
    }
}

/// <summary>
/// Represents information about a source text file.
/// </summary>
public record SourceInfo
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SourceInfo"/> class.
    /// </summary>
    /// <param name="source">Source text file full name.</param>
    public SourceInfo(string source)
    {
        this.Name = source;
        this.Content = File.ReadAllLines(source);
    }

    /// <summary>
    /// Gets the name of the current source.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the content of the current source.
    /// </summary>
    public string[] Content { get; }
}
