
#include "SourcesExplorer.hpp"

#include "LineInfo.hpp"
#include "../Parsers/LinesMainProcessor.hpp"


SourcesExplorer::SourcesExplorer(const std::vector<std::string>& sources)
{
    for (const std::string& source : sources)
    {
        scanSource(source);
    }
}

void SourcesExplorer::scanSource(const std::string& source_name)
{
    const SourceInfo source_info {source_name};
    m_Sources.push_back(source_info);
}

const LinesResultMapBasedView SourcesExplorer::getArtifactsFromSourcesAsMapBasedContent() const
{
    const LinesRepository<LinesStorageMap> uncommented_content = getUncommentedMapBasedContent();
    const LinesStorageMap common_content = extractCommonContent(uncommented_content);
    const LinesRepository<LinesStorageMap> unique_content = extractUniqueContent(uncommented_content, common_content);

    return LinesPresentationView::createResultView(uncommented_content, common_content, unique_content);
}

const LinesResultSetBasedView SourcesExplorer::getArtifactsFromSourcesAsSetBasedContent() const
{
    const LinesRepository<LinesStorageSet> uncommented_content = getUncommentedSetBasedContent();
    const LinesStorageSet common_content = extractCommonContent(uncommented_content);
    const LinesRepository<LinesStorageSet> unique_content = extractUniqueContent(uncommented_content, common_content);

    return LinesPresentationView::createResultView(uncommented_content, common_content, unique_content);
}

const LinesRepository<LinesStorageMap> SourcesExplorer::getUncommentedMapBasedContent() const
{
    LinesRepository<LinesStorageMap> uncommented_content;

    for (const SourceInfo& source : m_Sources)
    {
        uncommented_content.putContent(source.getArtifactsAsMapBasedStorage());
    }

    return uncommented_content;
}

const LinesRepository<LinesStorageSet> SourcesExplorer::getUncommentedSetBasedContent() const
{
    LinesRepository<LinesStorageSet> uncommented_content;

    for (const SourceInfo& source : m_Sources)
    {
        uncommented_content.putContent(source.getArtifactsAsSetBasedStorage());
    }

    return uncommented_content;
}

const LinesStorageMap SourcesExplorer::extractCommonContent(const LinesRepository<LinesStorageMap>& target_content_repos) const
{
    const unsigned short StorageInitializationIndex {0};
    const unsigned short ExtractionStartIndex {1};

    const auto uncommented_content_repos = target_content_repos.getContent();

    LinesStorageMap common_content {uncommented_content_repos.at(StorageInitializationIndex)};

    for (unsigned short index = ExtractionStartIndex; index < uncommented_content_repos.size(); index++)
    {
        common_content = LinesMainProcessor::extractCommonContent(common_content, uncommented_content_repos.at(index));
    }

    return common_content;
}

const LinesStorageSet SourcesExplorer::extractCommonContent(const LinesRepository<LinesStorageSet>& target_content_repos) const
{
    const unsigned short StorageInitializationIndex = 0;
    const unsigned short ExtractionStartIndex = 1;

    const auto uncommented_content_repos = target_content_repos.getContent();

    LinesStorageSet commonLinesSet(uncommented_content_repos.at(StorageInitializationIndex));

    for (unsigned short index = ExtractionStartIndex; index < uncommented_content_repos.size(); index++)
    {
        commonLinesSet = LinesMainProcessor::extractCommonContent(commonLinesSet, uncommented_content_repos.at(index));
    }

    return commonLinesSet;
}

const LinesRepository<LinesStorageMap> SourcesExplorer::extractUniqueContent(const LinesRepository<LinesStorageMap>& target_content_repos, const LinesStorageMap& common_content) const
{
    LinesRepository<LinesStorageMap> uniqueLinesInAllFiles {};

    for (const LinesStorageMap& content_map : target_content_repos.getContent())
    {
        const LinesStorageMap unique_content = LinesMainProcessor::extractUniqueContent(content_map, common_content);
        uniqueLinesInAllFiles.putContent(unique_content);
    }

    return uniqueLinesInAllFiles;
}

const LinesRepository<LinesStorageSet> SourcesExplorer::extractUniqueContent(const LinesRepository<LinesStorageSet>& target_content_repos, const LinesStorageSet& common_content) const
{
    LinesRepository<LinesStorageSet> uniqueLinesInAllFiles {};

    for (const LinesStorageSet& content_set : target_content_repos.getContent())
    {
        const LinesStorageSet unique_content = LinesMainProcessor::extractUniqueContent(content_set, common_content);
        uniqueLinesInAllFiles.putContent(unique_content);
    }

    return uniqueLinesInAllFiles;
}