#include <gtest/gtest.h>

#include "AppDatetimeService.hpp"

TEST(AppDatetimeServiceTest, GetYearFromDatetime_TestCase_1)
{
    struct tm datetime {};
    datetime.tm_year = 100;

    const int actual_year {DatetimeUtilities::getCurrentYear(&datetime)};
    const int expected_year {2000};

    EXPECT_EQ(actual_year, expected_year);
}

TEST(AppDatetimeServiceTest, GetYearFromDatetime_TestCase_2)
{
    struct tm datetime {};
    datetime.tm_year = 110;

    const int actual_year {DatetimeUtilities::getCurrentYear(&datetime)};
    const int expected_year {2010};

    EXPECT_EQ(actual_year, expected_year);
}

TEST(AppDatetimeServiceTest, GetYearFromDatetime_TestCase_3)
{
    struct tm datetime {};
    datetime.tm_year = 122;

    const int actual_year {DatetimeUtilities::getCurrentYear(&datetime)};
    const int expected_year {2022};

    EXPECT_EQ(actual_year, expected_year);
}


TEST(AppDatetimeServiceTest, GetMonthFromDatetimeWhenJanuary)
{
    struct tm datetime {};
    datetime.tm_mon = 0; // January

    const int actual_month {DatetimeUtilities::getCurrentMonth(&datetime)};
    const int expected_month {1};

    EXPECT_EQ(actual_month, expected_month);
}

TEST(AppDatetimeServiceTest, GetMonthFromDatetimeWhenFebruary)
{
    struct tm datetime {};
    datetime.tm_mon = 1; // February

    const int actual_month {DatetimeUtilities::getCurrentMonth(&datetime)};
    const int expected_month {2};

    EXPECT_EQ(actual_month, expected_month);
}

TEST(AppDatetimeServiceTest, GetMonthFromDatetimeWhenMarch)
{
    struct tm datetime {};
    datetime.tm_mon = 2; // March

    const int actual_month {DatetimeUtilities::getCurrentMonth(&datetime)};
    const int expected_month {3};

    EXPECT_EQ(actual_month, expected_month);
}

TEST(AppDatetimeServiceTest, GetMonthFromDatetimeWhenApril)
{
    struct tm datetime {};
    datetime.tm_mon = 3; // April

    const int actual_month {DatetimeUtilities::getCurrentMonth(&datetime)};
    const int expected_month {4};

    EXPECT_EQ(actual_month, expected_month);
}

TEST(AppDatetimeServiceTest, GetMonthFromDatetimeWhenMay)
{
    struct tm datetime {};
    datetime.tm_mon = 4; // May

    const int actual_month {DatetimeUtilities::getCurrentMonth(&datetime)};
    const int expected_month {5};

    EXPECT_EQ(actual_month, expected_month);
}

TEST(AppDatetimeServiceTest, GetMonthFromDatetimeWhenJune)
{
    struct tm datetime {};
    datetime.tm_mon = 5; // June

    const int actual_month {DatetimeUtilities::getCurrentMonth(&datetime)};
    const int expected_month {6};

    EXPECT_EQ(actual_month, expected_month);
}

TEST(AppDatetimeServiceTest, GetMonthFromDatetimeWhenJuly)
{
    struct tm datetime {};
    datetime.tm_mon = 6; // July

    const int actual_month {DatetimeUtilities::getCurrentMonth(&datetime)};
    const int expected_month {7};

    EXPECT_EQ(actual_month, expected_month);
}

TEST(AppDatetimeServiceTest, GetMonthFromDatetimeWhenAugust)
{
    struct tm datetime {};
    datetime.tm_mon = 7; // August

    const int actual_month {DatetimeUtilities::getCurrentMonth(&datetime)};
    const int expected_month {8};

    EXPECT_EQ(actual_month, expected_month);
}

TEST(AppDatetimeServiceTest, GetMonthFromDatetimeWhenSeptember)
{
    struct tm datetime {};
    datetime.tm_mon = 8; // September

    const int actual_month {DatetimeUtilities::getCurrentMonth(&datetime)};
    const int expected_month {9};

    EXPECT_EQ(actual_month, expected_month);
}

