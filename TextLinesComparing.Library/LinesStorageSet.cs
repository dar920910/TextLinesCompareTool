//-----------------------------------------------------------------------
// <copyright file="LinesStorageSet.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TextLinesComparing.Library;

public class LinesStorageSet
{
    private readonly SortedSet<string> currentLinesSet;

    public LinesStorageSet()
    {
        this.currentLinesSet = new SortedSet<string>();
        this.Name = "Lines Storage Set";
    }

    public LinesStorageSet(IEnumerable<string> sequence, string name = "Lines Storage Set")
    {
        this.currentLinesSet = new SortedSet<string>(sequence);
        this.Name = name;
    }

    public string Name { get; set; }

    public SortedSet<string> Content
    {
        get { return this.currentLinesSet; }
    }

    public void PutContent(LineInfo target_info)
    {
        this.currentLinesSet.Add(target_info.Content.Value);
    }
}
