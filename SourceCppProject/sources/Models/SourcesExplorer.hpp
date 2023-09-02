
#ifndef SOURCES_EXPLORER_HPP_
#define SOURCES_EXPLORER_HPP_

#include "LinesPresentationView.hpp"
#include "LinesStorageMap.hpp"
#include "LinesStorageSet.hpp"
#include "LinesRepository.hpp"
#include "SourceInfo.hpp"

#include <string>
#include <vector>


class SourcesExplorer
{
private:
    std::vector<SourceInfo> m_Sources {};

    void scanSource(const std::string& source_name);

    const LinesRepository<LinesStorageMap> getUncommentedMapBasedContent() const;
    const LinesRepository<LinesStorageSet> getUncommentedSetBasedContent() const;

    const LinesStorageMap extractCommonContent(const LinesRepository<LinesStorageMap>& target_content_repos) const;
    const LinesStorageSet extractCommonContent(const LinesRepository<LinesStorageSet>& target_content_repos) const;

    const LinesRepository<LinesStorageMap> extractUniqueContent(const LinesRepository<LinesStorageMap>& target_content_repos, const LinesStorageMap& common_content) const;
    const LinesRepository<LinesStorageSet> extractUniqueContent(const LinesRepository<LinesStorageSet>& target_content_repos, const LinesStorageSet& common_content) const;
public:
    SourcesExplorer(const std::vector<std::string>& sources);

    const LinesResultMapBasedView getArtifactsFromSourcesAsMapBasedContent() const;
    const LinesResultSetBasedView getArtifactsFromSourcesAsSetBasedContent() const;
};

#endif