TEST(AppDatetimeServiceTest, GetMonthFromDatetimeWhenOctober)
{
    struct tm datetime {};
    datetime.tm_mon = 9; // October

    const int actual_month {DatetimeUtilities::getCurrentMonth(&datetime)};
    const int expected_month {10};

    EXPECT_EQ(actual_month, expected_month);
}

TEST(AppDatetimeServiceTest, GetMonthFromDatetimeWhenNovember)
{
    struct tm datetime {};
    datetime.tm_mon = 10; // November

    const int actual_month {DatetimeUtilities::getCurrentMonth(&datetime)};
    const int expected_month {11};

    EXPECT_EQ(actual_month, expected_month);
}

TEST(AppDatetimeServiceTest, GetMonthFromDatetimeWhenDecember)
{
    struct tm datetime {};
    datetime.tm_mon = 11; // December

    const int actual_month {DatetimeUtilities::getCurrentMonth(&datetime)};
    const int expected_month {12};

    EXPECT_EQ(actual_month, expected_month);
}


TEST(AppDatetimeServiceTest, GetDayFromDatetime_TestCase_1)
{
    struct tm datetime {};
    datetime.tm_mday = 1;

    const int actual_day {DatetimeUtilities::getCurrentDay(&datetime)};
    const int expected_day {1};

    EXPECT_EQ(actual_day, expected_day);
}

TEST(AppDatetimeServiceTest, GetDayFromDatetime_TestCase_2)
{
    struct tm datetime {};
    datetime.tm_mday = 15;

    const int actual_day {DatetimeUtilities::getCurrentDay(&datetime)};
    const int expected_day {15};

    EXPECT_EQ(actual_day, expected_day);
}

TEST(AppDatetimeServiceTest, GetDayFromDatetime_TestCase_3)
{
    struct tm datetime {};
    datetime.tm_mday = 31;

    const int actual_day {DatetimeUtilities::getCurrentDay(&datetime)};
    const int expected_day {31};

    EXPECT_EQ(actual_day, expected_day);
}


TEST(AppDatetimeServiceTest, GetHourFromDatetime_TestCase_1)
{
    struct tm datetime {};
    datetime.tm_hour = 0;

    const int actual_hour {DatetimeUtilities::getCurrentHour(&datetime)};
    const int expected_hour {0};

    EXPECT_EQ(actual_hour, expected_hour);
}

TEST(AppDatetimeServiceTest, GetHourFromDatetime_TestCase_2)
{
    struct tm datetime {};
    datetime.tm_hour = 12;

    const int actual_hour {DatetimeUtilities::getCurrentHour(&datetime)};
    const int expected_hour {12};

    EXPECT_EQ(actual_hour, expected_hour);
}

TEST(AppDatetimeServiceTest, GetHourFromDatetime_TestCase_3)
{
    struct tm datetime {};
    datetime.tm_hour = 23;

    const int actual_hour {DatetimeUtilities::getCurrentHour(&datetime)};
    const int expected_hour {23};

    EXPECT_EQ(actual_hour, expected_hour);
}


TEST(AppDatetimeServiceTest, GetMinuteFromDatetime_TestCase_1)
{
    struct tm datetime {};
    datetime.tm_min = 0;

    const int actual_minute {DatetimeUtilities::getCurrentMinute(&datetime)};
    const int expected_minute {0};

    EXPECT_EQ(actual_minute, expected_minute);
}

TEST(AppDatetimeServiceTest, GetMinuteFromDatetime_TestCase_2)
{
    struct tm datetime {};
    datetime.tm_min = 30;

    const int actual_minute {DatetimeUtilities::getCurrentMinute(&datetime)};
    const int expected_minute {30};

    EXPECT_EQ(actual_minute, expected_minute);
}

TEST(AppDatetimeServiceTest, GetMinuteFromDatetime_TestCase_3)
{
    struct tm datetime {};
    datetime.tm_min = 59;

    const int actual_minute {DatetimeUtilities::getCurrentMinute(&datetime)};
    const int expected_minute {59};

    EXPECT_EQ(actual_minute, expected_minute);
}


