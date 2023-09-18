using TextLinesComparing.Library;

AppDatetimeService datetime = new();

List<string> arguments = AppLaunchConfiguration.GetArgumentsOfSources(args);
SourcesExplorer explorer = new(arguments);

const int CriticalPerformanceThreshold = 2;
if (arguments.Count > CriticalPerformanceThreshold)
{
    LinesResultView<LinesStorageMap> artifacts =
        explorer.GetArtifactsFromSourcesAsMapBasedContent();
    new OutputConsolePrinter().PrintArtifacts(artifacts);
    new OutputFilePrinter().PrintArtifacts(artifacts);
    new OutputWebPrinter().PrintArtifacts(artifacts);
}
else
{
    LinesResultView<LinesStorageSet> artifacts =
        explorer.GetArtifactsFromSourcesAsSetBasedContent();
    new OutputConsolePrinter().PrintArtifacts(artifacts);
    new OutputFilePrinter().PrintArtifacts(artifacts);
    new OutputWebPrinter().PrintArtifacts(artifacts);
}

datetime.PrintExecutionElapsedTimeMessage();
