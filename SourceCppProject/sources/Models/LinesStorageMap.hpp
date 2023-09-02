#ifndef LINES_STORAGE_MAP_HPP_
#define LINES_STORAGE_MAP_HPP_

#include "LineInfo.hpp"

#include <string>
#include <unordered_map>


class LinesStorageMap
{
private:
    std::string m_Name {};
    std::unordered_map<std::size_t, std::string> m_LinesMap {};
public:
    LinesStorageMap();
    LinesStorageMap(const LineInfo& initial_info);
    LinesStorageMap(const LineInfo& initial_info, const std::string& name);
    LinesStorageMap(const std::string& name);

    void putContent(const LineInfo& target_info);
    const std::unordered_map<std::size_t, std::string>& getContent() const;
    const std::string& getName() const;
};

#endif