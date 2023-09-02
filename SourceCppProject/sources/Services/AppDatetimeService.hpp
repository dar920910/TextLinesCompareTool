#ifndef APP_DATETIME_SERVICE
#define APP_DATETIME_SERVICE

#include <ctime>
#include <iostream>
#include <string>

class AppDatetimeService
{
private:
    clock_t m_AppStartDatetime;

    const clock_t getClockDatetime() const;
public:
    AppDatetimeService();
    void printExecutionElapsedTime() const;

    static const std::string getCurrentDatetimeText();
};

#endif

namespace DatetimeUtilities
{
    const int getCurrentYear(const tm* current_datetime);
    const int getCurrentMonth(const tm* current_datetime);
    const int getCurrentDay(const tm* current_datetime);

    const int getCurrentHour(const tm* current_datetime);
    const int getCurrentMinute(const tm* current_datetime);
    const int getCurrentSecond(const tm* current_datetime);

    const std::string getCurrentDateText(const int& year, const int& month, const int& day);
    const std::string getCurrentTimeText(const int& hour, const int& minute, const int& second);

    const std::string getDatetimeUnitText(const int& datetime_unit);

    const std::string concatenateDateAndTime(const std::string& date_text, const std::string& time_text);
}