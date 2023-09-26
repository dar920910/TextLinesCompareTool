﻿//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;
using TextLinesComparing.Library;

Stopwatch stopwatch = new ();
stopwatch.Start();

List<string> sources = new ();
for (int source_index = 1; source_index < args.Length; source_index++)
{
    sources.Add(args[source_index]);
}

SourcesExplorer explorer = new (sources);

const int CriticalPerformanceThreshold = 2;
if (sources.Count > CriticalPerformanceThreshold)
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

stopwatch.Stop();
Console.WriteLine($"[INFO] Program's Execution Time: {stopwatch.Elapsed}\n");
