namespace TextLinesComparing.Library;

public class AppDatetimeService
{
    private DateTime _AppStartDatetime;

    public AppDatetimeService()
    {
        _AppStartDatetime = GetClockDatetime();
    }

    private DateTime GetClockDatetime()
    {
        return DateTime.Now;
    }

    public string GetExecutionElapsedTimeMessage()
    {
        DateTime appFinishDatetime = GetClockDatetime();
        return $"Program's Execution Time :\nStart: {_AppStartDatetime},\nFinish: {appFinishDatetime}\n";
    }

    public string GetCurrentDatetimeText()
    {
        DateTime current_datetime = GetClockDatetime();

        int year = DatetimeUtilities.GetCurrentYear(current_datetime);
        int month = DatetimeUtilities.GetCurrentMonth(current_datetime);
        int day = DatetimeUtilities.GetCurrentDay(current_datetime);
        int hour = DatetimeUtilities.GetCurrentHour(current_datetime);
        int minute = DatetimeUtilities.GetCurrentMinute(current_datetime);
        int second = DatetimeUtilities.GetCurrentSecond(current_datetime);

        string date_text = DatetimeUtilities.GetCurrentDateText(year, month, day);
        string time_text = DatetimeUtilities.GetCurrentTimeText(hour, minute, second);

        return DatetimeUtilities.ConcatenateDateAndTime(date_text, time_text);
    }


}

public static class DatetimeUtilities
{
    public static int GetCurrentYear(DateTime current_datetime)
    {
        const int start_year = 1900; // 'tm_year' means years since 1900
        return current_datetime.Year + start_year;
    }

    public static int GetCurrentMonth(DateTime current_datetime)
    {
        return current_datetime.Month;
    }

    public static int GetCurrentDay(DateTime current_datetime)
    {
        return current_datetime.Day;
    }

    public static int GetCurrentHour(DateTime current_datetime)
    {
        return current_datetime.Hour;
    }

    public static int GetCurrentMinute(DateTime current_datetime)
    {
        return current_datetime.Minute;
    }

    public static int GetCurrentSecond(DateTime current_datetime)
    {
        return current_datetime.Second;
    }

    public static string GetCurrentDateText(int year, int month, int day)
    {
        const char date_separator = '-';

        string current_year = GetDatetimeUnitText(year);
        string current_month = GetDatetimeUnitText(month);
        string current_day = GetDatetimeUnitText(day);

        return current_year + date_separator + current_month + date_separator + current_day;
    }

    public static string GetCurrentTimeText(int hour, int minute, int second)
    {
        const char time_separator = '-';

        string current_hour = GetDatetimeUnitText(hour);
        string current_minute = GetDatetimeUnitText(minute);
        string current_second = GetDatetimeUnitText(second);

        return current_hour + time_separator + current_minute + time_separator + current_second;
    }

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

    public static string ConcatenateDateAndTime(string date_text, string time_text)
    {
        const char datetime_separator = '_';
        return date_text + datetime_separator + time_text;
    }
}
