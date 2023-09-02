#ifndef APP_INTELLIGENT_WORKER
#define APP_INTELLIGENT_WORKER

#include "AppLaunchConfiguration.hpp"
#include "../Models/LinesPresentationView.hpp"

#include <string>


class AppIntelligentWorker
{
private:
    static const int m_CriticalPerformanceThreshold {2};

    static bool isNeededIncreasePerformance(const unsigned int count_of_sources);

    static void showResults(const LinesResultMapBasedView& result_view);
    static void showResults(const LinesResultSetBasedView& result_view);

    static void saveResultsToTextFile(const LinesResultMapBasedView& result_view);
    static void saveResultsToTextFile(const LinesResultSetBasedView& result_view);

    static void saveResultsToWebPage(const LinesResultMapBasedView& result_view);
    static void saveResultsToWebPage(const LinesResultSetBasedView& result_view);
public:
    static void performTask(const AppLaunchConfiguration& configuration);
};

#endif