#include <gtest/gtest.h>

#include "LinesPreprocessor.hpp"


TEST(LinesPreprocessorTest, RetrieveArtifactFromLineWithStartSpaces_TestCase_1)
{
    LinesPreprocessor preprocessor("     /AAA/BBB/CCC/");
    EXPECT_EQ(preprocessor.retrievePreprocessedArtifact(), std::string("/AAA/BBB/CCC/"));
}

TEST(LinesPreprocessorTest, RetrieveArtifactFromLineWithStartSpaces_TestCase_2)
{
    LinesPreprocessor preprocessor("         /DDD/EEE/");
    EXPECT_EQ(preprocessor.retrievePreprocessedArtifact(), std::string("/DDD/EEE/"));
}

TEST(LinesPreprocessorTest, RetrieveArtifactFromLineWithStartSpaces_TestCase_3)
{
    LinesPreprocessor preprocessor("             /FFF/");
    EXPECT_EQ(preprocessor.retrievePreprocessedArtifact(), std::string("/FFF/"));
}


TEST(LinesPreprocessorTest, RetrieveArtifactFromLineWithEndSpaces_TestCase_1)
{
    LinesPreprocessor preprocessor("/AAA/BBB/CCC/     ");
    EXPECT_EQ(preprocessor.retrievePreprocessedArtifact(), std::string("/AAA/BBB/CCC/"));
}

TEST(LinesPreprocessorTest, RetrieveArtifactFromLineWithEndSpaces_TestCase_2)
{
    LinesPreprocessor preprocessor("/DDD/EEE/         ");
    EXPECT_EQ(preprocessor.retrievePreprocessedArtifact(), std::string("/DDD/EEE/"));
}

TEST(LinesPreprocessorTest, RetrieveArtifactFromLineWithEndSpaces_TestCase_3)
{
    LinesPreprocessor preprocessor("/FFF/             ");
    EXPECT_EQ(preprocessor.retrievePreprocessedArtifact(), std::string("/FFF/"));
}


TEST(LinesPreprocessorTest, RetrieveArtifactFromLineWrappedBySpaces_TestCase_1)
{
    LinesPreprocessor preprocessor("  /AAA/BBB/CCC/   ");
    EXPECT_EQ(preprocessor.retrievePreprocessedArtifact(), std::string("/AAA/BBB/CCC/"));
}

TEST(LinesPreprocessorTest, RetrieveArtifactFromLineWrappedBySpaces_TestCase_2)
{
    LinesPreprocessor preprocessor("    /DDD/EEE/     ");
    EXPECT_EQ(preprocessor.retrievePreprocessedArtifact(), std::string("/DDD/EEE/"));
}

TEST(LinesPreprocessorTest, RetrieveArtifactFromLineWrappedBySpaces_TestCase_3)
{
    LinesPreprocessor preprocessor("      /FFF/       ");
    EXPECT_EQ(preprocessor.retrievePreprocessedArtifact(), std::string("/FFF/"));
}


TEST(LinesPreprocessorTest, RetrieveArtifactFromLineWithComment_TestCase_1)
{
    LinesPreprocessor preprocessor("/aa/bb/cc# Unix style");
    EXPECT_EQ(preprocessor.retrievePreprocessedArtifact(), std::string("/aa/bb/cc"));
}

TEST(LinesPreprocessorTest, RetrieveArtifactFromLineWithComment_TestCase_2)
{
    LinesPreprocessor preprocessor("\\aa\\bb\\cc# Windows style");
    EXPECT_EQ(preprocessor.retrievePreprocessedArtifact(), std::string("\\aa\\bb\\cc"));
}


TEST(LinesPreprocessorTest, RetrieveArtifactFromLineWithSpacesAndComment_TestCase_1)
{
    LinesPreprocessor preprocessor("    /aa/bb/cc    # Unix style     ");
    EXPECT_EQ(preprocessor.retrievePreprocessedArtifact(), std::string("/aa/bb/cc"));
}

TEST(LinesPreprocessorTest, RetrieveArtifactFromLineWithSpacesAndComment_TestCase_2)
{
    LinesPreprocessor preprocessor("  \\aa\\bb\\cc   # Windows style  ");
    EXPECT_EQ(preprocessor.retrievePreprocessedArtifact(), std::string("\\aa\\bb\\cc"));
}


TEST(LinesPreprocessorTest, RetrieveArtifactFromLineWithCommentInsideText_TestCase_1)
{
    LinesPreprocessor preprocessor("/aa/bb/ # Unix style like /cc/dd/");
    EXPECT_EQ(preprocessor.retrievePreprocessedArtifact(), std::string("/aa/bb/"));
}

TEST(LinesPreprocessorTest, RetrieveArtifactFromLineWithCommentInsideText_TestCase_2)
{
    LinesPreprocessor preprocessor("\\aa\\bb\\ # Windows style like \\cc\\dd\\");
    EXPECT_EQ(preprocessor.retrievePreprocessedArtifact(), std::string("\\aa\\bb\\"));
}

TEST(LinesPreprocessorTest, RetrieveArtifact_SmokeTestCase_1)
{
    const std::string test_string {"     ./a/b/c/example.txt   #todo: replace the file to ./a/b  "};

    const std::string actual_result {LinesPreprocessor(test_string).retrievePreprocessedArtifact()};
    const std::string expected_result {"./a/b/c/example.txt"};

    EXPECT_EQ(actual_result, expected_result);
}

TEST(LinesPreprocessorTest, RetrieveArtifact_SmokeTestCase_2)
{
    const std::string test_string {"  EXAMPLE:/* comment_1 */     test_path:     /* comment_2 */./a/b/c/example.txt   #  todo   "};

    const std::string actual_result {LinesPreprocessor(test_string).retrievePreprocessedArtifact()};
    const std::string expected_result {"EXAMPLE: test_path: ./a/b/c/example.txt"};

    EXPECT_EQ(actual_result, expected_result);
}

TEST(LinesPreprocessorTest, RetrieveArtifact_SmokeTestCase_3)
{
    const std::string test_string {"/* Types of paths: */    dir1\\dir2\\dir3    /* it's a path for Windows */    dir1/dir2/dir3      /* it's a path for Unix */    \n"};

    const std::string actual_result {LinesPreprocessor(test_string).retrievePreprocessedArtifact()};
    const std::string expected_result {"dir1\\dir2\\dir3 dir1/dir2/dir3"};

    EXPECT_EQ(actual_result, expected_result);
}

TEST(LinesPreprocessorTest, RetrieveArtifact_SmokeTestCase_4)
{
    const std::string test_string {"    /* Comment: '#' is Unix-style comment */ dir1/dir2/dir3 /* for Unix */ # dir1\\dir2\\dir3 (for Windows)\n"};

    const std::string actual_result {LinesPreprocessor(test_string).retrievePreprocessedArtifact()};
    const std::string expected_result {"dir1/dir2/dir3"};

    EXPECT_EQ(actual_result, expected_result);
}