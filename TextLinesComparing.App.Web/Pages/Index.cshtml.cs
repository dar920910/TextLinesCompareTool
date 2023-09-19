using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;


public class IndexModel : PageModel
{
    private IWebHostEnvironment _Environment;
    private readonly string _UploadsFolderName;

    public IndexModel(IWebHostEnvironment environment)
    {
        _Environment = environment;

        _UploadsFolderName = Path.Combine(_Environment.WebRootPath, "uploads");
        if (Directory.Exists(_UploadsFolderName) is false)
        {
            Directory.CreateDirectory(_UploadsFolderName);
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
        ViewData["Title"] = "TextLinesCompareTool (Select Files to Upload)";
    }

    public async Task OnPostUploadFilesAsync()
    {
        IFormFile[] uploads = { Upload_1!, Upload_2!, Upload_3!, Upload_4!, Upload_5!, Upload_6!, Upload_7!, Upload_8!, Upload_9! };

        List<string> uploadedFilePaths = new();

        foreach (IFormFile upload in uploads)
        {
            if (upload is not null)
            {
                string uploadFilePath = Path.Combine(_UploadsFolderName, upload.FileName);

                using (FileStream fileStream = new(uploadFilePath, FileMode.Create))
                {
                    await upload.CopyToAsync(fileStream);
                }

                uploadedFilePaths.Add(uploadFilePath);
            }
        }

        UploadsStore.UploadedFilePaths = uploadedFilePaths;
    }
}
