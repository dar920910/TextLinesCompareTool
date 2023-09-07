namespace TextLinesComparing.Library;

public class LinesStorageMap
{
    public string Name { get; set; }
    private Dictionary<int, string> _LinesMap;

    public LinesStorageMap()
    {
        _LinesMap = new Dictionary<int, string>();
        Name = "Lines Storage Map";
    }

    public LinesStorageMap(LineInfo info, string name = "Lines Storage Map")
    {
        _LinesMap = new Dictionary<int, string>()
        {
            { info.Content.Key, info.Content.Value }
        };
        Name = name;
    }

    public void PutContent(LineInfo target_info)
    {
        _LinesMap.Add(target_info.Content.Key, target_info.Content.Value);
    }

    public Dictionary<int, string> Content
    {
        get { return _LinesMap; }
    }
};
