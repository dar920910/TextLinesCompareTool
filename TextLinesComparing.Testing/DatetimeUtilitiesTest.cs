//-----------------------------------------------------------------------
// <copyright file="DatetimeUtilitiesTest.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TextLinesComparing.Testing;

using TextLinesComparing.Library;

/// <summary>
/// Contains unit tests for the DatetimeUtilities class.
/// </summary>
public class DatetimeUtilitiesTest
{
    [Test]
    public void GetYearFromDatetime_TestCase_1()
    {
        DateTime datetime = new (year: 2000, month: 1, day: 1);
        int actual_year = DatetimeUtilities.GetCurrentYear(datetime);

        Assert.That(actual_year, Is.EqualTo(2000));
    }

    [Test]
    public void GetYearFromDatetime_TestCase_2()
    {
        DateTime datetime = new (year: 2010, month: 1, day: 1);
        int actual_year = DatetimeUtilities.GetCurrentYear(datetime);

        Assert.That(actual_year, Is.EqualTo(2010));
    }

    [Test]
    public void GetYearFromDatetime_TestCase_3()
    {
        DateTime datetime = new (year: 2022, month: 1, day: 1);
        int actual_year = DatetimeUtilities.GetCurrentYear(datetime);

        Assert.That(actual_year, Is.EqualTo(2022));
    }

    [Test]
    public void GetMonthFromDatetimeWhenJanuary()
    {
        DateTime datetime = new (year: 2023, month: 1, day: 1);
        int actual_month = DatetimeUtilities.GetCurrentMonth(datetime);

        Assert.That(actual_month, Is.EqualTo(1));
    }

    [Test]
    public void GetMonthFromDatetimeWhenFebruary()
    {
        DateTime datetime = new (year: 2023, month: 2, day: 1);
        int actual_month = DatetimeUtilities.GetCurrentMonth(datetime);

        Assert.That(actual_month, Is.EqualTo(2));
    }

    [Test]
    public void GetMonthFromDatetimeWhenMarch()
    {
        DateTime datetime = new (year: 2023, month: 3, day: 1);
        int actual_month = DatetimeUtilities.GetCurrentMonth(datetime);

        Assert.That(actual_month, Is.EqualTo(3));
    }

    [Test]
    public void GetMonthFromDatetimeWhenApril()
    {
        DateTime datetime = new (year: 2023, month: 4, day: 1);
        int actual_month = DatetimeUtilities.GetCurrentMonth(datetime);

        Assert.That(actual_month, Is.EqualTo(4));
    }

    [Test]
    public void GetMonthFromDatetimeWhenMay()
    {
        DateTime datetime = new (year: 2023, month: 5, day: 1);
        int actual_month = DatetimeUtilities.GetCurrentMonth(datetime);

        Assert.That(actual_month, Is.EqualTo(5));
    }

    [Test]
    public void GetMonthFromDatetimeWhenJune()
    {
        DateTime datetime = new (year: 2023, month: 6, day: 1);
        int actual_month = DatetimeUtilities.GetCurrentMonth(datetime);

        Assert.That(actual_month, Is.EqualTo(6));
    }

    [Test]
    public void GetMonthFromDatetimeWhenJuly()
    {
        DateTime datetime = new (year: 2023, month: 7, day: 1);
        int actual_month = DatetimeUtilities.GetCurrentMonth(datetime);

        Assert.That(actual_month, Is.EqualTo(7));
    }

    [Test]
    public void GetMonthFromDatetimeWhenAugust()
    {
        DateTime datetime = new (year: 2023, month: 8, day: 1);
        int actual_month = DatetimeUtilities.GetCurrentMonth(datetime);

        Assert.That(actual_month, Is.EqualTo(8));
    }

    [Test]
    public void GetMonthFromDatetimeWhenSeptember()
    {
        DateTime datetime = new (year: 2023, month: 9, day: 1);
        int actual_month = DatetimeUtilities.GetCurrentMonth(datetime);

        Assert.That(actual_month, Is.EqualTo(9));
    }

