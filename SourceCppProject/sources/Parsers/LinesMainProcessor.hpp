#ifndef LINES_MAIN_PROCESSOR_HPP_
#define LINES_MAIN_PROCESSOR_HPP_

#include "../Models/LinesStorageMap.hpp"
#include "../Models/LinesStorageSet.hpp"

#include <set>
#include <string>


class LinesMainProcessor
{
private:
    static const bool isUniqueLineInSource(const std::string& unique_object, const std::set<std::string>& source);
public:
    static const LinesStorageMap extractCommonContent(const LinesStorageMap& first_storage, const LinesStorageMap& second_storage);
    static const LinesStorageSet extractCommonContent(const LinesStorageSet& first_storage, const LinesStorageSet& second_storage);

    static const LinesStorageMap extractUniqueContent(const LinesStorageMap& target_storage, const LinesStorageMap& compared_storage);
    static const LinesStorageSet extractUniqueContent(const LinesStorageSet& target_storage, const LinesStorageSet& compared_storage);
};

#endif