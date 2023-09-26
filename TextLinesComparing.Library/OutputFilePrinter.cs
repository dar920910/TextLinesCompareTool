namespace TextLinesComparing.Library;

public class OutputFilePrinter : OutputAbstractDevice
{
    private const string RESULT_FOLDER_NAME = "~output";
    private const string RESULT_FILE_EXTENSION = ".txt";
    private readonly string _OutputDirectoryPath;
    private StreamWriter _OutputFileStream;

    public OutputFilePrinter()
    {
        _OutputDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), RESULT_FOLDER_NAME);

        if (Directory.Exists(_OutputDirectoryPath) is false)
        {
            Directory.CreateDirectory(_OutputDirectoryPath);
        }
    }

    public override void PrintArtifacts(LinesResultView<LinesStorageMap> result_artifact)
    {
        string outputFileName = DatetimeUtilities.GetCurrentDatetimeText() + RESULT_FILE_EXTENSION;
        string outputFilePath = Path.Combine(_OutputDirectoryPath, outputFileName);
        _OutputFileStream = new(outputFilePath);

        PrintUncommentedContent(result_artifact.ContentFromSources);
        PrintUniqueContent(result_artifact.UniqueContentRepository);
        PrintCommonContent(result_artifact.CommonContentStorage);

        _OutputFileStream.Close();
    }

    public override void PrintArtifacts(LinesResultView<LinesStorageSet> result_artifact)
    {
        string outputFileName = DatetimeUtilities.GetCurrentDatetimeText() + RESULT_FILE_EXTENSION;
        string outputFilePath = Path.Combine(_OutputDirectoryPath, outputFileName);
        _OutputFileStream = new(outputFilePath);

        PrintUncommentedContent(result_artifact.ContentFromSources);
        PrintUniqueContent(result_artifact.UniqueContentRepository);
        PrintCommonContent(result_artifact.CommonContentStorage);

        _OutputFileStream.Close();
    }


    protected override void PrintUncommentedContent(LinesRepository<LinesStorageMap> content_repos)
    {
        PrintContentTitle("UNCOMMENTED LINES FROM ALL FILES");
        List<LinesStorageMap> content_collection = content_repos.Content;
        foreach (var content_element in content_collection)
        {
            PrintUncommentedContent(content_element);
        }
    }

    protected override void PrintUncommentedContent(LinesRepository<LinesStorageSet> content_repos)
    {
        PrintContentTitle("UNCOMMENTED LINES FROM ALL FILES");
        List<LinesStorageSet> content_collection = content_repos.Content;
        foreach (var content_element in content_collection)
        {
            PrintUncommentedContent(content_element);
        }
    }

    protected override void PrintUncommentedContent(LinesStorageMap target_content)
    {
        PrintUncommentedContentTitle(target_content.Name);
        Dictionary<int, string> uncommented_lines = target_content.Content;
        foreach (KeyValuePair<int, string> uncommented_line in uncommented_lines)
        {
            PrintLineInfo(uncommented_line);
        }
        _OutputFileStream.WriteLine();
    }

    protected override void PrintUncommentedContent(LinesStorageSet target_content)
    {
        PrintUncommentedContentTitle(target_content.Name);
        SortedSet<string> uncommented_lines = target_content.Content;
        foreach (string uncommented_line in uncommented_lines)
        {
            PrintLineInfo(uncommented_line);
        }
        _OutputFileStream.WriteLine();
    }


    protected override void PrintUniqueContent(LinesRepository<LinesStorageMap> repos)
    {
        PrintContentTitle("UNIQUE LINES MAPS (HASH + STRING)");
        foreach (LinesStorageMap content_element in repos.Content)
        {
            PrintUniqueContent(content_element);
        }
        _OutputFileStream.WriteLine();
    }

    protected override void PrintUniqueContent(LinesRepository<LinesStorageSet> repos)
    {
        PrintContentTitle("UNIQUE LINES (SETS OF STRINGS)");
        foreach (LinesStorageSet unique_object in repos.Content)
        {
            PrintUniqueContent(unique_object);
        }
        _OutputFileStream.WriteLine();
    }

    protected override void PrintUniqueContent(LinesStorageMap content_element)
    {
        PrintUniqueContentTitle(content_element.Name);
        Dictionary<int, string> content_element_map = content_element.Content;
        foreach (KeyValuePair<int, string> content_pair in content_element_map)
        {
            PrintLineInfo(content_pair);
        }
        _OutputFileStream.WriteLine();
    }

    protected override void PrintUniqueContent(LinesStorageSet content_element)
    {
        PrintUniqueContentTitle(content_element.Name);
        SortedSet<string> content_element_set = content_element.Content;
        foreach (string content_unit in content_element_set)
        {
            PrintLineInfo(content_unit);
        }
        _OutputFileStream.WriteLine();
    }


    protected override void PrintCommonContent(LinesStorageMap target_content)
    {
        PrintContentTitle("COMMON LINES MAP");
        Dictionary<int, string> target_content_map = target_content.Content;
        foreach (KeyValuePair<int, string> element in target_content_map)
        {
            PrintLineInfo(element);
        }
        _OutputFileStream.WriteLine();
    }

    protected override void PrintCommonContent(LinesStorageSet target_content)
    {
        PrintContentTitle("COMMON LINES SET");
        SortedSet<string> target_content_set = target_content.Content;
        foreach (string common_line in target_content_set)
        {
            PrintLineInfo(common_line);
        }
        _OutputFileStream.WriteLine();
    }


    protected override void PrintContentTitle(string title_text)
    {
        _OutputFileStream.WriteLine(
            $"\n{GetDelimiter()} {title_text} {GetDelimiter()}\n");
    }

    protected override void PrintUncommentedContentTitle(string source_name)
    {
        _OutputFileStream.WriteLine(
            $"{GetSubDelimiter()} UNCOMMENTED LINES: {source_name} {GetSubDelimiter()}\n");
    }

    protected override void PrintUniqueContentTitle(string source_name)
    {
        _OutputFileStream.WriteLine(
            $"{GetSubDelimiter()} UNIQUE LINES: {source_name} {GetSubDelimiter()}\n");
    }


    protected override void PrintLineInfo(LineInfo target_info)
    {
        _OutputFileStream.Write("LINE: ");
        PrintLinePairKey(target_info.Content);
        PrintLinePairValue(target_info.Content);
        _OutputFileStream.WriteLine();
    }

    protected override void PrintLineInfo(KeyValuePair<int, string> pair_info)
    {
        _OutputFileStream.Write("LINE: ");
        PrintLinePairKey(pair_info);
        PrintLinePairValue(pair_info);
        _OutputFileStream.WriteLine();
    }

    protected override void PrintLineInfo(string target_line)
    {
        _OutputFileStream.Write("LINE: ");
        _OutputFileStream.Write($"\'{target_line}\'");
        _OutputFileStream.WriteLine();
    }


    protected override void PrintLinePairKey(KeyValuePair<int, string> pair)
    {
        _OutputFileStream.Write($"key = {pair.Key:X} | ");
    }

    protected override void PrintLinePairValue(KeyValuePair<int, string> pair)
    {
        _OutputFileStream.Write($"value = \"{pair.Value}\" | ");
    }
}
