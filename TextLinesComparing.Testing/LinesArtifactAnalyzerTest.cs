//-----------------------------------------------------------------------
// <copyright file="LinesArtifactAnalyzerTest.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TextLinesComparing.Testing;

using TextLinesComparing.Library;

public class LinesArtifactAnalyzerTest
{
    [Test]
    public void ExtractCommonLinesFromMapBasedSources_TestCase_1()
    {
        LinesStorageMap map_1 = new ();
        map_1.PutContent(new LineInfo("sss/ggg"));
        map_1.PutContent(new LineInfo("/test1/"));
        map_1.PutContent(new LineInfo("/test2/"));
        map_1.PutContent(new LineInfo("/rrr/ttt"));
        map_1.PutContent(new LineInfo("/aaa/eee/"));
        map_1.PutContent(new LineInfo("/test/"));

        LinesStorageMap map_2 = new ();
        map_2.PutContent(new LineInfo("/test2/"));
        map_2.PutContent(new LineInfo("vvvv/pppp"));
        map_2.PutContent(new LineInfo("/aaa/eee/"));
        map_2.PutContent(new LineInfo("sss/ggg"));
        map_2.PutContent(new LineInfo("/test/"));
        map_2.PutContent(new LineInfo("dddd/wwww"));
        map_2.PutContent(new LineInfo("/test1/"));

        LinesStorageMap expected_common_map = new ();
        expected_common_map.PutContent(new LineInfo("/aaa/eee/"));
        expected_common_map.PutContent(new LineInfo("/test/"));
        expected_common_map.PutContent(new LineInfo("/test1/"));
        expected_common_map.PutContent(new LineInfo("/test2/"));
        expected_common_map.PutContent(new LineInfo("sss/ggg"));

        LinesStorageMap actual_common_map = LinesArtifactAnalyzer.ExtractCommonContent(map_1, map_2);

        Assert.That(actual_common_map.Content, Is.EqualTo(expected_common_map.Content));
    }

    [Test]
    public void ExtractCommonLinesFromMapBasedSources_TestCase_2()
    {
        LinesStorageMap map_1 = new ();
        map_1.PutContent(new LineInfo("/test2/"));
        map_1.PutContent(new LineInfo("vvvv/pppp"));
        map_1.PutContent(new LineInfo("/aaa/eee/"));
        map_1.PutContent(new LineInfo("sss/ggg"));
        map_1.PutContent(new LineInfo("/test/"));
        map_1.PutContent(new LineInfo("dddd/wwww"));
        map_1.PutContent(new LineInfo("/test1/"));

        LinesStorageMap map_2 = new ();
        map_2.PutContent(new LineInfo("sss/ggg"));
        map_2.PutContent(new LineInfo("/test2/"));
        map_2.PutContent(new LineInfo("vvvv/pppp"));
        map_2.PutContent(new LineInfo("/test1/"));
        map_2.PutContent(new LineInfo("/test/"));

        LinesStorageMap expected_common_map = new ();
        expected_common_map.PutContent(new LineInfo("/test/"));
        expected_common_map.PutContent(new LineInfo("/test1/"));
        expected_common_map.PutContent(new LineInfo("/test2/"));
        expected_common_map.PutContent(new LineInfo("sss/ggg"));
        expected_common_map.PutContent(new LineInfo("vvvv/pppp"));

        LinesStorageMap actual_common_map = LinesArtifactAnalyzer.ExtractCommonContent(map_1, map_2);

        Assert.That(actual_common_map.Content, Is.EqualTo(expected_common_map.Content));
    }

    [Test]
    public void ExtractCommonLinesFromMapBasedSources_TestCase_3()
    {
        LinesStorageMap map_1 = new ();
        map_1.PutContent(new LineInfo("sss/ggg"));
        map_1.PutContent(new LineInfo("/test2/"));
        map_1.PutContent(new LineInfo("vvvv/pppp"));
        map_1.PutContent(new LineInfo("/test1/"));
        map_1.PutContent(new LineInfo("/test/"));

        LinesStorageMap map_2 = new ();
        map_2.PutContent(new LineInfo("/test/"));
        map_2.PutContent(new LineInfo("/test1/"));
        map_2.PutContent(new LineInfo("/test2/"));
        map_2.PutContent(new LineInfo("ddd/eee"));

        LinesStorageMap expected_common_map = new ();
        expected_common_map.PutContent(new LineInfo("/test/"));
        expected_common_map.PutContent(new LineInfo("/test1/"));
        expected_common_map.PutContent(new LineInfo("/test2/"));

        LinesStorageMap actual_common_map = LinesArtifactAnalyzer.ExtractCommonContent(map_1, map_2);

        Assert.That(actual_common_map.Content, Is.EqualTo(expected_common_map.Content));
    }

