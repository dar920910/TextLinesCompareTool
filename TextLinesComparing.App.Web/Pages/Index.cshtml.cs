//-----------------------------------------------------------------------
// <copyright file="Index.cshtml.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1649 // FileNameMustMatchTypeName

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private readonly IWebHostEnvironment currentEnvironment;
    private readonly string uploadsFolderName;

    public IndexModel(IWebHostEnvironment environment)
    {
        this.currentEnvironment = environment;

        this.uploadsFolderName = Path.Combine(this.currentEnvironment.WebRootPath, "uploads");
        if (Directory.Exists(this.uploadsFolderName) is false)
        {
            Directory.CreateDirectory(this.uploadsFolderName);
        }
    }

    [BindProperty]
    public IFormFile? Upload_1 { get; set; }

    [BindProperty]
    public IFormFile? Upload_2 { get; set; }

    [BindProperty]
    public IFormFile? Upload_3 { get; set; }

    [BindProperty]
    public IFormFile? Upload_4 { get; set; }

    [BindProperty]
    public IFormFile? Upload_5 { get; set; }

    [BindProperty]
    public IFormFile? Upload_6 { get; set; }

    [BindProperty]
    public IFormFile? Upload_7 { get; set; }

    [BindProperty]
    public IFormFile? Upload_8 { get; set; }

    [BindProperty]
    public IFormFile? Upload_9 { get; set; }

    public void OnGet()
    {
        this.ViewData["Title"] = "TextLinesCompareTool";
    }

    public async Task<IActionResult> OnPostUploadFilesAsync()
    {
        IFormFile[] uploads =
        {
            this.Upload_1!,
            this.Upload_2!,
            this.Upload_3!,
            this.Upload_4!,
            this.Upload_5!,
            this.Upload_6!,
            this.Upload_7!,
            this.Upload_8!,
            this.Upload_9!,
        };

        List<string> uploadedFilePaths = new ();

        foreach (IFormFile upload in uploads)
        {
            if (upload is not null)
            {
                string uploadFilePath = Path.Combine(this.uploadsFolderName, upload.FileName);

                using (FileStream fileStream = new (uploadFilePath, FileMode.Create))
                {
                    await upload.CopyToAsync(fileStream);
                }

                uploadedFilePaths.Add(uploadFilePath);
            }
        }

        UploadsStore.UploadedFilePaths = uploadedFilePaths;
        return this.RedirectToPage("/uploadedcontent");
    }
}
