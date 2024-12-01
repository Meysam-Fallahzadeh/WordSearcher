using System.Text.RegularExpressions;

namespace WordSearcherTools.FileProcessor;
internal class TextFileProcessor
{
    public static List<string> GetUniqueWordsFromFile(string filePath)
    {
        string fileContent = ReadFileContent(filePath);

        List<string> words = ExtractWords(fileContent);

        return words.Distinct().ToList();
    }

    private static string ReadFileContent(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return string.Empty;
        }

        return File.ReadAllText(filePath);
    }

    private static List<string> ExtractWords(string content)
    {
        var pascalOrCamelCaseWord = Regex.Matches(content, @"\b[a-zA-Z]+\b")
                         .Cast<Match>()
                         .Select(m => m.Value)
                         .Where(word => word.Length > 2)
                         .ToList();

        var words = new List<string>();

        foreach (var item in pascalOrCamelCaseWord)
        {
            var word = RemoveFirstIIfSecondIsUpper(item);

            var splitCamelOrPascalCaseWords = SplitCamelOrPascalCase(word).Where(w => w.Length > 1);

            words.AddRange(splitCamelOrPascalCaseWords);

        }
        return words;
    }
    private static List<string> SplitCamelOrPascalCase(string input)
    {
        var matches = Regex.Matches(input, @"[A-Z][a-z]*|[a-z]+");
        var result = new List<string>();

        foreach (Match match in matches)
        {
            result.Add(match.Value);
        }

        return result;
    }
    private static string RemoveFirstIIfSecondIsUpper(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        if (input[0] == 'I' && input.Length > 1 && char.IsUpper(input[1]))
        {
            return input.Substring(1);
        }

        return input;
    }
}