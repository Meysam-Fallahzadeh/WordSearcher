using WordSearcherTools.FileManager;
using WordSearcherTools.FileProcessor;

namespace WordSearcherTools.IngnoreManager;

internal class SearchIgnoreWords
{
    public static List<string> Manager(WordSearcherConfig config)
    {
        if(string.IsNullOrEmpty(config.IgnoreFolderPath))
            return new List<string>();

        var fileExtentions = new List<string>() { ".txt" };
        var files = FileFinder.GetFilesWithExtensions(config.IgnoreFolderPath, fileExtentions);

        var words = new List<string>();

        foreach (var file in files)
            words.AddRange(TextFileProcessor.GetUniqueWordsFromFile(file.FilePath));
        
        return words.Select(item => item.ToLower())
                    .Distinct()
                    .ToList();

    }
}


