using Microsoft.AspNetCore.Mvc.RazorPages;
using TextLinesComparing.Library;

public class ResultsModel : PageModel
{
    public readonly LinesResultView<LinesStorageMap> Artifacts;

    public ResultsModel()
    {
        SourcesExplorer explorer = new(UploadsStore.UploadedFilePaths);
        Artifacts = explorer.GetArtifactsFromSourcesAsMapBasedContent();

        //new OutputWebPrinter().PrintArtifacts(artifacts);
    }

    public void OnGet()
    {
        ViewData["Title"] = "Analysis Results";
    }

    public static string GetDelimiter() => new('=', 10);
    public static string GetSubDelimiter() => new('-', 5);

    public static string GetLineInfo(LineInfo target_info) => GetLinePairKey(target_info.Content);
    public static string GetLineInfo(KeyValuePair<int, string> pair_info)
    {
        return GetLinePairKey(pair_info) + GetLinePairValue(pair_info);
    }

    public static string GetLineInfo(string target_line) => $"\'{target_line}\'";

    public static string GetLinePairKey(KeyValuePair<int, string> pair) => $"key = {pair.Key:X} | ";
    public static string GetLinePairValue(KeyValuePair<int, string> pair) => $"value = \"{pair.Value}\" | ";
}