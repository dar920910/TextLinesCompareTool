#define HASH_OUTPUT

namespace TextLinesComparing.Library;

public class OutputWebPrinter : OutputAbstractDevice
{
    private StreamWriter _WebOutputFileStream;

    public OutputWebPrinter()
    {
        string outputFileName = new AppDatetimeService().GetCurrentDatetimeText() + ".html";
        _WebOutputFileStream = new(outputFileName);
    }

    ~OutputWebPrinter()
    {
        _WebOutputFileStream.Close();
    }


    public override void PrintArtifacts(LinesResultView<LinesStorageMap> result_artifact)
    {
        _WebOutputFileStream.WriteLine(GenerateWebPageBegin());
        PrintUncommentedContent(result_artifact.ContentFromSources);
        PrintUniqueContent(result_artifact.UniqueContentRepository);
        PrintCommonContent(result_artifact.CommonContentStorage);
        _WebOutputFileStream.WriteLine(GenerateWebPageEnd());
    }

    public override void PrintArtifacts(LinesResultView<LinesStorageSet> result_artifact)
    {
        _WebOutputFileStream.WriteLine(GenerateWebPageBegin());
        PrintUncommentedContent(result_artifact.ContentFromSources);
        PrintUniqueContent(result_artifact.UniqueContentRepository);
        PrintCommonContent(result_artifact.CommonContentStorage);
        _WebOutputFileStream.WriteLine(GenerateWebPageEnd());
    }


    protected override void PrintUncommentedContent(LinesRepository<LinesStorageMap> content_repos)
    {
        PrintContentTitle("UNCOMMENTED LINES FROM ALL FILES");
        foreach (LinesStorageMap content_element in content_repos.Content)
        {
            PrintUncommentedContent(content_element);
        }
    }

    protected override void PrintUncommentedContent(LinesRepository<LinesStorageSet> content_repos)
    {
        PrintContentTitle("UNCOMMENTED LINES FROM ALL FILES");
        foreach (LinesStorageSet content_element in content_repos.Content)
        {
            PrintUncommentedContent(content_element);
        }
    }

    protected override void PrintUncommentedContent(LinesStorageMap target_content)
    {
        PrintUncommentedContentTitle(target_content.Name);
        foreach (KeyValuePair<int, string> uncommented_line in target_content.Content)
        {
            _WebOutputFileStream.Write("<p class='all'>");
            _WebOutputFileStream.Write("LINE: ");
            PrintLineInfo(uncommented_line);
            _WebOutputFileStream.Write("</p>\n");
        }
        _WebOutputFileStream.WriteLine("<br>\n");
    }

    protected override void PrintUncommentedContent(LinesStorageSet target_content)
    {
        PrintUncommentedContentTitle(target_content.Name);
        foreach (string uncommented_line in target_content.Content)
        {
            _WebOutputFileStream.Write("<p>");
            _WebOutputFileStream.Write("LINE: ");
            PrintLineInfo(uncommented_line);
            _WebOutputFileStream.Write("</p>\n");
        }
        _WebOutputFileStream.WriteLine("<br>\n");
    }


    protected override void PrintUniqueContent(LinesRepository<LinesStorageMap> repos)
    {
        PrintContentTitle("UNIQUE LINES MAPS (HASH + STRING)");
        foreach (LinesStorageMap content_element in repos.Content)
        {
            PrintUniqueContent(content_element);
        }
        _WebOutputFileStream.WriteLine("<br>\n");
    }

    protected override void PrintUniqueContent(LinesRepository<LinesStorageSet> repos)
    {
        PrintContentTitle("UNIQUE LINES (SETS OF STRINGS)");
        foreach (LinesStorageSet unique_object in repos.Content)
        {
            PrintUniqueContent(unique_object);
        }
        _WebOutputFileStream.WriteLine("<br>\n");
    }