    [Test]
    public void GetMonthFromDatetimeWhenOctober()
    {
        DateTime datetime = new (year: 2023, month: 10, day: 1);
        int actual_month = DatetimeUtilities.GetCurrentMonth(datetime);

        Assert.That(actual_month, Is.EqualTo(10));
    }

    [Test]
    public void GetMonthFromDatetimeWhenNovember()
    {
        DateTime datetime = new (year: 2023, month: 11, day: 1);
        int actual_month = DatetimeUtilities.GetCurrentMonth(datetime);

        Assert.That(actual_month, Is.EqualTo(11));
    }

    [Test]
    public void GetMonthFromDatetimeWhenDecember()
    {
        DateTime datetime = new (year: 2023, month: 12, day: 1);
        int actual_month = DatetimeUtilities.GetCurrentMonth(datetime);

        Assert.That(actual_month, Is.EqualTo(12));
    }

    [Test]
    public void GetDayFromDatetime_TestCase_1()
    {
        DateTime datetime = new (year: 2023, month: 1, day: 1);

        int actual_day = DatetimeUtilities.GetCurrentDay(datetime);
        const int expected_day = 1;

        Assert.That(actual_day, Is.EqualTo(expected_day));
    }

    [Test]
    public void GetDayFromDatetime_TestCase_2()
    {
        DateTime datetime = new (year: 2023, month: 1, day: 10);

        int actual_day = DatetimeUtilities.GetCurrentDay(datetime);
        const int expected_day = 10;

        Assert.That(actual_day, Is.EqualTo(expected_day));
    }

    [Test]
    public void GetDayFromDatetime_TestCase_3()
    {
        DateTime datetime = new (year: 2023, month: 1, day: 20);

        int actual_day = DatetimeUtilities.GetCurrentDay(datetime);
        const int expected_day = 20;

        Assert.That(actual_day, Is.EqualTo(expected_day));
    }

    [Test]
    public void GetHourFromDatetime_TestCase_1()
    {
        DateTime datetime = new (
            year: 2023, month: 1, day: 1,
            hour: 0, minute: 0, second: 0);

        int actual_hour = DatetimeUtilities.GetCurrentHour(datetime);
        const int expected_hour = 0;

        Assert.That(actual_hour, Is.EqualTo(expected_hour));
    }

    [Test]
    public void GetHourFromDatetime_TestCase_2()
    {
        DateTime datetime = new (
            year: 2023, month: 1, day: 1,
            hour: 12, minute: 0, second: 0);

        int actual_hour = DatetimeUtilities.GetCurrentHour(datetime);
        const int expected_hour = 12;

        Assert.That(actual_hour, Is.EqualTo(expected_hour));
    }

    [Test]
    public void GetHourFromDatetime_TestCase_3()
    {
        DateTime datetime = new (
            year: 2023, month: 1, day: 1,
            hour: 23, minute: 0, second: 0);

        int actual_hour = DatetimeUtilities.GetCurrentHour(datetime);
        const int expected_hour = 23;

        Assert.That(actual_hour, Is.EqualTo(expected_hour));
    }

    [Test]
    public void GetMinuteFromDatetime_TestCase_1()
    {
        DateTime datetime = new (
            year: 2023, month: 1, day: 1,
            hour: 12, minute: 0, second: 0);

        int actual_minute = DatetimeUtilities.GetCurrentMinute(datetime);
        const int expected_minute = 0;

        Assert.That(actual_minute, Is.EqualTo(expected_minute));
    }

    [Test]
    public void GetMinuteFromDatetime_TestCase_2()
    {
        DateTime datetime = new (
            year: 2023, month: 1, day: 1,
            hour: 12, minute: 30, second: 0);

        int actual_minute = DatetimeUtilities.GetCurrentMinute(datetime);
        const int expected_minute = 30;

        Assert.That(actual_minute, Is.EqualTo(expected_minute));
    }

    [Test]
    public void GetMinuteFromDatetime_TestCase_3()
    {
        DateTime datetime = new (
            year: 2023, month: 1, day: 1,
            hour: 12, minute: 59, second: 0);

        int actual_minute = DatetimeUtilities.GetCurrentMinute(datetime);
        const int expected_minute = 59;

        Assert.That(actual_minute, Is.EqualTo(expected_minute));
    }

