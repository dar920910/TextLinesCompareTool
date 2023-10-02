//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;
using TextLinesComparing.Library;

Stopwatch stopwatch = new ();
stopwatch.Start();
OutputInfo outputInfo = new ();

List<string> sources = new ();

for (int source_index = 0; source_index < args.Length; source_index++)
{
    string argument = args[source_index];

    if (argument.EndsWith(".exe") || outputInfo.IsOutputParameter(argument))
    {
        continue;
    }

    sources.Add(args[source_index]);
}

SourcesExplorer explorer = new (sources);
LinesResultView artifacts = explorer.GetArtifactsFromSources();
outputInfo.PrintArtifacts(artifacts);

stopwatch.Stop();
Console.WriteLine($"[INFO] Program's Execution Time: {stopwatch.Elapsed}\n");
