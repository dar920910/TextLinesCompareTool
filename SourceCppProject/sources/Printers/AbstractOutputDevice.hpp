#ifndef ABSTRACT_OUTPUT_DEVICE_HPP_
#define ABSTRACT_OUTPUT_DEVICE_HPP_

#include "../Models/LinesPresentationView.hpp"
#include "../Models/LinesStorageMap.hpp"
#include "../Models/LinesStorageSet.hpp"
#include "../Models/LinesRepository.hpp"
#include "../Models/SourceInfo.hpp"
#include "../Models/SourcesExplorer.hpp"
#include "../Models/LineInfo.hpp"

#include <set>
#include <string>
#include <vector>


class AbstractOutputDevice
{
protected:
    virtual void printLineInfo(const LineInfo& target_info) = 0;
    virtual void printLineInfo(const std::pair<std::size_t, std::string>& target_line) = 0;
    virtual void printLineInfo(const std::string& target_line) = 0;

    virtual void printLinePairKey(const std::pair<std::size_t, std::string>& pair) = 0;
    virtual void printLinePairValue(const std::pair<std::size_t, std::string>& pair) = 0;

    virtual void printUncommentedContent(const LinesStorageMap& target_content) = 0;
    virtual void printUncommentedContent(const LinesStorageSet& target_content) = 0;
    virtual void printUncommentedContent(const LinesRepository<LinesStorageMap>& content_repos) = 0;
    virtual void printUncommentedContent(const LinesRepository<LinesStorageSet>& content_repos) = 0;

    virtual void printCommonContent(const LinesStorageMap& target_content) = 0;
    virtual void printCommonContent(const LinesStorageSet& target_content) = 0;

    virtual void printUniqueContent(const LinesStorageMap& content_element) = 0;
    virtual void printUniqueContent(const LinesStorageSet& content_element) = 0;
    virtual void printUniqueContent(const LinesRepository<LinesStorageMap>& repos) = 0;
    virtual void printUniqueContent(const LinesRepository<LinesStorageSet>& repos) = 0;

    virtual void printContentTitle(const std::string& title_text) = 0;
    virtual void printUncommentedContentTitle(const std::string& source_name) = 0;
    virtual void printUniqueContentTitle(const std::string& source_name) = 0;

    const std::string getDelimiter() const;
    const std::string getSubDelimiter() const;
public:
    virtual ~AbstractOutputDevice() {}

    virtual void printArtifacts(const LinesResultMapBasedView& result_artifact);
    virtual void printArtifacts(const LinesResultSetBasedView& result_artifact);
};

#endif