//-----------------------------------------------------------------------
// <copyright file="OutputFilePrinter.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TextLinesComparing.Library;

public class OutputFilePrinter : OutputAbstractDevice
{
    private const string ResultFolderName = "~output";
    private const string ResultFileExtension = ".txt";

    private readonly string outputDirectoryPath;
    private StreamWriter outputFileStream;

    public OutputFilePrinter()
    {
        this.outputDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), ResultFolderName);

        if (Directory.Exists(this.outputDirectoryPath) is false)
        {
            Directory.CreateDirectory(this.outputDirectoryPath);
        }
    }

    public override void PrintArtifacts(LinesResultView<LinesStorageMap> result_artifact)
    {
        string outputFileName = DatetimeUtilities.GetCurrentDatetimeText() + ResultFileExtension;
        string outputFilePath = Path.Combine(this.outputDirectoryPath, outputFileName);
        this.outputFileStream = new (outputFilePath);

        this.PrintUncommentedContent(result_artifact.ContentFromSources);
        this.PrintUniqueContent(result_artifact.UniqueContentRepository);
        this.PrintCommonContent(result_artifact.CommonContentStorage);

        this.outputFileStream.Close();
    }

    public override void PrintArtifacts(LinesResultView<LinesStorageSet> result_artifact)
    {
        string outputFileName = DatetimeUtilities.GetCurrentDatetimeText() + ResultFileExtension;
        string outputFilePath = Path.Combine(this.outputDirectoryPath, outputFileName);
        this.outputFileStream = new (outputFilePath);

        this.PrintUncommentedContent(result_artifact.ContentFromSources);
        this.PrintUniqueContent(result_artifact.UniqueContentRepository);
        this.PrintCommonContent(result_artifact.CommonContentStorage);

        this.outputFileStream.Close();
    }

    protected override void PrintUncommentedContent(LinesRepository<LinesStorageMap> content_repos)
    {
        this.PrintContentTitle("UNCOMMENTED LINES FROM ALL FILES");
        List<LinesStorageMap> content_collection = content_repos.Content;

        foreach (var content_element in content_collection)
        {
            this.PrintUncommentedContent(content_element);
        }
    }

    protected override void PrintUncommentedContent(LinesRepository<LinesStorageSet> content_repos)
    {
        this.PrintContentTitle("UNCOMMENTED LINES FROM ALL FILES");
        List<LinesStorageSet> content_collection = content_repos.Content;

        foreach (var content_element in content_collection)
        {
            this.PrintUncommentedContent(content_element);
        }
    }

    protected override void PrintUncommentedContent(LinesStorageMap target_content)
    {
        this.PrintUncommentedContentTitle(target_content.Name);
        Dictionary<int, string> uncommented_lines = target_content.Content;

        foreach (KeyValuePair<int, string> uncommented_line in uncommented_lines)
        {
            this.PrintLineInfo(uncommented_line);
        }

        this.outputFileStream.WriteLine();
    }

    protected override void PrintUncommentedContent(LinesStorageSet target_content)
    {
        this.PrintUncommentedContentTitle(target_content.Name);
        SortedSet<string> uncommented_lines = target_content.Content;

        foreach (string uncommented_line in uncommented_lines)
        {
            this.PrintLineInfo(uncommented_line);
        }

        this.outputFileStream.WriteLine();
    }

    protected override void PrintUniqueContent(LinesRepository<LinesStorageMap> repos)
    {
        this.PrintContentTitle("UNIQUE LINES MAPS (HASH + STRING)");

        foreach (LinesStorageMap content_element in repos.Content)
        {
            this.PrintUniqueContent(content_element);
        }

        this.outputFileStream.WriteLine();
    }

    protected override void PrintUniqueContent(LinesRepository<LinesStorageSet> repos)
    {
        this.PrintContentTitle("UNIQUE LINES (SETS OF STRINGS)");

        foreach (LinesStorageSet unique_object in repos.Content)
        {
            this.PrintUniqueContent(unique_object);
        }

        this.outputFileStream.WriteLine();
    }

    protected override void PrintUniqueContent(LinesStorageMap content_element)
    {
        this.PrintUniqueContentTitle(content_element.Name);
        Dictionary<int, string> content_element_map = content_element.Content;

        foreach (KeyValuePair<int, string> content_pair in content_element_map)
        {
            this.PrintLineInfo(content_pair);
        }

        this.outputFileStream.WriteLine();
    }

    protected override void PrintUniqueContent(LinesStorageSet content_element)
    {
        this.PrintUniqueContentTitle(content_element.Name);
        SortedSet<string> content_element_set = content_element.Content;

        foreach (string content_unit in content_element_set)
        {
            this.PrintLineInfo(content_unit);
        }

        this.outputFileStream.WriteLine();
    }

    protected override void PrintCommonContent(LinesStorageMap target_content)
    {
        this.PrintContentTitle("COMMON LINES MAP");
        Dictionary<int, string> target_content_map = target_content.Content;

        foreach (KeyValuePair<int, string> element in target_content_map)
        {
            this.PrintLineInfo(element);
        }

        this.outputFileStream.WriteLine();
    }

    protected override void PrintCommonContent(LinesStorageSet target_content)
    {
        this.PrintContentTitle("COMMON LINES SET");
        SortedSet<string> target_content_set = target_content.Content;

        foreach (string common_line in target_content_set)
        {
            this.PrintLineInfo(common_line);
        }

        this.outputFileStream.WriteLine();
    }

    protected override void PrintContentTitle(string title_text)
    {
        this.outputFileStream.WriteLine(
            $"\n{GetDelimiter()} {title_text} {GetDelimiter()}\n");
    }

    protected override void PrintUncommentedContentTitle(string source_name)
    {
        this.outputFileStream.WriteLine(
            $"{GetSubDelimiter()} UNCOMMENTED LINES: {source_name} {GetSubDelimiter()}\n");
    }

    protected override void PrintUniqueContentTitle(string source_name)
    {
        this.outputFileStream.WriteLine(
            $"{GetSubDelimiter()} UNIQUE LINES: {source_name} {GetSubDelimiter()}\n");
    }

    protected override void PrintLineInfo(LineInfo target_info)
    {
        this.outputFileStream.Write("LINE: ");
        this.PrintLinePairKey(target_info.Content);
        this.PrintLinePairValue(target_info.Content);
        this.outputFileStream.WriteLine();
    }

    protected override void PrintLineInfo(KeyValuePair<int, string> pair_info)
    {
        this.outputFileStream.Write("LINE: ");
        this.PrintLinePairKey(pair_info);
        this.PrintLinePairValue(pair_info);
        this.outputFileStream.WriteLine();
    }

    protected override void PrintLineInfo(string target_line)
    {
        this.outputFileStream.Write("LINE: ");
        this.outputFileStream.Write($"\'{target_line}\'");
        this.outputFileStream.WriteLine();
    }

    protected override void PrintLinePairKey(KeyValuePair<int, string> pair)
    {
        this.outputFileStream.Write($"key = {pair.Key:X} | ");
    }

    protected override void PrintLinePairValue(KeyValuePair<int, string> pair)
    {
        this.outputFileStream.Write($"value = \"{pair.Value}\" | ");
    }
}
