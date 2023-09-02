#include "LinesRepository.hpp"

#include "LinesStorageMap.hpp"
#include "LinesStorageSet.hpp"


template <class LinesStorageContainer>
void LinesRepository<LinesStorageContainer>::putContent(const LinesStorageContainer& unique_info)
{
    m_uniqueLines.push_back(unique_info);
}

template <class LinesStorageContainer>
const std::vector<LinesStorageContainer>& LinesRepository<LinesStorageContainer>::getContent() const
{
    return m_uniqueLines;
}


template void LinesRepository<LinesStorageMap>::putContent(const LinesStorageMap& unique_info);
template const std::vector<LinesStorageMap>& LinesRepository<LinesStorageMap>::getContent() const;

template void LinesRepository<LinesStorageSet>::putContent(const LinesStorageSet& unique_info);
template const std::vector<LinesStorageSet>& LinesRepository<LinesStorageSet>::getContent() const;