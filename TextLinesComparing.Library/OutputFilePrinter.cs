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

    public override void PrintArtifacts(LinesResultView result_artifact)
    {
        string outputFileName = DatetimeUtilities.GetCurrentDatetimeText() + ResultFileExtension;
        string outputFilePath = Path.Combine(this.outputDirectoryPath, outputFileName);
        this.outputFileStream = new (outputFilePath);

        this.PrintUncommentedContent(result_artifact.ContentFromSources);
        this.PrintUniqueContent(result_artifact.UniqueContentRepository);
        this.PrintCommonContent(result_artifact.CommonContentStorage);

        this.outputFileStream.Close();
    }

    protected override void PrintUncommentedContent(List<LinesStorage> content_repos)
    {
        this.PrintContentTitle("UNCOMMENTED LINES FROM ALL FILES");
        foreach (var content_element in content_repos)
        {
            this.PrintUncommentedContent(content_element);
        }
    }

    protected override void PrintUncommentedContent(LinesStorage target_content)
    {
        this.PrintUncommentedContentTitle(target_content.Name);
        Dictionary<int, string> uncommented_lines = target_content.Content;

        foreach (KeyValuePair<int, string> uncommented_line in uncommented_lines)
        {
            this.PrintLineInfo(uncommented_line);
        }

        this.outputFileStream.WriteLine();
    }

    protected override void PrintUniqueContent(List<LinesStorage> repos)
    {
        this.PrintContentTitle("UNIQUE LINES MAPS (HASH + STRING)");

        foreach (LinesStorage content_element in repos)
        {
            this.PrintUniqueContent(content_element);
        }

        this.outputFileStream.WriteLine();
    }

    protected override void PrintUniqueContent(LinesStorage content_element)
    {
        this.PrintUniqueContentTitle(content_element.Name);
        Dictionary<int, string> content_element_map = content_element.Content;

        foreach (KeyValuePair<int, string> content_pair in content_element_map)
        {
            this.PrintLineInfo(content_pair);
        }

        this.outputFileStream.WriteLine();
    }

    protected override void PrintCommonContent(LinesStorage target_content)
    {
        this.PrintContentTitle("COMMON LINES MAP");
        Dictionary<int, string> target_content_map = target_content.Content;

        foreach (KeyValuePair<int, string> element in target_content_map)
        {
            this.PrintLineInfo(element);
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
