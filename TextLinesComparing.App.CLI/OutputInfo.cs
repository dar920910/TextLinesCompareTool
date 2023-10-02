//-----------------------------------------------------------------------
// <copyright file="OutputInfo.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented

using TextLinesComparing.Library;

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