    protected override void PrintUniqueContent(LinesStorageMap content_element)
    {
        PrintUniqueContentTitle(content_element.Name);
        foreach (KeyValuePair<int, string> content_pair in content_element.Content)
        {
            _WebOutputFileStream.Write("<p class='unique'>");
            _WebOutputFileStream.Write("LINE: ");
            PrintLineInfo(content_pair);
            _WebOutputFileStream.Write("</p>\n");
        }
        _WebOutputFileStream.WriteLine("<br>");
    }

    protected override void PrintUniqueContent(LinesStorageSet content_element)
    {
        PrintUniqueContentTitle(content_element.Name);
        foreach (string content_unit in content_element.Content)
        {
            _WebOutputFileStream.Write("<p class='unique'>");
            _WebOutputFileStream.Write("LINE: ");
            PrintLineInfo(content_unit);
            _WebOutputFileStream.Write("</p>\n");
        }
        _WebOutputFileStream.WriteLine("<br>\n");
    }


    protected override void PrintCommonContent(LinesStorageMap target_content)
    {
        PrintContentTitle("COMMON LINES MAP");
        foreach (KeyValuePair<int, string> element in target_content.Content)
        {
            _WebOutputFileStream.Write("<p class='common'>");
            _WebOutputFileStream.Write("LINE: ");
            PrintLineInfo(element);
            _WebOutputFileStream.Write("</p>\n");
        }
        _WebOutputFileStream.WriteLine("<br>\n");
    }

    protected override void PrintCommonContent(LinesStorageSet target_content)
    {
        PrintContentTitle("COMMON LINES SET");
        foreach (string common_line in target_content.Content)
        {
            _WebOutputFileStream.Write("<p class='common'>");
            _WebOutputFileStream.Write("LINE: ");
            PrintLineInfo(common_line);
            _WebOutputFileStream.Write("</p>\n");
        }
        _WebOutputFileStream.WriteLine("<br>\n");
    }


    protected override void PrintContentTitle(string title_text)
    {
        _WebOutputFileStream.WriteLine(
            $"<br><h2>{GetDelimiter()} {title_text} {GetDelimiter()}</h2><br>\n");
    }

    protected override void PrintUncommentedContentTitle(string source_name)
    {
        _WebOutputFileStream.WriteLine(
            $"<h3>{GetSubDelimiter()} UNCOMMENTED LINES: {source_name} {GetSubDelimiter()}</h3><br>\n");
    }

    protected override void PrintUniqueContentTitle(string source_name)
    {
        _WebOutputFileStream.WriteLine(
            $"<h3>{GetSubDelimiter()} UNIQUE LINES: {source_name} {GetSubDelimiter()} + </h3><br>\n");
    }


    protected override void PrintLineInfo(LineInfo target_info)
    {
    #if HASH_OUTPUT
        PrintLinePairKey(target_info.Content);
    #endif
        PrintLinePairValue(target_info.Content);
    }

    protected override void PrintLineInfo(KeyValuePair<int, string> pair_info)
    {
    #if HASH_OUTPUT
        PrintLinePairKey(pair_info);
    #endif
        PrintLinePairValue(pair_info);
    }

    protected override void PrintLineInfo(string target_line)
    {
        _WebOutputFileStream.Write($"\'{target_line}\'");
    }


    protected override void PrintLinePairKey(KeyValuePair<int, string> pair)
    {
        _WebOutputFileStream.Write($"key = {pair.Key:X} | ");
    }

    protected override void PrintLinePairValue(KeyValuePair<int, string> pair)
    {
        _WebOutputFileStream.Write($"value = \"{pair.Value}\" | ");
    }

    private string GenerateWebPageBegin()
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

    private string GetDocumentCharset(string charset) => $"<meta charset=\"{charset}\">\n";
    private string GetDocumentName(string title) => $"<title>{title}</title>\n";

    private string GetStyles()
    {
        const string all_lines_css = " .all { color: green; font-size: 125%; } ";
        const string common_lines_css = " .common { color: red; font-size: 125%; } ";
        const string unique_lines_css = " .unique { color: blue; font-size: 125%; } ";

        return $"<style>{all_lines_css}{common_lines_css}{unique_lines_css}</style>\n";
    }

    private string GenerateWebPageEnd() => "\n</body>\n</html>";
}
