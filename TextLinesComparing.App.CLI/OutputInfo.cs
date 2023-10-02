//-----------------------------------------------------------------------
// <copyright file="OutputInfo.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented

using TextLinesComparing.Library;
using static System.Console;

internal struct OutputInfo
{
    internal const string ResultFileOutputParameter = "--output-file";
    internal const string ResultWebOutputParameter = "--output-web";

    public OutputInfo()
    {
        this.HasFileOutput = false;
        this.HasWebOutput = false;
    }

    internal bool HasFileOutput { get; set; }

    internal bool HasWebOutput { get; set; }

    internal static void PrintHelp()
    {
        const string source_1 = "./source_1.txt";
        const string source_2 = "./source_2.txt";
        const string source_3 = "./source_3.txt";
        const string source_4 = "./source_4.txt";
        const string source_5 = "./source_5.txt";

        WriteLine("\n[ERROR] You should pass command-line arguments to successfully run the program.\n");
        WriteLine("[HELP] Use the following format of the command:");
        WriteLine("<EXECUTABLE> [OPTIONAL_PARAMETERS] <SOURCE_FILES...>");

        WriteLine("\nPossible Parameters:\n");
        WriteLine($"{ResultFileOutputParameter} : add output of results to a text file");
        WriteLine($"{ResultWebOutputParameter} : add output of results to a web page");

        WriteLine("\nCommand Examples:\n");
        WriteLine($"dotnet run {source_1} {source_2}");
        WriteLine($"dotnet run {ResultFileOutputParameter} {source_1} {source_2} {source_3}");
        WriteLine($"dotnet run {ResultWebOutputParameter} {source_1} {source_2} {source_3}");
        WriteLine(
            $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name} " +
                $"{ResultFileOutputParameter} {ResultWebOutputParameter} " +
                    $"{source_1} {source_2} {source_3} {source_4} {source_5}");
        WriteLine();
    }

    internal bool IsOutputParameter(string argument)
    {
        if (argument.Equals(ResultFileOutputParameter))
        {
            this.HasFileOutput = true;
            return true;
        }

        if (argument.Equals(ResultWebOutputParameter))
        {
            this.HasWebOutput = true;
            return true;
        }

        return false;
    }

    internal readonly void PrintArtifacts(LinesResultView artifacts)
    {
        new OutputConsolePrinter().PrintArtifacts(artifacts);

        if (this.HasFileOutput)
        {
            new OutputFilePrinter().PrintArtifacts(artifacts);
        }

        if (this.HasWebOutput)
        {
            new OutputWebPrinter().PrintArtifacts(artifacts);
        }
    }
}
