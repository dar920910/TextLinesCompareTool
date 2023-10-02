//-----------------------------------------------------------------------
// <copyright file="Results.cshtml.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1649 // FileNameMustMatchTypeName

using Microsoft.AspNetCore.Mvc.RazorPages;
using TextLinesComparing.Library;

public class ResultsModel : PageModel
{
    public ResultsModel()
    {
        SourcesExplorer explorer = new (UploadsStore.UploadedFilePaths);
        this.Artifacts = explorer.GetArtifactsFromSources();
    }

    public LinesResultView Artifacts { get; }

    public static string GetDelimiter() => new ('=', 10);

    public static string GetSubDelimiter() => new ('-', 5);

    public static string GetLineInfo(LineInfo target_info) => GetLinePairKey(target_info.Content);

    public static string GetLineInfo(KeyValuePair<int, string> pair_info)
    {
        return GetLinePairKey(pair_info) + GetLinePairValue(pair_info);
    }

    public static string GetLineInfo(string target_line) => $"\'{target_line}\'";

    public static string GetLinePairKey(KeyValuePair<int, string> pair) => $"[{pair.Key:X}] ";

    public static string GetLinePairValue(KeyValuePair<int, string> pair) => $"\"{pair.Value}\"";

    public void OnGet()
    {
        this.ViewData["Title"] = "TextLinesCompareTool";
    }
}