    [Test]
    public void GetSecondFromDatetime_TestCase_1()
    {
        DateTime datetime = new (
            year: 2023, month: 1, day: 1,
            hour: 12, minute: 0, second: 0);

        int actual_second = DatetimeUtilities.GetCurrentSecond(datetime);
        const int expected_second = 0;

        Assert.That(actual_second, Is.EqualTo(expected_second));
    }

    [Test]
    public void GetSecondFromDatetime_TestCase_2()
    {
        DateTime datetime = new (
            year: 2023, month: 1, day: 1,
            hour: 12, minute: 0, second: 30);

        int actual_second = DatetimeUtilities.GetCurrentSecond(datetime);
        const int expected_second = 30;

        Assert.That(actual_second, Is.EqualTo(expected_second));
    }

    [Test]
    public void GetSecondFromDatetime_TestCase_3()
    {
        DateTime datetime = new (
            year: 2023, month: 1, day: 1,
            hour: 12, minute: 0, second: 59);

        int actual_second = DatetimeUtilities.GetCurrentSecond(datetime);
        const int expected_second = 59;

        Assert.That(actual_second, Is.EqualTo(expected_second));
    }

    [Test]
    public void GetDateAsText_TestCase_1()
    {
        const int year = 2021;
        const int month = 12;
        const int day = 31;

        string actual_date = DatetimeUtilities.GetCurrentDateText(year, month, day);
        const string expected_date = "2021-12-31";

        Assert.That(actual_date, Is.EqualTo(expected_date));
    }

    [Test]
    public void GetDateAsText_TestCase_2()
    {
        const int year = 2022;
        const int month = 1;
        const int day = 1;

        string actual_date = DatetimeUtilities.GetCurrentDateText(year, month, day);
        const string expected_date = "2022-01-01";

        Assert.That(actual_date, Is.EqualTo(expected_date));
    }

    [Test]
    public void GetTimeAsText_TestCase_1()
    {
        const int hour = 23;
        const int minute = 59;
        const int second = 59;

        string actual_time = DatetimeUtilities.GetCurrentTimeText(hour, minute, second);
        const string expected_time = "23-59-59";

        Assert.That(actual_time, Is.EqualTo(expected_time));
    }

    [Test]
    public void GetTimeAsText_TestCase_2()
    {
        const int hour = 6;
        const int minute = 0;
        const int second = 0;

        string actual_time = DatetimeUtilities.GetCurrentTimeText(hour, minute, second);
        const string expected_time = "06-00-00";

        Assert.That(actual_time, Is.EqualTo(expected_time));
    }

    [Test]
    public void GetDatetimeUnitWithZero_TestCase_0()
    {
        const int datetime_value = 0;

        string actual_text = DatetimeUtilities.GetDatetimeUnitText(datetime_value);
        const string expected_text = "00";

        Assert.That(actual_text, Is.EqualTo(expected_text));
    }

    [Test]
    public void GetDatetimeUnitWithZero_TestCase_1()
    {
        const int datetime_value = 1;

        string actual_text = DatetimeUtilities.GetDatetimeUnitText(datetime_value);
        const string expected_text = "01";

        Assert.That(actual_text, Is.EqualTo(expected_text));
    }

    [Test]
    public void GetDatetimeUnitWithZero_TestCase_2()
    {
        const int datetime_value = 2;

        string actual_text = DatetimeUtilities.GetDatetimeUnitText(datetime_value);
        const string expected_text = "02";

        Assert.That(actual_text, Is.EqualTo(expected_text));
    }

    [Test]
    public void GetDatetimeUnitWithZero_TestCase_3()
    {
        const int datetime_value = 3;

        string actual_text = DatetimeUtilities.GetDatetimeUnitText(datetime_value);
        const string expected_text = "03";

        Assert.That(actual_text, Is.EqualTo(expected_text));
    }

    [Test]
    public void GetDatetimeUnitWithZero_TestCase_4()
    {
        const int datetime_value = 4;

        string actual_text = DatetimeUtilities.GetDatetimeUnitText(datetime_value);
        const string expected_text = "04";

        Assert.That(actual_text, Is.EqualTo(expected_text));
    }

