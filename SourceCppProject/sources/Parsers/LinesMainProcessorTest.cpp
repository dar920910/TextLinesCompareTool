#include <gtest/gtest.h>

#include "LinesMainProcessor.hpp"
#include "../Models/LineInfo.hpp"

#include <functional>
#include <string>

using test_set = std::set<std::string>;


TEST(LinesMainProcessorTest, ExtractCommonLinesFromMapBasedSources_TestCase_1)
{
    LinesStorageMap map_1 = LinesStorageMap();
    map_1.putContent(LineInfo("sss/ggg"));
    map_1.putContent(LineInfo("/test1/"));
    map_1.putContent(LineInfo("/test2/"));
    map_1.putContent(LineInfo("/rrr/ttt"));
    map_1.putContent(LineInfo("/aaa/eee/"));
    map_1.putContent(LineInfo("/test/"));

    LinesStorageMap map_2 = LinesStorageMap();
    map_2.putContent(LineInfo("/test2/"));
    map_2.putContent(LineInfo("vvvv/pppp"));
    map_2.putContent(LineInfo("/aaa/eee/"));
    map_2.putContent(LineInfo("sss/ggg"));
    map_2.putContent(LineInfo("/test/"));
    map_2.putContent(LineInfo("dddd/wwww"));
    map_2.putContent(LineInfo("/test1/"));

    LinesStorageMap expected_common_map = LinesStorageMap();
    expected_common_map.putContent(LineInfo("/aaa/eee/"));
    expected_common_map.putContent(LineInfo("/test/"));
    expected_common_map.putContent(LineInfo("/test1/"));
    expected_common_map.putContent(LineInfo("/test2/"));
    expected_common_map.putContent(LineInfo("sss/ggg"));

    LinesStorageMap actual_common_map {LinesMainProcessor::extractCommonContent(map_1, map_2)};
    
    EXPECT_EQ(actual_common_map.getContent(), expected_common_map.getContent());
}

TEST(LinesMainProcessorTest, ExtractCommonLinesFromMapBasedSources_TestCase_2)
{
    LinesStorageMap map_1 = LinesStorageMap();
    map_1.putContent(LineInfo("/test2/"));
    map_1.putContent(LineInfo("vvvv/pppp"));
    map_1.putContent(LineInfo("/aaa/eee/"));
    map_1.putContent(LineInfo("sss/ggg"));
    map_1.putContent(LineInfo("/test/"));
    map_1.putContent(LineInfo("dddd/wwww"));
    map_1.putContent(LineInfo("/test1/"));

    LinesStorageMap map_2 = LinesStorageMap();
    map_2.putContent(LineInfo("sss/ggg"));
    map_2.putContent(LineInfo("/test2/"));
    map_2.putContent(LineInfo("vvvv/pppp"));
    map_2.putContent(LineInfo("/test1/"));
    map_2.putContent(LineInfo("/test/"));

    LinesStorageMap expected_common_map = LinesStorageMap();
    expected_common_map.putContent(LineInfo("/test/"));
    expected_common_map.putContent(LineInfo("/test1/"));
    expected_common_map.putContent(LineInfo("/test2/"));
    expected_common_map.putContent(LineInfo("sss/ggg"));
    expected_common_map.putContent(LineInfo("vvvv/pppp"));

    LinesStorageMap actual_common_map {LinesMainProcessor::extractCommonContent(map_1, map_2)};
    
    EXPECT_EQ(actual_common_map.getContent(), expected_common_map.getContent());
}

TEST(LinesMainProcessorTest, ExtractCommonLinesFromMapBasedSources_TestCase_3)
{
    LinesStorageMap map_1 = LinesStorageMap();
    map_1.putContent(LineInfo("sss/ggg"));
    map_1.putContent(LineInfo("/test2/"));
    map_1.putContent(LineInfo("vvvv/pppp"));
    map_1.putContent(LineInfo("/test1/"));
    map_1.putContent(LineInfo("/test/"));

    LinesStorageMap map_2 = LinesStorageMap();
    map_2.putContent(LineInfo("/test/"));
    map_2.putContent(LineInfo("/test1/"));
    map_2.putContent(LineInfo("/test2/"));
    map_2.putContent(LineInfo("ddd/eee"));

    LinesStorageMap expected_common_map = LinesStorageMap();
    expected_common_map.putContent(LineInfo("/test/"));
    expected_common_map.putContent(LineInfo("/test1/"));
    expected_common_map.putContent(LineInfo("/test2/"));

    LinesStorageMap actual_common_map {LinesMainProcessor::extractCommonContent(map_1, map_2)};
    
    EXPECT_EQ(actual_common_map.getContent(), expected_common_map.getContent());
}


