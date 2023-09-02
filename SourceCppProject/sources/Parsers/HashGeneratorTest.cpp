#include <gtest/gtest.h>

#include "HashGenerator.hpp"


TEST(HashGeneratorTest, CalculateHashForString)
{
    const std::string test_string {"A-B-C-D-E-F-G-H"};

    const std::size_t expected_hash = std::hash<std::string>{}(test_string);
    const std::size_t actual_hash = HashGenerator::generateLineHash(test_string);

    EXPECT_EQ(actual_hash, expected_hash);
}

TEST(HashGeneratorTest, CompareHashForEqualStrings)
{
    const std::string test_string_1 {"A-B-C-D-E-F-G-H"};
    const std::string test_string_2 {"A-B-C-D-E-F-G-H"};

    const std::size_t hash_1 = HashGenerator::generateLineHash(test_string_1);
    const std::size_t hash_2 = HashGenerator::generateLineHash(test_string_2);

    EXPECT_EQ(hash_1, hash_2);
}

TEST(HashGeneratorTest, CompareHashForNotEqualStrings)
{
    const std::string test_string_1 {"A-B-C-D-E-F-G-H"};
    const std::string test_string_2 {"a-b-c-d-e-f-g-h"};

    const std::size_t hash_1 = HashGenerator::generateLineHash(test_string_1);
    const std::size_t hash_2 = HashGenerator::generateLineHash(test_string_2);

    EXPECT_NE(hash_1, hash_2);
}

TEST(HashGeneratorTest, CompareHashForCustomEqualStrings_TestCase_1)
{
    std::hash<std::string> hash {};
    EXPECT_EQ(HashGenerator::generateLineHash("0123456789"), hash("0123456789"));
}

TEST(HashGeneratorTest, CompareHashForCustomEqualStrings_TestCase_2)
{
    std::hash<std::string> hash {};
    EXPECT_EQ(HashGenerator::generateLineHash("1234567890"), hash("1234567890"));
}

TEST(HashGeneratorTest, CompareHashForCustomEqualStrings_TestCase_3)
{
    std::hash<std::string> hash {};
    EXPECT_EQ(HashGenerator::generateLineHash("2345678901"), hash("2345678901"));
}

TEST(HashGeneratorTest, CompareHashForCustomEqualStrings_TestCase_4)
{
    std::hash<std::string> hash {};
    EXPECT_EQ(HashGenerator::generateLineHash("3456789012"), hash("3456789012"));
}

TEST(HashGeneratorTest, CompareHashForCustomEqualStrings_TestCase_5)
{
    std::hash<std::string> hash {};
    EXPECT_EQ(HashGenerator::generateLineHash("4567890123"), hash("4567890123"));
}

TEST(HashGeneratorTest, CompareHashForCustomEqualStrings_TestCase_6)
{
    std::hash<std::string> hash {};
    EXPECT_EQ(HashGenerator::generateLineHash("5678901234"), hash("5678901234"));
}

TEST(HashGeneratorTest, CompareHashForCustomEqualStrings_TestCase_7)
{
    std::hash<std::string> hash {};
    EXPECT_EQ(HashGenerator::generateLineHash("6789012345"), hash("6789012345"));
}

TEST(HashGeneratorTest, CompareHashForCustomEqualStrings_TestCase_8)
{
    std::hash<std::string> hash {};
    EXPECT_EQ(HashGenerator::generateLineHash("7890123456"), hash("7890123456"));
}

TEST(HashGeneratorTest, CompareHashForCustomEqualStrings_TestCase_9)
{
    std::hash<std::string> hash {};
    EXPECT_EQ(HashGenerator::generateLineHash("8901234567"), hash("8901234567"));
}

TEST(HashGeneratorTest, CompareHashForCustomEqualStrings_TestCase_10)
{
    std::hash<std::string> hash {};
    EXPECT_EQ(HashGenerator::generateLineHash("9012345678"), hash("9012345678"));
}


TEST(HashGeneratorTest, compareHashForCustomNotEqualStrings_TestCase_1)
{
    std::hash<std::string> hash {};
    EXPECT_NE(HashGenerator::generateLineHash("012345678"), hash("123456789"));
}

TEST(HashGeneratorTest, compareHashForCustomNotEqualStrings_TestCase_2)
{
    std::hash<std::string> hash {};
    EXPECT_NE(HashGenerator::generateLineHash("123456789"), hash("234567890"));
}

TEST(HashGeneratorTest, compareHashForCustomNotEqualStrings_TestCase_3)
{
    std::hash<std::string> hash {};
    EXPECT_NE(HashGenerator::generateLineHash("234567890"), hash("345678901"));
}

TEST(HashGeneratorTest, compareHashForCustomNotEqualStrings_TestCase_4)
{
    std::hash<std::string> hash {};
    EXPECT_NE(HashGenerator::generateLineHash("345678901"), hash("456789012"));
}

TEST(HashGeneratorTest, compareHashForCustomNotEqualStrings_TestCase_5)
{
    std::hash<std::string> hash {};
    EXPECT_NE(HashGenerator::generateLineHash("456789012"), hash("567890123"));
}

TEST(HashGeneratorTest, compareHashForCustomNotEqualStrings_TestCase_6)
{
    std::hash<std::string> hash {};
    EXPECT_NE(HashGenerator::generateLineHash("567890123"), hash("678901234"));
}

TEST(HashGeneratorTest, compareHashForCustomNotEqualStrings_TestCase_7)
{
    std::hash<std::string> hash {};
    EXPECT_NE(HashGenerator::generateLineHash("678901234"), hash("789012345"));
}

TEST(HashGeneratorTest, compareHashForCustomNotEqualStrings_TestCase_8)
{
    std::hash<std::string> hash {};
    EXPECT_NE(HashGenerator::generateLineHash("789012345"), hash("890123456"));
}

TEST(HashGeneratorTest, compareHashForCustomNotEqualStrings_TestCase_9)
{
    std::hash<std::string> hash {};
    EXPECT_NE(HashGenerator::generateLineHash("890123456"), hash("901234567"));
}

TEST(HashGeneratorTest, compareHashForCustomNotEqualStrings_TestCase_10)
{
    std::hash<std::string> hash {};
    EXPECT_NE(HashGenerator::generateLineHash("901234567"), hash("012345678"));
}