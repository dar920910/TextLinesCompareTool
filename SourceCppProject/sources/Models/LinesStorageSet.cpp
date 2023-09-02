#include "LinesStorageSet.hpp"


LinesStorageSet::LinesStorageSet()
{
}

LinesStorageSet::LinesStorageSet(const std::set<std::string>& initial_set)
{
    m_Name = std::string{"Lines Storage Set"};
    m_LinesSet = initial_set;
}

LinesStorageSet::LinesStorageSet(const std::set<std::string>& initial_set, const std::string& name)
{
    m_Name = name;
    m_LinesSet = initial_set;
}

LinesStorageSet::LinesStorageSet(const std::string& name)
{
    m_Name = name;
}

void LinesStorageSet::putContent(const std::string& content)
{
    m_LinesSet.insert(content);
}

const std::set<std::string>& LinesStorageSet::getContent() const
{
    return m_LinesSet;
}

const std::string& LinesStorageSet::getName() const
{
    return m_Name;
}