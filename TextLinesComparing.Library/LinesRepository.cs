//-----------------------------------------------------------------------
// <copyright file="LinesRepository.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented

namespace TextLinesComparing.Library;

public class LinesRepository<TLinesStorageContainer>
{
    private readonly List<TLinesStorageContainer> reposUniqueLines;

    public LinesRepository()
    {
        this.reposUniqueLines = new List<TLinesStorageContainer>();
    }

    public List<TLinesStorageContainer> Content
    {
        get { return this.reposUniqueLines; }
    }

    public void PutContent(TLinesStorageContainer unique_info)
    {
        this.reposUniqueLines.Add(unique_info);
    }
}
