using WordSearcherTools.Model;

namespace WordSearcherTools.FileManager;

public class FileFinder
{
    public static List<FileInformation> GetFilesWithExtensions(string folderPath, List<string> extensions)
    {
        List<FileInformation> result = new List<FileInformation>();

        try
        {
            return TryGetFilesWithExtensions(folderPath, extensions);

        }
        catch (Exception ex)
        {
            throw new Exception($"خطا در خواندن فایل‌ها: {ex.Message}");
        }
    }
    private static List<FileInformation> TryGetFilesWithExtensions(string folderPath, List<string> extensions)
    {
        List<FileInformation> result = new List<FileInformation>();


        if (!Directory.Exists(folderPath))
            throw new Exception($"فولدر '{folderPath}' پیدا نشد.");

        var allFiles = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories);

        foreach (var file in allFiles)
        {
            string fileExtension = Path.GetExtension(file).ToLower();
            if (extensions.Contains(fileExtension))
            {
                result.Add(new FileInformation
                {
                    FileName = Path.GetFileName(file),
                    Extension = fileExtension,
                    FilePath = file
                });
            }
        }

        return result;
    }
}