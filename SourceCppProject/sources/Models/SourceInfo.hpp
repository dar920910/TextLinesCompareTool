#ifndef SOURCE_INFO_HPP_
#define SOURCE_INFO_HPP_

#include "LinesStorageMap.hpp"
#include "LinesStorageSet.hpp"

#include <string>
#include <vector>


class SourceInfo
{
private:
    const std::string m_Name;
    std::vector<std::string> m_Content;

public:
    SourceInfo(const std::string& source);

    const std::string& getName() const;

    const LinesStorageMap getArtifactsAsMapBasedStorage() const;
    const LinesStorageSet getArtifactsAsSetBasedStorage() const;
};

#endif