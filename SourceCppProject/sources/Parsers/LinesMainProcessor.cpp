#include "LinesMainProcessor.hpp"

#include <algorithm>
#include <functional>
#include <iterator>
#include <utility>
#include <vector>


const LinesStorageMap LinesMainProcessor::extractCommonContent(const LinesStorageMap& first_storage, const LinesStorageMap& second_storage)
{
    LinesStorageMap common_content {};

    const auto first_map = first_storage.getContent();
    const auto second_map = second_storage.getContent();

    for (const std::pair<const std::size_t, std::string>& first_pair : first_map)
    {
        for (const std::pair<const std::size_t, std::string>& second_pair : second_map)
        {
            if (first_pair.first == second_pair.first)
            {
                common_content.putContent(LineInfo(first_pair));
            }
        }
    }

    return common_content;
}

const LinesStorageSet LinesMainProcessor::extractCommonContent(const LinesStorageSet& first_storage, const LinesStorageSet& second_storage)
{
    std::set<std::string> extractedCommonLines;

    std::insert_iterator<std::set<std::string>> inserter = std::inserter(extractedCommonLines, extractedCommonLines.end());

    auto first_src_begin = first_storage.getContent().begin();
    auto first_src_end = first_storage.getContent().end();

    auto second_src_begin = second_storage.getContent().begin();
    auto second_src_end = second_storage.getContent().end();

    std::set_intersection(first_src_begin, first_src_end, second_src_begin, second_src_end, inserter);

    return LinesStorageSet(extractedCommonLines);
}


const LinesStorageMap LinesMainProcessor::extractUniqueContent(const LinesStorageMap& target_storage, const LinesStorageMap& compared_storage)
{
    LinesStorageMap unique_content_map(target_storage.getName());

    const auto target_content_map = target_storage.getContent();
    const auto compared_content_map = compared_storage.getContent();

    for (const std::pair<std::size_t, std::string>& pair : target_content_map)
    {
        if (compared_content_map.count(pair.first) == 0)
        {
            unique_content_map.putContent(LineInfo(pair));
        }
    }

    return unique_content_map;
}

const LinesStorageSet LinesMainProcessor::extractUniqueContent(const LinesStorageSet& target_storage, const LinesStorageSet& compared_storage)
{
    LinesStorageSet extractedUniqueLines(target_storage.getName());

    const std::set<std::string> target_content = target_storage.getContent();
    const std::set<std::string> compared_content = compared_storage.getContent();

    for (const std::string& target_element : target_content)
    {
        if (isUniqueLineInSource(target_element, compared_content))
        {
            extractedUniqueLines.putContent(target_element);
        }
    }

    return extractedUniqueLines;
}

const bool LinesMainProcessor::isUniqueLineInSource(const std::string& unique_object, const std::set<std::string>& source)
{
    if (source.count(unique_object))
    {
        return false;
    }

    return true;
}