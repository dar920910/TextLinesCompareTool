#include "AppIntelligentWorker.hpp"

#include "../Models/SourcesExplorer.hpp"
#include "../Printers/ConsoleOutputPrinter.hpp"
#include "../Printers/FileOutputPrinter.hpp"
#include "../Printers/WebOutputPrinter.hpp"
#include "AppDatetimeService.hpp"


void AppIntelligentWorker::performTask(const AppLaunchConfiguration& configuration)
{
    const AppDatetimeService datetime = AppDatetimeService();

    const auto arguments = configuration.getArgumentsOfSources();
    const SourcesExplorer explorer(arguments);

    if (isNeededIncreasePerformance(arguments.size()))
    {
        const auto artifacts = explorer.getArtifactsFromSourcesAsMapBasedContent();

        showResults(artifacts);
        saveResultsToTextFile(artifacts);
        saveResultsToWebPage(artifacts);
    }
    else
    {
        const auto artifacts = explorer.getArtifactsFromSourcesAsSetBasedContent();

        showResults(artifacts);
        saveResultsToTextFile(artifacts);
        saveResultsToWebPage(artifacts);
    }

    datetime.printExecutionElapsedTime();
}

bool AppIntelligentWorker::isNeededIncreasePerformance(const unsigned int count_of_sources)
{
    return count_of_sources > m_CriticalPerformanceThreshold;
}

void AppIntelligentWorker::showResults(const LinesResultMapBasedView& result_view)
{
    ConsoleOutputPrinter().printArtifacts(result_view);
}

void AppIntelligentWorker::showResults(const LinesResultSetBasedView& result_view)
{
    ConsoleOutputPrinter().printArtifacts(result_view);
}

void AppIntelligentWorker::saveResultsToTextFile(const LinesResultMapBasedView& result_view)
{
    FileOutputPrinter result_file;
    result_file.printArtifacts(result_view);
}

void AppIntelligentWorker::saveResultsToTextFile(const LinesResultSetBasedView& result_view)
{
    FileOutputPrinter result_file;
    result_file.printArtifacts(result_view);
}

void AppIntelligentWorker::saveResultsToWebPage(const LinesResultMapBasedView& result_view)
{
    WebOutputPrinter result_page;
    result_page.printArtifacts(result_view);
}

void AppIntelligentWorker::saveResultsToWebPage(const LinesResultSetBasedView& result_view)
{
    WebOutputPrinter result_page;
    result_page.printArtifacts(result_view);
}