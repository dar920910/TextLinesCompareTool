namespace TextLinesComparing.Library;

public class LinesStorageSet
{
    public string Name { get; set; }
    private SortedSet<string> _LinesSet;

    public LinesStorageSet()
    {
        _LinesSet = new SortedSet<string>();
        Name = "Lines Storage Set";
    }

    public LinesStorageSet(IEnumerable<string> sequence, string name = "Lines Storage Set")
    {
        _LinesSet = new SortedSet<string>(sequence);
        Name = name;
    }

    public void PutContent(string content)
    {
        _LinesSet.Add(content);
    }

    public SortedSet<string> Content
    {
        get { return _LinesSet; }
    }
};
