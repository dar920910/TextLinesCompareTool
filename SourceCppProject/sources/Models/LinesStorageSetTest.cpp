#include <gtest/gtest.h>

#include "LinesStorageSet.hpp"

using test_set = std::set<std::string>;


TEST(LinesStorageSetTest, PutContent)
{
    using test_set = std::set<std::string>;

    LinesStorageSet storage(test_set{ "A", "B", "C" });

    storage.putContent("D");
    storage.putContent("E");
    storage.putContent("F");

    test_set actual_set = storage.getContent();
    test_set expected_set { "A", "B", "C", "D", "E", "F" };

    EXPECT_EQ(actual_set, expected_set);
}

TEST(UniqueLinesInfoTest, GetContent_TestCase_1)
{
    const test_set test_content { "str_1" };
    const LinesStorageSet unique_info(test_content);

    EXPECT_EQ(unique_info.getContent(), test_content);
}

TEST(UniqueLinesInfoTest, GetContent_TestCase_2)
{
    const test_set test_content { "str_1", "str_2", "str_3" };
    const LinesStorageSet unique_info(test_content);

    EXPECT_EQ(unique_info.getContent(), test_content);
}

TEST(UniqueLinesInfoTest, GetContent_TestCase_3)
{
    const test_set test_content { "str_1", "str_2", "str_3", "str_4", "str_5" };
    const LinesStorageSet unique_info(test_content);

    EXPECT_EQ(unique_info.getContent(), test_content);
}

TEST(UniqueLinesInfoTest, GetName_TestCase_1)
{
    const std::string storage_name { "Lines Storage Set" };
    const LinesStorageSet unique_info(test_set{});

    EXPECT_EQ(unique_info.getName(), storage_name);
}

TEST(UniqueLinesInfoTest, GetName_TestCase_2)
{
    const std::string storage_name { "Test Storage Name" };
    const LinesStorageSet unique_info(test_set{}, storage_name);

    EXPECT_EQ(unique_info.getName(), storage_name);
}

TEST(UniqueLinesInfoTest, GetName_TestCase_3)
{
    const std::string storage_name { "Test Storage Name" };
    const LinesStorageSet unique_info(storage_name);

    EXPECT_EQ(unique_info.getName(), storage_name);
}