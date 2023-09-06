namespace TextLinesComparing.Library;

public static class HashGenerator
{
    public static int GenerateLineHash(string target_string)
    {
        return target_string.GetHashCode();
    }
}
