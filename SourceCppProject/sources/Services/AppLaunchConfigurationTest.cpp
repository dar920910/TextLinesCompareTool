#include <gtest/gtest.h>

#include "AppLaunchConfiguration.hpp"


struct TestData
{
    const int args_count = 5;

    char exec_arg[4] = { 'a', 'p', 'p', '\0' };

    char src_1[10] = { 's', 'r', 'c', '_', '1', '.', 't', 'x', 't', '\0' };
    char src_2[10] = { 's', 'r', 'c', '_', '2', '.', 't', 'x', 't', '\0' };
    char src_3[10] = { 's', 'r', 'c', '_', '3', '.', 't', 'x', 't', '\0' };
    char src_4[10] = { 's', 'r', 'c', '_', '4', '.', 't', 'x', 't', '\0' };
} data;


TEST(AppLaunchConfigurationTest, ArgumentsDoNotContainSources)
{
    char* args[1] = { data.exec_arg };
    EXPECT_EQ(AppLaunchConfiguration(1, args).getArgumentsOfSources().size(), 0);
}

TEST(AppLaunchConfigurationTest, ArgumentsContainSources_TestCase_1)
{
    char* args[2] = { data.exec_arg, data.src_1, };
    EXPECT_EQ(AppLaunchConfiguration(2, args).getArgumentsOfSources().size(), 1);
}

TEST(AppLaunchConfigurationTest, ArgumentsContainSources_TestCase_2)
{
    char* args[3] = { data.exec_arg, data.src_1, data.src_2 };
    EXPECT_EQ(AppLaunchConfiguration(3, args).getArgumentsOfSources().size(), 2);
}

TEST(AppLaunchConfigurationTest, ArgumentsContainSources_TestCase_3)
{
    char* args[4] = { data.exec_arg, data.src_1, data.src_2, data.src_3 };
    EXPECT_EQ(AppLaunchConfiguration(4, args).getArgumentsOfSources().size(), 3);
}

TEST(AppLaunchConfigurationTest, ArgumentsContainSources_TestCase_4)
{
    char* args[5] = { data.exec_arg, data.src_1, data.src_2, data.src_3, data.src_4 };
    EXPECT_EQ(AppLaunchConfiguration(5, args).getArgumentsOfSources().size(), 4);
}