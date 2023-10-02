//-----------------------------------------------------------------------
// <copyright file="OutputAbstractDevice.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TextLinesComparing.Library;

public abstract class OutputAbstractDevice
{
    public virtual void PrintArtifacts(LinesResultView result_artifact)
    {
        this.PrintUncommentedContent(result_artifact.ContentFromSources);
        this.PrintUniqueContent(result_artifact.UniqueContentRepository);
        this.PrintCommonContent(result_artifact.CommonContentStorage);
    }

    protected static string GetDelimiter() => new ('=', 10);

    protected static string GetSubDelimiter() => new ('-', 5);

    protected abstract void PrintUncommentedContent(List<LinesStorage> content_repos);

    protected abstract void PrintUncommentedContent(LinesStorage target_content);

    protected abstract void PrintUniqueContent(List<LinesStorage> repos);

    protected abstract void PrintUniqueContent(LinesStorage content_element);

    protected abstract void PrintCommonContent(LinesStorage target_content);

    protected abstract void PrintContentTitle(string title_text);

    protected abstract void PrintUncommentedContentTitle(string source_name);

    protected abstract void PrintUniqueContentTitle(string source_name);

    protected abstract void PrintLineInfo(LineInfo target_info);

    protected abstract void PrintLineInfo(KeyValuePair<int, string> target_line);

    protected abstract void PrintLineInfo(string target_line);

    protected abstract void PrintLinePairKey(KeyValuePair<int, string> pair);

    protected abstract void PrintLinePairValue(KeyValuePair<int, string> pair);
}
