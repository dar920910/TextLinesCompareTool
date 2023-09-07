namespace TextLinesComparing.Library;

public static class LinesMainProcessor
{
    public static LinesStorageMap ExtractCommonContent(LinesStorageMap first_storage, LinesStorageMap second_storage)
    {
        LinesStorageMap common_content = new();

        Dictionary<int, string> first_map = first_storage.Content;
        Dictionary<int, string> second_map = second_storage.Content;

        foreach (KeyValuePair<int, string> first_pair in first_map)
        {
            foreach (KeyValuePair<int, string> second_pair in second_map)
            {
                if (first_pair.Key == second_pair.Key)
                {
                    common_content.PutContent(new LineInfo(first_pair));
                }
            }
        }

        return common_content;
    }

    public static LinesStorageSet ExtractCommonContent(LinesStorageSet first_storage, LinesStorageSet second_storage)
    {
        SortedSet<string> first_content = first_storage.Content;
        SortedSet<string> second_content = second_storage.Content;
        IEnumerable<string> extractedCommonLines = first_content.Intersect(second_content);
        return new LinesStorageSet(extractedCommonLines);
    }


    public static LinesStorageMap ExtractUniqueContent(LinesStorageMap target_storage, LinesStorageMap compared_storage)
    {
        LinesStorageMap unique_content_map = new()
        {
            Name = target_storage.Name
        };

        Dictionary<int, string> target_content_map = target_storage.Content;
        Dictionary<int, string> compared_content_map = compared_storage.Content;

        foreach (KeyValuePair<int, string> pair in target_content_map)
        {
            if (compared_content_map.ContainsKey(pair.Key) is false)
            {
                unique_content_map.PutContent(new LineInfo(pair));
            }
        }

        return unique_content_map;
    }

    public static LinesStorageSet ExtractUniqueContent(LinesStorageSet target_storage, LinesStorageSet compared_storage)
    {
        LinesStorageSet extractedUniqueLines = new()
        {
            Name = target_storage.Name
        };

        SortedSet<string> target_content = target_storage.Content;
        SortedSet<string> compared_content = compared_storage.Content;

        foreach (var target_element in target_content)
        {
            if (IsUniqueLineInSource(target_element, compared_content))
            {
                extractedUniqueLines.PutContent(target_element);
            }
        }

        return extractedUniqueLines;
    }


    private static bool IsUniqueLineInSource(string unique_object, SortedSet<string> source)
    {
        if (source.Contains(unique_object))
        {
            return false;
        }

        return true;
    }
}
