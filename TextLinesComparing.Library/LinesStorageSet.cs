namespace TextLinesComparing.Library;

public class LinesStorageSet
{
    public readonly string Name;
    private SortedSet<string> _LinesSet;

    public LinesStorageSet()
    {
        Name = "Lines Storage Set";
        _LinesSet = new SortedSet<string>();
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
