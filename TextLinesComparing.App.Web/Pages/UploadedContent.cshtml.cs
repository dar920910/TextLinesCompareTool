using Microsoft.AspNetCore.Mvc.RazorPages;

public class UploadedContentModel : PageModel
{
    public readonly List<string> UploadedFiles;
    public UploadedContentModel()
    {
        UploadedFiles = UploadsStore.UploadedFilePaths;
    }

    public void OnGet()
    {
        ViewData["Title"] = "TextLinesCompareTool (Uploaded Files)";
    }
}
