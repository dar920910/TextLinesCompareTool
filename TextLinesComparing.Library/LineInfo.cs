//-----------------------------------------------------------------------
// <copyright file="LineInfo.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TextLinesComparing.Library;

/// <summary>
/// Represents information about a string from a source text file.
/// </summary>
public record LineInfo
{
    private readonly string currentLineString;
    private readonly int currentLineHash;

    /// <summary>
    /// Initializes a new instance of the <see cref="LineInfo"/> class.
    /// </summary>
    /// <param name="target">Raw string from a source text file.</param>
    public LineInfo(string target)
    {
        this.currentLineString = target;
        this.currentLineHash = GenerateLineHash(target);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LineInfo"/> class.
    /// </summary>
    /// <param name="target">Target key-value pair.</param>
    public LineInfo(KeyValuePair<int, string> target)
    {
        this.currentLineString = target.Value;
        this.currentLineHash = target.Key;
    }

    /// <summary>
    /// Gets the information about the current line via its key-value pair.
    /// </summary>
    public KeyValuePair<int, string> Content
    {
        get { return new KeyValuePair<int, string>(this.currentLineHash, this.currentLineString); }
    }

    /// <summary>
    /// Generates the hash value for a string.
    /// </summary>
    /// <param name="target_string">Target string for hashing.</param>
    /// <returns>Hash value of a target string.</returns>
    public static int GenerateLineHash(string target_string)
    {
        return target_string.GetHashCode();
    }
}
