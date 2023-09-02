#ifndef LINES_STORAGE_SET_HPP_
#define LINES_STORAGE_SET_HPP_

#include <set>
#include <string>


class LinesStorageSet
{
private:
    std::string m_Name {};
    std::set<std::string> m_LinesSet {};
public:
    LinesStorageSet();
    LinesStorageSet(const std::set<std::string>& initial_set);
    LinesStorageSet(const std::set<std::string>& initial_set, const std::string& name);
    LinesStorageSet(const std::string& name);

    void putContent(const std::string& content);
    const std::set<std::string>& getContent() const;
    const std::string& getName() const;
};

#endif