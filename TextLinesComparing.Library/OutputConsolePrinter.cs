//-----------------------------------------------------------------------
// <copyright file="OutputConsolePrinter.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TextLinesComparing.Library;

using static System.Console;

public class OutputConsolePrinter : OutputAbstractDevice
{
    public OutputConsolePrinter()
    {
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
        foreach (LinesStorageSet content_element in content_collection)
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

        WriteLine();
    }

    protected override void PrintUncommentedContent(LinesStorageSet target_content)
    {
        this.PrintUncommentedContentTitle(target_content.Name);
        SortedSet<string> uncommented_lines = target_content.Content;

        foreach (string uncommented_line in uncommented_lines)
        {
            this.PrintLineInfo(uncommented_line);
        }

        WriteLine();
    }

    protected override void PrintUniqueContent(LinesRepository<LinesStorageMap> repos)
    {
        this.PrintContentTitle("UNIQUE LINES MAPS (HASH + STRING)");
        List<LinesStorageMap> content_collection = repos.Content;

        foreach (var content_element in content_collection)
        {
            this.PrintUniqueContent(content_element);
        }

        WriteLine();
    }

    protected override void PrintUniqueContent(LinesRepository<LinesStorageSet> repos)
    {
        this.PrintContentTitle("UNIQUE LINES (SETS OF STRINGS)");

        foreach (LinesStorageSet unique_object in repos.Content)
        {
            this.PrintUniqueContent(unique_object);
        }

        WriteLine();
    }

    protected override void PrintUniqueContent(LinesStorageMap content_element)
    {
        this.PrintUniqueContentTitle(content_element.Name);

        Dictionary<int, string> content_element_map = content_element.Content;
        foreach (KeyValuePair<int, string> content_pair in content_element_map)
        {
            this.PrintLineInfo(content_pair);
        }

        WriteLine();
    }

    protected override void PrintUniqueContent(LinesStorageSet content_element)
    {
        this.PrintUniqueContentTitle(content_element.Name);
        SortedSet<string> content_element_set = content_element.Content;

        foreach (var content_unit in content_element_set)
        {
            this.PrintLineInfo(content_unit);
        }

        WriteLine();
    }

    protected override void PrintCommonContent(LinesStorageMap target_content)
    {
        this.PrintContentTitle("COMMON LINES MAP");
        Dictionary<int, string> target_content_map = target_content.Content;

        foreach (KeyValuePair<int, string> element in target_content_map)
        {
            this.PrintLineInfo(element);
        }

        WriteLine();
    }

    protected override void PrintCommonContent(LinesStorageSet target_content)
    {
        this.PrintContentTitle("COMMON LINES SET");
        SortedSet<string> target_content_set = target_content.Content;
        foreach (string common_line in target_content_set)
        {
            this.PrintLineInfo(common_line);
        }

        WriteLine();
    }

    protected override void PrintContentTitle(string title_text)
    {
        WriteLine($"\n{GetDelimiter()} {title_text} {GetDelimiter()}\n");
    }

    protected override void PrintUncommentedContentTitle(string source_name)
    {
        WriteLine($"{GetSubDelimiter()} UNCOMMENTED LINES: {source_name} {GetSubDelimiter()}\n");
    }

    protected override void PrintUniqueContentTitle(string source_name)
    {
        WriteLine($"{GetSubDelimiter()} UNIQUE LINES: {source_name} {GetSubDelimiter()}\n");
    }

    protected override void PrintLineInfo(LineInfo target_info)
    {
        KeyValuePair<int, string> content = target_info.Content;

        Write("LINE: ");
        this.PrintLinePairKey(content);
        this.PrintLinePairValue(content);
        WriteLine();
    }

    protected override void PrintLineInfo(KeyValuePair<int, string> pair_info)
    {
        Write("LINE: ");
        this.PrintLinePairKey(pair_info);
        this.PrintLinePairValue(pair_info);
        WriteLine();
    }

    protected override void PrintLineInfo(string target_line)
    {
        Write("LINE: ");
        Write($"\'{target_line}\'");
        WriteLine();
    }

    protected override void PrintLinePairKey(KeyValuePair<int, string> pair)
    {
        Write($"key = {pair.Key:X} | ");
    }

    protected override void PrintLinePairValue(KeyValuePair<int, string> pair)
    {
        Write($"value = \"{pair.Value}\"");
    }
}
