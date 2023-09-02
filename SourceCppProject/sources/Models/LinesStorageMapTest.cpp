#include <gtest/gtest.h>

#include "LinesStorageMap.hpp"

#include <string>
#include <unordered_map>

using content_map_t = std::unordered_map<std::size_t, std::string>;


TEST(LinesStorageMapTest, PutContent_TestCase_1)
{
    const std::string test_string {"1111111111"};
    const LineInfo test_info(test_string);

    content_map_t test_content {test_info.getContent()};
    LinesStorageMap storage_map {test_info};

    storage_map.putContent(test_info);

    EXPECT_EQ(storage_map.getContent(), test_content);
}

TEST(LinesStorageMapTest, PutContent_TestCase_2)
{
    const std::string test_string_1 {"1111111111"};
    const std::string test_string_2 {"2222222222"};

    const LineInfo test_info_1(test_string_1);
    const LineInfo test_info_2(test_string_2);

    content_map_t test_content {test_info_1.getContent()};
    test_content.insert(test_info_2.getContent());

    LinesStorageMap storage_map {test_info_1};
    storage_map.putContent(test_info_1);
    storage_map.putContent(test_info_2);

    EXPECT_EQ(storage_map.getContent(), test_content);
}

TEST(LinesStorageMapTest, PutContent_TestCase_3)
{
    const std::string test_string_1 {"1111111111"};
    const std::string test_string_2 {"2222222222"};
    const std::string test_string_3 {"3333333333"};

    const LineInfo test_info_1(test_string_1);
    const LineInfo test_info_2(test_string_2);
    const LineInfo test_info_3(test_string_3);

    content_map_t test_content {test_info_1.getContent()};
    test_content.insert(test_info_2.getContent());
    test_content.insert(test_info_3.getContent());

    LinesStorageMap storage_map {test_info_1};
    storage_map.putContent(test_info_2);
    storage_map.putContent(test_info_3);

    EXPECT_EQ(storage_map.getContent(), test_content);
}

TEST(LinesStorageMapTest, GetContent)
{
    const std::string test_string {"000000000000"};
    const LineInfo test_info(test_string);

    std::unordered_map<std::size_t, std::string> test_content {test_info.getContent()};
    LinesStorageMap storage_map {test_info};

    EXPECT_EQ(storage_map.getContent(), test_content);
}