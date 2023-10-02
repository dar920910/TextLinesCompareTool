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
    /// Gets artifacts from sources.
    /// </summary>
    /// <returns>Result view of found artifacts.</returns>
    public LinesResultView GetArtifactsFromSources()
    {
        List<LinesStorage> uncommented_content = this.ExtractUncommentedContent();

        LinesStorage common_content = ExtractCommonContent(uncommented_content);
        List<LinesStorage> unique_content = ExtractUniqueContent(uncommented_content, common_content);

        return new LinesResultView
        {
            ContentFromSources = uncommented_content,
            CommonContentStorage = common_content,
            UniqueContentRepository = unique_content,
        };
    }

    private static LinesStorage ExtractCommonContent(List<LinesStorage> target_content_repos)
    {
        const byte storageInitializationIndex = 0;
        const byte extractionStartIndex = 1;

        LinesStorage common_content = target_content_repos.ElementAt(storageInitializationIndex);

        for (byte index = extractionStartIndex; index < target_content_repos.Count; index++)
        {
            common_content = LinesArtifactAnalyzer.ExtractCommonContent(
                common_content, target_content_repos.ElementAt(index));
        }

        return common_content;
    }

    private static List<LinesStorage> ExtractUniqueContent(List<LinesStorage> target_content_repos, LinesStorage common_content)
    {
        List<LinesStorage> uniqueLinesInAllFiles = new ();

        foreach (LinesStorage content_map in target_content_repos)
        {
            LinesStorage unique_content = LinesArtifactAnalyzer.ExtractUniqueContent(content_map, common_content);
            uniqueLinesInAllFiles.Add(unique_content);
        }

        return uniqueLinesInAllFiles;
    }

    private static LinesStorage ExtractArtifactsFromSource(SourceInfo sourceInfo)
    {
        LinesStorage target_content = new ()
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

    private List<LinesStorage> ExtractUncommentedContent()
    {
        List<LinesStorage> uncommented_content = new ();

        foreach (SourceInfo source in this.customSources)
        {
            LinesStorage artifactStorage = ExtractArtifactsFromSource(source);
            uncommented_content.Add(artifactStorage);
        }

        return uncommented_content;
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

/// <summary>
/// Represents a result of made analysis of content from source text files.
/// </summary>
public record LinesResultView
{
    /// <summary>
    /// Gets or sets the repository to keep original content from sources.
    /// </summary>
    public List<LinesStorage> ContentFromSources { get; set; }

    /// <summary>
    /// Gets or sets the storage to keep common content for all sources.
    /// </summary>
    public LinesStorage CommonContentStorage { get; set; }

    /// <summary>
    /// Gets or sets the repository to keep unique content from every source.
    /// </summary>
    public List<LinesStorage> UniqueContentRepository { get; set; }
}
