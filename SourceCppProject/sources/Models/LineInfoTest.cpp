#include <gtest/gtest.h>
#include "LineInfo.hpp"

#include "../Parsers/HashGenerator.hpp"

using pair_t = std::pair<std::size_t, std::string>;


TEST(LineInfoTest, GetLinePairInfo_TestCase_1)
{
    const std::string test_string {"/aaa/bbb/ccc/ddd/eee/"};

    const pair_t expected_pair {HashGenerator::generateLineHash(test_string), test_string};
    const pair_t actual_pair {LineInfo(test_string).getContent()};

    EXPECT_EQ(actual_pair, expected_pair);
}

TEST(LineInfoTest, GetLinePairInfo_TestCase_2)
{
    const std::string test_string {"\\AAA\\BBB\\CCC\\DDD\\EEE\\"};

    const pair_t expected_pair {HashGenerator::generateLineHash(test_string), test_string};
    const pair_t actual_pair {LineInfo(test_string).getContent()};

    EXPECT_EQ(actual_pair, expected_pair);
}

TEST(LineInfoTest, GetKeyOfPair_TestCase_1)
{
    const std::string test_string {"/aaa/bbb/ccc/ddd/eee/"};

    const size_t expected_pair_key = HashGenerator::generateLineHash(test_string);
    const size_t actual_pair_key = LineInfo(test_string).getContent().first;

    EXPECT_EQ(actual_pair_key, expected_pair_key);
}

TEST(LineInfoTest, GetKeyOfPair_TestCase_2)
{
    const std::string test_string {"\\AAA\\BBB\\CCC\\DDD\\EEE\\"};

    const size_t expected_pair_key = HashGenerator::generateLineHash(test_string);
    const size_t actual_pair_key = LineInfo(test_string).getContent().first;

    EXPECT_EQ(actual_pair_key, expected_pair_key);
}

TEST(LineInfoTest, GetValueOfPair_TestCase_1)
{
    const std::string test_string {"/aaa/bbb/ccc/ddd/eee/"};
    EXPECT_EQ(LineInfo(test_string).getContent().second, test_string);
}

TEST(LineInfoTest, GetValueOfPair_TestCase_2)
{
    const std::string test_string {"\\AAA\\BBB\\CCC\\DDD\\EEE\\"};
    EXPECT_EQ(LineInfo(test_string).getContent().second, test_string);
}