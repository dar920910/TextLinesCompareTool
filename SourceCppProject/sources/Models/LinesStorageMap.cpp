#include "LinesStorageMap.hpp"


LinesStorageMap::LinesStorageMap()
{
}

LinesStorageMap::LinesStorageMap(const LineInfo& initial_info) : m_LinesMap{initial_info.getContent()}, m_Name(std::string{"Lines Storage Map"})
{
}

LinesStorageMap::LinesStorageMap(const LineInfo& initial_info, const std::string& name) : m_LinesMap{initial_info.getContent()}, m_Name(name)
{
}

LinesStorageMap::LinesStorageMap(const std::string& name) : m_Name(name)
{
}

void LinesStorageMap::putContent(const LineInfo& target_info)
{
    m_LinesMap.insert(target_info.getContent());
}

const std::unordered_map<std::size_t, std::string>& LinesStorageMap::getContent() const
{
    return m_LinesMap;
}

const std::string& LinesStorageMap::getName() const
{
    return m_Name;
}