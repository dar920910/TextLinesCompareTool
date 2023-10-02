//-----------------------------------------------------------------------
// <copyright file="OutputWebPrinter.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented

#define HASH_OUTPUT

namespace TextLinesComparing.Library;

public class OutputWebPrinter : OutputAbstractDevice
{
    private const string ResultFolderName = "~output";
    private const string ResultFileExtension = ".html";

    private readonly string outputDirectoryPath;
    private StreamWriter webOutputFileStream;

    public OutputWebPrinter()
    {
        this.outputDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), ResultFolderName);

        if (Directory.Exists(this.outputDirectoryPath) is false)
        {
            Directory.CreateDirectory(this.outputDirectoryPath);
        }
    }

    public override void PrintArtifacts(LinesResultView result_artifact)
    {
        string outputFileName = DatetimeUtilities.GetCurrentDatetimeText() + ResultFileExtension;
        string outputFilePath = Path.Combine(this.outputDirectoryPath, outputFileName);
        this.webOutputFileStream = new (outputFilePath);

        this.webOutputFileStream.WriteLine(GenerateWebPageBegin());
        this.PrintUncommentedContent(result_artifact.ContentFromSources);
        this.PrintUniqueContent(result_artifact.UniqueContentRepository);
        this.PrintCommonContent(result_artifact.CommonContentStorage);
        this.webOutputFileStream.WriteLine(GenerateWebPageEnd());

        this.webOutputFileStream.Close();
    }

    protected override void PrintUncommentedContent(List<LinesStorage> content_repos)
    {
        this.PrintContentTitle("UNCOMMENTED LINES FROM ALL FILES");

        foreach (LinesStorage content_element in content_repos)
        {
            this.PrintUncommentedContent(content_element);
        }
    }

    protected override void PrintUncommentedContent(LinesStorage target_content)
    {
        this.PrintUncommentedContentTitle(target_content.Name);

        foreach (KeyValuePair<int, string> uncommented_line in target_content.Content)
        {
            this.webOutputFileStream.Write("<p class='all'>");
            this.webOutputFileStream.Write("LINE: ");
            this.PrintLineInfo(uncommented_line);
            this.webOutputFileStream.Write("</p>\n");
        }

        this.webOutputFileStream.WriteLine("<br>\n");
    }

    protected override void PrintUniqueContent(List<LinesStorage> repos)
    {
        this.PrintContentTitle("UNIQUE LINES MAPS (HASH + STRING)");

        foreach (LinesStorage content_element in repos)
        {
            this.PrintUniqueContent(content_element);
        }

        this.webOutputFileStream.WriteLine("<br>\n");
    }

    protected override void PrintUniqueContent(LinesStorage content_element)
    {
        this.PrintUniqueContentTitle(content_element.Name);

        foreach (KeyValuePair<int, string> content_pair in content_element.Content)
        {
            this.webOutputFileStream.Write("<p class='unique'>");
            this.webOutputFileStream.Write("LINE: ");
            this.PrintLineInfo(content_pair);
            this.webOutputFileStream.Write("</p>\n");
        }

        this.webOutputFileStream.WriteLine("<br>");
    }

    protected override void PrintCommonContent(LinesStorage target_content)
    {
        this.PrintContentTitle("COMMON LINES MAP");

        foreach (KeyValuePair<int, string> element in target_content.Content)
        {
            this.webOutputFileStream.Write("<p class='common'>");
            this.webOutputFileStream.Write("LINE: ");
            this.PrintLineInfo(element);
            this.webOutputFileStream.Write("</p>\n");
        }

        this.webOutputFileStream.WriteLine("<br>\n");
    }

    protected override void PrintContentTitle(string title_text)
    {
        this.webOutputFileStream.WriteLine(
            $"<br><h2>{GetDelimiter()} {title_text} {GetDelimiter()}</h2><br>\n");
    }

    protected override void PrintUncommentedContentTitle(string source_name)
    {
        this.webOutputFileStream.WriteLine(
            $"<h3>{GetSubDelimiter()} UNCOMMENTED LINES: {source_name} {GetSubDelimiter()}</h3><br>\n");
    }

    protected override void PrintUniqueContentTitle(string source_name)
    {
        this.webOutputFileStream.WriteLine(
            $"<h3>{GetSubDelimiter()} UNIQUE LINES: {source_name} {GetSubDelimiter()} + </h3><br>\n");
    }

    protected override void PrintLineInfo(LineInfo target_info)
    {
    #if HASH_OUTPUT
        this.PrintLinePairKey(target_info.Content);
    #endif
        this.PrintLinePairValue(target_info.Content);
    }

    protected override void PrintLineInfo(KeyValuePair<int, string> pair_info)
    {
    #if HASH_OUTPUT
        this.PrintLinePairKey(pair_info);
    #endif
        this.PrintLinePairValue(pair_info);
    }

    protected override void PrintLineInfo(string target_line)
    {
        this.webOutputFileStream.Write($"\'{target_line}\'");
    }

    protected override void PrintLinePairKey(KeyValuePair<int, string> pair)
    {
        this.webOutputFileStream.Write($"key = {pair.Key:X} | ");
    }

    protected override void PrintLinePairValue(KeyValuePair<int, string> pair)
    {
        this.webOutputFileStream.Write($"value = \"{pair.Value}\" | ");
    }

    private static string GenerateWebPageBegin()
    {
        string hypertext = "<!DOCTYPE html>";
        hypertext += "<html lang=\"en\">\n";
        hypertext += "<head>\n";
        hypertext += GetDocumentCharset("UTF-8");
        hypertext += GetDocumentName("Results");
        hypertext += GetStyles();
        hypertext += "</head>\n";
        hypertext += "<body>\n";
        return hypertext;
    }

    private static string GetDocumentCharset(string charset) => $"<meta charset=\"{charset}\">\n";

    private static string GetDocumentName(string title) => $"<title>{title}</title>\n";

    private static string GetStyles()
    {
        const string all_lines_css = " .all { color: green; font-size: 125%; } ";
        const string common_lines_css = " .common { color: red; font-size: 125%; } ";
        const string unique_lines_css = " .unique { color: blue; font-size: 125%; } ";

        return $"<style>{all_lines_css}{common_lines_css}{unique_lines_css}</style>\n";
    }

    private static string GenerateWebPageEnd() => "\n</body>\n</html>";
}
