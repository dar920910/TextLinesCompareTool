namespace TextLinesComparing.Library;

public class LinesRepository<LinesStorageContainer>
{
    private List<LinesStorageContainer> _UniqueLines;

    public LinesRepository()
    {
        _UniqueLines = new List<LinesStorageContainer>();
    }

    public void PutContent(LinesStorageContainer unique_info)
    {
        _UniqueLines.Add(unique_info);
    }

    public List<LinesStorageContainer> Content
    {
        get { return _UniqueLines; }
    }
}
