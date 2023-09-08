namespace TextLinesComparing.Library;

public record LinesResultView<LinesStorageContainer>
{
    public LinesRepository<LinesStorageContainer> ContentFromSources;
    public LinesStorageContainer CommonContentStorage;
    public LinesRepository<LinesStorageContainer> UniqueContentRepository;
}
