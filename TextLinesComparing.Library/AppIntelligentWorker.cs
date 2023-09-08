namespace TextLinesComparing.Library;

public static class AppIntelligentWorker
{
    const int CriticalPerformanceThreshold = 2;

    public static void PerformTask(string[] args)
    {
        AppDatetimeService datetime = new();

        List<string> arguments = AppLaunchConfiguration.GetArgumentsOfSources(args);
        SourcesExplorer explorer = new(arguments);

        if (IsNeededIncreasePerformance(arguments.Count))
        {
            LinesResultView<LinesStorageMap> artifacts = 
                explorer.GetArtifactsFromSourcesAsMapBasedContent();

            ShowResults(artifacts);
            SaveResultsToTextFile(artifacts);
            SaveResultsToWebPage(artifacts);
        }
        else
        {
            LinesResultView<LinesStorageSet> artifacts = 
                explorer.GetArtifactsFromSourcesAsSetBasedContent();

            ShowResults(artifacts);
            SaveResultsToTextFile(artifacts);
            SaveResultsToWebPage(artifacts);
        }

        datetime.PrintExecutionElapsedTimeMessage();
    }



    private static bool IsNeededIncreasePerformance(int count_of_sources) => 
        count_of_sources > CriticalPerformanceThreshold;

    private static void ShowResults(LinesResultView<LinesStorageMap> result_view)
    {
        new OutputConsolePrinter().PrintArtifacts(result_view);
    }

    private static void ShowResults(LinesResultView<LinesStorageSet> result_view)
    {
        new OutputConsolePrinter().PrintArtifacts(result_view);
    }

    private static void SaveResultsToTextFile(LinesResultView<LinesStorageMap> result_view)
    {
        new OutputFilePrinter().PrintArtifacts(result_view);
    }

    private static void SaveResultsToTextFile(LinesResultView<LinesStorageSet> result_view)
    {
        new OutputFilePrinter().PrintArtifacts(result_view);
    }

    private static void SaveResultsToWebPage(LinesResultView<LinesStorageMap> result_view)
    {
        new OutputWebPrinter().PrintArtifacts(result_view);
    }

    private static void SaveResultsToWebPage(LinesResultView<LinesStorageSet> result_view)
    {
        new OutputWebPrinter().PrintArtifacts(result_view);
    }
}
