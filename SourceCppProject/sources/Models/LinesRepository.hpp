#ifndef REPOSITORY_OF_LINES_STORAGES_HPP_
#define REPOSITORY_OF_LINES_STORAGES_HPP_

#include <vector>


template <class LinesStorageContainer>
class LinesRepository
{
private:
    std::vector<LinesStorageContainer> m_uniqueLines;
public:
    LinesRepository() : m_uniqueLines{} {}

    void putContent(const LinesStorageContainer& unique_info);
    const std::vector<LinesStorageContainer>& getContent() const;
};

#endif