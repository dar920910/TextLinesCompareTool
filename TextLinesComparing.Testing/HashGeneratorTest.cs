using TextLinesComparing.Library;

namespace TextLinesComparing.Testing;


public class HashGeneratorTest
{
    [Test]
    public void CalculateHashForString()
    {
        const string test_string = "A-B-C-D-E-F-G-H";
    
        int expected_hash = test_string.GetHashCode();
        int actual_hash = HashGenerator.GenerateLineHash(test_string);
    
        Assert.That(actual_hash, Is.EqualTo(expected_hash));
    }

    [Test]
    public void CompareHashForEqualStrings()
    {
        const string test_string_1 = "A-B-C-D-E-F-G-H";
        const string test_string_2 = "A-B-C-D-E-F-G-H";

        int hash_1 = HashGenerator.GenerateLineHash(test_string_1);
        int hash_2 = HashGenerator.GenerateLineHash(test_string_2);

        Assert.That(actual: hash_1, expression: Is.EqualTo(hash_2));
    }

    [Test]
    public void CompareHashForNotEqualStrings()
    {
        const string test_string_1 = "A-B-C-D-E-F-G-H";
        const string test_string_2 = "a-b-c-d-e-f-g-h";
    
        int hash_1 = HashGenerator.GenerateLineHash(test_string_1);
        int hash_2 = HashGenerator.GenerateLineHash(test_string_2);
    
        Assert.That(actual: hash_1, expression: Is.Not.EqualTo(hash_2));
    }


    [Test]
    public void CompareHashForCustomEqualStrings()
    {
        Assert.Multiple(() =>
        {
            Assert.That(
            actual: HashGenerator.GenerateLineHash("0123456789"),
            expression: Is.EqualTo("0123456789".GetHashCode()));

            Assert.That(
                actual: HashGenerator.GenerateLineHash("1234567890"),
                expression: Is.EqualTo("1234567890".GetHashCode()));

            Assert.That(
                actual: HashGenerator.GenerateLineHash("2345678901"),
                expression: Is.EqualTo("2345678901".GetHashCode()));

            Assert.That(
                actual: HashGenerator.GenerateLineHash("3456789012"),
                expression: Is.EqualTo("3456789012".GetHashCode()));

            Assert.That(
                actual: HashGenerator.GenerateLineHash("4567890123"),
                expression: Is.EqualTo("4567890123".GetHashCode()));

            Assert.That(
                actual: HashGenerator.GenerateLineHash("5678901234"),
                expression: Is.EqualTo("5678901234".GetHashCode()));

            Assert.That(
                actual: HashGenerator.GenerateLineHash("6789012345"),
                expression: Is.EqualTo("6789012345".GetHashCode()));

            Assert.That(
                actual: HashGenerator.GenerateLineHash("7890123456"),
                expression: Is.EqualTo("7890123456".GetHashCode()));

            Assert.That(
                actual: HashGenerator.GenerateLineHash("8901234567"),
                expression: Is.EqualTo("8901234567".GetHashCode()));

            Assert.That(
                actual: HashGenerator.GenerateLineHash("9012345678"),
                expression: Is.EqualTo("9012345678".GetHashCode()));
        });
    }

    [Test]
    public void CompareHashForCustomNotEqualStrings()
    {
        Assert.Multiple(() =>
        {
            Assert.That(
                actual: HashGenerator.GenerateLineHash("012345678"),
                expression: Is.Not.EqualTo("123456789".GetHashCode()));

            Assert.That(
                actual: HashGenerator.GenerateLineHash("123456789"),
                expression: Is.Not.EqualTo("234567890".GetHashCode()));
            Assert.That(
                actual: HashGenerator.GenerateLineHash("234567890"),
                expression: Is.Not.EqualTo("345678901".GetHashCode()));
            Assert.That(
                actual: HashGenerator.GenerateLineHash("345678901"),
                expression: Is.Not.EqualTo("456789012".GetHashCode()));
            Assert.That(
                actual: HashGenerator.GenerateLineHash("456789012"),
                expression: Is.Not.EqualTo("567890123".GetHashCode()));
            Assert.That(
                actual: HashGenerator.GenerateLineHash("567890123"),
                expression: Is.Not.EqualTo("678901234".GetHashCode()));
            Assert.That(
                actual: HashGenerator.GenerateLineHash("678901234"),
                expression: Is.Not.EqualTo("789012345".GetHashCode()));
            Assert.That(
                actual: HashGenerator.GenerateLineHash("789012345"),
                expression: Is.Not.EqualTo("890123456".GetHashCode()));
            Assert.That(
                actual: HashGenerator.GenerateLineHash("890123456"),
                expression: Is.Not.EqualTo("901234567".GetHashCode()));
            Assert.That(
                actual: HashGenerator.GenerateLineHash("901234567"),
                expression: Is.Not.EqualTo("012345678".GetHashCode()));
        });
    }
}
