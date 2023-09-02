#include <gtest/gtest.h>

#include "GeneralCharacterValidator.hpp"


TEST(GeneralCharacterValidatorTest, IsNotCommentCharacter_TestCase_1)
{
    const char comment_character {'#'};
    const char test_character {'A'};

    EXPECT_EQ(GeneralCharacterValidator::isNotCommentCharacter(test_character), test_character != comment_character);
}

TEST(GeneralCharacterValidatorTest, IsNotCommentCharacter_TestCase_2)
{
    const char comment_character {'#'};
    const char test_character {'Z'};

    EXPECT_EQ(GeneralCharacterValidator::isNotCommentCharacter(test_character), test_character != comment_character);
}

TEST(GeneralCharacterValidatorTest, IsNotCommentCharacter_TestCase_3)
{
    const char comment_character {'#'};
    const char test_character {'b'};

    EXPECT_EQ(GeneralCharacterValidator::isNotCommentCharacter(test_character), test_character != comment_character);
}

TEST(GeneralCharacterValidatorTest, IsNotCommentCharacter_TestCase_4)
{
    const char comment_character {'#'};
    const char test_character {'y'};

    EXPECT_EQ(GeneralCharacterValidator::isNotCommentCharacter(test_character), test_character != comment_character);
}

TEST(GeneralCharacterValidatorTest, IsNotCommentCharacter_TestCase_5)
{
    const char comment_character {'#'};
    const char test_character {'1'};

    EXPECT_EQ(GeneralCharacterValidator::isNotCommentCharacter(test_character), test_character != comment_character);
}

TEST(GeneralCharacterValidatorTest, IsNotCommentCharacter_TestCase_6)
{
    const char comment_character {'#'};
    const char test_character {'9'};

    EXPECT_EQ(GeneralCharacterValidator::isNotCommentCharacter(test_character), test_character != comment_character);
}

TEST(GeneralCharacterValidatorTest, IsNotCommentCharacter_TestCase_7)
{
    const char comment_character {'#'};
    const char test_character {'@'};

    EXPECT_EQ(GeneralCharacterValidator::isNotCommentCharacter(test_character), test_character != comment_character);
}

TEST(GeneralCharacterValidatorTest, IsNotCommentCharacter_TestCase_8)
{
    const char comment_character {'#'};
    const char test_character {'&'};

    EXPECT_EQ(GeneralCharacterValidator::isNotCommentCharacter(test_character), test_character != comment_character);
}


TEST(GeneralCharacterValidatorTest, IsCommentCharacter)
{
    const char comment_character {'#'};
    const char test_character {comment_character};

    EXPECT_EQ(GeneralCharacterValidator::isNotCommentCharacter(test_character), test_character != comment_character);
}


TEST(GeneralCharacterValidatorTest, IsSpaceCharacter_TestCase_1)
{
    EXPECT_EQ(GeneralCharacterValidator::isSpaceCharacter(' '), true); // ASCII: 0x20
}

TEST(GeneralCharacterValidatorTest, IsSpaceCharacter_TestCase_2)
{
    EXPECT_EQ(GeneralCharacterValidator::isSpaceCharacter('\f'), true); // ASCII: 0x0C
}

TEST(GeneralCharacterValidatorTest, IsSpaceCharacter_TestCase_3)
{
    EXPECT_EQ(GeneralCharacterValidator::isSpaceCharacter('\n'), true); // ASCII: 0x0A
}

TEST(GeneralCharacterValidatorTest, IsSpaceCharacter_TestCase_4)
{
    EXPECT_EQ(GeneralCharacterValidator::isSpaceCharacter('\r'), true); // ASCII: 0x0D
}

TEST(GeneralCharacterValidatorTest, IsSpaceCharacter_TestCase_5)
{
    EXPECT_EQ(GeneralCharacterValidator::isSpaceCharacter('\t'), true); // ASCII: 0x09
}

TEST(GeneralCharacterValidatorTest, IsSpaceCharacter_TestCase_6)
{
    EXPECT_EQ(GeneralCharacterValidator::isSpaceCharacter('\v'), true); // ASCII: 0x0B
}


TEST(GeneralCharacterValidatorTest, IsNotSpaceCharacter_TestCase_1)
{
    EXPECT_EQ(GeneralCharacterValidator::isSpaceCharacter('A'), false);
}

TEST(GeneralCharacterValidatorTest, IsNotSpaceCharacter_TestCase_2)
{
    EXPECT_EQ(GeneralCharacterValidator::isSpaceCharacter('Z'), false);
}

TEST(GeneralCharacterValidatorTest, IsNotSpaceCharacter_TestCase_3)
{
    EXPECT_EQ(GeneralCharacterValidator::isSpaceCharacter('b'), false);
}

TEST(GeneralCharacterValidatorTest, IsNotSpaceCharacter_TestCase_4)
{
    EXPECT_EQ(GeneralCharacterValidator::isSpaceCharacter('y'), false);
}

TEST(GeneralCharacterValidatorTest, IsNotSpaceCharacter_TestCase_5)
{
    EXPECT_EQ(GeneralCharacterValidator::isSpaceCharacter('0'), false);
}

TEST(GeneralCharacterValidatorTest, IsNotSpaceCharacter_TestCase_6)
{
    EXPECT_EQ(GeneralCharacterValidator::isSpaceCharacter('9'), false);
}

TEST(GeneralCharacterValidatorTest, IsNotSpaceCharacter_TestCase_7)
{
    EXPECT_EQ(GeneralCharacterValidator::isSpaceCharacter('#'), false);
}

TEST(GeneralCharacterValidatorTest, IsNotSpaceCharacter_TestCase_8)
{
    EXPECT_EQ(GeneralCharacterValidator::isSpaceCharacter('/'), false);
}

TEST(GeneralCharacterValidatorTest, IsNotSpaceCharacter_TestCase_9)
{
    EXPECT_EQ(GeneralCharacterValidator::isSpaceCharacter('\\'), false);
}