TEST(LinesMainProcessorTest, ExtractCommonLinesFromSetBasedSources_TestCase_1)
{
    LinesStorageSet source_1(test_set{ "sss/ggg", "/test1/", "/test2/", "/rrr/ttt", "/aaa/eee/", "/test/" });
    LinesStorageSet source_2(test_set{ "/test2/", "vvvv/pppp", "/aaa/eee/", "sss/ggg", "/test/", "dddd/wwww", "/test1/" });

    LinesStorageSet common_storage(LinesMainProcessor::extractCommonContent(source_1, source_2));
    
    EXPECT_EQ(common_storage.getContent(), test_set({"/aaa/eee/", "/test/", "/test1/", "/test2/", "sss/ggg"}));
}

TEST(LinesMainProcessorTest, ExtractCommonLinesFromSetBasedSources_TestCase_2)
{
    LinesStorageSet source_2(test_set{ "/test2/", "vvvv/pppp", "/aaa/eee/", "sss/ggg", "/test/", "dddd/wwww", "/test1/" });
    LinesStorageSet source_3(test_set{ "sss/ggg", "/test2/", "vvvv/pppp", "/test1/", "/test/" });

    LinesStorageSet common_storage(LinesMainProcessor::extractCommonContent(source_2, source_3));

    EXPECT_EQ(common_storage.getContent(), test_set({"/test/", "/test1/", "/test2/", "sss/ggg", "vvvv/pppp"}));
}

TEST(LinesMainProcessorTest, ExtractCommonLinesFromSetBasedSources_TestCase_3)
{
    LinesStorageSet source_3(test_set{ "sss/ggg", "/test2/", "vvvv/pppp", "/test1/", "/test/" });
    LinesStorageSet source_4(test_set{ "/test/", "/test1/", "/test2/", "ddd/eee" });

    LinesStorageSet common_storage(LinesMainProcessor::extractCommonContent(source_3, source_4));

    EXPECT_EQ(common_storage.getContent(), test_set({"/test/", "/test1/", "/test2/"}));
}


TEST(LinesMainProcessorTest, ExtractUniqueLinesFromSource_TestCase_1)
{
    LinesStorageSet compared_storage(test_set{ "/test/", "/test1/", "/test2/" });

    LinesStorageSet target_storage(test_set{ "sss/ggg", "/test1/", "/test2/", "/rrr/ttt", "/aaa/eee/", "/test/" });
    LinesStorageSet diff_storage(LinesMainProcessor::extractUniqueContent(target_storage, compared_storage));

    EXPECT_EQ(diff_storage.getContent(), test_set({ "/aaa/eee/", "/rrr/ttt", "sss/ggg" }));
}

TEST(LinesMainProcessorTest, ExtractUniqueLinesFromSource_TestCase_2)
{
    LinesStorageSet compared_storage(test_set{ "/test/", "/test1/", "/test2/" });

    LinesStorageSet target_storage(test_set{ "/test2/", "vvvv/pppp", "/aaa/eee/", "sss/ggg", "/test/", "dddd/wwww", "/test1/" });
    LinesStorageSet diff_storage(LinesMainProcessor::extractUniqueContent(target_storage, compared_storage));

    EXPECT_EQ(diff_storage.getContent(), test_set({ "/aaa/eee/", "dddd/wwww", "sss/ggg", "vvvv/pppp" }));
}

TEST(LinesMainProcessorTest, ExtractUniqueLinesFromSource_TestCase_3)
{
    LinesStorageSet compared_storage(test_set{ "/test/", "/test1/", "/test2/" });

    LinesStorageSet target_storage(test_set{ "sss/ggg", "/test2/", "vvvv/pppp", "/test1/", "/test/" });
    LinesStorageSet diff_storage(LinesMainProcessor::extractUniqueContent(target_storage, compared_storage));

    EXPECT_EQ(diff_storage.getContent(), test_set({ "sss/ggg", "vvvv/pppp" }));
}

TEST(LinesMainProcessorTest, ExtractUniqueLinesFromSource_TestCase_4)
{
    LinesStorageSet compared_storage(test_set{ "/test/", "/test1/", "/test2/" });

    LinesStorageSet target_storage(test_set{ "/test/", "/test1/", "/test2/", "ddd/eee" });
    LinesStorageSet diff_storage(LinesMainProcessor::extractUniqueContent(target_storage, compared_storage));

    EXPECT_EQ(diff_storage.getContent(), test_set({ "ddd/eee" }));
}