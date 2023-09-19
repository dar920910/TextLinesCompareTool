public static class UploadsStore
{
    public static List<string> UploadedFilePaths;
    static UploadsStore()
    {
        UploadedFilePaths = new();
    }
}
