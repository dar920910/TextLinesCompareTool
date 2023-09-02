#include "AppDatetimeService.hpp"

AppDatetimeService::AppDatetimeService()
{
    m_AppStartDatetime = getClockDatetime();
}

const clock_t AppDatetimeService::getClockDatetime() const
{
    return std::clock();
}

void AppDatetimeService::printExecutionElapsedTime() const
{
    clock_t appFinishDatetime = getClockDatetime();

    double elapsed_secs = double(appFinishDatetime - m_AppStartDatetime) / CLOCKS_PER_SEC;

    std::cout << "Program's Execution Time : ";
    std::cout << elapsed_secs << " seconds";
    std::cout << std::endl;
}

const std::string AppDatetimeService::getCurrentDatetimeText()
{
    std::time_t now = std::time(nullptr);
    const tm* current_datetime = std::localtime(&now);

    const int year {DatetimeUtilities::getCurrentYear(current_datetime)};
    const int month {DatetimeUtilities::getCurrentMonth(current_datetime)};
    const int day {DatetimeUtilities::getCurrentDay(current_datetime)};
    const int hour {DatetimeUtilities::getCurrentHour(current_datetime)};
    const int minute {DatetimeUtilities::getCurrentMinute(current_datetime)};
    const int second {DatetimeUtilities::getCurrentSecond(current_datetime)};

    const std::string date_text {DatetimeUtilities::getCurrentDateText(year, month, day)};
    const std::string time_text {DatetimeUtilities::getCurrentTimeText(hour, minute, second)};

    return DatetimeUtilities::concatenateDateAndTime(date_text, time_text);
}


const int DatetimeUtilities::getCurrentYear(const tm* current_datetime)
{
    const int start_year {1900}; // 'tm_year' means years since 1900
    return current_datetime->tm_year + start_year;
}

const int DatetimeUtilities::getCurrentMonth(const tm* current_datetime)
{
    const int month_offset {1}; // 'tm_mon' means months since January [0,11]
    return current_datetime->tm_mon + month_offset;
}

const int DatetimeUtilities::getCurrentDay(const tm* current_datetime)
{
    return current_datetime->tm_mday;
}

const int DatetimeUtilities::getCurrentHour(const tm* current_datetime)
{
    return current_datetime->tm_hour;
}

const int DatetimeUtilities::getCurrentMinute(const tm* current_datetime)
{
    return current_datetime->tm_min;
}

const int DatetimeUtilities::getCurrentSecond(const tm* current_datetime)
{
    return current_datetime->tm_sec;
}

const std::string DatetimeUtilities::getCurrentDateText(const int& year, const int& month, const int& day)
{
    const char date_separator {'-'};

    const std::string current_year {getDatetimeUnitText(year)};
    const std::string current_month {getDatetimeUnitText(month)};
    const std::string current_day {getDatetimeUnitText(day)};

    return std::string(current_year + date_separator + current_month + date_separator + current_day);
}

const std::string DatetimeUtilities::getCurrentTimeText(const int& hour, const int& minute, const int& second)
{
    const char time_separator {'-'};

    const std::string current_hour {getDatetimeUnitText(hour)};
    const std::string current_minute {getDatetimeUnitText(minute)};
    const std::string current_second {getDatetimeUnitText(second)};

    return std::string(current_hour + time_separator + current_minute + time_separator + current_second);
}

const std::string DatetimeUtilities::getDatetimeUnitText(const int& datetime_unit)
{
    const int datetime_threshold {10};
    const char zero {'0'};

    if (datetime_unit < datetime_threshold)
    {
        return zero + std::to_string(datetime_unit);
    }

    return std::to_string(datetime_unit);
}

const std::string DatetimeUtilities::concatenateDateAndTime(const std::string& date_text, const std::string& time_text)
{
    const char datetime_separator {'_'};
    return std::string(date_text + datetime_separator + time_text);
}