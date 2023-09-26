//-----------------------------------------------------------------------
// <copyright file="LinesStorageMap.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TextLinesComparing.Library;

public class LinesStorageMap
{
    private readonly Dictionary<int, string> currentLinesMap;

    public LinesStorageMap()
    {
        this.currentLinesMap = new Dictionary<int, string>();
        this.Name = "Lines Storage Map";
    }

    public LinesStorageMap(LineInfo info, string name = "Lines Storage Map")
    {
        this.currentLinesMap = new Dictionary<int, string>()
        {
            { info.Content.Key, info.Content.Value },
        };

        this.Name = name;
    }

    public string Name { get; set; }

    public Dictionary<int, string> Content
    {
        get { return this.currentLinesMap; }
    }

    public void PutContent(LineInfo target_info)
    {
        this.currentLinesMap.Add(target_info.Content.Key, target_info.Content.Value);
    }
}