TEST(AppDatetimeServiceTest, GetSecondFromDatetime_TestCase_1)
{
    struct tm datetime {};
    datetime.tm_sec = 0;

    const int actual_second {DatetimeUtilities::getCurrentSecond(&datetime)};
    const int expected_second {0};

    EXPECT_EQ(actual_second, expected_second);
}

TEST(AppDatetimeServiceTest, GetSecondFromDatetime_TestCase_2)
{
    struct tm datetime {};
    datetime.tm_sec = 30;

    const int actual_second {DatetimeUtilities::getCurrentSecond(&datetime)};
    const int expected_second {30};

    EXPECT_EQ(actual_second, expected_second);
}

TEST(AppDatetimeServiceTest, GetSecondFromDatetime_TestCase_3)
{
    struct tm datetime {};
    datetime.tm_sec = 60;

    const int actual_second {DatetimeUtilities::getCurrentSecond(&datetime)};
    const int expected_second {60};

    EXPECT_EQ(actual_second, expected_second);
}


TEST(AppDatetimeServiceTest, GetDateAsText_TestCase_1)
{
    const int year {2021};
    const int month {12};
    const int day {31};

    const std::string actual_date {DatetimeUtilities::getCurrentDateText(year, month, day)};
    const std::string expected_date {"2021-12-31"};

    EXPECT_EQ(actual_date, expected_date);
}

TEST(AppDatetimeServiceTest, GetDateAsText_TestCase_2)
{
    const int year {2022};
    const int month {1};
    const int day {1};

    const std::string actual_date {DatetimeUtilities::getCurrentDateText(year, month, day)};
    const std::string expected_date {"2022-01-01"};

    EXPECT_EQ(actual_date, expected_date);
}


TEST(AppDatetimeServiceTest, GetTimeAsText_TestCase_1)
{
    const int hour {23};
    const int minute {59};
    const int second {59};

    const std::string actual_date {DatetimeUtilities::getCurrentTimeText(hour, minute, second)};
    const std::string expected_date {"23-59-59"};

    EXPECT_EQ(actual_date, expected_date);
}

TEST(AppDatetimeServiceTest, GetTimeAsText_TestCase_2)
{
    const int hour {6};
    const int minute {0};
    const int second {0};

    const std::string actual_date {DatetimeUtilities::getCurrentTimeText(hour, minute, second)};
    const std::string expected_date {"06-00-00"};

    EXPECT_EQ(actual_date, expected_date);
}


TEST(AppDatetimeServiceTest, GetDatetimeUnitWithZero_TestCase_0)
{
    const int datetime_value {0};

    const std::string actual_text {DatetimeUtilities::getDatetimeUnitText(datetime_value)};
    const std::string expected_text {"00"};

    EXPECT_EQ(actual_text, expected_text);
}

TEST(AppDatetimeServiceTest, GetDatetimeUnitWithZero_TestCase_1)
{
    const int datetime_value {1};

    const std::string actual_text {DatetimeUtilities::getDatetimeUnitText(datetime_value)};
    const std::string expected_text {"01"};

    EXPECT_EQ(actual_text, expected_text);
}

TEST(AppDatetimeServiceTest, GetDatetimeUnitWithZero_TestCase_2)
{
    const int datetime_value {2};

    const std::string actual_text {DatetimeUtilities::getDatetimeUnitText(datetime_value)};
    const std::string expected_text {"02"};

    EXPECT_EQ(actual_text, expected_text);
}

TEST(AppDatetimeServiceTest, GetDatetimeUnitWithZero_TestCase_3)
{
    const int datetime_value {3};

    const std::string actual_text {DatetimeUtilities::getDatetimeUnitText(datetime_value)};
    const std::string expected_text {"03"};

    EXPECT_EQ(actual_text, expected_text);
}

TEST(AppDatetimeServiceTest, GetDatetimeUnitWithZero_TestCase_4)
{
    const int datetime_value {4};

    const std::string actual_text {DatetimeUtilities::getDatetimeUnitText(datetime_value)};
    const std::string expected_text {"04"};

    EXPECT_EQ(actual_text, expected_text);
}