    [Test]
    public void ExtractCommonLinesFromSetBasedSources_TestCase_1()
    {
        LinesStorageSet source_1 = new (new string[] { "sss/ggg", "/test1/", "/test2/", "/rrr/ttt", "/aaa/eee/", "/test/" });
        LinesStorageSet source_2 = new (new string[] { "/test2/", "vvvv/pppp", "/aaa/eee/", "sss/ggg", "/test/", "dddd/wwww", "/test1/" });

        LinesStorageSet common_storage = LinesArtifactAnalyzer.ExtractCommonContent(source_1, source_2);

        Assert.That(common_storage.Content, Is.EqualTo(new SortedSet<string>() { "/aaa/eee/", "/test/", "/test1/", "/test2/", "sss/ggg" }));
    }

    [Test]
    public void ExtractCommonLinesFromSetBasedSources_TestCase_2()
    {
        LinesStorageSet source_2 = new (new string[] { "/test2/", "vvvv/pppp", "/aaa/eee/", "sss/ggg", "/test/", "dddd/wwww", "/test1/" });
        LinesStorageSet source_3 = new (new string[] { "sss/ggg", "/test2/", "vvvv/pppp", "/test1/", "/test/" });

        LinesStorageSet common_storage = LinesArtifactAnalyzer.ExtractCommonContent(source_2, source_3);

        Assert.That(common_storage.Content, Is.EqualTo(new SortedSet<string>() { "/test/", "/test1/", "/test2/", "sss/ggg", "vvvv/pppp" }));
    }

    [Test]
    public void ExtractCommonLinesFromSetBasedSources_TestCase_3()
    {
        LinesStorageSet source_3 = new (new string[] { "sss/ggg", "/test2/", "vvvv/pppp", "/test1/", "/test/" });
        LinesStorageSet source_4 = new (new string[] { "/test/", "/test1/", "/test2/", "ddd/eee" });

        LinesStorageSet common_storage = LinesArtifactAnalyzer.ExtractCommonContent(source_3, source_4);

        Assert.That(common_storage.Content, Is.EqualTo(new SortedSet<string>() { "/test/", "/test1/", "/test2/" }));
    }

    [Test]
    public void ExtractUniqueLinesFromSource_TestCase_1()
    {
        LinesStorageSet compared_storage = new (new string[] { "/test/", "/test1/", "/test2/" });

        LinesStorageSet target_storage = new (new string[] { "sss/ggg", "/test1/", "/test2/", "/rrr/ttt", "/aaa/eee/", "/test/" });
        LinesStorageSet diff_storage = LinesArtifactAnalyzer.ExtractUniqueContent(target_storage, compared_storage);

        Assert.That(diff_storage.Content, Is.EqualTo(new SortedSet<string>() { "/aaa/eee/", "/rrr/ttt", "sss/ggg" }));
    }

    [Test]
    public void ExtractUniqueLinesFromSource_TestCase_2()
    {
        LinesStorageSet compared_storage = new (new string[] { "/test/", "/test1/", "/test2/" });

        LinesStorageSet target_storage = new (new string[] { "/test2/", "vvvv/pppp", "/aaa/eee/", "sss/ggg", "/test/", "dddd/wwww", "/test1/" });
        LinesStorageSet diff_storage = LinesArtifactAnalyzer.ExtractUniqueContent(target_storage, compared_storage);

        Assert.That(diff_storage.Content, Is.EqualTo(new SortedSet<string>() { "/aaa/eee/", "dddd/wwww", "sss/ggg", "vvvv/pppp" }));
    }

