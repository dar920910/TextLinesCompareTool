namespace TextLinesComparing.Library;

public static class AppLaunchConfiguration
{
    public static List<string> GetArgumentsOfSources(string[] arguments)
    {
        List<string> argumentsOfSources = new();

        for (int arg_index = 1; arg_index < arguments.Length; arg_index++)
        {
            argumentsOfSources.Add(arguments[arg_index]);
        }

        return argumentsOfSources;
    }
}
