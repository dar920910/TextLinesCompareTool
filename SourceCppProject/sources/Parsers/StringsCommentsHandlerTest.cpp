#include <gtest/gtest.h>

#include "StringsCommentsHandler.hpp"


TEST(StringsCommentsHandlerTest, CutAllCommentsInsideString_TestCase_1)
{
    std::string artifact {"0 1 /* 1 */ 2 /* 2 */ 3 4 5 6 7 /* 7 */ 8 /* 8 */ 9"};

    const std::string actual_artifact {StringsCommentsHandler(artifact).trimWrappedCommentsInsideString()};
    const std::string expected_artifact {"0 1  2  3 4 5 6 7  8  9"};

    EXPECT_EQ(actual_artifact, expected_artifact);
}

TEST(StringsCommentsHandlerTest, CutAllCommentsInsideString_TestCase_2)
{
    std::string artifact {"0 1 /*step1*/ 2 /*step2*/ 3 /*step3*/ 4 5"};

    const std::string actual_artifact {StringsCommentsHandler(artifact).trimWrappedCommentsInsideString()};
    const std::string expected_artifact {"0 1  2  3  4 5"};

    EXPECT_EQ(actual_artifact, expected_artifact);
}

TEST(StringsCommentsHandlerTest, CutAllCommentsInsideString_TestCase_3)
{
    std::string artifact {"/* comment */   0 1 2 3 4 5"};

    const std::string actual_artifact {StringsCommentsHandler(artifact).trimWrappedCommentsInsideString()};
    const std::string expected_artifact {"   0 1 2 3 4 5"};

    EXPECT_EQ(actual_artifact, expected_artifact);
}

TEST(StringsCommentsHandlerTest, CutAllCommentsInsideString_TestCase_4)
{
    std::string artifact {"0 1 2 3 4 5   /* comment */\n"};

    const std::string actual_artifact {StringsCommentsHandler(artifact).trimWrappedCommentsInsideString()};
    const std::string expected_artifact {"0 1 2 3 4 5   \n"};

    EXPECT_EQ(actual_artifact, expected_artifact);
}

TEST(StringsCommentsHandlerTest, CutAllCommentsInsideString_TestCase_5)
{
    std::string artifact {"/* comment */0 1 2 /*   comment   */ 3 4 5/* comment */\n"};

    const std::string actual_artifact {StringsCommentsHandler(artifact).trimWrappedCommentsInsideString()};
    const std::string expected_artifact {"0 1 2  3 4 5\n"};

    EXPECT_EQ(actual_artifact, expected_artifact);
}