    [Test]
    public void GetDatetimeUnitWithZero_TestCase_5()
    {
        const int datetime_value = 5;

        string actual_text = DatetimeUtilities.GetDatetimeUnitText(datetime_value);
        const string expected_text = "05";

        Assert.That(actual_text, Is.EqualTo(expected_text));
    }

    [Test]
    public void GetDatetimeUnitWithZero_TestCase_6()
    {
        const int datetime_value = 6;

        string actual_text = DatetimeUtilities.GetDatetimeUnitText(datetime_value);
        const string expected_text = "06";

        Assert.That(actual_text, Is.EqualTo(expected_text));
    }

    [Test]
    public void GetDatetimeUnitWithZero_TestCase_7()
    {
        const int datetime_value = 7;

        string actual_text = DatetimeUtilities.GetDatetimeUnitText(datetime_value);
        const string expected_text = "07";

        Assert.That(actual_text, Is.EqualTo(expected_text));
    }

    [Test]
    public void GetDatetimeUnitWithZero_TestCase_8()
    {
        const int datetime_value = 8;

        string actual_text = DatetimeUtilities.GetDatetimeUnitText(datetime_value);
        const string expected_text = "08";

        Assert.That(actual_text, Is.EqualTo(expected_text));
    }

    [Test]
    public void GetDatetimeUnitWithZero_TestCase_9()
    {
        const int datetime_value = 9;

        string actual_text = DatetimeUtilities.GetDatetimeUnitText(datetime_value);
        const string expected_text = "09";

        Assert.That(actual_text, Is.EqualTo(expected_text));
    }

    [Test]
    public void GetDatetimeUnitWithoutZero_TestCase_1()
    {
        const int datetime_value = 15;

        string actual_text = DatetimeUtilities.GetDatetimeUnitText(datetime_value);
        const string expected_text = "15";

        Assert.That(actual_text, Is.EqualTo(expected_text));
    }

    [Test]
    public void GetDatetimeUnitWithoutZero_TestCase_2()
    {
        const int datetime_value = 25;

        string actual_text = DatetimeUtilities.GetDatetimeUnitText(datetime_value);
        const string expected_text = "25";

        Assert.That(actual_text, Is.EqualTo(expected_text));
    }

    [Test]
    public void GetDatetimeUnitWithoutZero_TestCase_3()
    {
        const int datetime_value = 35;

        string actual_text = DatetimeUtilities.GetDatetimeUnitText(datetime_value);
        const string expected_text = "35";

        Assert.That(actual_text, Is.EqualTo(expected_text));
    }

    [Test]
    public void GetDatetimeUnitWithoutZero_TestCase_4()
    {
        const int datetime_value = 45;

        string actual_text = DatetimeUtilities.GetDatetimeUnitText(datetime_value);
        const string expected_text = "45";

        Assert.That(actual_text, Is.EqualTo(expected_text));
    }

    [Test]
    public void GetDatetimeUnitWithoutZero_TestCase_5()
    {
        const int datetime_value = 55;

        string actual_text = DatetimeUtilities.GetDatetimeUnitText(datetime_value);
        const string expected_text = "55";

        Assert.That(actual_text, Is.EqualTo(expected_text));
    }

    [Test]
    public void ConcatenateDateAndTime_TestCase_1()
    {
        const string date_text = "2021-12-31";
        const string time_text = "23-55-55";

        string actual_datetime = DatetimeUtilities.ConcatenateDateAndTime(date_text, time_text);
        const string expected_datetime = "2021-12-31_23-55-55";

        Assert.That(actual_datetime, Is.EqualTo(expected_datetime));
    }

    [Test]
    public void ConcatenateDateAndTime_TestCase_2()
    {
        const string date_text = "2022-01-01";
        const string time_text = "09-00-00";

        string actual_datetime = DatetimeUtilities.ConcatenateDateAndTime(date_text, time_text);
        const string expected_datetime = "2022-01-01_09-00-00";

        Assert.That(actual_datetime, Is.EqualTo(expected_datetime));
    }
}
