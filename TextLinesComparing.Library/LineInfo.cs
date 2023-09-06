namespace TextLinesComparing.Library;

public class LineInfo
{
    private readonly string _LineString;
    private readonly int _LineHash;

    public LineInfo(string target)
    {
        _LineString = target;
        _LineHash = target.GetHashCode();
    }

    public LineInfo(KeyValuePair<int, string> target)
    {
        _LineString = target.Value;
        _LineHash = target.Key;
    }

    public KeyValuePair<int, string> Content
    {
        get { return new KeyValuePair<int, string>(_LineHash, _LineString); }
    }
}
