namespace TextLinesComparing.Library;

public abstract class OutputAbstractDevice
{
    public virtual void PrintArtifacts(LinesResultView<LinesStorageMap> result_artifact)
    {
        PrintUncommentedContent(result_artifact.ContentFromSources);
        PrintUniqueContent(result_artifact.UniqueContentRepository);
        PrintCommonContent(result_artifact.CommonContentStorage);
    }

    public virtual void PrintArtifacts(LinesResultView<LinesStorageSet> result_artifact)
    {
        PrintUncommentedContent(result_artifact.ContentFromSources);
        PrintUniqueContent(result_artifact.UniqueContentRepository);
        PrintCommonContent(result_artifact.CommonContentStorage);
    }

    protected abstract void PrintUncommentedContent(LinesRepository<LinesStorageMap> content_repos);
    protected abstract void PrintUncommentedContent(LinesRepository<LinesStorageSet> content_repos);
    protected abstract void PrintUncommentedContent(LinesStorageMap target_content);
    protected abstract void PrintUncommentedContent(LinesStorageSet target_content);

    protected abstract void PrintUniqueContent(LinesRepository<LinesStorageMap> repos);
    protected abstract void PrintUniqueContent(LinesRepository<LinesStorageSet> repos);
    protected abstract void PrintUniqueContent(LinesStorageMap content_element);
    protected abstract void PrintUniqueContent(LinesStorageSet content_element);

    protected abstract void PrintCommonContent(LinesStorageMap target_content);
    protected abstract void PrintCommonContent(LinesStorageSet target_content);


    protected abstract void PrintContentTitle(string title_text);
    protected abstract void PrintUncommentedContentTitle(string source_name);
    protected abstract void PrintUniqueContentTitle(string source_name);

    protected abstract void PrintLineInfo(LineInfo target_info);
    protected abstract void PrintLineInfo(KeyValuePair<int, string> target_line);
    protected abstract void PrintLineInfo(string target_line);

    protected abstract void PrintLinePairKey(KeyValuePair<int, string> pair);
    protected abstract void PrintLinePairValue(KeyValuePair<int, string> pair);


    protected static string GetDelimiter() => new('=', 10);
    protected static string GetSubDelimiter() => new('-', 5);
}