TEST(AppDatetimeServiceTest, GetDatetimeUnitWithZero_TestCase_5)
{
    const int datetime_value {5};

    const std::string actual_text {DatetimeUtilities::getDatetimeUnitText(datetime_value)};
    const std::string expected_text {"05"};

    EXPECT_EQ(actual_text, expected_text);
}

TEST(AppDatetimeServiceTest, GetDatetimeUnitWithZero_TestCase_6)
{
    const int datetime_value {6};

    const std::string actual_text {DatetimeUtilities::getDatetimeUnitText(datetime_value)};
    const std::string expected_text {"06"};

    EXPECT_EQ(actual_text, expected_text);
}

TEST(AppDatetimeServiceTest, GetDatetimeUnitWithZero_TestCase_7)
{
    const int datetime_value {7};

    const std::string actual_text {DatetimeUtilities::getDatetimeUnitText(datetime_value)};
    const std::string expected_text {"07"};

    EXPECT_EQ(actual_text, expected_text);
}

TEST(AppDatetimeServiceTest, GetDatetimeUnitWithZero_TestCase_8)
{
    const int datetime_value {8};

    const std::string actual_text {DatetimeUtilities::getDatetimeUnitText(datetime_value)};
    const std::string expected_text {"08"};

    EXPECT_EQ(actual_text, expected_text);
}

TEST(AppDatetimeServiceTest, GetDatetimeUnitWithZero_TestCase_9)
{
    const int datetime_value {9};

    const std::string actual_text {DatetimeUtilities::getDatetimeUnitText(datetime_value)};
    const std::string expected_text {"09"};

    EXPECT_EQ(actual_text, expected_text);
}

TEST(AppDatetimeServiceTest, GetDatetimeUnitWithoutZero_TestCase_1)
{
    const int datetime_value {15};

    const std::string actual_text {DatetimeUtilities::getDatetimeUnitText(datetime_value)};
    const std::string expected_text {"15"};

    EXPECT_EQ(actual_text, expected_text);
}

TEST(AppDatetimeServiceTest, GetDatetimeUnitWithoutZero_TestCase_2)
{
    const int datetime_value {25};

    const std::string actual_text {DatetimeUtilities::getDatetimeUnitText(datetime_value)};
    const std::string expected_text {"25"};

    EXPECT_EQ(actual_text, expected_text);
}

TEST(AppDatetimeServiceTest, GetDatetimeUnitWithoutZero_TestCase_3)
{
    const int datetime_value {35};

    const std::string actual_text {DatetimeUtilities::getDatetimeUnitText(datetime_value)};
    const std::string expected_text {"35"};

    EXPECT_EQ(actual_text, expected_text);
}

TEST(AppDatetimeServiceTest, GetDatetimeUnitWithoutZero_TestCase_4)
{
    const int datetime_value {45};

    const std::string actual_text {DatetimeUtilities::getDatetimeUnitText(datetime_value)};
    const std::string expected_text {"45"};

    EXPECT_EQ(actual_text, expected_text);
}

TEST(AppDatetimeServiceTest, GetDatetimeUnitWithoutZero_TestCase_5)
{
    const int datetime_value {55};

    const std::string actual_text {DatetimeUtilities::getDatetimeUnitText(datetime_value)};
    const std::string expected_text {"55"};

    EXPECT_EQ(actual_text, expected_text);
}

TEST(AppDatetimeServiceTest, ConcatenateDateAndTime_TestCase_1)
{
    const std::string date_text {"2021-12-31"};
    const std::string time_text {"23-55-55"};

    const std::string actual_datetime {DatetimeUtilities::concatenateDateAndTime(date_text, time_text)};
    const std::string expected_datetime {"2021-12-31_23-55-55"};

    EXPECT_EQ(actual_datetime, expected_datetime);
}

TEST(AppDatetimeServiceTest, ConcatenateDateAndTime_TestCase_2)
{
    const std::string date_text {"2022-01-01"};
    const std::string time_text {"09-00-00"};

    const std::string actual_datetime {DatetimeUtilities::concatenateDateAndTime(date_text, time_text)};
    const std::string expected_datetime {"2022-01-01_09-00-00"};

    EXPECT_EQ(actual_datetime, expected_datetime);
}