    [Test]
    public void ExtractUniqueLinesFromSource_TestCase_3()
    {
        LinesStorageSet compared_storage = new (new string[] { "/test/", "/test1/", "/test2/" });

        LinesStorageSet target_storage = new (new string[] { "sss/ggg", "/test2/", "vvvv/pppp", "/test1/", "/test/" });
        LinesStorageSet diff_storage = LinesArtifactAnalyzer.ExtractUniqueContent(target_storage, compared_storage);

        Assert.That(diff_storage.Content, Is.EqualTo(new SortedSet<string>() { "sss/ggg", "vvvv/pppp" }));
    }

    [Test]
    public void ExtractUniqueLinesFromSource_TestCase_4()
    {
        LinesStorageSet compared_storage = new (new string[] { "/test/", "/test1/", "/test2/" });

        LinesStorageSet target_storage = new (new string[] { "/test/", "/test1/", "/test2/", "ddd/eee" });
        LinesStorageSet diff_storage = LinesArtifactAnalyzer.ExtractUniqueContent(target_storage, compared_storage);

        Assert.That(diff_storage.Content, Is.EqualTo(new SortedSet<string>() { "ddd/eee" }));
    }

    [Test]
    public void RetrieveArtifactFromLineWithStartSpaces_TestCase_1()
    {
        Assert.That(LinesArtifactAnalyzer.RetrievePreprocessedArtifact("     /AAA/BBB/CCC/"), Is.EqualTo("/AAA/BBB/CCC/"));
    }

    [Test]
    public void RetrieveArtifactFromLineWithStartSpaces_TestCase_2()
    {
        Assert.That(LinesArtifactAnalyzer.RetrievePreprocessedArtifact("         /DDD/EEE/"), Is.EqualTo("/DDD/EEE/"));
    }

    [Test]
    public void RetrieveArtifactFromLineWithStartSpaces_TestCase_3()
    {
        Assert.That(LinesArtifactAnalyzer.RetrievePreprocessedArtifact("             /FFF/"), Is.EqualTo("/FFF/"));
    }

    [Test]
    public void RetrieveArtifactFromLineWithEndSpaces_TestCase_1()
    {
        Assert.That(LinesArtifactAnalyzer.RetrievePreprocessedArtifact("/AAA/BBB/CCC/     "), Is.EqualTo("/AAA/BBB/CCC/"));
    }

    [Test]
    public void RetrieveArtifactFromLineWithEndSpaces_TestCase_2()
    {
        Assert.That(LinesArtifactAnalyzer.RetrievePreprocessedArtifact("/DDD/EEE/         "), Is.EqualTo("/DDD/EEE/"));
    }

    [Test]
    public void RetrieveArtifactFromLineWithEndSpaces_TestCase_3()
    {
        Assert.That(LinesArtifactAnalyzer.RetrievePreprocessedArtifact("/FFF/             "), Is.EqualTo("/FFF/"));
    }

    [Test]
    public void RetrieveArtifactFromLineWrappedBySpaces_TestCase_1()
    {
        Assert.That(LinesArtifactAnalyzer.RetrievePreprocessedArtifact("  /AAA/BBB/CCC/   "), Is.EqualTo("/AAA/BBB/CCC/"));
    }

    [Test]
    public void RetrieveArtifactFromLineWrappedBySpaces_TestCase_2()
    {
        Assert.That(LinesArtifactAnalyzer.RetrievePreprocessedArtifact("    /DDD/EEE/     "), Is.EqualTo("/DDD/EEE/"));
    }

    [Test]
    public void RetrieveArtifactFromLineWrappedBySpaces_TestCase_3()
    {
        Assert.That(LinesArtifactAnalyzer.RetrievePreprocessedArtifact("      /FFF/       "), Is.EqualTo("/FFF/"));
    }

    [Test]
    public void RetrieveArtifactFromLineWithComment_TestCase_1()
    {
        Assert.That(LinesArtifactAnalyzer.RetrievePreprocessedArtifact("/aa/bb/cc# Unix style"), Is.EqualTo("/aa/bb/cc"));
    }

