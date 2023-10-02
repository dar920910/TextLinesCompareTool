//-----------------------------------------------------------------------
// <copyright file="UploadsStore.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented

public static class UploadsStore
{
    static UploadsStore()
    {
        UploadedFilePaths = new ();
    }

    public static List<string> UploadedFilePaths { get; set; }
}
