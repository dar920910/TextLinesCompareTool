using static System.Console;

namespace TextLinesComparing.Library;

public class OutputConsolePrinter : OutputAbstractDevice
{
    public OutputConsolePrinter() {}

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
        foreach (LinesStorageSet content_element in content_collection)
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
        WriteLine();
    }

    protected override void PrintUncommentedContent(LinesStorageSet target_content)
    {
        PrintUncommentedContentTitle(target_content.Name);
        SortedSet<string> uncommented_lines = target_content.Content;
        foreach (string uncommented_line in uncommented_lines)
        {
            PrintLineInfo(uncommented_line);
        }
        WriteLine();
    }


    protected override void PrintUniqueContent(LinesRepository<LinesStorageMap> repos)
    {
        PrintContentTitle("UNIQUE LINES MAPS (HASH + STRING)");
        List<LinesStorageMap> content_collection = repos.Content;
        foreach (var content_element in content_collection)
        {
            PrintUniqueContent(content_element);
        }
        WriteLine();
    }

    protected override void PrintUniqueContent(LinesRepository<LinesStorageSet> repos)
    {
        PrintContentTitle("UNIQUE LINES (SETS OF STRINGS)");
        foreach (LinesStorageSet unique_object in repos.Content)
        {
            PrintUniqueContent(unique_object);
        }
        WriteLine();
    }

    protected override void PrintUniqueContent(LinesStorageMap content_element)
    {
        PrintUniqueContentTitle(content_element.Name);
        Dictionary<int, string> content_element_map = content_element.Content;
        foreach (KeyValuePair<int, string> content_pair in content_element_map)
        {
            PrintLineInfo(content_pair);
        }
        WriteLine();
    }

    protected override void PrintUniqueContent(LinesStorageSet content_element)
    {
        PrintUniqueContentTitle(content_element.Name);
        SortedSet<string> content_element_set = content_element.Content;
        foreach (var content_unit in content_element_set)
        {
            PrintLineInfo(content_unit);
        }
        WriteLine();
    }


    protected override void PrintCommonContent(LinesStorageMap target_content)
    {
        PrintContentTitle("COMMON LINES MAP");
        Dictionary<int, string> target_content_map = target_content.Content;
        foreach (KeyValuePair<int, string> element in target_content_map)
        {
            PrintLineInfo(element);
        }
        WriteLine();
    }

    protected override void PrintCommonContent(LinesStorageSet target_content)
    {
        PrintContentTitle("COMMON LINES SET");
        SortedSet<string> target_content_set = target_content.Content;
        foreach (string common_line in target_content_set)
        {
            PrintLineInfo(common_line);
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
        PrintLinePairKey(content);
        PrintLinePairValue(content);
        WriteLine();
    }

    protected override void PrintLineInfo(KeyValuePair<int, string> pair_info)
    {
        Write("LINE: ");
        PrintLinePairKey(pair_info);
        PrintLinePairValue(pair_info);
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
