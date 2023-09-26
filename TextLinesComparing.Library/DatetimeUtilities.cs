//-----------------------------------------------------------------------
// <copyright file="DatetimeUtilities.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TextLinesComparing.Library;

/// <summary>
/// Represents static methods to work with date and time in the program context.
/// </summary>
public static class DatetimeUtilities
{
    /// <summary>
    /// Gets a special text value for current date and time.
    /// </summary>
    /// <returns>Special string value of current date and time.</returns>
    public static string GetCurrentDatetimeText()
    {
        DateTime current_datetime = DateTime.Now;

        int year = GetCurrentYear(current_datetime);
        int month = GetCurrentMonth(current_datetime);
        int day = GetCurrentDay(current_datetime);
        int hour = GetCurrentHour(current_datetime);
        int minute = GetCurrentMinute(current_datetime);
        int second = GetCurrentSecond(current_datetime);

        string date_text = GetCurrentDateText(year, month, day);
        string time_text = GetCurrentTimeText(hour, minute, second);

        return ConcatenateDateAndTime(date_text, time_text);
    }

    /// <summary>
    /// Gets the value of the current year.
    /// </summary>
    /// <param name="current_datetime">Current datetime.</param>
    /// <returns>Current year.</returns>
    public static int GetCurrentYear(DateTime current_datetime)
    {
        return current_datetime.Year;
    }

    /// <summary>
    /// Gets the value of the current month.
    /// </summary>
    /// <param name="current_datetime">Current datetime.</param>
    /// <returns>Current month.</returns>
    public static int GetCurrentMonth(DateTime current_datetime)
    {
        return current_datetime.Month;
    }

    /// <summary>
    /// Gets the value of the current day.
    /// </summary>
    /// <param name="current_datetime">Current datetime.</param>
    /// <returns>Current day.</returns>
    public static int GetCurrentDay(DateTime current_datetime)
    {
        return current_datetime.Day;
    }

    /// <summary>
    /// Gets the value of the current hour.
    /// </summary>
    /// <param name="current_datetime">Current datetime.</param>
    /// <returns>Current hour.</returns>
    public static int GetCurrentHour(DateTime current_datetime)
    {
        return current_datetime.Hour;
    }

    /// <summary>
    /// Gets the value of the current minute.
    /// </summary>
    /// <param name="current_datetime">Current datetime.</param>
    /// <returns>Current minute.</returns>
    public static int GetCurrentMinute(DateTime current_datetime)
    {
        return current_datetime.Minute;
    }

    /// <summary>
    /// Gets the value of the current second.
    /// </summary>
    /// <param name="current_datetime">Current datetime.</param>
    /// <returns>Current second.</returns>
    public static int GetCurrentSecond(DateTime current_datetime)
    {
        return current_datetime.Second;
    }

    /// <summary>
    /// Gets text for the current date separated by the hyphen character.
    /// </summary>
    /// <param name="year">Year value.</param>
    /// <param name="month">Month value.</param>
    /// <param name="day">Day value.</param>
    /// <returns>Date text value separated via the hyphen.</returns>
    public static string GetCurrentDateText(int year, int month, int day)
    {
        const char date_separator = '-';

        string current_year = GetDatetimeUnitText(year);
        string current_month = GetDatetimeUnitText(month);
        string current_day = GetDatetimeUnitText(day);

        return current_year + date_separator + current_month + date_separator + current_day;
    }

    /// <summary>
    /// Gets text for the current time separated by the hyphen character.
    /// </summary>
    /// <param name="hour">Hours value.</param>
    /// <param name="minute">Minutes value.</param>
    /// <param name="second">Seconds value.</param>
    /// <returns>Date text value separated via the hyphen.</returns>
    public static string GetCurrentTimeText(int hour, int minute, int second)
    {
        const char time_separator = '-';

        string current_hour = GetDatetimeUnitText(hour);
        string current_minute = GetDatetimeUnitText(minute);
        string current_second = GetDatetimeUnitText(second);

        return current_hour + time_separator + current_minute + time_separator + current_second;
    }

    /// <summary>
    /// Gets text for a datetime unit with additional zeroes.
    /// </summary>
    /// <param name="datetime_unit">Datetime unit.</param>
    /// <returns>Datetime text value with zero characters.</returns>
    public static string GetDatetimeUnitText(int datetime_unit)
    {
        const int datetime_threshold = 10;
        const char zero = '0';

        if (datetime_unit < datetime_threshold)
        {
            return zero + datetime_unit.ToString();
        }

        return datetime_unit.ToString();
    }

    /// <summary>
    /// Concatenates text values of date and time.
    /// </summary>
    /// <param name="date_text">Date text value.</param>
    /// <param name="time_text">Time text value.</param>
    /// <returns>Concatenated datetime text.</returns>
    public static string ConcatenateDateAndTime(string date_text, string time_text)
    {
        const char datetime_separator = '_';
        return date_text + datetime_separator + time_text;
    }
}