    [Test]
    public void RetrieveArtifactFromLineWithComment_TestCase_2()
    {
        Assert.That(LinesArtifactAnalyzer.RetrievePreprocessedArtifact("\\aa\\bb\\cc# Windows style"), Is.EqualTo("\\aa\\bb\\cc"));
    }

    [Test]
    public void RetrieveArtifactFromLineWithSpacesAndComment_TestCase_1()
    {
        Assert.That(LinesArtifactAnalyzer.RetrievePreprocessedArtifact("    /aa/bb/cc    # Unix style     "), Is.EqualTo("/aa/bb/cc"));
    }

    [Test]
    public void RetrieveArtifactFromLineWithSpacesAndComment_TestCase_2()
    {
        Assert.That(LinesArtifactAnalyzer.RetrievePreprocessedArtifact("  \\aa\\bb\\cc   # Windows style  "), Is.EqualTo("\\aa\\bb\\cc"));
    }

    [Test]
    public void RetrieveArtifactFromLineWithCommentInsideText_TestCase_1()
    {
        Assert.That(LinesArtifactAnalyzer.RetrievePreprocessedArtifact("/aa/bb/ # Unix style like /cc/dd/"), Is.EqualTo("/aa/bb/"));
    }

    [Test]
    public void RetrieveArtifactFromLineWithCommentInsideText_TestCase_2()
    {
        Assert.That(LinesArtifactAnalyzer.RetrievePreprocessedArtifact("\\aa\\bb\\ # Windows style like \\cc\\dd\\"), Is.EqualTo("\\aa\\bb\\"));
    }

    [Test]
    public void RetrieveArtifact_SmokeTestCase_1()
    {
        const string test_string = "     ./a/b/c/example.txt   #todo: replace the file to ./a/b  ";
        string actual_result = LinesArtifactAnalyzer.RetrievePreprocessedArtifact(test_string);

        Assert.That(actual_result, Is.EqualTo("./a/b/c/example.txt"));
    }

    [Test]
    public void RetrieveArtifact_SmokeTestCase_2()
    {
        const string test_string = "  EXAMPLE:/* comment_1 */     test_path:     /* comment_2 */./a/b/c/example.txt   #  todo   ";
        string actual_result = LinesArtifactAnalyzer.RetrievePreprocessedArtifact(test_string);

        Assert.That(actual_result, Is.EqualTo("EXAMPLE: test_path: ./a/b/c/example.txt"));
    }

    [Test]
    public void RetrieveArtifact_SmokeTestCase_3()
    {
        const string test_string = "/* Types of paths: */    dir1\\dir2\\dir3    /* it's a path for Windows */    dir1/dir2/dir3      /* it's a path for Unix */    \n";
        string actual_result = LinesArtifactAnalyzer.RetrievePreprocessedArtifact(test_string);

        Assert.That(actual_result, Is.EqualTo("dir1\\dir2\\dir3 dir1/dir2/dir3"));
    }

    [Test]
    public void RetrieveArtifact_SmokeTestCase_4()
    {
        const string test_string = "    /* Comment: '#' is Unix-style comment */ dir1/dir2/dir3 /* for Unix */ # dir1\\dir2\\dir3 (for Windows)\n";
        string actual_result = LinesArtifactAnalyzer.RetrievePreprocessedArtifact(test_string);

        Assert.That(actual_result, Is.EqualTo("dir1/dir2/dir3"));
    }

    [Test]
    public void DeleteSingleStringComment_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(
            actual: LinesArtifactAnalyzer.TrimSingleStringComment(
                artifactString: "This is a test artifact # with a comment"),
            expression: Is.EqualTo("This is a test artifact "));

            Assert.That(
                actual: LinesArtifactAnalyzer.TrimSingleStringComment(
                    artifactString: "012345#6789"),
                expression: Is.EqualTo("012345"));

