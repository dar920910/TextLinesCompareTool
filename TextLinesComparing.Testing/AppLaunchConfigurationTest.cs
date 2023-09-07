using TextLinesComparing.Library;

namespace TextLinesComparing.Testing;

public class AppLaunchConfigurationTest
{
    private static readonly string exec_arg = "app";
    private static readonly  string src_1 = "src_1.txt";
    private static readonly  string src_2 = "src_2.txt";
    private static readonly  string src_3 = "src_3.txt";
    private static readonly  string src_4 = "src_4.txt";

    [Test]
    public void ArgumentsDoNotContainSources()
    {
        string[] args = { exec_arg };
        Assert.That(AppLaunchConfiguration.GetArgumentsOfSources(args), Is.Empty);
    }

    [Test]
    public void ArgumentsContainSources_TestCase_1()
    {
        string[] args = { exec_arg, src_1, };
        Assert.That(AppLaunchConfiguration.GetArgumentsOfSources(args), Has.Count.EqualTo(1));
    }

    [Test]
    public void ArgumentsContainSources_TestCase_2()
    {
        string[] args = { exec_arg, src_1, src_2 };
        Assert.That(AppLaunchConfiguration.GetArgumentsOfSources(args), Has.Count.EqualTo(2));
    }

    [Test]
    public void ArgumentsContainSources_TestCase_3()
    {
        string[] args = { exec_arg, src_1, src_2, src_3 };
        Assert.That(AppLaunchConfiguration.GetArgumentsOfSources(args), Has.Count.EqualTo(3));
    }

    [Test]
    public void ArgumentsContainSources_TestCase_4()
    {
        string[] args = { exec_arg, src_1, src_2, src_3, src_4 };
        Assert.That(AppLaunchConfiguration.GetArgumentsOfSources(args), Has.Count.EqualTo(4));
    }
}