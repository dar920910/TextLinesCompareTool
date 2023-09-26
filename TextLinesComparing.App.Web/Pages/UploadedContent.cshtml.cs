//-----------------------------------------------------------------------
// <copyright file="UploadedContent.cshtml.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1649 // FileNameMustMatchTypeName

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class UploadedContentModel : PageModel
{
    public UploadedContentModel()
    {
        this.UploadedFiles = UploadsStore.UploadedFilePaths;
    }

    public List<string> UploadedFiles { get; }

    public void OnGet()
    {
        this.ViewData["Title"] = "TextLinesCompareTool (Uploaded Files)";
    }

    public IActionResult OnPost()
    {
        if (this.ModelState.IsValid)
        {
            return this.RedirectToPage("/results");
        }
        else
        {
            return this.Page();
        }
    }
}
