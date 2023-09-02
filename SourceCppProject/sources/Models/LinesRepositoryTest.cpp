#include <gtest/gtest.h>
#include <gmock/gmock.h>

#include "LinesRepository.hpp"
#include "LinesStorageSet.hpp"

#include <set>
#include <string>
#include <vector>


TEST(LinesRepositoryTest, PutContent)
{
    // STEP 1: ARRANGE

    const std::set<std::string> test_set {};

    const std::string unique_source_name_0("unique_source_name_0");
    const std::string unique_source_name_1("unique_source_name_1");
    const std::string unique_source_name_2("unique_source_name_2");

    const LinesStorageSet unique_info_0(test_set, unique_source_name_0);
    const LinesStorageSet unique_info_1(test_set, unique_source_name_1);
    const LinesStorageSet unique_info_2(test_set, unique_source_name_2);


    // STEP 2: ACT

    LinesRepository<LinesStorageSet> repos;

    repos.putContent(unique_info_0);
    std::vector<LinesStorageSet> actual_content_0 = repos.getContent();

    repos.putContent(unique_info_1);
    std::vector<LinesStorageSet> actual_content_1 = repos.getContent();

    repos.putContent(unique_info_2);
    std::vector<LinesStorageSet> actual_content_2 = repos.getContent();


    // STEP 3: ASSERT

    EXPECT_EQ(actual_content_0.at(0).getName(), unique_source_name_0);

    EXPECT_EQ(actual_content_1.at(0).getName(), unique_source_name_0);
    EXPECT_EQ(actual_content_1.at(1).getName(), unique_source_name_1);

    EXPECT_EQ(actual_content_2.at(0).getName(), unique_source_name_0);
    EXPECT_EQ(actual_content_2.at(1).getName(), unique_source_name_1);
    EXPECT_EQ(actual_content_2.at(2).getName(), unique_source_name_2);
}

TEST(LinesRepositoryTest, GetContent)
{
    // STEP 1: ARRANGE

    const std::string test_name { "test_source" };

    const std::set<std::string> set_1 = { "A", "B", "C", "D", "E", "F" };
    const std::set<std::string> set_2 = { "A", "B", "C", "D", "E" };
    const std::set<std::string> set_3 = { "A", "B", "C", "D" };
    const std::set<std::string> set_4 = { "A", "B", "C", };
    const std::set<std::string> set_5 = { "A", "B" };
    const std::set<std::string> set_6 = { "A" };

    const LinesStorageSet unique_info_1(set_1, test_name);
    const LinesStorageSet unique_info_2(set_2, test_name);
    const LinesStorageSet unique_info_3(set_3, test_name);
    const LinesStorageSet unique_info_4(set_4, test_name);
    const LinesStorageSet unique_info_5(set_5, test_name);
    const LinesStorageSet unique_info_6(set_6, test_name);


    // STEP 2: ACT

    std::vector<LinesStorageSet> expected_content;
    expected_content.push_back(unique_info_1);
    expected_content.push_back(unique_info_2);
    expected_content.push_back(unique_info_3);
    expected_content.push_back(unique_info_4);
    expected_content.push_back(unique_info_5);
    expected_content.push_back(unique_info_6);

    std::vector<LinesStorageSet> actual_content;
    LinesRepository<LinesStorageSet> repos;
    repos.putContent(unique_info_1);
    repos.putContent(unique_info_2);
    repos.putContent(unique_info_3);
    repos.putContent(unique_info_4);
    repos.putContent(unique_info_5);
    repos.putContent(unique_info_6);
    actual_content = repos.getContent();


    // STEP 3: ASSERT

    EXPECT_THAT(actual_content.at(0).getContent(), testing::ElementsAreArray(expected_content.at(0).getContent()));
    EXPECT_THAT(actual_content.at(1).getContent(), testing::ElementsAreArray(expected_content.at(1).getContent()));
    EXPECT_THAT(actual_content.at(2).getContent(), testing::ElementsAreArray(expected_content.at(2).getContent()));
    EXPECT_THAT(actual_content.at(3).getContent(), testing::ElementsAreArray(expected_content.at(3).getContent()));
    EXPECT_THAT(actual_content.at(4).getContent(), testing::ElementsAreArray(expected_content.at(4).getContent()));
    EXPECT_THAT(actual_content.at(5).getContent(), testing::ElementsAreArray(expected_content.at(5).getContent()));
}