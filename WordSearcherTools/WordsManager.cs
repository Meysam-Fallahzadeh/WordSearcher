using WordSearcherTools.FileManager;
using WordSearcherTools.FileProcessor;
using WordSearcherTools;
using WordSearcherTools.IngnoreManager;

namespace WordSearcher
{
    public class WordsManager
    {
        public List<string> Manager(WordSearcherConfig config)
        {
            var ignoreWord= SearchIgnoreWords.Manager(config);

            var files = FileFinder.GetFilesWithExtensions(config.SourceFolderPath, config.FileExtentions);

            var words = new List<string>();

            foreach (var file in files)
                words.AddRange(TextFileProcessor.GetUniqueWordsFromFile(file.FilePath));

            var allWords= words.Select(item => item.ToLower())
                        .Distinct()
                        .ToList();

            allWords.AddRange(ignoreWord);

            return allWords.Distinct().ToList();  
        }
    }
}
