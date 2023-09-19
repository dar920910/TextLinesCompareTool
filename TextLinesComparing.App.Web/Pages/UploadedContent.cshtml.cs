using Microsoft.AspNetCore.Mvc;
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

    public IActionResult OnPost() // CompareUploadedFiles
    {
        if (ModelState.IsValid)
        {
            return RedirectToPage("/results");
        }
        else
        {
            return Page();
        }
    }
}