            Assert.That(
                actual: LinesArtifactAnalyzer.TrimSingleStringComment(
                    artifactString: "# This is a comment string!"),
                expression: Is.EqualTo(string.Empty));
        });
    }

    [Test]
    public void DeleteAllCommentsFromString_TestCase_0()
    {
        const string artifact = "$/* comment */$";

        string actual_artifact = LinesArtifactAnalyzer.TrimWrappedCommentsInsideString(artifact);
        string expected_artifact = "$$";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void DeleteAllCommentsFromString_TestCase_1()
    {
        const string artifact = "0 1 /* 1 */ 2 /* 2 */ 3 4 5 6 7 /* 7 */ 8 /* 8 */ 9";

        string actual_artifact = LinesArtifactAnalyzer.TrimWrappedCommentsInsideString(artifact);
        string expected_artifact = "0 1  2  3 4 5 6 7  8  9";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void DeleteAllCommentsFromString_TestCase_2()
    {
        const string artifact = "0 1 /*step1*/ 2 /*step2*/ 3 /*step3*/ 4 5";

        string actual_artifact = LinesArtifactAnalyzer.TrimWrappedCommentsInsideString(artifact);
        string expected_artifact = "0 1  2  3  4 5";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void DeleteAllCommentsFromString_TestCase_3()
    {
        const string artifact = "/* comment */   0 1 2 3 4 5";

        string actual_artifact = LinesArtifactAnalyzer.TrimWrappedCommentsInsideString(artifact);
        string expected_artifact = "   0 1 2 3 4 5";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void DeleteAllCommentsFromString_TestCase_4()
    {
        const string artifact = "0 1 2 3 4 5   /* comment */\n";

        string actual_artifact = LinesArtifactAnalyzer.TrimWrappedCommentsInsideString(artifact);
        string expected_artifact = "0 1 2 3 4 5   \n";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void DeleteAllCommentsFromString_TestCase_5()
    {
        const string artifact = "/* comment */0 1 2 /*   comment   */ 3 4 5/* comment */\n";

        string actual_artifact = LinesArtifactAnalyzer.TrimWrappedCommentsInsideString(artifact);
        string expected_artifact = "0 1 2  3 4 5\n";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void PostProcessingForSpaces_TestCase_1()
    {
        string artifact = "A  B   C    D     E          F";

        string actual_artifact = LinesArtifactAnalyzer.TrimRedundantWhitespaces(artifact);
        const string expected_artifact = "A B C D E F";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void PostProcessingForSpaces_TestCase_2()
    {
        string artifact = "G     H     I     J     K     L";

        string actual_artifact = LinesArtifactAnalyzer.TrimRedundantWhitespaces(artifact);
        const string expected_artifact = "G H I J K L";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void PostProcessingForSpaces_TestCase_3()
    {
        string artifact = "0   1 2    3     4 5     6    7 8   9";

        string actual_artifact = LinesArtifactAnalyzer.TrimRedundantWhitespaces(artifact);
        const string expected_artifact = "0 1 2 3 4 5 6 7 8 9";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void PostProcessingForSpaces_TestCase_4()
    {
        string artifact = "0 1 2  3      4  5     6  7 8 9";

        string actual_artifact = LinesArtifactAnalyzer.TrimRedundantWhitespaces(artifact);
        const string expected_artifact = "0 1 2 3 4 5 6 7 8 9";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void PostProcessingForSpaces_TestCase_5()
    {
        string artifact = "/  home /  user   / projects /   SendCodeLinesExplorer  /";

        string actual_artifact = LinesArtifactAnalyzer.TrimRedundantWhitespaces(artifact);
        const string expected_artifact = "/ home / user / projects / SendCodeLinesExplorer /";

        Assert.That(actual_artifact, Is.EqualTo(expected_artifact));
    }

    [Test]
    public void TrimStartWhitespaces_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(
            actual: LinesArtifactAnalyzer.TrimStartWhitespaces("     0123456789"),
            expression: Is.EqualTo("0123456789"));

            Assert.That(
                actual: LinesArtifactAnalyzer.TrimStartWhitespaces("     0123456789     "),
                expression: Is.EqualTo("0123456789     "));

            Assert.That(
                actual: LinesArtifactAnalyzer.TrimStartWhitespaces("   qwerty   0123456789   qwerty   "),
                expression: Is.EqualTo("qwerty   0123456789   qwerty   "));
        });
    }

    [Test]
    public void TrimEndWhitespaces_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(
            actual: LinesArtifactAnalyzer.TrimEndWhitespaces("0123456789     "),
            expression: Is.EqualTo("0123456789"));

            Assert.That(
                actual: LinesArtifactAnalyzer.TrimEndWhitespaces("     0123456789     "),
                expression: Is.EqualTo("     0123456789"));

            Assert.That(
                actual: LinesArtifactAnalyzer.TrimEndWhitespaces("   qwerty   0123456789   qwerty   "),
                expression: Is.EqualTo("   qwerty   0123456789   qwerty"));
        });
    }

    [Test]
    public void IsCommentCharacter()
    {
        const char comment_character = '#';
        const char test_character = comment_character;

        Assert.That(LinesArtifactAnalyzer.IsNotCommentCharacter(test_character), Is.EqualTo(test_character != comment_character));
    }

    [Test]
    public void IsNotCommentCharacter_TestCase()
    {
        char comment_character = '#';
        char test_character = default;
        Assert.That(LinesArtifactAnalyzer.IsNotCommentCharacter(test_character), Is.EqualTo(test_character != comment_character));

        comment_character = '#';
        test_character = 'Z';
        Assert.That(LinesArtifactAnalyzer.IsNotCommentCharacter(test_character), Is.EqualTo(test_character != comment_character));

        comment_character = '#';
        test_character = 'b';
        Assert.That(LinesArtifactAnalyzer.IsNotCommentCharacter(test_character), Is.EqualTo(test_character != comment_character));

        comment_character = '#';
        test_character = 'y';
        Assert.That(LinesArtifactAnalyzer.IsNotCommentCharacter(test_character), Is.EqualTo(test_character != comment_character));

        comment_character = '#';
        test_character = '1';
        Assert.That(LinesArtifactAnalyzer.IsNotCommentCharacter(test_character), Is.EqualTo(test_character != comment_character));

        comment_character = '#';
        test_character = '9';
        Assert.That(LinesArtifactAnalyzer.IsNotCommentCharacter(test_character), Is.EqualTo(test_character != comment_character));

        comment_character = '#';
        test_character = '@';
        Assert.That(LinesArtifactAnalyzer.IsNotCommentCharacter(test_character), Is.EqualTo(test_character != comment_character));

        comment_character = '#';
        test_character = '&';
        Assert.That(LinesArtifactAnalyzer.IsNotCommentCharacter(test_character), Is.EqualTo(test_character != comment_character));
    }

    [Test]
    public void IsSpaceCharacter_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(LinesArtifactAnalyzer.IsSpaceCharacter(' '), Is.True); // ASCII: 0x20
            Assert.That(LinesArtifactAnalyzer.IsSpaceCharacter('\f'), Is.True); // ASCII: 0x0C
            Assert.That(LinesArtifactAnalyzer.IsSpaceCharacter('\n'), Is.True); // ASCII: 0x0A
            Assert.That(LinesArtifactAnalyzer.IsSpaceCharacter('\r'), Is.True); // ASCII: 0x0D
            Assert.That(LinesArtifactAnalyzer.IsSpaceCharacter('\t'), Is.True); // ASCII: 0x09
            Assert.That(LinesArtifactAnalyzer.IsSpaceCharacter('\v'), Is.True); // ASCII: 0x0B
            Assert.That(LinesArtifactAnalyzer.IsSpaceCharacter('A'), Is.False);
            Assert.That(LinesArtifactAnalyzer.IsSpaceCharacter('Z'), Is.False);
            Assert.That(LinesArtifactAnalyzer.IsSpaceCharacter('b'), Is.False);
            Assert.That(LinesArtifactAnalyzer.IsSpaceCharacter('y'), Is.False);
            Assert.That(LinesArtifactAnalyzer.IsSpaceCharacter('0'), Is.False);
            Assert.That(LinesArtifactAnalyzer.IsSpaceCharacter('9'), Is.False);
            Assert.That(LinesArtifactAnalyzer.IsSpaceCharacter('#'), Is.False);
            Assert.That(LinesArtifactAnalyzer.IsSpaceCharacter('/'), Is.False);
            Assert.That(LinesArtifactAnalyzer.IsSpaceCharacter('\\'), Is.False);
        });
    }

    [Test]
    public void IsArtifact_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(LinesArtifactAnalyzer.IsArtifact("/a/b/c/d/"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("   b/c   "), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("/a/ # /d/"), Is.True);
        });
    }

    [Test]
    public void IsNotArtifact_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(LinesArtifactAnalyzer.IsArtifact(string.Empty), Is.False);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("         "), Is.False);
        });
    }

    [Test]
    public void IsArtifactWhenLineContainsOnlyLetters_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(LinesArtifactAnalyzer.IsArtifact("ABCDEFGHIJKLMNOPQRSTUVWXYZ"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("abcdefghijklmnopqrstuvwxyz"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("ABCDEFGHIJKLMnopqrstuvwxyz"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("abcdefghijklmNOPQRSTUVWXYZ"), Is.True);
        });
    }

    [Test]
    public void IsArtifactWhenLineContainsOnlyDigits_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(LinesArtifactAnalyzer.IsArtifact("0123456789"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("9876543210"), Is.True);
        });
    }

    [Test]
    public void IsArtifactWhenLineContainsOnlyPunctuationSigns_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(LinesArtifactAnalyzer.IsArtifact("....."), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact(",,,,,,"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("!!!!!"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("?????"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact(":::::"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact(";;;;;"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("((((("), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact(")))))"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("-----"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("'''''"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("\"\"\"\"\""), Is.True);
        });
    }

    [Test]
    public void IsArtifactWhenLineContainsOnlyArithmeticSigns_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(LinesArtifactAnalyzer.IsArtifact("+++++"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("-----"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("*****"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("/////"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("======"), Is.True);
        });
    }

    [Test]
    public void IsArtifactWhenLineContainsOnlySpecialSymbols_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(LinesArtifactAnalyzer.IsArtifact("~~~~~"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("`````"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("@@@@@"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("$$$$$"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("%%%%%"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("&&&&&"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("_____"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("^^^^^"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("<<<<<"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact(">>>>>"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("[[[[["), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("]]]]]"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("|||||"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("\\\\\\\\\\"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("{{{{{"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("}}}}}"), Is.True);
        });
    }

    [Test]
    public void IsArtifactWhenLineContainsOnlyPathLikeUnixStyle_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(LinesArtifactAnalyzer.IsArtifact("/AAA/"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("/BBB/CCC/"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("/CCC/DDD/EEE/"), Is.True);
        });
    }

    [Test]
    public void IsArtifactWhenLineContainsOnlyPathLikeWindowsStyle_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(LinesArtifactAnalyzer.IsArtifact("\\AAA\\"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("\\BBB\\CCC\\"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("\\CCC\\DDD\\EEE\\"), Is.True);
        });
    }

    [Test]
    public void IsArtifactWhenLineContainsSpacesBeforeText_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(LinesArtifactAnalyzer.IsArtifact("          \\AAA\\BBB\\CCC\\"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("     /ddd/eee/fff/"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact(" /g\\h/i\\j"), Is.True);
        });
    }

    [Test]
    public void IsArtifactWhenLineContainsCommentsAfterText_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(LinesArtifactAnalyzer.IsArtifact("\\AAA\\BBB\\CCC\\ # Windows style"), Is.True);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("/ddd/eee/fff/     # Unix style   "), Is.True);
        });
    }

    [Test]
    public void IsNotArtifactWhenLineContainsOnlyComments_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(LinesArtifactAnalyzer.IsArtifact("##########"), Is.False);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("#####"), Is.False);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("#"), Is.False);
        });
    }

    [Test]
    public void IsNotArtifactWhenLineContainsCommentsBeforeText_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(LinesArtifactAnalyzer.IsArtifact("#/AAA/BBB/CCC/"), Is.False);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("#    /DDD/EEE/"), Is.False);
        });
    }

    [Test]
    public void IsNotArtifactWhenLineContainsSpacesBeforeComment_TestCase()
    {
        Assert.Multiple(() =>
        {
            Assert.That(LinesArtifactAnalyzer.IsArtifact(" #/AAA/BBB/CCC/"), Is.False);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("  #/DDD/EEE/"), Is.False);
            Assert.That(LinesArtifactAnalyzer.IsArtifact("   #/FFF/GGG/"), Is.False);
        });
    }
}
