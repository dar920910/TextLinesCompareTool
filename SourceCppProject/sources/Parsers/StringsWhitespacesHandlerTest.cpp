#include <gtest/gtest.h>

#include "StringsWhitespacesHandler.hpp"


TEST(StringsWhitespacesHandlerTest, PostProcessingForSpaces_TestCase_1)
{
    std::string artifact {"A  B   C    D     E          F"};

    const std::string actual_artifact {StringsWhitespacesHandler(artifact).trimRedunantWhitespaces()};
    const std::string expected_artifact {"A B C D E F"};

    EXPECT_EQ(actual_artifact, expected_artifact);
}

TEST(StringsWhitespacesHandlerTest, PostProcessingForSpaces_TestCase_2)
{
    std::string artifact {"G     H     I     J     K     L"};

    const std::string actual_artifact {StringsWhitespacesHandler(artifact).trimRedunantWhitespaces()};
    const std::string expected_artifact {"G H I J K L"};

    EXPECT_EQ(actual_artifact, expected_artifact);
}

TEST(StringsWhitespacesHandlerTest, PostProcessingForSpaces_TestCase_3)
{
    std::string artifact {"0   1 2    3     4 5     6    7 8   9"};

    const std::string actual_artifact {StringsWhitespacesHandler(artifact).trimRedunantWhitespaces()};
    const std::string expected_artifact {"0 1 2 3 4 5 6 7 8 9"};

    EXPECT_EQ(actual_artifact, expected_artifact);
}

TEST(StringsWhitespacesHandlerTest, PostProcessingForSpaces_TestCase_4)
{
    std::string artifact {"0 1 2  3      4  5     6  7 8 9"};

    const std::string actual_artifact {StringsWhitespacesHandler(artifact).trimRedunantWhitespaces()};
    const std::string expected_artifact {"0 1 2 3 4 5 6 7 8 9"};

    EXPECT_EQ(actual_artifact, expected_artifact);
}

TEST(StringsWhitespacesHandlerTest, PostProcessingForSpaces_TestCase_5)
{
    std::string artifact {"/  home /  user   / projects /   SendCodeLinesExplorer  /"};

    const std::string actual_artifact {StringsWhitespacesHandler(artifact).trimRedunantWhitespaces()};
    const std::string expected_artifact {"/ home / user / projects / SendCodeLinesExplorer /"};

    EXPECT_EQ(actual_artifact, expected_artifact);
}