#include "SourceInfo.hpp"

#include "LineInfo.hpp"
#include "../Parsers/ArtifactValidator.hpp"
#include "../Parsers/LinesPreprocessor.hpp"

#include <fstream>


SourceInfo::SourceInfo(const std::string& source) : m_Name{source}
{
    m_Content = std::vector<std::string>{};

    std::ifstream fileStreamToReadSource {source};
    std::string tempStringToSaveData {};

    while(std::getline(fileStreamToReadSource, tempStringToSaveData))
    {
        m_Content.push_back(tempStringToSaveData);
    }
}

const std::string& SourceInfo::getName() const
{
    return m_Name;
}

const LinesStorageMap SourceInfo::getArtifactsAsMapBasedStorage() const
{
    LinesStorageMap target_content(m_Name);

    for (const std::string& stringFromSource : m_Content)
    {
        if (ArtifactValidator(stringFromSource).isArtifact())
        {
            std::string artifact_string {LinesPreprocessor(stringFromSource).retrievePreprocessedArtifact()};
            target_content.putContent(LineInfo(artifact_string));
        }
    }

    return target_content;
}

const LinesStorageSet SourceInfo::getArtifactsAsSetBasedStorage() const
{
    LinesStorageSet target_content(m_Name);

    for (const std::string& stringFromSource : m_Content)
    {
        if (ArtifactValidator(stringFromSource).isArtifact())
        {
            std::string artifact_string {LinesPreprocessor(stringFromSource).retrievePreprocessedArtifact()};
            target_content.putContent(artifact_string);
        }
    }

    return target_content;
}