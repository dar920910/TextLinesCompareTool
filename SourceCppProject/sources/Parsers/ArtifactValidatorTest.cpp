#include <gtest/gtest.h>

#include "ArtifactValidator.hpp"


TEST(ArtifactValidatorTest, isArtifact_TestCase_1)
{
    EXPECT_EQ(ArtifactValidator("/a/b/c/d/").isArtifact(), true);
}

TEST(ArtifactValidatorTest, isArtifact_TestCase_2)
{
    EXPECT_EQ(ArtifactValidator("   b/c   ").isArtifact(), true);
}

TEST(ArtifactValidatorTest, isArtifact_TestCase_3)
{
    EXPECT_EQ(ArtifactValidator("/a/ # /d/").isArtifact(), true);
}


TEST(ArtifactValidatorTest, IsNotArtifact_TestCase_1)
{
    EXPECT_EQ(ArtifactValidator("").isArtifact(), false);
}

TEST(ArtifactValidatorTest, IsNotArtifact_TestCase_2)
{
    EXPECT_EQ(ArtifactValidator(std::string{}).isArtifact(), false);
}

TEST(ArtifactValidatorTest, isNotArtifact_TestCase_3)
{
    EXPECT_EQ(ArtifactValidator("         ").isArtifact(), false);
}


TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlyLetters_TestCase_1)
{
    EXPECT_EQ(ArtifactValidator("ABCDEFGHIJKLMNOPQRSTUVWXYZ").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlyLetters_TestCase_2)
{
    EXPECT_EQ(ArtifactValidator("abcdefghijklmnopqrstuvwxyz").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlyLetters_TestCase_3)
{
    EXPECT_EQ(ArtifactValidator("ABCDEFGHIJKLMnopqrstuvwxyz").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlyLetters_TestCase_4)
{
    EXPECT_EQ(ArtifactValidator("abcdefghijklmNOPQRSTUVWXYZ").isArtifact(), true);
}


TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlyDigits_TestCase_1)
{
    EXPECT_EQ(ArtifactValidator("0123456789").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlyDigits_TestCase_2)
{
    EXPECT_EQ(ArtifactValidator("9876543210").isArtifact(), true);
}


TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlyPunctuationSigns_TestCase_1)
{
    EXPECT_EQ(ArtifactValidator(".....").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlyPunctuationSigns_TestCase_2)
{
    EXPECT_EQ(ArtifactValidator(",,,,,,").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlyPunctuationSigns_TestCase_3)
{
    EXPECT_EQ(ArtifactValidator("!!!!!").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlyPunctuationSigns_TestCase_4)
{
    EXPECT_EQ(ArtifactValidator("?????").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlyPunctuationSigns_TestCase_5)
{
    EXPECT_EQ(ArtifactValidator(":::::").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlyPunctuationSigns_TestCase_6)
{
    EXPECT_EQ(ArtifactValidator(";;;;;").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlyPunctuationSigns_TestCase_7)
{
    EXPECT_EQ(ArtifactValidator("(((((").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlyPunctuationSigns_TestCase_8)
{
    EXPECT_EQ(ArtifactValidator(")))))").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlyPunctuationSigns_TestCase_9)
{
    EXPECT_EQ(ArtifactValidator("-----").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlyPunctuationSigns_TestCase_10)
{
    EXPECT_EQ(ArtifactValidator("'''''").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlyPunctuationSigns_TestCase_11)
{
    EXPECT_EQ(ArtifactValidator("\"\"\"\"\"").isArtifact(), true);
}


TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlyArithmeticSigns_TestCase_1)
{
    EXPECT_EQ(ArtifactValidator("+++++").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlyArithmeticSigns_TestCase_2)
{
    EXPECT_EQ(ArtifactValidator("-----").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlyArithmeticSigns_TestCase_3)
{
    EXPECT_EQ(ArtifactValidator("*****").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlyArithmeticSigns_TestCase_4)
{
    EXPECT_EQ(ArtifactValidator("/////").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlyArithmeticSigns_TestCase_5)
{
    EXPECT_EQ(ArtifactValidator("======").isArtifact(), true);
}


TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlySpecialSymbols)
{
    EXPECT_EQ(ArtifactValidator("~~~~~").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlySpecialSymbols_TestCase_2)
{
    EXPECT_EQ(ArtifactValidator("`````").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlySpecialSymbols_TestCase_3)
{
    EXPECT_EQ(ArtifactValidator("@@@@@").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlySpecialSymbols_TestCase_4)
{
    EXPECT_EQ(ArtifactValidator("$$$$$").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlySpecialSymbols_TestCase_5)
{
    EXPECT_EQ(ArtifactValidator("%%%%%").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlySpecialSymbols_TestCase_6)
{
    EXPECT_EQ(ArtifactValidator("&&&&&").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlySpecialSymbols_TestCase_7)
{
    EXPECT_EQ(ArtifactValidator("_____").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlySpecialSymbols_TestCase_8)
{
    EXPECT_EQ(ArtifactValidator("^^^^^").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlySpecialSymbols_TestCase_9)
{
    EXPECT_EQ(ArtifactValidator("<<<<<").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlySpecialSymbols_TestCase_10)
{
    EXPECT_EQ(ArtifactValidator(">>>>>").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlySpecialSymbols_TestCase_11)
{
    EXPECT_EQ(ArtifactValidator("[[[[[").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlySpecialSymbols_TestCase_12)
{
    EXPECT_EQ(ArtifactValidator("]]]]]").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlySpecialSymbols_TestCase_13)
{
    EXPECT_EQ(ArtifactValidator("|||||").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlySpecialSymbols_TestCase_14)
{
    EXPECT_EQ(ArtifactValidator("\\\\\\\\\\").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlySpecialSymbols_TestCase_15)
{
    EXPECT_EQ(ArtifactValidator("{{{{{").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlySpecialSymbols_TestCase_16)
{
    EXPECT_EQ(ArtifactValidator("}}}}}").isArtifact(), true);
}


TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlyPathLikeUnixStyle_TestCase_1)
{
    EXPECT_EQ(ArtifactValidator("/AAA/").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlyPathLikeUnixStyle_TestCase_2)
{
    EXPECT_EQ(ArtifactValidator("/BBB/CCC/").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlyPathLikeUnixStyle_TestCase_3)
{
    EXPECT_EQ(ArtifactValidator("/CCC/DDD/EEE/").isArtifact(), true);
}


TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlyPathLikeWindowsStyle_TestCase_1)
{
    EXPECT_EQ(ArtifactValidator("\\AAA\\").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlyPathLikeWindowsStyle_TestCase_2)
{
    EXPECT_EQ(ArtifactValidator("\\BBB\\CCC\\").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsOnlyPathLikeWindowsStyle_TestCase_3)
{
    EXPECT_EQ(ArtifactValidator("\\CCC\\DDD\\EEE\\").isArtifact(), true);
}


TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsSpacesBeforeText_TestCase_1)
{
    EXPECT_EQ(ArtifactValidator("          \\AAA\\BBB\\CCC\\").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsSpacesBeforeText_TestCase_2)
{
    EXPECT_EQ(ArtifactValidator("     /ddd/eee/fff/").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsSpacesBeforeText_TestCase_3)
{
    EXPECT_EQ(ArtifactValidator(" /g\\h/i\\j").isArtifact(), true);
}


TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsCommentsAfterText_TestCase_1)
{
    EXPECT_EQ(ArtifactValidator("\\AAA\\BBB\\CCC\\ # Windows style").isArtifact(), true);
}

TEST(ArtifactValidatorTest, IsArtifactWhenLineContainsCommentsAfterText_TestCase_2)
{
    EXPECT_EQ(ArtifactValidator("/ddd/eee/fff/     # Unix style   ").isArtifact(), true);
}


TEST(ArtifactValidatorTest, IsNotArtifactWhenLineContainsOnlyComments_TestCase_1)
{
    EXPECT_EQ(ArtifactValidator("##########").isArtifact(), false);
}

TEST(ArtifactValidatorTest, IsNotArtifactWhenLineContainsOnlyComments_TestCase_2)
{
    EXPECT_EQ(ArtifactValidator("#####").isArtifact(), false);
}

TEST(ArtifactValidatorTest, IsNotArtifactWhenLineContainsOnlyComments_TestCase_3)
{
    EXPECT_EQ(ArtifactValidator("#").isArtifact(), false);
}


TEST(ArtifactValidatorTest, IsNotArtifactWhenLineContainsCommentsBeforeText_TestCase_1)
{
    EXPECT_EQ(ArtifactValidator("#/AAA/BBB/CCC/").isArtifact(), false);
}

TEST(ArtifactValidatorTest, IsNotArtifactWhenLineContainsCommentsBeforeText_TestCase_2)
{
    EXPECT_EQ(ArtifactValidator("#    /DDD/EEE/").isArtifact(), false);
}


TEST(ArtifactValidatorTest, IsNotArtifactWhenLineContainsSpacesBeforeComment_TestCase_1)
{
    EXPECT_EQ(ArtifactValidator(" #/AAA/BBB/CCC/").isArtifact(), false);
}

TEST(ArtifactValidatorTest, IsNotArtifactWhenLineContainsSpacesBeforeComment_TestCase_2)
{
    EXPECT_EQ(ArtifactValidator("  #/DDD/EEE/").isArtifact(), false);
}

TEST(ArtifactValidatorTest, IsNotArtifactWhenLineContainsSpacesBeforeComment_TestCase_3)
{
    EXPECT_EQ(ArtifactValidator("   #/FFF/GGG/").isArtifact(), false);
}